using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class MatchingContactsPage : PageBase
    {
        public MatchingContactsPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement divTableDuplicatecontacts => _webDriver.FindElementByCssSelector("div[id*='DuplicateContactsScreen:ResultsLV'][class*='x-panel-default x-grid']");
        public IWebElement btnReturnToCreateAccount => _webDriver.FindElementByXPath("//a[contains(text(),'Return to Create Account')]");
        #endregion

        #region Page Methods
        public bool ClickReturnToCreateAccount()
        {
            return sClick(btnReturnToCreateAccount);
        }

        public bool ClickFirstDuplicateContact()
        {
            return sClick(_webDriver.FindElementByCssSelector("a[id *= 'ResultsLV:0:SelectBtn']"));
        }

        // TODO: This should really be pulled out & finished to be put in a TableUtilities class
        public List<Duplicatecontact> GetAllDuplicateContacts()
        {
            int i = 0;
            IWebElement element;
            List<Duplicatecontact> duplicateContacts = new List<Duplicatecontact>();
            while (true)
            {
                element = _webDriver.FindElementByCssSelector("a[id *= 'ResultsLV:'" + i + "':SelectBtn']");
                if (element.Displayed)
                {
                    // This selector will get everything in the row based on the index []
                    //a[contains(@id, 'ResultsLV:0:SelectBtn')]/parent::div/parent::td/following-sibling::*[1]
                }
                else
                {
                    return duplicateContacts;
                }
                i++;
            }
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Matching Contact");
        }
        #endregion

        #region Anonymous ModelClass
        public class Duplicatecontact
        {
            public string FirstName;
            public string MiddleName;
            public string LastName;
            public string AlternateFirstName;
            public string AlternateLastName;
            public string FormerName;
            public string MatchType;
            public string PrimaryAddress;
            public string SSN;
            public string TIN;
            public string PrimaryPhone;
            public string DateOfBirth;
        }
        #endregion
    }
}
