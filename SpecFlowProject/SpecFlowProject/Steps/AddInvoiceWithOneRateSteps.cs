using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using SpecFlowProject.Models;
using System.Collections.Generic;
using Xunit;
using SpecFlowProject.Pages;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class AddInvoiceWithOneRateSteps
    {
        private readonly IWebDriver _webDriver;
        string invoiceNumber = string.Empty;
        string projectName = string.Empty;
        InvoicePage invoicePage;
        public AddInvoiceWithOneRateSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            invoicePage = new InvoicePage(_webDriver);
        }

        [Given(@"I have accessed application via url '(.*)'")]
        public void GivenIHaveAccessedApplicationViaUrl(string url)
        {
            _webDriver.Url = url;
        }
        
        [Given(@"the login page should be displayed")]
        public void GivenTheLoginPageShouldBeDisplayed()
        {
            Thread.Sleep(5000);
        }
        
        [When(@"I enter username '(.*)'")]
        public void WhenIEnterUsername(string username)
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Name("loginfmt")));
            _webDriver.FindElement(By.Name("loginfmt")).SendKeys(username);
        }
        
        [When(@"click next button")]
        public void WhenClickNextButton()
        {
            _webDriver.FindElement(By.Id("idSIButton9")).Click();
        }
        
        
        [Then(@"the password login should be displayed")]
        public void ThenThePasswordLoginShouldBeDisplayed()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Name("passwd")));
        }
        
        [When(@"I enter password '(.*)'")]
        public void WhenIEnterPassword(string password)
        {
            _webDriver.FindElement(By.Name("passwd")).SendKeys(password);
        }
        
        [When(@"click sign in button")]
        public void WhenClickSignInButton()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
            _webDriver.FindElement(By.Id("idSIButton9")).Click();
        }


        [Then(@"the budget tracker page should be displayed")]
        public void ThenTheBudgetTrackerPageShouldBeDisplayed()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
            _webDriver.FindElement(By.Id("idSIButton9")).Click();
        }

        [When(@"I click on a project name '(.*)'")]
        public void WhenIClickOnAProjectName(string projectName)
        {
            this.projectName = projectName;
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[.=' Carlson Testing '])[1]")));
            _webDriver.FindElement(By.XPath("(//span[.=' Carlson Testing '])[1]")).Click();
        }

        [Then(@"project page should be displayed")]
        public void ThenProjectPageShouldBeDisplayed()
        {
            var menuBreadcum = _webDriver.FindElement(By.XPath("//*[@id='nav-menu']/span[2]/button/span"));
            Assert.True(projectName == menuBreadcum.Text);
        }

        [When(@"I click on invoices tab")]
        public void WhenIClickOnInvoicesTab()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='mat-tab-label-0-1']")));
            _webDriver.FindElement(By.XPath("//div[@id='mat-tab-label-0-1']")).Click();
        }

        [When(@"I click on add invoice button")]
        public void WhenIClickOnAddInvoiceButton()
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='mat-tab-content-0-1']/div/app-invoice/button")));
            var s = _webDriver.FindElement(By.XPath("//*[@id='mat-tab-content-0-1']/div/app-invoice/button"));
            s.Click();
        }

        [Then(@"popup add invoice should be showed")]
        public void ThenPopupAddInvoiceShouldBeShowed()
        {
        }

        [When(@"I add a new invoice by typing as below")]
        public void WhenIAddANewInvoiceByTypingAsBelow(Table table)
        {
            var invoice = table.CreateInstance<Invoice>();
            invoicePage.CreateNewInvoiceTwoRate(invoice);
            //WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //var invoiceNumberElement = _webDriver.FindElement(By.Id("invoiceNumber"));
            //invoiceNumberElement.SendKeys(invoice.Number);

            //waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='invoice-modal']/form/div[4]/div[1]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle")));
            //var datepickerModal = _webDriver.FindElement(By.XPath("//*[@id='invoice-modal']/form/div[4]/div[1]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle"));
            //datepickerModal.Click();
            //var monthYearSelected = _webDriver.FindElement(By.XPath("//button[@cdkarialive='polite']"));
            //monthYearSelected.Click();

            //var yearElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            //foreach(var item in yearElements)
            //{
            //    if(item.Text == invoice.Date.Year.ToString())
            //    {
            //        item.Click();
            //        break;
            //    }
            //}

            //var monthElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            //foreach(var item in monthElements)
            //{
            //    if(item.Text.ToLower() == invoice.Date.ToString("MMM").ToLower())
            //    {
            //        item.Click();
            //        break;
            //    }
            //}

            //var dateElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            //foreach (var item in dateElements)
            //{
            //    if (item.Text == invoice.Date.Day.ToString())
            //    {
            //        item.Click();
            //        break;
            //    }
            //}

            //waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='invoice-modal']/form/div[4]/div[2]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle")));
            //var monthpickerModal = _webDriver.FindElement(By.XPath("//*[@id='invoice-modal']/form/div[4]/div[2]/mat-form-field/div/div[1]/div[2]/mat-datepicker-toggle"));
            //monthpickerModal.Click();

            //var currentYearElement = _webDriver.FindElement(By.XPath("//button[@cdkarialive='polite']"));
            //var currentBillingElementValue = currentYearElement.GetProperty("value");
            //if(currentBillingElementValue != invoice.BillingMonth.Year.ToString())
            //{
            //    currentYearElement.Click();
            //    currentYearElement.Click();

            //    yearElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            //    foreach (var item in yearElements)
            //    {
            //        if (item.Text == invoice.BillingMonth.Year.ToString())
            //        {
            //            item.Click();
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    var currentBillingElement = _webDriver.FindElement(By.XPath("//div[@class='mat-calendar-body-cell-content mat-calendar-body-today']"));
            //    if (currentBillingElement.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
            //    {
            //        currentBillingElement.Click();
            //    }
            //}

            //var monthBillingElements = _webDriver.FindElements(By.XPath("//div[@class='mat-calendar-body-cell-content']"));
            //foreach (var item in monthBillingElements)
            //{
            //    if (item.Text.ToLower() == invoice.BillingMonth.ToString("MMM").ToLower())
            //    {
            //        item.Click();
            //        break;
            //    }
            //}

            //// After billing month was selected load jira time logged raw + withheld hours
            //waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //waitForElement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@placeholder='Jira Time Logged Raw (US)']")));
            //var timeLoggedRawUS = _webDriver.FindElement(By.XPath("//*[@placeholder='Jira Time Logged Raw (US)']"));
            //var s1 = timeLoggedRawUS.GetProperty("value");

            //waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //waitForElement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@placeholder='Jira Time Logged Raw (VN)']")));
            //var timeLoggedRawVN = _webDriver.FindElement(By.XPath("//*[@placeholder='Jira Time Logged Raw (VN)']"));
            //var s2 = timeLoggedRawVN.GetProperty("value");
            //invoiceNumber = invoiceNumberElement.GetProperty("value");

            //var createButtonElement = _webDriver.FindElement(By.XPath("//*[@id='invoice-modal']/form/div[12]/div[2]/button[2]"));
            //createButtonElement.Click();
        }

        [Then(@"the message result '(.*)' should be displayed")]
        public void ThenTheMessageResultShouldBeDisplayed(string message)
        {
            IWebElement tableElement = _webDriver.FindElement(By.XPath("//*[@id='invoices-table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                var rowTD = row.FindElements(By.TagName("td"));
                if(rowTD.Count > 0)
                {
                    var s = rowTD[0].Text;
                    if (rowTD[0].Text.Equals(invoiceNumber))
                    {
                        Assert.True(rowTD[0].Text.Equals(invoiceNumber));
                        Thread.Sleep(100);
                        var editButtons = rowTD[7].FindElements(By.TagName("button"));
                        editButtons[1].Click();
                        var deleteButton = _webDriver.FindElement(By.XPath("//*[@id='invoice-modal']/form/div[12]/div[1]/button"));
                        deleteButton.Click();
                    }
                }
            }
        }
    }
}
