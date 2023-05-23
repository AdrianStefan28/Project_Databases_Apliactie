using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class AddEmployeePage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement employeeFirstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement employeeLastName;

        [FindsBy(How = How.Id, Using = "CNP")]
        private IWebElement employeeCNP;

        [FindsBy(How = How.Id, Using = "AssociationId")]
        private IWebElement employeeAssociationId;

        [FindsBy(How = How.XPath, Using = "/ html / body / div[2] / main / div[1] / div / form / div[9] / input")]
        private IWebElement createButton;

        public AddEmployeePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Create(string employeeFirstName, string employeeLastName, string employeeCNP, string employeeAssociationId)
        {
            this.employeeFirstName.Clear();
            this.employeeFirstName.SendKeys(employeeFirstName);
            this.employeeLastName.Clear();
            this.employeeLastName.SendKeys(employeeLastName);
            this.employeeCNP.Clear();
            this.employeeCNP.SendKeys(employeeCNP);
            this.employeeAssociationId.Clear();
            this.employeeAssociationId.SendKeys(employeeAssociationId);
            createButton.Click();
        }
    }
}
