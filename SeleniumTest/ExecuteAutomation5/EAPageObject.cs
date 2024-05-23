using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

// In order to use POM, we need to install the DotNetSeleniumExtras.PageObjects.Core NuGet package
// This package provides the PageFactory class, which is used to initialize elements of a page object
// The PageFactory class is now part of the SeleniumExtras.PageObjects namespace (see the reference above)

namespace ExecuteAutomation5
{
    public class EAPageObject
    {
        // Initialize the page object
        public EAPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement txtFirstname { get; set; }

        [FindsBy(How = How.Id, Using = "surname")]
        public IWebElement txtSurnname { get; set; }

        [FindsBy(How = How.Id, Using = "age")]
        public IWebElement intAge { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement ddlCountry { get; set; }

        [FindsBy(How = How.Id, Using = "notes")]
        public IWebElement txtNotes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        public IWebElement btnSubmit { get; set; }

        public void FillUserForm(string firstName, string surName, string age, string country, string notes)
        {
            // Fill the form
            txtFirstname.SendKeys(firstName);
            txtSurnname.SendKeys(surName);
            intAge.SendKeys(age);
            ddlCountry.SendKeys(country);
            txtNotes.SendKeys(notes);
            btnSubmit.Submit();
        }
    }


}
