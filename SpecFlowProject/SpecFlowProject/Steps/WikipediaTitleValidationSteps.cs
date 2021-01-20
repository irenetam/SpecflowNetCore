using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class WikipediaTitleValidationSteps
    {
        private readonly IWebDriver _webDriver;
        public WikipediaTitleValidationSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the ""(.*)"" page on Wikipedia")]
        public void GivenIHaveNavigatedToThePageOnWikipedia(string subject)
        {
            _webDriver.Url = $"https://en.wikipedia.org/wiki/{subject}";
        }
        
        [Then(@"the title of the page should be ""(.*)""")]
        public void ThenTheTitleOfThePageShouldBe(string title)
        {
            Assert.Equal(title, _webDriver.Title);
        }
    }
}
