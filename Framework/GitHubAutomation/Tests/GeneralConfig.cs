using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using FlyuiaTestFramework.Driver;

namespace FlyuiaTestFramework.Tests
{
    public class GeneralConfig
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetDriver()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://www.flyuia.com/ua/ua/home");
        }

        protected void SaveScreenshotOnTestFailure(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                var screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                throw;
            }

        }

        [TearDown]
        public void QuitDriver()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
