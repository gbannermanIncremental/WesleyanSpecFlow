using OpenQA.Selenium;
using WesSpecFlowExample.Drivers;



namespace WesSpecFlowExample.Pages.Lead
{
    public class LeadViewsPage
    {
        private Page page;

        public LeadViewsPage(IWebDriver driver)
        {
            page = new Page(driver);
        }

        // Element locators
        private By searchInput = By.XPath("//input[contains(@id,'quickFind_text')]");
        private By searchButton = By.XPath("//button[contains(@id,'quickFind_button')]");
        private By newLeadRecordButton = By.XPath("//button[contains(@id,'lead') and contains(@id, 'NewRecordFromGrid')]");


        public void To()
        {
            page.To(Url.QaEnvironment + Url.LeadViewsPage);
        }

        public void OpenNewLeadForm()
        {
            page.Click(newLeadRecordButton);
        }

        public bool CanSearchForLeadWithName(string name)
        {
            page.FillIn(searchInput, name);
            page.Click(searchButton);
            By subjectLabel = By.XPath("//label[contains(@title,'" + name + "')]");
            return page.IsDisplayed(subjectLabel);
        }
    }
}