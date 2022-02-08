using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using AppiumDotNetSamples.Helper;
using System.Collections.ObjectModel;
using AppiumDotNetSamples.PageObjects;

namespace AppiumDotNetSamples
{
    [TestFixture()]
    public class AndroidBasicInteractionsTest
    {
        
        private const string placeToSearchForText = "Flinders Street";
        private const string expectedLocationtoFind = "Melbourne VIC, Australia";
        private AndroidDriver<AndroidElement> driver;

        [SetUp()]
        public void BeforeAll()
        {
            InitializeDriver();

            var signInPage = new SignInPage(driver);
            signInPage.SkipSignIn();
        }

        private void InitializeDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "11");
            capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Nexus");
            capabilities.SetCapability("appActivity", "com.google.android.maps.MapsActivity");
            capabilities.SetCapability("appPackage", "com.google.android.apps.maps");

            driver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [TearDown()]
        public void AfterAll()
        {
            driver.Quit();
        }

        [Test()]
        public void TestShouldSendKetsToSearchBoxThenCheckTheValue()
        {
            var initialScreenPage = new InitialScreenPage(driver);

            AndroidElement searchEditBox = initialScreenPage.TapAndTypeText(placeToSearchForText);
            ReadOnlyCollection<AndroidElement> searchResultsTexts = initialScreenPage.GetSearchResults();

            Assert.That(searchEditBox.Text, Is.EqualTo(placeToSearchForText));
            Assert.That(searchResultsTexts, Has.One.Items.With.Property(nameof(AndroidElement.Text)).EqualTo(expectedLocationtoFind));
            //ReadOnlyCollection<AndroidElement> searchResults = driver.FindElementsByClassName("android.widget.TextView");
            //Assert.AreEqual("Flinders Street", searchResults.Text);
        }

       

       

        [Test()]
        [Ignore("do not exeCUTE")]
        public void TestShouldClickAButtonThatOpensAnAlertAndThenDismissesIt()
        {
            driver.StartActivity("io.appium.android.apis", ".app.AlertDialogSamples");

            AndroidElement openDialogButton = driver.FindElementById("io.appium.android.apis:id/two_buttons");
            openDialogButton.Click();

            AndroidElement alertElement = driver.FindElementById("android:id/alertTitle");
            String alertText = alertElement.Text;
            Assert.AreEqual("Lorem ipsum dolor sit aie consectetur adipiscing\nPlloaso mako nuto siwuf cakso dodtos anr koop.", alertText);

            driver.FindElementById("android:id/button1").Click();
        }
    }
}
