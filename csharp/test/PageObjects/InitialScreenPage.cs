
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;

namespace AppiumDotNetSamples.PageObjects
{
    public class InitialScreenPage
    {
        private const string searchBoxElementId = "com.google.android.apps.maps:id/search_omnibox_text_box";
        private const string searchBoxEditElementId = "com.google.android.apps.maps:id/search_omnibox_edit_text";
        private const string searchResultClassName = "android.widget.TextView";
        private AndroidDriver<AndroidElement> driver;

        public InitialScreenPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public AndroidElement TapAndTypeText(string textToType)
        {
            AndroidElement searchBoxElement = driver.FindElementById(searchBoxElementId);
            searchBoxElement.Click();

            AndroidElement searchEditBox = driver.FindElementById(searchBoxEditElementId);
            searchEditBox.SendKeys(textToType);
            return searchEditBox;
        }

        public ReadOnlyCollection<AndroidElement> GetSearchResults()
        {
            return driver.FindElementsByClassName(searchResultClassName);
        }
    }
}
