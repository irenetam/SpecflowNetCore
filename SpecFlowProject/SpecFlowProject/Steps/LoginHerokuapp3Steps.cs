using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class LoginHerokuapp3Steps
    {
        private readonly IWebDriver _webDriver;
        public LoginHerokuapp3Steps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the Login Page is")]
        public void GivenIHaveNavigatedToTheLoginPageIs()
        {
            _webDriver.Url = "https://the-internet.herokuapp.com/login";
        }
        
        [When(@"I enter some info below:")]
        public void WhenIEnterSomeInfoBelow(Table table)
        {
            _webDriver.FindElement(By.Name("username")).SendKeys(table.Rows[0][0]);
            _webDriver.FindElement(By.Name("password")).SendKeys(table.Rows[0][1]);
        }
        
        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            var loginButton = _webDriver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));
            if (loginButton != null)
            {
                loginButton.Click();
            }
        }
        
        [Then(@"I am logged into the Home Page and do something")]
        public void ThenIAmLoggedIntoTheHomePageAndDoSomething()
        {
            var alertMessage = _webDriver.FindElement(By.Id("flash"));
            if (alertMessage != null)
            {
                string message = alertMessage.Text.Split("\r")[0];
            }
        }
    }
}
