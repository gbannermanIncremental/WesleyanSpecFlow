using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WesSpecFlowExample.Drivers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WesSpecFlowExample.Pages.Contact
{
    class ContactRecordPage
    {

        private Page page;

        public ContactRecordPage(IWebDriver driver)
        {
            page = new Page(driver);
        }

        //Element locators
        private By saveButton = By.XPath("//button[contains(@id, 'SavePrimary')]");
        private By contactTypeSelect = By.XPath("//select[contains(@id, 'wes_contacttype.fieldControl-option-set-select')]");
        private By segmentSelect = By.XPath("//select[contains(@id, 'wes_segment.fieldControl-option-set-select')]");
        private By mailingAddressSelect = By.XPath("//select[contains(@id, 'wes_preferredmailingaddress.fieldControl-option-set-select')]");
        private By phoneNumberSelect = By.XPath("//select[contains(@id, 'wes_preferredphone.fieldControl-option-set-select')]");

        private By mobileNumberInput = By.XPath("//input[contains(@id, 'mobilephone.fieldControl-phone-text-input')]");
        private By lastNameInput = By.XPath("//input[contains(@id, 'lastname.fieldControl-text-box-text')]");
        private By addressLine1Input = By.XPath("//input[contains(@id, 'address1_line1.fieldControl-text-box-text')]");
        private By postCodeInput = By.Id("postcodeTextFieldaddress1_postalcode");

        private By dialogConfirmButton = By.Id("confirmButton");
        private By customerSummaryTab = By.XPath("//li[contains(@data-id, 'tablist-tab_summary')]");
        private By personalDetailsTab = By.XPath("//li[contains(@data-id, 'tablist-tab_personal')]");
        private By contactDetailsTab = By.XPath("//li[contains(@data-id, 'tablist-tab_contact_details')]");


        /// <summary> navigates to the new lead form url <summary>
        public void To()
        {
            page.To(Url.QaEnvironment + Url.ContactRecordPage);
        }

        public void SelectContactType(string option)
        {
            page.Select(contactTypeSelect, option);
            page.Click(dialogConfirmButton);
        }

        public void OpenCustomerSummaryTab()
        {
            page.Click(customerSummaryTab);
        }

        public void OpenPersonalDetailsTab()
        {
            page.Click(personalDetailsTab);
        }

        public void OpenContactDetailsTab()
        {
            page.Click(contactDetailsTab);
        }

        public void SetSegment(string option)
        {
            page.Select(segmentSelect, option);
        }

        public void SetLastName(string text)
        {
            page.FillIn(lastNameInput, text);
        }

        public void SetPreferedAddress(string type, string address, string postCode)
        {
            page.Select(mailingAddressSelect, type);
            page.FillIn(addressLine1Input, address);
            page.FillIn(postCodeInput, postCode);
        }

        public void SetMobilePhoneNumber(string number)
        {
            page.Select(phoneNumberSelect, "Mobile");
            page.FillIn(mobileNumberInput, number);
        }

        public void SaveContact()
        {
            page.Click(saveButton);
        }
    }
}
