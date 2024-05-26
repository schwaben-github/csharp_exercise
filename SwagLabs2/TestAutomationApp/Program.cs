using AutomationTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [Test]
        public void VerifyLoginScreenDisplay()
        {
            // Test Case ID: TC001
            // Requirement Mark: 1
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.WriteLine("Test Execution started");
            Assert.That(loginPage.UsernameField.Displayed, Is.True);
            Assert.That(loginPage.PasswordField.Displayed, Is.True);
            Assert.That(loginPage.LoginButton.Displayed, Is.True);
            Console.WriteLine("Test Case TC001 passed");
        }

        [Test]
        public void VerifyUsernameAndPasswordTextboxes()
        {
            // Test Case ID: TC002
            // Requirement Mark: 1.1
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Assert.That(loginPage.UsernameField.Displayed && loginPage.UsernameField.Enabled && string.IsNullOrEmpty(loginPage.UsernameField.GetAttribute("value")), Is.True);
            Assert.That(loginPage.PasswordField.Displayed && loginPage.PasswordField.Enabled && string.IsNullOrEmpty(loginPage.PasswordField.GetAttribute("value")), Is.True);
            Console.WriteLine("Test Case TC002 passed");
        }

        [Test]
        public void VerifyLoginButton()
        {
            // Test Case ID: TC003
            // Requirement Mark: 1.2
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Assert.That(loginPage.LoginButton.Displayed && loginPage.LoginButton.Enabled);
            Console.WriteLine("Test Case TC003 passed");
        }

        [Test]
        public void VerifyErrorMessageForInvalidCredentials()
        {
            // Test Case ID: TC004
            // Requirement Mark: 1.3
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.EnterUsername("invalid_user");
            loginPage.EnterPassword("invalid_pass");
            loginPage.ClickLogin();
            Assert.That(loginPage.ErrorMessage.Displayed, Is.True);
            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Console.WriteLine("Test Case TC004 passed");
        }

        [Test]
        public void VerifyWebShopTestPageLoadedAfterLogin()
        {
            // Test Case ID: TC005
            // Requirement Mark: 1.4
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");
            loginPage.ClickLogin();
            Assert.That(inventoryPage.IsPageLoaded(), Is.True);
            Console.WriteLine("Test Case TC005 passed");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            Console.WriteLine("Test Execution Completed");
        }
    }
}