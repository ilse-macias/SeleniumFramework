using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;

using Constants;

namespace SeleniumFramework
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(ConstantsBase.Url);
            Console.WriteLine(ConstantsBase.UrlMessage);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.Manage().Window.Maximize();
            Console.WriteLine(ConstantsBase.MaximizeMessage);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void SearchElement()
        {
            IWebElement search = _driver.FindElement(By.Id("search_query_top"));
            search.SendKeys("t-shirt");

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(45));
            Console.WriteLine("Element located.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
            Console.WriteLine(ConstantsBase.CloseBrowserMessage);
        }
    }
}
