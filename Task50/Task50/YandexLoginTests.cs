using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class YandexLoginTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://yandex.by/";
            driver.Manage().Window.Maximize();           
        }

        [TestCase ("mastermister123","mastermister1231", "mastermister123")]
        [TestCase ("mastermister567","mastermister5675", "mastermister567")]
        public void SuccessfullLogin(string username, string password, string userLoggedInLabel)
        {
            IWebElement startLoginButton = driver.FindElement(By.ClassName("desk-notif-card__login-new-item-title"));
            startLoginButton.Click();
            IWebElement usernameField = driver.FindElement(By.Id("passp-field-login"));
            usernameField.SendKeys(username);
            IWebElement continueLoginButton = driver.FindElement(By.Id("passp:sign-in"));
            continueLoginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);//implicit waiter applied
            IWebElement passwordField = driver.FindElement(By.Name("passwd"));
            passwordField.SendKeys(password);
            Thread.Sleep(5000);//threading applied, is an explicit waiter
            IWebElement signInButton = driver.FindElement(By.Id("passp:sign-in"));
            signInButton.Click();

            //Explicit wait starts
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementdisplay = driver.FindElement(By.ClassName("desk-notif-card__title"));
                    return elementdisplay.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            //explicit wait finishes

           var userLabelDisplayed = driver.FindElement(By.ClassName("desk-notif-card__title")).Text;

            Assert.AreEqual(userLabelDisplayed, userLoggedInLabel, "User Label is not found on page.");
        }
    }
}