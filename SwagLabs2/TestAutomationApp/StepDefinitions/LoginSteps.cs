using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AutomationTests.PageObjects;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        [BeforeScenario]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");
            loginPage.ClickLogin();
        }

        [When(@"the user enters invalid credentials")]
        public void WhenTheUserEntersInvalidCredentials()
        {
            loginPage.EnterUsername("invalid_user");
            loginPage.EnterPassword("invalid_pass");
            loginPage.ClickLogin();
        }

        [Then(@"the user is redirected to the dashboard")]
        public void ThenTheUserIsRedirectedToTheDashboard()
        {
            Assert.That(inventoryPage.IsPageLoaded());
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            Assert.That(loginPage.ErrorMessage.Displayed);
            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [Given(@"the user navigates to the application URL")]
        public void GivenTheUserNavigatesToTheApplicationURL()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Then(@"the login screen should be displayed")]
        public void ThenTheLoginScreenShouldBeDisplayed()
        {
            Assert.That(loginPage.UsernameField.Displayed);
            Assert.That(loginPage.PasswordField.Displayed);
            Assert.That(loginPage.LoginButton.Displayed);
        }

        [Then(@"the username and password textboxes should be enabled and empty")]
        public void ThenTheUsernameAndPasswordTextboxesShouldBeEnabledAndEmpty()
        {
            Assert.That(loginPage.UsernameField.Enabled && string.IsNullOrEmpty(loginPage.UsernameField.GetAttribute("value")));
            Assert.That(loginPage.PasswordField.Enabled && string.IsNullOrEmpty(loginPage.PasswordField.GetAttribute("value")));
        }

        [Then(@"the login button should be enabled")]
        public void ThenTheLoginButtonShouldBeEnabled()
        {
            Assert.That(loginPage.LoginButton.Enabled);
        }

        [Then(@"the web shop test page should be loaded")]
        public void ThenTheWebShopTestPageShouldBeLoaded()
        {
            Assert.That(inventoryPage.IsPageLoaded());
        }
    }
}
