using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class AddContactPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement contactFirstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement contactLastName;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement contactEmail;

        [FindsBy(How = How.Id, Using = "AssociationId")]
        private IWebElement contactAssociationId;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div/form/div[7]/input")]
        private IWebElement createButton;

        public AddContactPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void Create(string contactFirstName,string contactLastName,string contactEmail, string contactAssociationId)
        {
            this.contactFirstName.Clear();
            this.contactFirstName.SendKeys(contactFirstName);
            this.contactLastName.Clear();
            this.contactLastName.SendKeys(contactLastName);
            this.contactEmail.Clear();
            this.contactEmail.SendKeys(contactEmail);
            this.contactAssociationId.Clear();
            this.contactAssociationId.SendKeys(contactAssociationId);
            createButton.Click();
        }
    }
}
