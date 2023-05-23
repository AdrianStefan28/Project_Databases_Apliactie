using MTAApp.AutomatedTests.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests
{
    [TestClass]
    public class ContactsTest
    {
        private IWebDriver webDriver;
        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void ContactsAddContact_Creates_NewContactWithGivenEmail()
        {
            Random randomNumber = new Random();
            string contactEmail = "test " + randomNumber.Next(100, 10000000) + "@email.com";
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();

            ContactsIndexPage indexPage = new ContactsIndexPage(webDriver);
            indexPage.GoToPage();
            AddContactPage addContactPage = indexPage.GetAddContactPage();
            addContactPage.Create("FirstName Test","LastName Test",contactEmail, "1");

            Assert.IsTrue(indexPage.ContactExists(contactEmail));
        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
