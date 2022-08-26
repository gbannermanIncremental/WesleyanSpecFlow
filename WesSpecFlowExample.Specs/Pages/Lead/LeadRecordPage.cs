using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WesSpecFlowExample.Drivers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WesSpecFlowExample.Pages.Lead
{
    public class LeadRecordPage
    {
        private Page page;

        public LeadRecordPage(IWebDriver driver)
        {
            page = new Page(driver);
        }

        // Element locators
        private By customerInput = By.XPath("//input[contains(@id, 'customerid_0_textInputBox_with_filter_new')]");
        private By lastNameInput = By.XPath("//input[contains(@id, 'lastname.fieldControl-text-box-text')]");
        private By mobilePhoneInput = By.XPath("//input[contains(@id,'mobilephone.fieldControl-phone-text-input')]");
        private By saveButton = By.XPath("//button[contains(@id, 'SavePrimary')]");
        private By qualifyButton = By.XPath("//button[contains(@id, 'qualifylead')]");
        private By contactInfoSection = By.XPath("//section[contains(@data-id, 'summary_section_contact')]");
        private By phoneSection = By.XPath("//section[contains(@data-id, 'summary_section_phone')]");
        private By emailSection = By.XPath("//section[contains(@data-id, 'summary_section_email')]");
        private By OpportunityTypeSelect = By.XPath("//select[contains(@id, 'wes_opportunitytype.fieldControl-option-set-select')]");


        /// <summary> navigates to the new lead form url <summary>
        public void To()
        {
            page.To(Url.QaEnvironment + Url.LeadRecordPage);
        }

        /// <summary> 
        /// Save data for the 2 required fields for the lead form 
        /// </summary>
        public void SaveLeadWithMinimalData(string lastName, string mobileNumber)
        {
            page.FillIn(lastNameInput, lastName);
            page.FillIn(mobilePhoneInput, mobileNumber);
            SaveLead();
        }

        public void SaveLeadForExistingCustomer(string name)
        {
            page.FillIn(customerInput, name);
            By typeAheadSearchResult = By.XPath("//li[contains(@aria-label, '" + name + "')]");
            page.Click(typeAheadSearchResult);
            SaveLead();
        }

        // TODO fix me string to index conversion
        public void SetOpportunityType(string option)
        {
            page.Select(OpportunityTypeSelect, 2);
        }

        public void SaveLead()
        {
            page.Click(saveButton);
        }

        public void QualifyLead()
        {
            page.Click(qualifyButton);
        }

        /// <summary> 
        /// <returns>true</returns> when each section is displayed </summary>
        public bool IsFormSectionsDisplayed()
        {
            var isContactDisplayed = page.IsDisplayed(contactInfoSection);
            var isPhoneDisplayed = page.IsDisplayed(phoneSection);
            var isEmailDisplayed = page.IsDisplayed(emailSection);

            return isContactDisplayed && isPhoneDisplayed && isEmailDisplayed;
        }
    }
}