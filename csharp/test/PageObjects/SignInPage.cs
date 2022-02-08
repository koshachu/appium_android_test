using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDotNetSamples.PageObjects
{
    public class SignInPage
    {
        private readonly AndroidDriver<AndroidElement> driver;

        public SignInPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
     

        public void SkipSignIn()
        {
            try
            {
                AndroidElement skipButton = driver.FindElementByClassName("android.widget.Button");
                skipButton.Click();
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine("Skip button not found. Proceed with execution");
            }
        }
    }
}
