using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class PageRefresh
    {
        private WebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
            driver.Manage().Window.Maximize();  
        }

        [Test]
        public void PageRefreshWhileDownload()
        {
            IWebElement downloadButton = driver.FindElement(By.Id("cricle-btn"));
            downloadButton.Click();
            var waitPercentage = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement percentage50 = waitPercentage.Until(e => e.FindElement(By.XPath("//div[contains(text(),'50%')]")));
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}