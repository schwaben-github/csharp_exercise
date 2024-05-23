using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation2
{
    internal class SeleniumGetMethod
    {
        public static string GetText(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "id")
            {
                return driver.FindElement(By.Id(element)).GetAttribute("value");
            }
            if (elementtype == "name")
            {
                return driver.FindElement(By.Name(element)).GetAttribute("value");
            }
            else return String.Empty;
        }

        // Getting text from drop down list works for me with the above method!
        /*public static string GetTextFromDDL(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "id")
            {
                return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            }
            if (elementtype == "name")
            {
                return new SelectElement(driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            }
            else return String.Empty;
        }*/
    }
}
