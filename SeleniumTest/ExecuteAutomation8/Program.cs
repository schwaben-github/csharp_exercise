// Data driven testing in Selenium C#

using System;
using System.Text;
using System.Threading;
using ExecuteAutomation8;
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

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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
        ExcelLib.PopulateInCollection(@"C:\Data.xlsx");

        // Click the link to the input form
        LoginPageObject pageLogin = new LoginPageObject();
        EAPageObject pageEA = pageLogin.ClickInputForm();
        Console.WriteLine("Link on the index page clicked. \n");

        string firstname = ExcelLib.ReadData(1, "firstname");
        string surname = ExcelLib.ReadData(1, "surname");
        string age = ExcelLib.ReadData(1, "age");
        string country = ExcelLib.ReadData(1, "country");
        string notes = ExcelLib.ReadData(1, "notes");

        /*if (firstname == null || surname == null || age == null || country == null || notes == null)
        {
            Assert.Fail("Test data is missing");
        }
        else
        {
            pageEA.FillUserForm(firstname, surname, age, country, notes);
            Console.WriteLine("Form filled. \n");
        }*/

        pageEA.FillUserForm(ExcelLib.ReadData(1, "firstname"), ExcelLib.ReadData(1, "surname"), ExcelLib.ReadData(1, "age"), ExcelLib.ReadData(1, "country"), ExcelLib.ReadData(1, "notes"));
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