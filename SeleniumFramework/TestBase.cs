using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace SeleniumFramework
{
    public class TestBase
    {
        protected IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("URL opened.");

            _driver.Manage().Window.Maximize();
            Console.WriteLine("Windows Maximized.");
            Thread.Sleep(3000);

        }

        [Test]
        public void SearchElement()
        {
            IWebElement search = _driver.FindElement(By.Id("search_query_top"));
            search.SendKeys("t-shirt");
            Thread.Sleep(3000);
            Console.WriteLine("Element located.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
            Console.WriteLine("Close Browser.");
        }
    }
}
