using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.AutomatedTests.PageObjects
{
    class AddPollPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Subject")]
        private IWebElement pollSubject;

        [FindsBy(How = How.Id, Using = "Context")]
        private IWebElement pollContext;

        [FindsBy(How = How.Id, Using = "UserId")]
        private IWebElement pollUserId;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div/form/div[4]/input")]
        private IWebElement createButton;

        public AddPollPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Create(string pollSubject, string pollContext, string pollUserId)
        {
            this.pollSubject.Clear();
            this.pollSubject.SendKeys(pollSubject);
            this.pollContext.Clear();
            this.pollContext.SendKeys(pollContext);
            this.pollUserId.Clear();
            this.pollUserId.SendKeys(pollUserId);
            createButton.Click();
        }
    }
}
