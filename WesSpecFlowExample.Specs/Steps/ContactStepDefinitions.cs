using TechTalk.SpecFlow;
using WesSpecFlowExample.Drivers;
using WesSpecFlowExample.Entities;
using WesSpecFlowExample.Pages.Contact;

namespace WesSpecFlowExample.Steps
{
    [Binding]
    class ContactStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private ContactRecordPage contactRecordPage;

        public ContactStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            contactRecordPage = new ContactRecordPage(browserDriver.Current);

        }

        [Given(@"I add a contact with segment (.*)")]
        public void AddAContactWithSegment(string segment)
        {
            Contact contact = new ContactBuilder().BuildJaneDoe();
            contact.Segment = segment;
            scenarioContext.Set(contact, "contact");

            contactRecordPage.To();
            contactRecordPage.SelectContactType(contact.ContactType);
            contactRecordPage.OpenCustomerSummaryTab();
            contactRecordPage.SetSegment(contact.Segment);
            contactRecordPage.OpenPersonalDetailsTab();
            contactRecordPage.SetLastName(contact.LastName);
            contactRecordPage.OpenContactDetailsTab();
            contactRecordPage.SetMobilePhoneNumber(contact.MobileNumber);
            contactRecordPage.SetPreferedAddress(contact.AddressType, contact.Address, contact.PostCode);
            contactRecordPage.SaveContact();
        }
    }
}
