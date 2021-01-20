using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Pages
{
    public class InvoicePage
    {
        public IWebDriver _webDriver;
        public InvoicePage(IWebDriver webDriver)
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

        public string InvoiceNumber { get; set; }

        public void CreateNewInvoiceTwoRate(Invoice invoice)
        {
            var invoiceNumberElement = _webDriver.FindElement(invoiceNumber);
            invoiceNumberElement.SendKeys(invoice.Number);

            // Invoice Date
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(invoiceDate));
            var datepickerModal = _webDriver.FindElement(invoiceDate);
            datepickerModal.Click();
            var monthYearSelected = _webDriver.FindElement(By.XPath("//button[@cdkarialive='polite']"));
            monthYearSelected.Click();
            var yearElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            foreach (var item in yearElements)
            {
                if (item.Text == invoice.Date.Year.ToString())
                {
                    item.Click();
                    break;
                }
            }

            var monthElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            foreach (var item in monthElements)
            {
                if (item.Text.ToLower() == invoice.Date.ToString("MMM").ToLower())
                {
                    item.Click();
                    break;
                }
            }

            var dateElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            foreach (var item in dateElements)
            {
                if (item.Text == invoice.Date.Day.ToString())
                {
                    item.Click();
                    break;
                }
            }

            // Invoice month
            waitForElement.Until(ExpectedConditions.ElementIsVisible(billingMonth));
            var monthpickerModal = _webDriver.FindElement(billingMonth);
            monthpickerModal.Click();

            var currentYearElement = _webDriver.FindElement(By.XPath("//button[@cdkarialive='polite']"));
            var currentBillingElementValue = currentYearElement.GetProperty("value");
            if (currentBillingElementValue != invoice.BillingMonth.Year.ToString())
            {
                currentYearElement.Click();
                currentYearElement.Click();

                yearElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
                foreach (var item in yearElements)
                {
                    if (item.Text == invoice.BillingMonth.Year.ToString())
                    {
                        item.Click();
                        break;
                    }
                }
            }
            else
            {
                var currentBillingElement = _webDriver.FindElement(By.XPath("//div[@class='mat-calendar-body-cell-content mat-calendar-body-today']"));
                if (currentBillingElement.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
                {
                    currentBillingElement.Click();
                }
            }

            var monthBillingElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            foreach (var item in monthBillingElements)
            {
                if (item.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
                {
                    item.Click();
                    break;
                }
            }

            waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementExists(jiraTimeLoggedRawUS));
            var timeLoggedRawUS = _webDriver.FindElement(jiraTimeLoggedRawUS);
            var s1 = timeLoggedRawUS.GetProperty("value");

            waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementExists(jiraTimeLoggedRawVN));
            var timeLoggedRawVN = _webDriver.FindElement(jiraTimeLoggedRawVN);
            var s2 = timeLoggedRawVN.GetProperty("value");
            InvoiceNumber = invoiceNumberElement.GetProperty("value");

            var createButtonElement = _webDriver.FindElement(createButton);
            createButtonElement.Click();
        }
    }
}
