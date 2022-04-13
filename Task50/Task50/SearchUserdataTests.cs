using System;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class SearchUserdataTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void GetEmployees()
        {
            var optionsDropown = new SelectElement(driver.FindElement(By.Name("example_length")));
            optionsDropown.SelectByText("10");
            var listOfEmployees = ListEmployees();
        }

        private List<EmployeeData> ListEmployees()
        {
            var listOfEmployees = new List<EmployeeData>();
            var pagerButton = driver.FindElement(By.Id("example_next"));
            var x = 0;

            do
            {
                if (x > 1)
                {
                    pagerButton.Click();
                }

                SortOutEmployees(listOfEmployees);
                x++;
                pagerButton = driver.FindElement(By.Id("example_next"));
            } while (pagerButton.GetCssValue("cursor") != "default");
            return listOfEmployees;
        }

        private void SortOutEmployees(List<EmployeeData> listOfEmployees)
        {
            var employees = driver.FindElements(By.XPath("//table[@id='example']//tbody/*"));
            foreach (var employee in employees)
            {
                var age = employee.FindElement(By.XPath(".//td[4]")).Text;
                var salary = employee.FindElement(By.XPath(".//td[6]")).GetAttribute("data-order");

                if (int.Parse(age) > 50 && int.Parse(salary) < 300000)
                {
                    var newEmp = new EmployeeData(
                        employee.FindElement(By.XPath(".//td[1]")).Text,
                        employee.FindElement(By.XPath(".//td[2]")).Text,
                        employee.FindElement(By.XPath(".//td[3]")).Text);
                    listOfEmployees.Add(newEmp);
                }
            }
        }
    }

   
}