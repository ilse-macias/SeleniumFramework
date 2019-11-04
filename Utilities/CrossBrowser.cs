using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using Enum;

namespace Utilities
{
    public class CrossBrowser
    {
        private IWebDriver _driver;
        private GenerateEvidences _generateEvidences;

        public CrossBrowser(IWebDriver _driver)
        {
            this._driver = _driver;
            _generateEvidences = new GenerateEvidences(_driver);
        }

        public IWebDriver Driver(EnumBrowser.BrowserOption option)
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
                }
            }

            catch(NullReferenceException ex)
            {
                _generateEvidences.FileLog(ex.Message);
            }

            return default (IWebDriver);
        }
    }
}