using System;
using System.Threading;
using ExecuteAutomation2;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Execute Automation Selenium Test Site not available anymore!
// Instead, we will use the following test site
// https://testpages.eviltester.com/styled/validation/input-validation.html
// Since this site is simialr to the Execute Automation site, we can use the same code
// The test will fill out the form on the page

public class Program
{
    // Create a new instance of the Chrome driver
    static IWebDriver driver = new ChromeDriver();

    [SetUp]
    public void Initialize()
    {
        // Navigate to URL
        driver.Navigate().GoToUrl("https://testpages.eviltester.com/styled/validation/input-validation.html");
        Console.WriteLine("\n Opened URL \n");
        Thread.Sleep(1000);
        // Maximize the browser window
        driver.Manage().Window.Maximize();
        // Manully enter the data on the form
        Thread.Sleep(15000);
    }

    [Test]
    public void ExecuteTest()
    {
        // First name
        Console.WriteLine("The value from the first name field is: " + SeleniumGetMethod.GetText(driver, "firstname", "id"));
        Thread.Sleep(2000);

        // Last name
        Console.WriteLine("The value from the last name field is: " + SeleniumGetMethod.GetText(driver, "surname", "id"));
        Thread.Sleep(2000);

        // Age
        Console.WriteLine("The value from the age field is: " + SeleniumGetMethod.GetText(driver, "age", "id"));
        Thread.Sleep(2000);

        // Country dropdown
        Console.WriteLine("The value from the country dropdown is: " + SeleniumGetMethod.GetText(driver, "country", "id"));
        Thread.Sleep(2000);

        // Notes
        Console.WriteLine("The note entered is : " + SeleniumGetMethod.GetText(driver, "notes", "id"));
        Thread.Sleep(5000);
    }

    [TearDown]
    public void CleanUp()
    {
        // Close the browser
        driver.Close();
        Console.WriteLine("Test case closed! \n");
    }
}