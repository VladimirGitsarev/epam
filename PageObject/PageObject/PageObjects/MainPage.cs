using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        const int timeToWait = 15;
        public IWebElement onlineBoard => GetElement("//*[@class='container-fluid main-buttons white-bgr']/div/div[4]");
        public IWebElement flightChechBox => GetElement("//*[@class='input-v2 js-radio-change in-focus input-radio-v2 error-left']/span");
        public IWebElement flightInput => GetElement("//*[@id='fl_num']");
        public IWebElement searchBtn => GetElement("//*[@id='timetable_generate_btn']");
        public string flightErrorMessage => GetText("//*[@id='depart_tbl']/p");

        public IWebElement specialsBtn => GetElement("//*[@class='btn-v2 btn-blue btn-small']");
        public IWebElement subscribeBtn => GetElement("//*[@id='frmSS8']/div/div[8]/div/button");
        public IWebElement emailInput => GetElement("//*[@id='email']");
        public IWebElement nameInput => GetElement("//*[@id='CustomFields_2_8']");
        public string emailErrorMsg=> GetText("//*[@id='frmSS8']/div/div[1]/div[1]/div/span");
       

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, timeToWait, By.XPath(xPath));
            return driver.FindElement(By.XPath(xPath));
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public string GetText(string xPath)
        {
            WaitForElementToAppear(driver, timeToWait, By.XPath(xPath));
            return driver.FindElement(By.XPath(xPath)).Text;
        }

        static void Main(string[] args)
        {

        }
    }
}