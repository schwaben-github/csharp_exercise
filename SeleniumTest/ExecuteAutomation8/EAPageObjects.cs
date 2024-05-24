using OpenQA.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using ExecuteAutomation8;

namespace ExecuteAutomation8
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

            txtFirstname.EnterText(firstName);
            txtSurnname.EnterText(surName);
            intAge.EnterText(age);
            ddlCountry.SelectDropDown(country);
            txtNotes.EnterText(notes);
            btnSubmit.Click();

            /*SeleniumGetSetMethods.EnterText(txtFirstname, firstName);
            SeleniumGetSetMethods.EnterText(txtSurnname, surName);
            SeleniumGetSetMethods.EnterText(intAge, age);
            SeleniumGetSetMethods.EnterText(ddlCountry, country);
            SeleniumGetSetMethods.EnterText(txtNotes, notes);
            SeleniumGetSetMethods.Click(btnSubmit);*/


            /*// Fill the form
            txtFirstname.SendKeys(firstName);
            txtSurnname.SendKeys(surName);
            intAge.SendKeys(age);
            ddlCountry.SendKeys(country);
            txtNotes.SendKeys(notes);
            btnSubmit.Submit();*/
        }
    }
}
