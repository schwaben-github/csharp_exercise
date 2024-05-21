using OpenQA.Selenium;
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
    }
}
