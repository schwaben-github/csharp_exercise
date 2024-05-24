using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation7
{
    public class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "inputvalidation")]
        public IWebElement linkInputForm { get; set; }

        public EAPageObject ClickInputForm()
        {
            // Click the link
            linkInputForm.Click();

            // Return the page object
            return new EAPageObject();
        }
    }
}