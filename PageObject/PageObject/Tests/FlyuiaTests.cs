using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.PageObjects;

namespace PageObject.Tests
{
    [TestFixture]
    public class FlyuiaTests
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowserChrome()
        {
            driver = new ChromeDriver
            {
                Url = "https://www.flyuia.com/ua/ua/home"
            };
        }

        [Test]
        public void WrongFlightInput()
        {
            var mainPage = new MainPage(driver);
            mainPage.onlineBoard.Click();
            mainPage.flightChechBox.Click();
            mainPage.flightInput.SendKeys("999");
            mainPage.searchBtn.Click();
            string errorMsg = "Данi недоступнi";
            Assert.AreEqual(errorMsg, mainPage.flightErrorMessage);
        }

        [Test]
        public void EmptyAndInvalidFields()
        {
            var mainPage = new MainPage(driver);
            mainPage.specialsBtn.Click();
            mainPage.emailInput.SendKeys("123456789");
            mainPage.nameInput.SendKeys("Vladimir");
            mainPage.subscribeBtn.Click();
            string errorEmailMsg = "Будь ласка, вкажіть Ваш e-mail\r\nБудь ласка, введіть Ваш e-mail латинськими літерами";
            Assert.AreEqual(errorEmailMsg, mainPage.emailErrorMsg);

        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}