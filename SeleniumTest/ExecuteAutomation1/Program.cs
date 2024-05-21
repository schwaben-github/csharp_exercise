using System;
using System.Threading;
using ExecuteAutomation1;
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
        Thread.Sleep(5000);
        // Maximize the browser window
        driver.Manage().Window.Maximize();
        Thread.Sleep(5000);
    }

    [Test]
    public void ExecuteTest()
    {
        // First name
        SeleniumSetMethod.EnterText(driver, "firstname", "Tibor", "id");
        Console.WriteLine("Entered first name \n");
        Thread.Sleep(2000);

        // Last name
        SeleniumSetMethod.EnterText(driver, "surname", "Weigand", "id");
        Console.WriteLine("Entered last name \n");
        Thread.Sleep(2000);

        // Age
        SeleniumSetMethod.EnterText(driver, "age", "52", "id");
        Console.WriteLine("Entered age \n");
        Thread.Sleep(2000);

        // Country dropdown
        SeleniumSetMethod.SelectDropDown(driver, "country", "Croatia", "id");
        Console.WriteLine("Opened dropdown and country chosen \n");
        Thread.Sleep(2000);

        // Notes
        SeleniumSetMethod.EnterText(driver, "notes", "This is a test", "id");
        Console.WriteLine("Entered a note \n");
        Thread.Sleep(2000);

        // Submit button
        SeleniumSetMethod.Click(driver, "submitbutton", "id");
        Console.WriteLine("Submit button clicked \n");
        Thread.Sleep(2000);
    }

    [TearDown]
    public void CleanUp()
    {
        // Close the browser
        driver.Close();
        Console.WriteLine("Test case closed! \n");
    }
}