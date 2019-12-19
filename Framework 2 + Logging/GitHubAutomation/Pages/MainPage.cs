using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using FlyuiaTestFramework.Models;
using FlyuiaTestFramework.Utils;


namespace FlyuiaTestFramework.Pages
{
    public class MainPage
    {
        IWebDriver driver;
        const int timeToWait = 15;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='btn-v2 btn-blue btn-small']")]
        public IWebElement specialsBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        public IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_2_8']")]
        public IWebElement nameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_3_8']")]
        public IWebElement secondNameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='subscribe_phone']")]
        public IWebElement mobileInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']div[4]/span")]
        public IWebElement countrySelectorBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[5]")]
        public IWebElement modalEmptySpace;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div[5]/span")]
        public IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//*[@class='container-fluid main-buttons white-bgr']/div/div[4]")]
        public IWebElement onlineBoardBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='SEARCH_WIDGET_FORM_BUTTONS_ONE_WAY']")]
        public IWebElement oneWayBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='sw-row']/i")]
        public IWebElement countryFromPickerShowBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='sw-container']/sw-form-control-select/sw-form-control-container")]
        public IWebElement countryFromListBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='ps-content']/div[6]")]
        public IWebElement oneCountryFromElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='list-item ng-star-inserted']")]
        public IWebElement oneCityFromElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='sw-row']/i")]
        public IWebElement countryToPickerShowBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='sw-container']/sw-form-control-select/sw-form-control-container")]
        public IWebElement countryToListBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='ps-content']/div[75]")]
        public IWebElement oneCountryToElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='ps-content']/div[6]")]
        public IWebElement oneCountryToSameElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='list-item ng-star-inserted']")]
        public IWebElement oneCityToElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='value-as-text-container ng-star-inserted']")]
        public IWebElement dataPickerBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk-overlay-42']/div/div[30]")]
        public IWebElement chooseDayElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk-overlay-42']/div/div[1]")]
        public IWebElement choosePastDayElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='focus-trap ng-valid ng-dirty ng-touched']")]
        public IWebElement promoInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='SEARCH_WIDGET_FORM_BUTTONS_SEARCH_FLIGHTS']")]
        public IWebElement searchFlightBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='mat-dialog-0']/sw-dialog-error/span")]
        public IWebElement promoErrorMsg;

        [FindsBy(How = How.XPath, Using = "//*[@class='search-widget-container']/sw-search-flights/sw-form-control-passengers")]
        public IWebElement choosePasengersCountBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk-overlay-0']/div/button[2]")]
        public IWebElement plusOneBabyBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='warning-pax-count")]
        public IWebElement countBabiesErrorMsg;

        [FindsBy(How = How.XPath, Using = "//*[@class='col-md-7 nav-wrapper/ul/li[4]")]
        public IWebElement flightsScheduleBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='obe-login")]
        public IWebElement logInFormBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='mat-input-65']")]
        public IWebElement logInEmailInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='mat-input-66']")]
        public IWebElement logInPasswordInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='signInEmailForm']/perfect-scrollbar/button")]
        public IWebElement logInBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='validation-error ng-star-inserted']")]
        public IWebElement logInErrorMsg;
        

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

        public OnlineBoardPage GoToOnlineBoardPage()
        {
            Logger.Log.Info("Go to online board page");
            Actions action = new Actions(driver);
            action.MoveToElement(onlineBoardBtn).Click().Build().Perform();
            return new OnlineBoardPage(driver);
        }

        public FlightsSchedulePage GoToFlightsSchedulePage()
        {
            Logger.Log.Info("Go to flights schedule page");
            Actions action = new Actions(driver);
            action.MoveToElement(flightsScheduleBtn).Click().Build().Perform();
            return new FlightsSchedulePage(driver);
        }


        public MainPage FillInUserDataFields(UserData data)
        {
            Logger.Log.Info("Fill in fields with data: Email: " + data.Email + "User Name: " + 
                data.UserName + "User Second Name: " + data.UserSecondName + "Phone: " + data.Mobile);
            emailInput.SendKeys(data.Email);
            nameInput.SendKeys(data.UserName);
            secondNameInput.SendKeys(data.UserSecondName);
            mobileInput.SendKeys(data.Mobile);
            return this;
        }

        public MainPage ClickGetSpecialProposionsSubscribeButton()
        {
            Logger.Log.Info("Open special propositions");
            specialsBtn.Click();
            return this;
        }

        public MainPage ClickCountrySelectorButton()
        {
            Logger.Log.Info("Open country selector");
            countrySelectorBtn.Click();
            return this;
        }

        public MainPage ClickOutOfAnyButtons()
        {
            Logger.Log.Info("Unfocus on input field");
            modalEmptySpace.Click();
            return this;
        }

        public MainPage ClickOneWayButton()
        {
            Logger.Log.Info("Choose one way");
            oneWayBtn.Click();
            return this;
        }

        public MainPage ClickDatePicker()
        {
            Logger.Log.Info("Open date picker");
            dataPickerBtn.Click();
            return this;
        }

        public MainPage ChooseFromAirport()
        {
            Logger.Log.Info("Choose departure country and airport");
            countryFromPickerShowBtn.Click();
            countryFromListBtn.Click();
            oneCountryFromElement.Click();
            oneCityFromElement.Click();
            return this;
        }

        public MainPage ChooseToAirport()
        {
            Logger.Log.Info("Choose arrival country and airport");
            countryToPickerShowBtn.Click();
            countryToListBtn.Click();
            oneCountryToElement.Click();
            oneCityToElement.Click();
            return this;
        }

        public MainPage ChooseToSameAirport()
        {
            Logger.Log.Info("Choose the same as departure country and airport");
            countryToPickerShowBtn.Click();
            countryToListBtn.Click();
            oneCountryToSameElement.Click();
            oneCityToElement.Click();
            return this;
        }

        public MainPage ChooseDate()
        {
            Logger.Log.Info("Choose date");
            dataPickerBtn.Click();
            chooseDayElement.Click();
            return this;
        }

        public MainPage EnterPromo(string text)
        {
            Logger.Log.Info("Enter promocode: " + text);
            promoInput.SendKeys(text);
            return this;
        }

        public MainPage ClickSearchFlightButtton()
        {
            Logger.Log.Info("Search for flights");
            searchFlightBtn.Click();
            return this;
        }

        public MainPage ClickPassengersCountButton()
        {
            Logger.Log.Info("Open passengers count picker");
            choosePasengersCountBtn.Click();
            return this;
        }

        public MainPage ClickPlusOneBabyBtn()
        {
            Logger.Log.Info("Add one more baby passenger");
            plusOneBabyBtn.Click();
            return this;
        }

        public MainPage ClickLogInFormButton()
        {
            Logger.Log.Info("Open login window");
            logInFormBtn.Click();
            return this;
        }

        public MainPage EnterUserLogInData(UserData data, string password)
        {
            Logger.Log.Info("Enter login user data: Email: " + data.Email + " Password: " + password);
            logInEmailInput.SendKeys(data.Email);
            logInPasswordInput.SendKeys(password);
            return this;
        }

        public MainPage ClickLogInButton()
        {
            Logger.Log.Info("Loggin in");
            logInBtn.Click();
            return this;
        }
    }
}
