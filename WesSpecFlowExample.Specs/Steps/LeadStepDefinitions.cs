
using TechTalk.SpecFlow;
using WesSpecFlowExample.Drivers;
using WesSpecFlowExample.Entities;
using WesSpecFlowExample.Pages.Lead;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public class LeadStepDefinitions
    {
        private ScenarioContext context;

        private LeadRecordPage leadRecordsPage;
        private LeadViewsPage leadViewsPage;

        public LeadStepDefinitions(BrowserDriver browserDriver, ScenarioContext context)
        {
            this.context = context;
            leadRecordsPage = new LeadRecordPage(browserDriver.Current);
            leadViewsPage = new LeadViewsPage(browserDriver.Current);
        }

        [StepDefinition(@"I open the new lead form")]
        public void GetNewLeadForm()
        {
            leadViewsPage.To();
            leadViewsPage.OpenNewLeadForm();
        }


        [Given(@"I add that contact to a lead")]
        public void AddContactToLead()
        {
            Contact contact = context.Get<Contact>("contact");
            leadRecordsPage.To();
            leadRecordsPage.SaveLeadForExistingCustomer(contact.LastName);
        }


        [When(@"I qualify the lead as an opportunity (.*)")]
        public void WhenIQualifyTheLeadAsAnOpportunity(string opportunityType)
        {
            leadRecordsPage.SetOpportunityType(opportunityType);
            leadRecordsPage.QualifyLead();
        }

        [When(@"I qualify the lead as opportunityType (.*)")]
        public void WhenIQualifyTheLeadAsOpportunityTypeDirect(string opportunityType)
        {
            leadRecordsPage.SetOpportunityType(opportunityType);
            leadRecordsPage.QualifyLead();
        }


        [When("I save a last name (.*) and phone number (.*)")]
        public void WhenISaveAPhoneNumberAndLastName(string lastName, string phoneNumber)
        {
            leadRecordsPage.SaveLeadWithMinimalData(lastName, phoneNumber);
        }


        [Then("I have a new lead record with subject containing (.*)")]
        public bool HasNewLeadRecord(string name)
        {
            leadViewsPage.To();
            return leadViewsPage.CanSearchForLeadWithName(name);

        }

        [Then("I have the new lead form displayed")]
        public bool IsLeadFormDisplayed()
        {
            return leadRecordsPage.IsFormSectionsDisplayed();
        }
    }
}