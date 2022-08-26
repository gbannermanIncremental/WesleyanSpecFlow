using FluentAssertions;
using TechTalk.SpecFlow;
using WesSpecFlowExample.Drivers;
using WesSpecFlowExample.Entities;
using WesSpecFlowExample.Pages.Opportunity;

namespace WesSpecFlowExample.Steps
{
    [Binding]
    class OpportunityStepDefinitions
    {

        private OpportunityViewsPage opportunityViewsPage;
        private ScenarioContext context;

        public OpportunityStepDefinitions(BrowserDriver browserDriver, ScenarioContext context)
        {
            opportunityViewsPage = new OpportunityViewsPage(browserDriver.Current);
            this.context = context;
        }


        [Then(@"I can find and view the created opportunity")]
        public void ThenICanFindAndViewTheCreatedOpportunity()
        {
            Contact contact = context.Get<Contact>("contact");
            opportunityViewsPage.To();
            opportunityViewsPage.OpenView("Open Opportunities");
            var result = opportunityViewsPage.CanSearchForOpportunityWithName(contact.LastName);
            result.Should().BeTrue();
        }

    }
}
