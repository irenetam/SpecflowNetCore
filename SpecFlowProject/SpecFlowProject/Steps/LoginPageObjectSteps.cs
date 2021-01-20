using OpenQA.Selenium;
using SpecFlowProject.Pages;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class LoginPageObjectSteps
    {
        private readonly IWebDriver _webDriver;
        readonly LoginPage loginPage;
        public LoginPageObjectSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            loginPage = new LoginPage(_webDriver);
        }

        [Given(@"I navigated to the Login Page successfully")]
        public void GivenINavigatedToTheLoginPageSuccessfully()
        {
            _webDriver.Url = "https://the-internet.herokuapp.com/login";
        }

        [When(@"I enter username '(.*)' and  password '(.*)'")]
        public void WhenIEnterUsernameAndPassword(string userName, string password)
        {
            loginPage.EnterUserNameAndPassword(userName, password);
        }
        
        [When(@"I submit the Login button")]
        public void WhenISubmitTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }
        
        [Then(@"I am logged into the Home Page and display Message '(.*)'")]
        public void ThenIAmLoggedIntoTheHomePageAndDisplayMessage(string expectedMessage)
        {
            string actualMessage = loginPage.GetMessage();
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
