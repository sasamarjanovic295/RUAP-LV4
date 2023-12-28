using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class ProductSortingTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            finally
            {
                driver.Dispose();
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ProductSortingTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Books")).Click();
            driver.FindElement(By.Id("products-orderby")).Click();
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Name: A to Z");
            driver.FindElement(By.Id("products-orderby")).Click();
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Name: Z to A");
            driver.FindElement(By.Id("products-orderby")).Click();
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Price: Low to High");
            driver.FindElement(By.Id("products-orderby")).Click();
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Price: High to Low");
            driver.FindElement(By.Id("products-orderby")).Click();
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Created on");
            driver.FindElement(By.Id("products-viewmode")).Click();
            new SelectElement(driver.FindElement(By.Id("products-viewmode"))).SelectByText("List");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
