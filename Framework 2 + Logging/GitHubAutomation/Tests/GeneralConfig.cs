using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using FlyuiaTestFramework.Driver;
using FlyuiaTestFramework.Utils;
using log4net;
using log4net.Config;

namespace FlyuiaTestFramework.Tests
{
    public class GeneralConfig
    {
        protected IWebDriver Driver;
        [SetUp]
        public void SetDriver()
        {
            Logger.InitLogger();
            Logger.Log.Warn("Initializing driver...");
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://www.flyuia.com/ua/ua/home");
            Logger.Log.Info("Driver initialized.");
        }

        protected void TakeScreenshotWhenTestFailed(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                Logger.Log.Info("Test failed");
                var screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                Logger.Log.Info("Screenshot saved");
                throw;
            }
        }

        [TearDown]
        public void QuitDriver()
        {
            Logger.Log.Info("Test finished");
            //DriverSingleton.CloseDriver();
        }
    }
}
