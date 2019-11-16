using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriver
{
    [TestFixture]
    class FlyuiaTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void StartBrowserChrome()
        {
            webDriver = new ChromeDriver
            {
                Url = "https://www.flyuia.com/ua/ua/home"
            };
        }

        [Test] //Check unknown flight status
        public void WrongFlight()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("/html/body/main/div[3]/div/div[4]"));
            var onlineBoard = webDriver.FindElement(By.XPath("/ html/body/main/div[3]/div/div[4]"));
            onlineBoard.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("/html/body/main/div/div[2]/div[1]/div/div[1]/span"));
            var flightCheckBox = webDriver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div[1]/span"));
            flightCheckBox.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='fl_num']"));
            var flightInput = webDriver.FindElement(By.XPath("//*[@id='fl_num']"));
            flightInput.SendKeys("999");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='timetable_generate_btn']"));
            var searchBtn = webDriver.FindElement(By.XPath("//*[@id='timetable_generate_btn']"));
            searchBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='depart_tbl']/p"));
            var fliightFromMsg = webDriver.FindElement(By.XPath("//*[@id='depart_tbl']/p"));

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='arrival_tbl']/p"));
            var fliightToMsg = webDriver.FindElement(By.XPath("//*[@id='arrival_tbl']/p"));

            Assert.AreEqual(fliightFromMsg.Text, "Данi недоступнi");
            Assert.AreEqual(fliightToMsg.Text, "Данi недоступнi");
        }

        [Test]
        public void EmptyField()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='SEARCH_WIDGET_FORM_BUTTONS_ONE_WAY']"));
            var oneWayButton = webDriver.FindElement(By.XPath("//*[@id='SEARCH_WIDGET_FORM_BUTTONS_ONE_WAY']"));
            oneWayButton.Click();

            var fromDivInput = webDriver.FindElement(By.XPath("/html/body/footer/div[1]/div/div/div[3]/form/button"));
            fromDivInput.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='myModal']/div"));
            var confirmBtn = webDriver.FindElement(By.XPath("//*[@id='frmSS8']/div/div[8]/div/button"));
            confirmBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='frmSS8']/div/div[1]/div[1]/div/span"));
            var errorMsg = webDriver.FindElement(By.XPath("//*[@id='frmSS8']/div/div[1]/div[1]/div/span"));

            Assert.AreEqual(errorMsg.Text, "Будь ласка, вкажіть Ваш e-mail\r\nБудь ласка, введіть Ваш e-mail латинськими літерами"); ;
        }

        

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        //[TearDown]
        //public void QuitDriver()
        //{
        //    webDriver.Quit();
        //}
    }
}