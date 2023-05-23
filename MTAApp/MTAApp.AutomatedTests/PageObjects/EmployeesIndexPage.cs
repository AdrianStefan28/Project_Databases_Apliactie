using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class EmployeesIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement employeesList;

        [FindsBy(How = How.LinkText, Using = "Add New Employee")]
        private IWebElement addEmployeeButton;

        public EmployeesIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7288/Employees");
        }

        public AddEmployeePage GetAddEmployeePage()
        {
            addEmployeeButton.Click();
            return new AddEmployeePage(webDriver);
        }

        public bool EmployeeExists(string employeeCNP)
        {
            var elements = employeesList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(employeeCNP)).Count() > 0;
        }


    }
}
