using OpenQA.Selenium;
using SpecFlowProject.Commons;

namespace SpecFlowProject.Pages
{
    public class ProjectPage
    {
        public IWebDriver _webDriver;
        public ProjectPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private readonly By projectName = By.XPath("//*[@id='nav-menu']/span[2]/button/span");
        private readonly By invoiceTab = By.XPath("//div[@id='mat-tab-label-0-1']");
        private readonly By addButton = By.XPath("//*[@id='mat-tab-content-0-1']/div/app-invoice/button");

        public IWebElement GetProjectName()
        {
            return _webDriver.FindElement(projectName);
        }

        public void ClickInvoiceTab()
        {
            WebElementFunctions.WaitForElementAppears(_webDriver, invoiceTab);
            _webDriver.FindElement(invoiceTab).Click();
        }

        public void ClickOnAddInvoiceButton()
        {
            WebElementFunctions.WaitForElementAppears(_webDriver, addButton);
            _webDriver.FindElement(addButton).Click();
        }
    }
}
