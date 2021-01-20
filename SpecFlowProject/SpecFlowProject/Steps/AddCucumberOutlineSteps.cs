using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class AddCucumberOutlineSteps
    {
        private readonly Calculator calculator = new Calculator();
        private int result = 0;

        [Given(@"the first number (.*)")]
        public void GivenTheFirstNumber(int p0)
        {
            calculator.FirstNumber = p0;
        }
        
        [Given(@"the second number (.*)")]
        public void GivenTheSecondNumber(int p0)
        {
            calculator.SecondNumber = p0;
        }
        
        [When(@"let the two numbers are added")]
        public void WhenLetTheTwoNumbersAreAdded()
        {
            result = calculator.Add();
        }
        
        [Then(@"so the result should be (.*)")]
        public void ThenSoTheResultShouldBe(int expectedResults)
        {
            Assert.Equal(expectedResults, result);
        }
    }
}
