﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FlyuiaTestFramework.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new EdgeDriver();
                        break;
                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
