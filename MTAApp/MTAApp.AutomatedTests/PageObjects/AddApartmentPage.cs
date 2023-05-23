using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class AddApartmentPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "ApNumber")]
        private IWebElement apartmentApNumber;

        [FindsBy(How = How.Id, Using = "TenantName")]
        private IWebElement apartmentTenantName;

        [FindsBy(How = How.Id, Using = "UserId")]
        private IWebElement apartmentUserId;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div/form/div[11]/input")]
        private IWebElement createButton;

        public AddApartmentPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Create(string apartmentApNumber, string apartmentTenantName, string apartmentUserId)
        {
            this.apartmentApNumber.Clear();
            this.apartmentApNumber.SendKeys(apartmentApNumber);
            this.apartmentTenantName.Clear();
            this.apartmentTenantName.SendKeys(apartmentTenantName);
            this.apartmentUserId.Clear();
            this.apartmentUserId.SendKeys(apartmentUserId);
            createButton.Click();
        }
    }
}
