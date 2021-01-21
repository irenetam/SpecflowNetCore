using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Pages
{
    public class AuthenticatePage
    {
        public IWebDriver _webDriver;
        public AuthenticatePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private readonly By userNameInput = By.Name("loginfmt");
        private readonly By nextButton = By.Id("idSIButton9");
        private readonly By passwordInput = By.Name("passwd");

        public void SendUserName(string userName)
        {
            WebElementFunctions.WaitForElementAppears(_webDriver, userNameInput);
            _webDriver.FindElement(userNameInput).SendKeys(userName);
        }

        public void SendPassword(string password)
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(passwordInput));
            _webDriver.FindElement(passwordInput).SendKeys(password);
        }

        public void SendNextButton()
        {
            WebElementFunctions.WaitForElementAppears(_webDriver, nextButton);
            _webDriver.FindElement(nextButton).Click();
        }
    }
}
