using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class ContractsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement contractsList;

        [FindsBy(How = How.LinkText, Using = "Add New Contract")]
        private IWebElement addContractButton;

        public ContractsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7288/Contracts");
        }

        public AddContractPage GetAddContractPage()
        {
            addContractButton.Click();
            return new AddContractPage(webDriver);
        }

        public bool ContractExists(string contractSupplierName) 
        {
            var elements = contractsList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(contractSupplierName)).Count() > 0;
        }

        
    }
}
