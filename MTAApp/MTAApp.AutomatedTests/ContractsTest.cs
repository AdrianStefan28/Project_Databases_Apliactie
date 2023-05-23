using MTAApp.AutomatedTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MTAApp.AutomatedTests
{
    [TestClass]
    public class ContractsTest
    {
        private IWebDriver webDriver;
        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void ContractsAddContract_Creates_NewContractWithGivenSupplierName()
        {
            Random randomNumber = new Random();
            string contractSupplierName = "MyTestContract " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();

            ContractsIndexPage indexPage = new ContractsIndexPage(webDriver);
            indexPage.GoToPage();
            AddContractPage addContractPage = indexPage.GetAddContractPage();
            addContractPage.Create("My Test Type", contractSupplierName, "1");

            Assert.IsTrue(indexPage.ContractExists(contractSupplierName));
        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}