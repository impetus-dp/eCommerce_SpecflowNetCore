using eCommerce_SpecflowNetCore.Hooks;
using eCommerce_SpecflowNetCore.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace eCommerce_SpecflowNetCore.Steps
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver = WebHook.driver;
             LoginPage loginPage = new LoginPage();

        [Given(@"User opens URL ""(.*)""")]
        public void GivenUserOpensURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        [When(@"User enters username: ""(.*)""")]
        public void WhenUserEntersUsername(string username)
        {
            loginPage.SetUserName(username);
           
        }

        [When(@"User enters Password: ""(.*)""")]
        public void WhenUserEntersPassword(string pwd)
        {
            loginPage.SetPassword(pwd);
        }

        [Then(@"Click on login")]
        public void ThenClickOnLogin()
        {
            loginPage.ClickLogin();
        }

        [Then(@"User click on Logout link")]
        public void ThenUserClickOnLogoutLink()
        {
            loginPage.ClickLogout();

        }

    }
    
}
