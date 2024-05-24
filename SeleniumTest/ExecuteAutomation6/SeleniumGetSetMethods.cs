using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation6
{
    internal class SeleniumGetSetMethods
    {
        // Set text methods
        // EnterText method
        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        // Click method
        public static void Click(IWebElement element)
        {
            element.Click();
        }

        // SelectDropDown method
        public static void SelectDropDown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }


        // Get text method
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        // Get text from dropdown method
        public static string GetTextFromDDL(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}