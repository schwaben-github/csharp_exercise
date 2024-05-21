using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    // Create a new instance of the Chrome driver
    static IWebDriver driver = new ChromeDriver();

    [SetUp]
    public void Initialize()
    {
        // Navigate to URL
        driver.Navigate().GoToUrl("https://www.google.com/");
        Console.WriteLine("\n Opened URL \n");
        Thread.Sleep(5000);
        // Maximize the browser window
        driver.Manage().Window.Maximize();
        Thread.Sleep(5000);
    }

    [Test]
    public void ExecuteTest()
    {
        // Find the element that's name attribute is q (Google Search Box)
        IWebElement element = driver.FindElement(By.Name("q"));

        // Type something in the search box
        element.SendKeys("blinkenlights wikipedia");
        Console.WriteLine("Entered text \n");
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