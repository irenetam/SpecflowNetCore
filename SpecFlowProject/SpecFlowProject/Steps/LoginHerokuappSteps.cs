using OpenQA.Selenium;
using SpecFlowProject.Pages;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class LoginHerokuappSteps
    {
        private readonly IWebDriver _webDriver;
        public LoginHerokuappSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the Login Page")]
        public void GivenIHaveNavigatedToTheLoginPage()
        {
            _webDriver.Url = "https://the-internet.herokuapp.com/login";
        }

        [When(@"I enter username: '(.*)'")]
        public void WhenIEnterUsername(string userName)
        {
            _webDriver.FindElement(By.Name("username")).SendKeys(userName);
        }


        [When(@"I enter password: '(.*)'")]
        public void WhenIEnterPassword(string password)
        {
            _webDriver.FindElement(By.Name("password")).SendKeys(password);
        }
        
        [When(@"I press the Login button")]
        public void WhenIPressTheLoginButton()
        {
            var loginButton = _webDriver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));
            loginButton.Click();
        }
        
        [Then(@"I am logged into the Home Page and show Message '(.*)'")]
        public void ThenIAmLoggedIntoTheHomePageAndShowMessage(string expectedMessage)
        {
            var alertMessage = _webDriver.FindElement(By.Id("flash"));
            if (alertMessage != null)
            {
                string message = alertMessage.Text.Split("\r")[0];
                Assert.Equal(expectedMessage, message);
            }
        }
    }
}
