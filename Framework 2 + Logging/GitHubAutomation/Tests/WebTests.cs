using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using FlyuiaTestFramework.Driver;
using FlyuiaTestFramework.Pages;
using FlyuiaTestFramework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using FlyuiaTestFramework.Utils;

namespace FlyuiaTestFramework.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        [Test]
        [Category("UserData")]
        public void SendDataWithSomeEmptyFields()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"SendDataWithSomeEmptyFields\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickGetSpecialProposionsSubscribeButton()
                    .FillInUserDataFields(UserDataCreator.WithFilledFields())
                    .ClickCountrySelectorButton()
                    .ClickOutOfAnyButtons();
                Assert.AreEqual("Будь ласка, вкажіть країну", mainPage.errorMessage.Text);
            });
        }

        [Test]
		[Category("RandomValues")]
        public void EnterWrongFlight()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"EnterWrongFlight\" test");
                OnlineBoardPage onlineBoardPage = new MainPage(Driver)
                    .GoToOnlineBoardPage()
                    .ClickFlightCheckBox()
                    .InputFlightNumber(RandomNumbers.FlightNumber())
                    .ClickSearchButton();
                Assert.AreEqual("Данi недоступнi", onlineBoardPage.flightMsg.Text);
            });
        }

        [Test]
		[Category("RandomValues")]
        public void EnterWrongPromo()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"EnterWrongPromo\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickOneWayButton()
                    .ChooseFromAirport()
                    .ChooseToAirport()
                    .EnterPromo(RandomNumbers.RandomString(5));
                    //.ClickSearchFlightButtton();
                ///Assert.AreEqual("Промокод недійсний. Цей промокод не існує.", mainPage.promoErrorMsg.Text);
                Assert.IsTrue(mainPage.searchFlightBtn.Enabled);
            });
        }

        [Test]
        public void ChangeInterfaceLanguage()
        {
            Logger.Log.Info("Start \"ChangeInterfaceLanguage\" test");
            MainPage mainPage = new MainPage(Driver)
                .ClickLanguageSelector()
                .SelectLocationElement()
                .SelectLanguageElement()
                .ClickConfirmLanguageButton();
            Assert.AreEqual("Мой Аккаунт", mainPage.logInText.Text);
        }

        [Test]
        public void SearchFlightWithEmptyNumber()
        {
            Logger.Log.Info("Start \"SearchFlightWithEmptyNumber\" test");
            OnlineBoardPage onlineBoardPage = new MainPage(Driver)
                    .GoToOnlineBoardPage()
                    .ClickFlightCheckBox()
                    .ClickSearchButton();
            Assert.AreEqual("Данi недоступнi", onlineBoardPage.flightMsg.Text);
        }

        [Test]
        public void SearchFlightWithTheSameAirports()
        {
            Logger.Log.Info("Start \"SearchFlightWithTheSameAirports\" test");
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                     .ClickOneWayButton()
                     .ChooseFromAirport()
                     .ChooseToSameAirport();
                Assert.IsTrue(mainPage.searchFlightBtn.Enabled);
            });
        }

        [Test]
        public void SearchFlightWithEmptyArrivalCity()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"SearchFlightWithEmptyArrivalCity\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickOneWayButton()
                    .ChooseFromAirport();
                Assert.IsTrue(mainPage.searchFlightBtn.Enabled);
            });
        }

        [Test]
        public void SearchFlightWithPastDate()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"SearchFlightWithPastDate\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickOneWayButton()
                    .ChooseFromAirport()
                    .ChooseToAirport()
                    .ClickDatePicker();
                Assert.IsTrue(mainPage.searchFlightBtn.Enabled);
            });
        }
		
		
        [Test]
        [Category("UserData")]
        public void LogInWithWrongUserData()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"LogInWithWrongUserData\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickLogInFormButton()
                    .EnterUserLogInData(UserDataCreator.WithFilledFields(),
                                        RandomNumbers.RandomString(10))
                    .ClickLogInButton();
                Assert.AreEqual("Недійсні облікові дані користувача", mainPage.logInErrorMsg.Text);
            });
        }


        [Test]
        [Category("RandomValues")]
        public void EnterWrongCardNumberAndPassword()
        {
            Logger.Log.Info("Start \"DepartureCityEqualsArrivalCity\" test");
            FlightsSchedulePage flightsSchedulePage = new MainPage(Driver)
                 .GoToFlightsSchedulePage()
                 .EnterCode("100000" + RandomNumbers.FlightNumber())
                 .EnterPassword("123456")
                 .ClickEnterButton();
            Assert.AreEqual("Невірний Номер картки або Пароль", flightsSchedulePage.enterErrorMsg.Text);
        }    
    }
}
