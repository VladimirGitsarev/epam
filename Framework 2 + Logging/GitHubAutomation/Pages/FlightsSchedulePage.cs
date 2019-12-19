using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using FlyuiaTestFramework.Utils;


namespace FlyuiaTestFramework.Pages
{
    public class FlightsSchedulePage
    {
        IWebDriver driver;
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
    }
}
