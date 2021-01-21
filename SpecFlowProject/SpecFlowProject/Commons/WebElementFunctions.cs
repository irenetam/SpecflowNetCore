using OpenQA.Selenium;
using System;

namespace SpecFlowProject.Commons
{
    public static class WebElementFunctions
    {
        public static bool IsElementPresent(IWebDriver driver, By by)
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

        public static void WaitForElementAppears(IWebDriver driver, By by)
        {
            if (!IsElementPresent(driver, by))
            {
                WaitForElementAppears(driver, by);
            }
            else
            {
                Console.WriteLine("Element disappears!");
            }
        }
    }
}
