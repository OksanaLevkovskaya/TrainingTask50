using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class MultiSelectTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            driver.Manage().Window.Maximize();  
        }

        [TestCase("California")]
        [TestCase("Florida")]
        [TestCase("New Jersey")]
        public void DropdownOptionsSelection(string state)
        {
            IWebElement multiSelect = driver.FindElement(By.Id("multi-select"));
            SelectElement dropdownOption = new SelectElement(multiSelect);
            dropdownOption.SelectByText(state);
            IWebElement addOption = driver.FindElement(By.Id("printMe"));
            addOption.Click();  
            Assert.AreEqual(state, dropdownOption.SelectedOption.Text, "Element is not selected.");
        }
    }
}