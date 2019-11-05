using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver
{
    [TestFixture]
    class WebTests
    {
        private IWebDriver webDriver;
        [SetUp]
        public void StartBrowser()
        {
            webDriver = new ChromeDriver
            {
                Url = "https://www.flyuia.com/"
            };
        }

        [Test]
        public void TestMethod()
        {

        }

    }
}
