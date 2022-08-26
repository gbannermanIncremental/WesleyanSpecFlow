using TechTalk.SpecFlow;
using WesSpecFlowExample.Drivers;
using WesSpecFlowExample.Pages;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPage loginPage;

        public LoginStepDefinitions(BrowserDriver browserDriver)
        {
            loginPage = new LoginPage(browserDriver.Current);
        }

        [Given("I am logged in with Financial Consultant privileges")]
        public void LoginAsFinancialConsultant()
        {
            loginPage.To();
            loginPage.LoginAs(Credentials.fcUsername, Credentials.fcPassword);
        }

        [Given(@"I am logged in as a SRC user")]
        public void LogInAsSRCUser()
        {
            loginPage.To();
            loginPage.LoginAs(Credentials.srcUsername, Credentials.srcPassword);
        }

    }
}