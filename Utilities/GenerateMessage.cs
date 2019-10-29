using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Utilities
{
    public class GenerateMessage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public GenerateMessage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public void FileLog(string message)
        {
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
    }
}
