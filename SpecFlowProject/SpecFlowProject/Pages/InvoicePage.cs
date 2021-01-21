using OpenQA.Selenium;
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

        private readonly By invoiceTable = By.XPath("//*[@id='invoices-table']");

        internal IList<IWebElement> GetInvoiceRows()
        {
            IWebElement tableElement = _webDriver.FindElement(invoiceTable);
            IList<IWebElement> rows = tableElement.FindElements(By.TagName("tr"));
            return rows;
        }
    }
}
