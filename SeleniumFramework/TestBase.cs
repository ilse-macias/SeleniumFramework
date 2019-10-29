using System;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Constants;
using Utilities;

namespace SeleniumFramework
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected GenerateMessage _generateMessage;

        public TestBase()
        {
            _generateMessage = new GenerateMessage(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(ConstantsBase.Url);
            _generateMessage.FileLog(ConstantsBase.UrlMessage);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            _driver.Manage().Window.Maximize();
            _generateMessage.FileLog(ConstantsBase.MaximizeMessage);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void SearchElement()
        {
            IWebElement search = _driver.FindElement(By.Id("search_query_top"));
            search.SendKeys("t-shirt");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


            Console.WriteLine("Element located.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
            _generateMessage.FileLog(ConstantsBase.CloseBrowserMessage);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
    }
}
