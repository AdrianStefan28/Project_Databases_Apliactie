using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class AddContractPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Type")]
        private IWebElement contractType;

        [FindsBy(How = How.Id, Using = "SupplierName")]
        private IWebElement contractSupplierName;

        [FindsBy(How = How.Id,Using = "AssociationId")]
        private IWebElement contractAssociationId;

        [FindsBy(How=How.XPath, Using = "/html/body/div[2]/main/div[1]/div/form/div[6]/input")]
        private IWebElement createButton;

        public AddContractPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Create(string contractType,string contractSupplierName, string contractAssociationId)
        {
            this.contractType.Clear();
            this.contractType.SendKeys(contractType);
            this.contractSupplierName.Clear();
            this.contractSupplierName.SendKeys(contractSupplierName);
            this.contractAssociationId.Clear();
            this.contractAssociationId.SendKeys(contractAssociationId);
            createButton.Click();
        }
    }
}
