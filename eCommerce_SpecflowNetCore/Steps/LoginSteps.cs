


using eCommerce_SpecflowNetCore.Hooks;
using eCommerce_SpecflowNetCore.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;

namespace eCommerce_SpecflowNetCore.Steps
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver = WebHook.driver;
            LoginPage loginPage = new LoginPage();


        // static IWebDriver driver = new ChromeDriver(); // = WebHook.driver;
        // LoginPage loginPage = new LoginPage(driver);

        //LoginPage loginPage = null;

        [Given(@"User opens URL ""(.*)""")]
        public void GivenUserOpensURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(400);
        }


        [When(@"User enters username: ""(.*)""")]
        public void WhenUserEntersUsername(string username)
        {
            loginPage.SetUserName(username);
            Thread.Sleep(400);
            
        }

        [When(@"User enters Password: ""(.*)""")]
        public void WhenUserEntersPassword(string pwd)
        {
            loginPage.SetPassword(pwd);
            Thread.Sleep(400);

        }

        [Then(@"Click on login")]
        public void ThenClickOnLogin()
        {
            loginPage.ClickLogin();
            Thread.Sleep(1000);

        }

        [Then(@"User click on Logout link")]
        public void ThenUserClickOnLogoutLink()
        {
            loginPage.ClickLogout();
            Thread.Sleep(400);

        }

    }
    
}
