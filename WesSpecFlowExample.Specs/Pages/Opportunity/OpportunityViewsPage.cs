using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WesSpecFlowExample.Drivers;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;

namespace WesSpecFlowExample.Pages.Opportunity
{
    public class OpportunityViewsPage
    {
        //private IWebDriver driver;
        private Page page;


        public OpportunityViewsPage(IWebDriver driver)
        {
           // this.driver = driver;
            page = new Page(driver);

        }

        // Element locators
        private By viewsButton = By.XPath("//button[contains(@id,'View_Selector')]");
        private By searchInput = By.XPath("//input[contains(@id,'quickFind_text')]");
        private By searchButton = By.XPath("//button[contains(@id,'quickFind_button')]");


        public void To()
        {
            page.To(Url.QaEnvironment + Url.OpportunityViewsPage);
        }

        public void OpenView(string viewName)
        {
            page.Click(viewsButton);
            var viewListItem = By.XPath("//span[text() = '" + viewName + "']");
            page.Click(viewListItem);
        }


        public bool CanSearchForOpportunityWithName(string name)
        {
            page.FillIn(searchInput, name);
            page.Click(searchButton);

            By customerNameLink = By.XPath("//a[contains(@title,'" + name + "')]");
            return page.IsDisplayed(customerNameLink);
        }


        /// <summary> 
        /// Use quick search functionality to find the opportuntity and open it
        /// <param name="customerName"/> the text to search for (full name is prefered) </param>
        /// <summary>
        public void OpenOpportunity(string customerName)
        {
            page.FillIn(searchInput, customerName);
            page.Click(searchButton);

            By customerNameLink = By.XPath("//a[contains(@title,'" + customerName + "')]");
            page.Click(customerNameLink);
        }


    }
}