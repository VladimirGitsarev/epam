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
        public void EnterWrongPromo()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"EnterWrongPromo\" test");
                MainPage mainPage = new MainPage(Driver)
                    .ClickOneWayButton()
                    .ChooseFromAirport()
                    .ChooseToAirport()
                    .ChooseDate()
                    .EnterPromo(RandomNumbers.RandomString(5))
                    .ClickSearchFlightButtton();
                 Assert.AreEqual("Промокод недійсний. Цей промокод не існує.", mainPage.promoErrorMsg.Text);
            });
        }

        [Test]
        public void BabiesMoreThanAdults()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"BabiesMoreThanAdults\" test");
                MainPage mainPage = new MainPage(Driver)
                     .ClickOneWayButton()
                     .ChooseFromAirport()
                     .ChooseToAirport()
                     .ChooseDate()
                     .ClickPassengersCountButton()
                     .ClickPlusOneBabyBtn()
                     .ClickPlusOneBabyBtn();
                Assert.AreEqual("Кожне немовля може подорожувати щонайменше з одним дорослим", mainPage.countBabiesErrorMsg.Text);
            });
        }

        [Test]
        public void DepartureCityEqualsArrivalCity()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                Logger.Log.Info("Start \"DepartureCityEqualsArrivalCity\" test");
                FlightsSchedulePage flightsSchedulePage = new MainPage(Driver)
                     .GoToFlightsSchedulePage()
                     .SelectFromAirport()
                     .SelectToAirport()
                     .ChooseDate()
                     .ClickSearchTicketsButton();
                Assert.AreEqual("Рейси недоступні або продані.Будь ласка, виберіть іншу дату або змініть параметри запиту.", flightsSchedulePage.errorMsg.Text);
            });
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
                     .ChooseToSameAirport()
                     .ChooseDate();
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
                .ChooseFromAirport()
                .ChooseDate();
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
                Assert.IsTrue(mainPage.choosePastDayElement.Enabled);
            });
        }



        [Test]
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
                Assert.AreEqual("Недійсні облікові дані користувача", mainPage.logInErrorMsg);
            });
        }
    }
}
