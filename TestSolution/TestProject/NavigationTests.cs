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
    public class NavigationTests
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
        public void NavigationLinksAndPathsTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Books")).Click();
            driver.FindElement(By.LinkText("Computers")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Desktops']")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='/'])[1]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Notebooks']")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='/'])[1]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Accessories']")).Click();
            driver.FindElement(By.LinkText("Electronics")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Camera, photo']")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Wait...'])[1]/following::div[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='/'])[1]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Cell phones']")).Click();
            driver.FindElement(By.LinkText("Apparel & Shoes")).Click();
            driver.FindElement(By.LinkText("Digital downloads")).Click();
            driver.FindElement(By.LinkText("Jewelry")).Click();
            driver.FindElement(By.LinkText("Gift Cards")).Click();
            driver.FindElement(By.XPath("//img[@alt='Tricentis Demo Web Shop']")).Click();
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
