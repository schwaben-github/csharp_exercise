using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Chrome driver
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(2000);

            // Navigate to URL
            Console.WriteLine("Test case started!");
            driver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(2000);

            // Find the element that's name attribute is q (Google Search Box)
            IWebElement element = driver.FindElement(By.Name("q"));

            // Type something in the search box
            element.SendKeys("blinkenlights wikipedia");
            Thread.Sleep(2000);

            // Identify the Google Search button
            IWebElement element1 = driver.FindElement(By.Name("btnK"));

            // Click the Search button
            element1.Click();
            Thread.Sleep(3000);

            // Close the browser
            driver.Close();
            Console.WriteLine("Test case closed!");
        }
    }
}
