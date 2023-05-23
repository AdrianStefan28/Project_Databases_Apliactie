using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class ContactsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement contactsList;

        [FindsBy(How = How.LinkText, Using = "Add New Contact")]
        private IWebElement addContactButton;

        public ContactsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7288/Contacts");
        }

        public AddContactPage GetAddContactPage()
        {
            addContactButton.Click();
            return new AddContactPage(webDriver);
        }

        public bool ContactExists(string contactEmail)
        {
            var elements = contactsList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(contactEmail)).Count() > 0;
        }

    }
}
