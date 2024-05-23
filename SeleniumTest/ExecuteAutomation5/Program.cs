// Page Navigation of Page Object Model in Selenium with C#
    
using System;
using System.Threading;
using ExecuteAutomation5;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Execute Automation Selenium Test Site not available anymore!
// Instead, we will use the following test site
// Index: https://testpages.eviltester.com/styled/index.html
// Target: https://testpages.eviltester.com/styled/validation/input-validation.html

public class Program
{
    [SetUp]
    public void Initialize()
    {
        PropertiesCollection.driver = new ChromeDriver();

        // Navigate to URL
        PropertiesCollection.driver.Navigate().GoToUrl("https://testpages.eviltester.com/styled/index.html");
        Console.WriteLine("\n Opened URL. \n");
        Thread.Sleep(1000);
        // Maximize the browser window
        PropertiesCollection.driver.Manage().Window.Maximize();
        Thread.Sleep(1000);
    }

    [Test]
    public void ExecuteTest()
    {
        // Click the link to the input form
        LoginPageObject pageLogin = new LoginPageObject();
        EAPageObject pageEA = pageLogin.ClickInputForm();
        Console.WriteLine("Link on the index page clicked. \n");

        pageEA.FillUserForm("Tibor", "Weigand", "52", "Croatia", "This is a test note!");
        Console.WriteLine("Form filled. \n");
    }

    [TearDown]
    public void CleanUp()
    {
        // Close the browser
        PropertiesCollection.driver.Close();
        Console.WriteLine("Test case closed! \n");
    }
}
