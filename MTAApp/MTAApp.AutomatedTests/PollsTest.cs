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
    public class PollsTest
    {
        private IWebDriver webDriver;
        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void PollsAddPoll_Creates_NewPollWithGivenSubject()
        {
            Random randomNumber = new Random();
            string pollSubject = "MyTestPoll " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();

            PollsIndexPage indexPage = new PollsIndexPage(webDriver);
            indexPage.GoToPage();
            AddPollPage addPollPage = indexPage.GetAddPollPage();
            addPollPage.Create(pollSubject, "MyTestContext", "1");

            Assert.IsTrue(indexPage.PollExists(pollSubject));
        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
