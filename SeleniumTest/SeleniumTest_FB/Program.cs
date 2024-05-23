using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

partial class Test
{
    // Create a new instance of the Chrome driver
    IWebDriver driver = new ChromeDriver();
    
    [SetUp]
    public void Initialize()
    {
        // Navigate to URL
        driver.Navigate().GoToUrl("https://www.facebook.com/");
        Console.WriteLine("Opened URL \n");
        Thread.Sleep(1000);
        // Maximize the browser window
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);
    }

    [Test]
    public void ExecuteTest()
    {
        // Identify the username text box
        IWebElement element = driver.FindElement(By.Id("email"));
        // Enter the username value  
        element.SendKeys("tibor.weigand@gmail.com");
        Thread.Sleep(1000);
        Console.Write("username value is entered \n");

        // Identify the password text box
        IWebElement element1 = driver.FindElement(By.Name("pass"));
        //enter the password value  
        element1.SendKeys("*********");
        Console.Write("password is entered \n");
        Thread.Sleep(1000);

        // Click on the Log in button
        IWebElement element2 = driver.FindElement(By.Name("login"));
        element2.Click();
        Thread.Sleep(1000);
        Console.Write("login button is clicked \n");
    }

    [TearDown]
    public void EndTest()
    {
        // Close the browser
        driver.Close();
        Console.WriteLine("Test case closed!");
    }
}