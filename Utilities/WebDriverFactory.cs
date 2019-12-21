using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Enum;

namespace Utilities
{
    public class WebDriverFactory
    {
        private GenerateEvidences _generateEvidences;

        public WebDriverFactory(GenerateEvidences generateEvidences)
        {
            _generateEvidences = generateEvidences;
        }

        public IWebDriver GetDriver(EnumBrowser.BrowserOption option)
        {
            try
            {
                switch (option)
                {
                    case EnumBrowser.BrowserOption.Chrome:
                        _generateEvidences.FileLog("Google Chrome");
                        return new ChromeDriver();

                    case EnumBrowser.BrowserOption.Firefox:
                        _generateEvidences.FileLog("Mozilla Firefox");
                        return new FirefoxDriver();

                    default:
                        throw new ArgumentException("There is no driver for the selected option " + option.ToString());
                }
            }
            catch (Exception ex)
            {
                _generateEvidences.FileLog("There was an unexpected exception when getting WebDriver. Exception: " + ex.Message + ex.StackTrace);
                throw;
            }

        }
    }
}