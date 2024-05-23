using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // In order to follow the execution in the browser, there are sleep commands added!

            // Create a new instance of the Chrome driver
            Console.WriteLine("Test case started! \n");
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);

            // Navigate to URL
            driver.Navigate().GoToUrl("https://www.google.com/");
            Console.WriteLine("\n Opened URL \n");
            Thread.Sleep(1000);
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            // Find the element that's name attribute is q (Google Search Box)
            IWebElement element = driver.FindElement(By.Name("q"));

            // Type something in the search box
            element.SendKeys("blinkenlights wikipedia");
            Console.WriteLine("Entered text \n");
            Thread.Sleep(1000);

            // Identify the Google Search button
            IWebElement element1 = driver.FindElement(By.Name("btnK"));
            

            // Click the Search button
            element1.Click();
            Console.WriteLine("Button found and clicked \n");
            Thread.Sleep(1000);

            // Close the browser
            // Optionally, it can be closed by the test case
            driver.Close();
            Console.WriteLine("Test case closed!");
        }
    }
}
