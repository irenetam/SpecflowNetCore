using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    public class LoginPage
    {
        private IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement txtUserName => _webDriver.FindElement(By.Name("username"));
        IWebElement txtPassword => _webDriver.FindElement(By.Name("password"));
        IWebElement btnLogin => _webDriver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));
        IWebElement Message => _webDriver.FindElement((By.Id("flash")));

        public void EnterUserNameAndPassword(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            btnLogin.Click();
        }

        public string GetMessage() {
            return Message.Text.Split("\r")[0];
        }
    }
}
