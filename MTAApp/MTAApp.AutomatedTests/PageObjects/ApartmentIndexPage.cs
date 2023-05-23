using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class ApartmentIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement apartmentsList;

        [FindsBy(How = How.LinkText, Using = "Add New Apartment")]
        private IWebElement addApartmentButton;

        public ApartmentIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7288/Apartments");
        }

        public AddApartmentPage GetAddApartmentPage()
        {
            addApartmentButton.Click();
            return new AddApartmentPage(webDriver);
        }

        public bool ApartmentExists(string apartmentTenantName)
        {
            var elements = apartmentsList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(apartmentTenantName)).Count() > 0;
        }


    }
}
