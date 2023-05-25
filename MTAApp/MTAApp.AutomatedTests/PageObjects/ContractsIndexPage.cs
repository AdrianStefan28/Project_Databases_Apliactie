using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MTAApp.AutomatedTests.PageObjects
{
    class ContractsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/table/tbody")]
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
            var elements = contractsList.FindElements(By.XPath("tr/td"));
        
            return elements.Where(element => element.Text.Equals(contractSupplierName)).Count() > 0;
        }

        
    }
}
