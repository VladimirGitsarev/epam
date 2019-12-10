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
                OnlineBoardPage onlineBoardPage = new MainPage(Driver)
                .GoToOnlineBoardPage()
                .ClickFlightCheckBox()
                .InputFlightNumber(RandomNumbers.FlightNumber())
                .ClickSearchButton();
                Assert.AreEqual("Данi недоступнi", onlineBoardPage.flightMsg.Text);
            });
        }
    }
}
