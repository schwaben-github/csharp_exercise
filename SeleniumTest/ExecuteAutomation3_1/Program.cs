// Refactoring Custom Methods Revisited
// Strongly typed properties
// The testsite changed in the meantime, so I adjusted the code to CssSelector instead of Id

using System;
using System.Threading;
using ExecuteAutomation3_1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Execute Automation Selenium Test Site not available anymore!
// Instead, we will use the following test site
// https://testpages.eviltester.com/styled/validation/input-validation.html
// Since this site is similar to the Execute Automation site, we can use the same code
// The test will fill out the form on the page and then read the values back

public class Program
{
    [SetUp]
    public void Initialize()
    {
        PropertiesCollection.driver = new ChromeDriver();

        // Navigate to URL
        PropertiesCollection.driver.Navigate().GoToUrl("https://testpages.eviltester.com/styled/validation/input-validation.html");
        Console.WriteLine("\n Opened URL \n");
        Thread.Sleep(1000);
        // Maximize the browser window
        PropertiesCollection.driver.Manage().Window.Maximize();
        Thread.Sleep(1000);
    }

    [Test]
    public void ExecuteTest()
    {
        // First name
        SeleniumGetSetMethods.EnterText("firstname", "Tibor", PropertyType.Id);
        Console.WriteLine("Entered first name \n");
        Thread.Sleep(1000);

        // Last name
        SeleniumGetSetMethods.EnterText("surname", "Weigand", PropertyType.Id);
        Console.WriteLine("Entered last name \n");
        Thread.Sleep(1000);

        // Age
        SeleniumGetSetMethods.EnterText("age", "52", PropertyType.Id);
        Console.WriteLine("Entered age \n");
        Thread.Sleep(1000);

        // Country dropdown
        SeleniumGetSetMethods.SelectDropDown("country", "Croatia", PropertyType.Id);
        Console.WriteLine("Opened dropdown and country chosen \n");
        Thread.Sleep(1000);

        // Notes
        SeleniumGetSetMethods.EnterText("notes", "This is a test", PropertyType.Id);
        Console.WriteLine("Entered a note \n");
        Thread.Sleep(1000);

        // Submit button
        SeleniumGetSetMethods.Click("input[type='submit']", PropertyType.CssSelector);
        Console.WriteLine("Submit button clicked \n");
        Thread.Sleep(1000);

        // Only for troubleshooting purposes:
        // Print the page source to the console, to verify that the page has loaded correctly and that the element is available for interaction:
        // Console.WriteLine(PropertiesCollection.driver.PageSource);


        // First name
        Console.WriteLine("The value from the first name field is: " + SeleniumGetSetMethods.GetText("firstname", PropertyType.Id));
        Thread.Sleep(2000);

        // Last name
        Console.WriteLine("The value from the last name field is: " + SeleniumGetSetMethods.GetText("surname", PropertyType.Id));
        Thread.Sleep(2000);

        // Age
        Console.WriteLine("The value from the age field is: " + SeleniumGetSetMethods.GetText("age", PropertyType.Id));
        Thread.Sleep(2000);

        // Country dropdown
        Console.WriteLine("The value from the country dropdown is: " + SeleniumGetSetMethods.GetText("country", PropertyType.Id));
        Thread.Sleep(2000);

        // Notes
        Console.WriteLine("The note entered is : " + SeleniumGetSetMethods.GetText("notes", PropertyType.Id));
        Thread.Sleep(5000);
    }

    [TearDown]
    public void CleanUp()
    {
        // Close the browser
        PropertiesCollection.driver.Close();
        Console.WriteLine("Test case closed! \n");
    }
}