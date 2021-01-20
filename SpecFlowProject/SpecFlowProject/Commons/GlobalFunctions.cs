using OpenQA.Selenium;

namespace SpecFlowProject.Commons
{
    public class GlobalFunctions
    {
        public bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
