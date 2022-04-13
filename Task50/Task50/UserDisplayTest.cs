using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class DataDisplayWaiter
    {
        private WebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
            driver.Manage().Window.Maximize();  
        }

        [Test]
        public void UserDisplay()
        {
            IWebElement getUserButton = driver.FindElement(By.Id("save"));
            getUserButton.Click();
            var waitForUserData = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement dataDisplayed = waitForUserData.Until(e => e.FindElement(By.Id("loading")));

            Console.WriteLine(dataDisplayed.Text);
        }
    }
}