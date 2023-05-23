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
    public class EmployeesTest
    {
        private IWebDriver webDriver;
        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void EmployeesAddEmployee_Creates_NewEmployeeWithGivenCNP()
        {
            Random randomNumber = new Random();
            string employeeCNP = "" + randomNumber.Next(10000000, 90000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();

            EmployeesIndexPage indexPage = new EmployeesIndexPage(webDriver);
            indexPage.GoToPage();
            AddEmployeePage addEmployeePage = indexPage.GetAddEmployeePage();
            addEmployeePage.Create("FirstName Test","LastName Test",employeeCNP, "1");

            Assert.IsTrue(indexPage.EmployeeExists(employeeCNP));
        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
