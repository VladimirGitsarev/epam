using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using FlyuiaTestFramework.Utils;
using System.Threading;


namespace FlyuiaTestFramework.Pages
{
    public class FlightsSchedulePage
    {
        IWebDriver driver;
        const int timeToWait = 15;
        public FlightsSchedulePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='airport_1']")]
        public IWebElement selectFromCity;

        [FindsBy(How = How.XPath, Using = "//*[@id='airport_2']")]
        public IWebElement selectToCity;

        [FindsBy(How = How.XPath, Using = "//*[@class='flyicons flyicon-calendar input-group-addon-v2']")]
        public IWebElement datePickerBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='ui-datepicker-calendar']/tbody/tr[5]/td")]
        public IWebElement chooseDateElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='timetable-booking-btn']")]
        public IWebElement searchTicketsBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='message-text']")]
        public IWebElement errorMsg;

        [FindsBy(How = How.XPath, Using = "//*[@id='login-card-number']")]
        public IWebElement codeInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='login']/div[2]/div/div/input")]
        public IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='login']/div[6]/input")]
        public IWebElement enterBtn;

        public IWebElement enterErrorMsg;

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, timeToWait, By.XPath(xPath));
            return driver.FindElement(By.XPath(xPath));
        }

        public FlightsSchedulePage SelectFromAirport()
        {
            Logger.Log.Info("Select departure city element");
            SelectElement selectFrom = new SelectElement(selectFromCity);
            selectFrom.SelectByIndex(0);
            return this;
        }

        public FlightsSchedulePage SelectToAirport()
        {
            Logger.Log.Info("Select arrival city element");
            SelectElement selectTo = new SelectElement(selectFromCity);
            selectTo.SelectByIndex(0);
            return this;
        }

        public FlightsSchedulePage ChooseDate()
        {
            Logger.Log.Info("Choose date");
            datePickerBtn.Click();
            chooseDateElement.Click();
            return this;
        }

        public FlightsSchedulePage ClickSearchTicketsButton()
        {
            Logger.Log.Info("Search flights");
            searchTicketsBtn.Click();
            return this;
        }

        public FlightsSchedulePage EnterCode(string code)
        {
            Logger.Log.Info("Enter code: " + code);
            codeInput.SendKeys(code);
            return this;
        }

        public FlightsSchedulePage EnterPassword(string password)
        {
            Logger.Log.Info("Enter password: " + password);
            passwordInput.SendKeys(password);
            return this;
        }

        public FlightsSchedulePage ClickEnterButton()
        {
            Logger.Log.Info("Search flights");
            enterBtn.Click();
            Thread.Sleep(3000);
            enterErrorMsg = GetElement("//*[@id='response-title']");
            return this;
        }
    }
}
