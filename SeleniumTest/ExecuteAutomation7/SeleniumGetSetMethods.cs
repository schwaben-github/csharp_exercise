using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation7
{
    public static class SeleniumGetSetMethods
    {
        // Set text methods
        // EnterText method
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        // Click method
        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        // SelectDropDown method
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }


        // Get text method
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        // Get text from dropdown method
        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
