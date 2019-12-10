using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using FlyuiaTestFramework.Models;

namespace FlyuiaTestFramework.Pages
{
    public class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='btn-v2 btn-blue btn-small']")]
        private IWebElement specialsBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        private IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_2_8']")]
        private IWebElement nameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='CustomFields_3_8']")]
        private IWebElement secondNameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='subscribe_phone']")]
        private IWebElement mobileInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[4]/div[1]/div/div/span")]
        private IWebElement countrySelectorBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[5]")]
        private IWebElement modalEmptySpace;

        [FindsBy(How = How.XPath, Using = "//*[@id='frmSS8']/div/div[4]/div[1]/div/span")]
        public IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//*[@class='container-fluid main-buttons white-bgr']/div/div[4]")]
        private IWebElement onlineBoardBtn;

        public OnlineBoardPage GoToOnlineBoardPage()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(onlineBoardBtn).Click().Build().Perform();
            return new OnlineBoardPage(driver);
        }

        public MainPage FillInUserDataFields(UserData data)
        {
            emailInput.SendKeys(data.Email);
            nameInput.SendKeys(data.UserName);
            secondNameInput.SendKeys(data.UserSecondName);
            mobileInput.SendKeys(data.Mobile);
            return this;
        }

        public MainPage ClickGetSpecialProposionsSubscribeButton()
        {
            specialsBtn.Click();
            return this;
        }

        public MainPage ClickCountrySelectorButton()
        {
            countrySelectorBtn.Click();
            return this;
        }

        public MainPage ClickOutOfAnyButtons()
        {
            modalEmptySpace.Click();
            return this;
        }
    }
}
