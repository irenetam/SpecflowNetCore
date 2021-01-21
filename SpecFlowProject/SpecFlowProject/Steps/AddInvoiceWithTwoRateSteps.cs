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
    public class AddInvoiceWithTwoRateSteps
    {
        private readonly IWebDriver _webDriver;
        string projectName = string.Empty;
        private readonly InvoiceModel invoiceModel;
        private readonly InvoicePage invoicePage;
        private readonly HomePage homePage;
        private readonly ProjectPage projectPage;
        private readonly AuthenticatePage authenticatePage;

        public AddInvoiceWithTwoRateSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            invoiceModel = new InvoiceModel(_webDriver);
            invoicePage = new InvoicePage(_webDriver);
            homePage = new HomePage(_webDriver);
            projectPage = new ProjectPage(_webDriver);
            authenticatePage = new AuthenticatePage(_webDriver);
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
            authenticatePage.SendUserName(username);

        }
        
        [When(@"click next button")]
        public void WhenClickNextButton()
        {
            authenticatePage.SendNextButton();
        }
        
        
        [Then(@"the password login should be displayed")]
        public void ThenThePasswordLoginShouldBeDisplayed()
        {
        }
        
        [When(@"I enter password '(.*)'")]
        public void WhenIEnterPassword(string password)
        {
            authenticatePage.SendPassword(password);
        }
        
        [When(@"click sign in button")]
        public void WhenClickSignInButton()
        {
            authenticatePage.SendNextButton();
        }


        [Then(@"the budget tracker page should be displayed")]
        public void ThenTheBudgetTrackerPageShouldBeDisplayed()
        {
            authenticatePage.SendNextButton();
        }

        [When(@"I click on a project name '(.*)'")]
        public void WhenIClickOnAProjectName(string projectName)
        {
            homePage.SelectProject();
            this.projectName = projectName;
        }

        [Then(@"project page should be displayed")]
        public void ThenProjectPageShouldBeDisplayed()
        {
            var menuBreadcum = projectPage.GetProjectName();
            Assert.True(projectName == menuBreadcum.Text);
        }

        [When(@"I click on invoices tab")]
        public void WhenIClickOnInvoicesTab()
        {
            projectPage.ClickInvoiceTab();
        }

        [When(@"I click on add invoice button")]
        public void WhenIClickOnAddInvoiceButton()
        {
            projectPage.ClickOnAddInvoiceButton();
        }

        [Then(@"popup add invoice should be showed")]
        public void ThenPopupAddInvoiceShouldBeShowed()
        {
        }

        [When(@"I add a new invoice by typing as below")]
        public void WhenIAddANewInvoiceByTypingAsBelow(Table table)
        {
            var invoice = table.CreateInstance<Invoice>();
            invoiceModel.CreateNewInvoiceTwoRate(invoice);
        }

        [Then(@"the message result '(.*)' should be displayed")]
        public void ThenTheMessageResultShouldBeDisplayed(string message)
        {
            IList<IWebElement> rows = invoicePage.GetInvoiceRows();
            foreach (IWebElement row in rows)
            {
                var rowTD = row.FindElements(By.TagName("td"));
                if(rowTD.Count > 0)
                {
                    if (rowTD[0].Text.Equals(invoiceModel.InvoiceNumber))
                    {
                        Assert.True(rowTD[0].Text.Equals(invoiceModel.InvoiceNumber));
                        invoiceModel.FindAndDeleteInvoice(rowTD);
                    }
                }
            }
        }
    }
}
