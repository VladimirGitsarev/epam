using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using FlyuiaTestFramework.Models;
using FlyuiaTestFramework.Utils;
using System.Threading;


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

        public IWebElement closeStartWindowBtn;
        //[FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        public IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_2_8']")]
        public IWebElement nameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_3_8']")]
        public IWebElement secondNameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='subscribe_phone']")]
        public IWebElement mobileInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[4]/div[1]/div/div/span")]
        public IWebElement countrySelectorBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[5]")]
        public IWebElement modalEmptySpace;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[4]/div[1]/div/span")]
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

        //[FindsBy(How = How.XPath, Using = "//*[@class='cities-container ng-star-inserted']/div/div[1]")]
        public IWebElement oneCityFromElement;

        public IWebElement oneSameCityToElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='1']/div/sw-root/sw-layout/sw-search-flights/div[2]/form/div[2]/sw-form-control-suggester/div/i")]
        public IWebElement countryToPickerShowBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='sw-container']/sw-form-control-select/sw-form-control-container")]
        public IWebElement countryToListBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='ps-content']/div[7]")]
        public IWebElement oneCountryToElement;

        [FindsBy(How = How.XPath, Using = "//*[@class='ps-content']/div[6]")]
        public IWebElement oneCountryToSameElement;

        public IWebElement oneCityToElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='1']/div/sw-root/sw-layout/sw-search-flights/div[2]/form/div[3]/div[1]/sw-form-control-datepicker/div[1]/div[2]/div")]
        public IWebElement dataPickerBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk-overlay-5']/div/div[2]/div[3]/div[2]/div[32]/button")]
        public IWebElement chooseDayElement;

        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div/div/div/div[2]/div[3]/div[2]/div[3]")]
        public IWebElement choosePastDayElement;

        

        [FindsBy(How = How.XPath, Using = "//*[@class='focus-trap ng-untouched ng-pristine ng-valid']")]
        public IWebElement promoInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='SEARCH_WIDGET_FORM_BUTTONS_SEARCH_FLIGHTS']")]
        public IWebElement searchFlightBtn;

        //[FindsBy(How = How.XPath, Using = "//*[@id='mat-dialog-0']/sw-dialog-error/div/div[2]/span")]
        public IWebElement promoErrorMsg;

        [FindsBy(How = How.XPath, Using = "//*[@id='1']/div/sw-root/sw-layout/sw-search-flights/div[2]/form/div[4]/div[1]/sw-form-control-passengers/div[1]/div[2]/div")]
        public IWebElement choosePasengersCountBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='cdk-overlay-0']/div/button[2]")]
        public IWebElement plusOneBabyBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='warning-pax-count")]
        public IWebElement countBabiesErrorMsg;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[1]/div[1]/ul/li[3]/a")]
        public IWebElement flightsScheduleBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='obe-login']")]
        public IWebElement logInFormBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='obe-user-login-widget']/app-sign-in-root/div/div/button/div/span")]
        public IWebElement logInText;

        //[FindsBy(How = How.XPath, Using = "//*[@class='mat-input-element mat-form-field-autofill-control cdk-text-field-autofill-monitored ng-untouched ng-pristine ng-invalid")]
        public IWebElement logInEmailInput;

        //[FindsBy(How = How.XPath, Using = "//*[@id='mat-input-21']")]
        public IWebElement logInPasswordInput;

        //[FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[2]/div/mat-dialog-container/app-sign-in-dialog/perfect-scrollbar/div/div[1]/div/mat-tab-group/div/mat-tab-body[1]/div/app-sign-in/mat-tab-group/div/mat-tab-body[1]/div/app-sign-in-email/div/div/div[1]/form/div[4]/button")]
        public IWebElement logInBtn;

        //[FindsBy(How = How.XPath, Using = "//*[@id='validation-error ng-star-inserted']")]
        public IWebElement logInErrorMsg;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[1]/div[2]/ul/li[1]/span[1]/img")]
        public IWebElement langSelector;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[2]/div/div[9]/form/span[1]/input")]
        public IWebElement locationInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='mCSB_1_container']/li[5]")]
        public IWebElement locationElement;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[2]/div/div[9]/form/span[2]/input")]
        public IWebElement languageInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='mCSB_2_container']/li[12]")]
        public IWebElement languageElement;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[2]/div/div[9]/form/button")]
        public IWebElement confirmLanguageBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div[1]/div[1]/ul/li[4]/a")]
        public IWebElement panoramaClubBtn;

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
            action.MoveToElement(panoramaClubBtn).Click().Build().Perform();
            return new FlightsSchedulePage(driver);
        }

        public MainPage FillInUserDataFields(UserData data)
        {
            emailInput = GetElement("//*[@id='email']");
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
            //closeStartWindowBtn = GetElement("//*[@id='promo-sub']/div/div/div[1]/span");
            //closeStartWindowBtn.Click();
            specialsBtn.Click();
            return this;
        }

        public MainPage ClickCountrySelectorButton()
        {
            Logger.Log.Info("Open country selector");
            countrySelectorBtn.Click();
            return this;
        }

        public MainPage SelectLocationElement()
        {
            Logger.Log.Info("Select location");
            locationInput.Click();
            locationElement.Click();
            return this;
        }

        public MainPage SelectLanguageElement()
        {
            Logger.Log.Info("Select language");
            languageInput.Click();
            languageElement.Click();
            return this;
        }

        public MainPage ClickConfirmLanguageButton()
        {
            Logger.Log.Info("Select language");
            confirmLanguageBtn.Click();
            return this;
        }


        public MainPage ClickLanguageSelector()
        {
            Logger.Log.Info("Open language selector");
            langSelector.Click();
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
            oneCityFromElement = GetElement("//*[@id='cdk-overlay-0']/div/div[2]/div/perfect-scrollbar/div/div[1]");
            oneCityFromElement.Click();
            return this;
        }

        public MainPage ChooseToAirport()
        {
            Logger.Log.Info("Choose arrival country and airport");
            countryToPickerShowBtn.Click();
            countryToListBtn.Click();
            oneCountryToElement.Click();
            oneCityToElement = GetElement("//*[@id='cdk-overlay-2']/div/div[2]/div/perfect-scrollbar/div/div[1]/div");
            oneCityToElement.Click();
            return this;
        }

        public MainPage ChooseToSameAirport()
        {
            Logger.Log.Info("Choose the same as departure country and airport");
            countryToPickerShowBtn.Click();
            countryToListBtn.Click();
            oneCountryToSameElement.Click();
            oneSameCityToElement = GetElement("//*[@id='cdk-overlay-2']/div/div[2]/div/perfect-scrollbar/div/div[1]/div");
            oneSameCityToElement.Click();
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
            promoErrorMsg = GetElement("//*[@id='mat-dialog-0']/sw-dialog-error/div/div[2]/span");
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
            logInEmailInput = GetElement("//*[@class='mat-input-element mat-form-field-autofill-control cdk-text-field-autofill-monitored ng-untouched ng-pristine ng-invalid']");
            logInEmailInput.SendKeys(data.Email);
            logInPasswordInput = GetElement("//*[@name='password']");
            logInPasswordInput.SendKeys(password);
            return this;
        }

        public MainPage ClickLogInButton()
        {
            Logger.Log.Info("Loggin in");
            logInBtn = GetElement("//*[@class='form--buttons']");
            logInBtn.Click();
            logInErrorMsg = GetElement("//*[@class='validation-error ng-star-inserted']");
            return this;
        }
    }
}
