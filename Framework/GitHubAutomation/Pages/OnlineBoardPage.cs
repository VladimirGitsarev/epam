using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace FlyuiaTestFramework.Pages
{
    public class OnlineBoardPage
    {
        IWebDriver driver;

        public OnlineBoardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='input-v2 js-radio-change in-focus input-radio-v2 error-left']/span")]
        public IWebElement flightCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='fl_num']")]
        public IWebElement flightInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='timetable_generate_btn']")]
        public IWebElement searchBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='depart_tbl']/p")]
        public IWebElement flightMsg;

        public OnlineBoardPage ClickFlightCheckBox()
        {
            flightCheckBox.Click();
            return this;
        }
        public OnlineBoardPage InputFlightNumber(string text)
        {
            flightInput.SendKeys(text);
            return this;
        }

        public OnlineBoardPage ClickSearchButton()
        {
            searchBtn.Click();
            return this;
        }
    }
}
