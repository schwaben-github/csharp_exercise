using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation3_1
{
    internal class SeleniumGetSetMethods
    {
        // Set text methods
        // EnterText method
        public static void EnterText(string element, string value, PropertyType elementType)
        {
            if (elementType == PropertyType.Id)
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementType == PropertyType.Name)
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
        }

        // Click method
        public static void Click(string element, PropertyType elementType)
        {
            By byElement = null;

            switch (elementType)
            {
                case PropertyType.Id:
                    byElement = By.Id(element);
                    break;
                case PropertyType.Name:
                    byElement = By.Name(element);
                    break;
                case PropertyType.CssSelector:
                    byElement = By.CssSelector(element);
                    break;
                case PropertyType.XPath:
                    byElement = By.XPath(element);
                    break;
                case PropertyType.ClassName:
                    byElement = By.ClassName(element);
                    break;
                case PropertyType.TagName:
                    byElement = By.TagName(element);
                    break;
                case PropertyType.LinkText:
                    byElement = By.LinkText(element);
                    break;
                case PropertyType.PartialLinkText:
                    byElement = By.PartialLinkText(element);
                    break;
            }

            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byElement));
            webElement.Click();
        }

        // SelectDropDown method
        public static void SelectDropDown(string element, string value, PropertyType elementType)
        {
            if (elementType == PropertyType.Id)
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementType == PropertyType.Name)
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
        }


        // Get text method
        public static string GetText(string element, PropertyType elementType)
        {
            if (elementType == PropertyType.Id)
            {
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            }
            if (elementType == PropertyType.Name)
            {
                return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            }
            else return String.Empty;
        }
    }
}
