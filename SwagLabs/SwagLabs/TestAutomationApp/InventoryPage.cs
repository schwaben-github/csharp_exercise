using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects
{
    public class InventoryPage
    {
        private IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "inventory_container")]
        public IWebElement InventoryContainer { get; set; }

        public bool IsPageLoaded()
        {
            return InventoryContainer.Displayed;
        }
    }
}