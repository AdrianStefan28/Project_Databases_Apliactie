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
     public class ApartmentsTest
    {
        private IWebDriver webDriver;
        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void ApartmentsAddApartment_Creates_NewApartmentWithGivenTenantName()
        {
            Random randomNumber = new Random();
            string apartmentTenanatName = "MyTestApartment " + randomNumber.Next(100, 10000000);
            string apartmentApNumber ="" + randomNumber.Next(1, 200);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();

            ApartmentIndexPage indexPage = new ApartmentIndexPage(webDriver);
            indexPage.GoToPage();
            AddApartmentPage addApartmentPage = indexPage.GetAddApartmentPage();
            addApartmentPage.Create(apartmentApNumber, apartmentTenanatName, "1");

            Assert.IsTrue(indexPage.ApartmentExists(apartmentTenanatName));
        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
