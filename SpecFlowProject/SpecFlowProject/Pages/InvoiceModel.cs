using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Commons;
using SpecFlowProject.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SpecFlowProject.Pages
{
    public class InvoiceModel
    {
        public IWebDriver _webDriver;
        public InvoiceModel(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private readonly By invoiceNumber = By.Id("invoiceNumber");
        private readonly By snapshot = By.XPath("");
        private readonly By invoiceDate = By.XPath("//*[@id='invoice-modal']/form/div[4]/div[1]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle");
        private readonly By billingMonth = By.XPath("//*[@id='invoice-modal']/form/div[4]/div[2]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle");
        private readonly By internalRateUS = By.XPath("");
        private readonly By invoiceDescription = By.XPath("");
        private readonly By internalRateVN = By.XPath("");
        private readonly By devLineUSDescription = By.XPath("");
        private readonly By devLineUSTotalBilledHours = By.XPath("");
        private readonly By devLineUSBillingRate = By.XPath("");
        private readonly By devLineUSAmount = By.XPath("");
        private readonly By devLineVNDescription = By.XPath("");
        private readonly By devLineVNTotalBilledHours = By.XPath("");
        private readonly By devLineVNBillingRate = By.XPath("");
        private readonly By devLineVNAmount = By.XPath("");
        private readonly By creditUSDescription = By.XPath("");
        private readonly By creditUSTotalHours = By.XPath("");
        private readonly By creditUSRate = By.XPath("");
        private readonly By creditUSAmount = By.XPath("");
        private readonly By creditVNDescription = By.XPath("");
        private readonly By creditVNTotalHours = By.XPath("");
        private readonly By creditVNRate = By.XPath("");
        private readonly By creditVNAmount = By.XPath("");
        private readonly By carryOverCreddit = By.XPath("");
        private readonly By newCredit = By.XPath("");
        private readonly By creditTotal = By.XPath("");
        private readonly By nonDevLineDescription = By.XPath("");
        private readonly By nonDevLineAmount = By.XPath("");
        private readonly By paidAmountUS = By.XPath("");
        private readonly By paidAmountVN = By.XPath("");
        private readonly By nonDevPaidAmount = By.XPath("");
        private readonly By jiraTimeLoggedRawUS = By.XPath("//*[@placeholder='Jira Time Logged Raw (US)']");
        private readonly By withheldHoursUS = By.XPath("");
        private readonly By withheldHoursVN = By.XPath("");
        private readonly By jiraTimeLoggedRawVN = By.XPath("//*[@placeholder='Jira Time Logged Raw (VN)']");
        private readonly By createButton = By.XPath("//*[@id='invoice-modal']/form/div[12]/div[2]/button[2]");
        private readonly By deleteButton = By.XPath("//*[@id='invoice-modal']/form/div[12]/div[1]/button");

        public string InvoiceNumber { get; set; }

        public void CreateNewInvoiceTwoRate(Invoice invoice)
        {
            var invoiceNumberElement = _webDriver.FindElement(invoiceNumber);
            invoiceNumberElement.SendKeys(invoice.Number);

            // Invoice Date
            //WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //waitForElement.Until(ExpectedConditions.ElementIsVisible(invoiceDate));
            WebElementFunctions.WaitForElementAppears(_webDriver, invoiceDate);
            var datepickerModal = _webDriver.FindElement(invoiceDate);
            datepickerModal.Click();
            DatePicker datePicker = new DatePicker();
            datePicker.SelectectDate(invoice, _webDriver);

            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            // Invoice month
            //waitForElement.Until(ExpectedConditions.ElementIsVisible(billingMonth));
            WebElementFunctions.WaitForElementAppears(_webDriver, billingMonth);
            var monthpickerModal = _webDriver.FindElement(billingMonth);
            monthpickerModal.Click();
            datePicker.SelectMonth(invoice, _webDriver);

            waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //waitForElement.Until(ExpectedConditions.ElementExists(jiraTimeLoggedRawUS));

            WebElementFunctions.WaitForElementAppears(_webDriver, jiraTimeLoggedRawUS);
            var timeLoggedRawUS = _webDriver.FindElement(jiraTimeLoggedRawUS);
            var s1 = timeLoggedRawUS.GetProperty("value");

            waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //waitForElement.Until(ExpectedConditions.ElementExists(jiraTimeLoggedRawVN));
            WebElementFunctions.WaitForElementAppears(_webDriver, jiraTimeLoggedRawVN);
            var timeLoggedRawVN = _webDriver.FindElement(jiraTimeLoggedRawVN);
            var s2 = timeLoggedRawVN.GetProperty("value");
            InvoiceNumber = invoiceNumberElement.GetProperty("value");

            var createButtonElement = _webDriver.FindElement(createButton);
            createButtonElement.Click();
        }

        internal void FindAndDeleteInvoice(ReadOnlyCollection<IWebElement> rowTD)
        {
            var editButtons = rowTD[7].FindElements(By.TagName("button"));
            editButtons[1].Click();
            Thread.Sleep(1000);
            DeleteInvoice();
        }

        private void DeleteInvoice()
        {
            var button = _webDriver.FindElement(deleteButton);
            button.Click();
        }
    }
}
