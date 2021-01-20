using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class WriteLogPerformanceSteps
    {
        private readonly IWebDriver _webDriver;
        public WriteLogPerformanceSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"navigated to the Login Page")]
        public void GivenNavigatedToTheLoginPage()
        {
            _webDriver.Url = "https://the-internet.herokuapp.com/login";
        }
        
        [When(@"press console tab")]
        public void WhenPressConsoleTab()
        {
        }
        
        [When(@"press to performance tab")]
        public void WhenPressToPerformanceTab()
        {
        }
        
        [Then(@"write log of performance")]
        public void ThenWriteLogOfPerformance()
        {
        }
    }
}
