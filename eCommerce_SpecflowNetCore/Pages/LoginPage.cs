using eCommerce_SpecflowNetCore.Hooks;
using OpenQA.Selenium;


namespace eCommerce_SpecflowNetCore.Pages
{
    public class LoginPage
    {
        public IWebDriver driver;

        public LoginPage()
        {
            driver = WebHook.driver;
        }

    
        public IWebElement txtEmail => driver.FindElement(By.Id("Email"));
        public IWebElement txtPassword => driver.FindElement(By.Id("Password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[normalize-space()='Log in']"));
        public IWebElement lnkLogout => driver.FindElement(By.XPath("//*[@id=\"navbarText\"]/ul/li[3]/a"));

        public void SetUserName(string username)
        {
            txtEmail.Clear();
            txtEmail.SendKeys(username);
        }
        public void SetPassword(string pwd)
        {
            txtPassword.Clear();
            txtPassword.SendKeys(pwd);
        }

        public void ClickLogin()
        {
            LoginBtn.Click();
        }

        public void ClickLogout()
        {
            lnkLogout.Click();

        }
    }

}
