using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WesSpecFlowExample.Drivers;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;

namespace WesSpecFlowExample.Pages
{
    public class LoginPage
    {
        private Page page;

        public LoginPage(IWebDriver driver) {
            page = new Page(driver);
        }

        // Element locators
        private By usernameField = By.Name("loginfmt");
        private By usernameNextBtn = By.Id("idSIButton9");
        private By passwordField = By.Id("passwordInput");
        private By passwordSignInBtn = By.Id("submitButton");
        private By staySignedInYesBtn = By.Id("idSIButton9");


        /// <summary> navigates to the new lead form url <summary>
        public void To()
        {
            page.To(Url.QaEnvironment);
        }

        /// <summary> Provide credentials to sign in to the application </summary>
        public void LoginAs(string username, string password)
        {
            page.FillIn(usernameField, username);
            page.Click(usernameNextBtn);
            page.FillIn(passwordField, password);
            page.Click(passwordSignInBtn);
            page.Click(staySignedInYesBtn);
        }

    }
}