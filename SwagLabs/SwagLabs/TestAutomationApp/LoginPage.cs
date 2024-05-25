using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UsernameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField { get; set; }
        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "h3[data-test='error']")]
        public IWebElement ErrorMessage { get; set; }
        public void EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }
    }

}
