using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WesSpecFlowExample.Drivers
{
    class Page
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            var waitTime = System.TimeSpan.FromSeconds(20);
            wait = new WebDriverWait(driver, waitTime);
        }

        public void Click(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).Click();
        }

        public void FillIn(By locator, string input)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            var element = driver.FindElement(locator);
            element.Click();
            element.Clear();
            element.SendKeys(input);
        }

        public void Select(By locator, string selection)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            var element = driver.FindElement(locator);
            new SelectElement(element).SelectByText(selection);
        }

        public void Select(By locator, int index)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            var element = driver.FindElement(locator);
            new SelectElement(element).SelectByIndex(index);
        }

        public void To(string pageSuffix)
        {
            driver.Navigate().GoToUrl(pageSuffix);
        }

        public bool IsDisplayed(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            return driver.FindElement(locator).Displayed;
        }

    }
}
