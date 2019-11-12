using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Utilities
{
    public class GenerateEvidences
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public GenerateEvidences(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public void FileLog(string message)
        {
            Thread.Sleep(3000);
            Console.WriteLine("*** " + message + " ***");
        }

        public void Time(int seconds)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            }

            catch(ArgumentNullException ex)
            {
                FileLog(ex.Message);
            }
        }

        public void TakeScreenshot()
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile("C:\\Repositories\\SeleniumFramework\\Screenshot\\scr.png", ScreenshotImageFormat.Png);
                FileLog("Take a screenshot.");
            }

            catch (NullReferenceException ex)
            {
                FileLog(ex.Message);
            }

        }
    }
}
