using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
     class PollsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement pollsList;

        [FindsBy(How = How.LinkText, Using = "Add New Poll")]
        private IWebElement addPollButton;

        public PollsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7288/Polls");
        }

        public AddPollPage GetAddPollPage()
        {
            addPollButton.Click();
            return new AddPollPage(webDriver);
        }

        public bool PollExists(string pollSubject)
        {
            var elements = pollsList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(pollSubject)).Count() > 0;
        }

    }
}
