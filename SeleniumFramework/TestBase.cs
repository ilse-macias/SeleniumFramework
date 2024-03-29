﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Constants;
using Utilities;
using Enum;

namespace SeleniumFramework
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected GenerateEvidences _generateEvidences;
        protected WebDriverFactory _webDriverFactory;

        public TestBase() 
        {
            _generateEvidences = new GenerateEvidences(_driver);
            _webDriverFactory = new WebDriverFactory(_generateEvidences);
        }

        [SetUp]
        public void SetUp()
        {
            _driver = _webDriverFactory.GetDriver(EnumBrowser.BrowserOption.Chrome);
            //_driver = new ChromeDriver();

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(ConstantsBase.Url);
            _generateEvidences.FileLog(ConstantsBase.UrlMessage);
           // _generateEvidences.TakeScreenshot();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            _driver.Manage().Window.Maximize();
            _generateEvidences.FileLog(ConstantsBase.MaximizeMessage);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void SearchElement()
        {
            IWebElement search = _driver.FindElement(By.Id("search_query_top"));
            search.SendKeys("t-shirt");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // _wait.Until(ExpectedConditions.ElementIsVisible(search));

            _generateEvidences.TakeScreenshot();
            Console.WriteLine("Element located.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
            _generateEvidences.FileLog(ConstantsBase.CloseBrowserMessage);            
        }
    }
}
