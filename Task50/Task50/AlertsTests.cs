using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class AlertsTests
    {
        private WebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = " https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            driver.Manage().Window.Maximize();  
        }

        [Test]
        public void AlertDisplay()
        {
            IWebElement triggerAlertButton = driver.FindElement(By.XPath("//button[@class='btn btn-default']"));
            triggerAlertButton.Click();
            var waitForAlert = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IAlert alert = waitForAlert.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            string alertText = alert.Text.ToString();
            var expectedAlert = "I am an alert box!";
            Assert.AreEqual(expectedAlert, alertText, "Wrong alert text.");
            alert.Accept();
        }

        [Test]
        public void AlertConfirm()
        {
            IWebElement triggerAlertButton = driver.FindElement(By.XPath("//button[@class='btn btn-default btn-lg']"));
            triggerAlertButton.Click();
            var waitForAlert = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            string alertConfirmedText = driver.FindElement(By.XPath("//p[contains (text(), 'You pressed OK!')]")).Text;
            string expectedAlertText = "You pressed OK!";
            Assert.AreEqual(expectedAlertText, alertConfirmedText, "Wrong alert text.");
        }

        [Test]
        public void AlertDismiss()
        {
            IWebElement triggerAlertButton = driver.FindElement(By.XPath("//button[@class='btn btn-default btn-lg']"));
            triggerAlertButton.Click();
            var waitForAlert = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            string alertDismissedText = driver.FindElement(By.XPath("//p[contains (text(), 'You pressed Cancel!')]")).Text;
            string expectedAlertText = "You pressed Cancel!";
            Assert.AreEqual(expectedAlertText, alertDismissedText, "Wrong alert text.");
        }
    }
}