using OpenQA.Selenium;
using SpecFlowProject.Models;

namespace SpecFlowProject.Pages
{
    public class DatePicker
    {
        private readonly By currentPicker = By.XPath("//button[@cdkarialive='polite']");
        private readonly By calendarCellContent = By.XPath("//div[@class='mat-calendar-body-cell-content']");
        private readonly By currentMonth = By.XPath("//div[@class='mat-calendar-body-cell-content mat-calendar-body-today']");

        public void SelectectDate(Invoice invoice, IWebDriver webDriver)
        {
            var monthYearSelected = webDriver.FindElement(currentPicker);
            monthYearSelected.Click();
            var yearElements = webDriver.FindElements(calendarCellContent);
            foreach (var item in yearElements)
            {
                if (item.Text == invoice.Date.Year.ToString())
                {
                    item.Click();
                    break;
                }
            }

            var monthElements = webDriver.FindElements(calendarCellContent);
            foreach (var item in monthElements)
            {
                if (item.Text.ToLower() == invoice.Date.ToString("MMM").ToLower())
                {
                    item.Click();
                    break;
                }
            }

            var dateElements = webDriver.FindElements(calendarCellContent);
            foreach (var item in dateElements)
            {
                if (item.Text == invoice.Date.Day.ToString())
                {
                    item.Click();
                    break;
                }
            }
        }


        public void SelectMonth(Invoice invoice, IWebDriver webDriver)
        {
            var currentYearElement = webDriver.FindElement(currentPicker);
            var currentBillingElementValue = currentYearElement.GetProperty("value");
            if (currentBillingElementValue != invoice.BillingMonth.Year.ToString())
            {
                currentYearElement.Click();
                currentYearElement.Click();

                var yearElements = webDriver.FindElements(calendarCellContent);
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
                var currentBillingElement = webDriver.FindElement(currentMonth);
                if (currentBillingElement.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
                {
                    currentBillingElement.Click();
                }
            }

            var monthBillingElements = webDriver.FindElements(calendarCellContent);
            foreach (var item in monthBillingElements)
            {
                if (item.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
                {
                    item.Click();
                    break;
                }
            }
        }
    }
}
