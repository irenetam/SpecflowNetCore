using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Pages
{
    public class HomePage
    {
        public IWebDriver _webDriver;
        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private readonly By project = By.XPath("(//span[.=' Carlson Testing '])[1]");

        public void SelectProject()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(project));
            _webDriver.FindElement(project).Click();
        }
    }
}
