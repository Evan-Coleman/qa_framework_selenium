using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

// Note: Addresses tab hasn't been implemented
namespace GWRepository.PageObjects.PC
{
    public class CreateAccountPage : PageBase
    {
        public CreateAccountPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        // TOP NAVIGATION SECTION
        public IWebElement btnUpdate => _webDriver.FindElementByCssSelector("span[id*=ForceDupCheckUpdate][class*=wrap]");
        public IWebElement btnCancel => _webDriver.FindElementByCssSelector("span[id*=Cancel-btnInner]");
        public IWebElement btnCheckForDuplicates => _webDriver.FindElementByCssSelector("span[id*=CheckForDuplicates][class*=wrap]");

        // ACCOUNT INFO SECTION
        public IWebElement selAgentNumber => _webDriver.FindElementByCssSelector("table[id*=ProducerCode-triggerWrap][class*=wrap]"); // *

        // TAB SECTION
        public IWebElement btnTabBasics => _webDriver.FindElementByCssSelector("a[id*=BasicsTabTab]");
        public IWebElement btnTabAddresses => _webDriver.FindElementByCssSelector("a[id*=AddressTabTab]");

        // PERSON SECTION
        public IWebElement txtFirstName => _webDriver.FindElementByCssSelector("input[id*=FirstName]"); // *
        public IWebElement txtMiddleName => _webDriver.FindElementByCssSelector("input[id*=MiddleName]");
        public IWebElement txtLastName => _webDriver.FindElementByCssSelector("input[id*=':LastName']"); // *
        public IWebElement selSuffix => _webDriver.FindElementByCssSelector("");
        public IWebElement txtFormerName => _webDriver.FindElementByCssSelector("input[id*='FormerLastName']");
        public IWebElement txtAlternateName => _webDriver.FindElementByCssSelector("input[id*='AlternateName']");
        public IWebElement txtSSN => _webDriver.FindElementByCssSelector("input[id*='SSN']");
        public IWebElement txtTIN => _webDriver.FindElementByCssSelector("input[id*='TIN']");
        public IWebElement txtAlternateID => _webDriver.FindElementByCssSelector("input[id*='Input-input']");
        public IWebElement txtDateOfBirth => _webDriver.FindElementByCssSelector("input[id*='DateOfBirth']"); // *
        public IWebElement selGender => _webDriver.FindElementByCssSelector("input[id*='Gender']");

        // EMAIL SECTION
        public IWebElement txtMainEmail => _webDriver.FindElementByCssSelector("input[id*='EmailAddress1']");
        public IWebElement txtAlternateEmail => _webDriver.FindElementByCssSelector("input[id*='EmailAddress2']");
        
        // PRIMARY ADDRESS SECTION
        public IWebElement txtOfficeNumber => _webDriver.FindElementByCssSelector("input[id*='OfficeNumber']");
        public IWebElement selCountry => _webDriver.FindElementByCssSelector("input[id*='Country']"); // *
        public IWebElement txtAddressOne => _webDriver.FindElementByCssSelector("input[id*='AddressLine1']"); // *
        public IWebElement txtAddressTwo => _webDriver.FindElementByCssSelector("input[id*='AddressLine2']");
        public IWebElement txtCity => _webDriver.FindElementByCssSelector("input[id*='City']"); // *
        public IWebElement txtCounty => _webDriver.FindElementByCssSelector("input[id*='County']");
        public IWebElement selState => _webDriver.FindElementByCssSelector("input[id*='State']"); // *
        public IWebElement txtPostalCode => _webDriver.FindElementByCssSelector("input[id*='PostalCode']"); // *
        public IWebElement selAddressType => _webDriver.FindElementByCssSelector("input[id*='AddressType']"); // *
        public IWebElement txtAddressDescription => _webDriver.FindElementByCssSelector("input[id*='Description']");
        
        // PHONE NUMBERS SECTION
        public IWebElement txtBusinessNumber => _webDriver.FindElementByCssSelector("input[id*='BusinessPhone']");
        public IWebElement txtWorkNumber => _webDriver.FindElementByCssSelector("input[id*='WorkPhone']");
        public IWebElement txtHomeNumber => _webDriver.FindElementByCssSelector("input[id*='HomePhone']");
        public IWebElement txtMobileNumber => _webDriver.FindElementByCssSelector("input[id*='MobilePhone']");
        public IWebElement txtFaxNumber => _webDriver.FindElementByCssSelector("input[id*='FaxPhone']");
        public IWebElement selPrimaryPhone => _webDriver.FindElementByCssSelector("input[id*='primaryPhone']");
        public IWebElement txtSpeedDial => _webDriver.FindElementByCssSelector("input[id*='SpeedDial']");
        #endregion

        #region Page Methods
        // TOP NAVIGATION SECTION
        public bool ClickUpdate()
        {
            return sClick(btnUpdate);
        }
        public bool ClickCancel()
        {
            return sClick(btnCancel);
        }
        public bool ClickCheckForDuplicates()
        {
            return sClick(btnCheckForDuplicates);
        }

        // ACCOUNT INFO SECTION
        public bool SelectAgentNumber(string agent)
        {
            return sSelectorSelect(selAgentNumber, agent);         
        }

        // TAB SECTION
        public bool ClickBasicsTab()
        {
            return sClick(btnTabBasics);
        }
        public bool ClickAddressesTab()
        {
            return sClick(btnTabAddresses);
        }

        // PERSON SECTION
        public bool SetFirstName(string firstName)
        {
            return sSendKeys(txtFirstName, firstName);
        }
        public bool SetMiddleName(string middleName)
        {
            return sSendKeys(txtMiddleName, middleName);
        }
        public bool SetLastName(string lastName)
        {
            return sSendKeys(txtLastName, lastName);
        }
        public bool SetSuffix(string suffix)
        {
            return sSendKeys(selSuffix, suffix);
        }
        public bool SetFormerName(string formerName)
        {
            return sSendKeys(txtFormerName, formerName);
        }
        public bool SetSSN(string SSN)
        {
            return sSendKeys(txtSSN, SSN);
        }
        public bool SetTIN(string TIN)
        {
            return sSendKeys(txtTIN, TIN);
        }
        public bool SetAlternateID(string alternateID)
        {
            return sSendKeys(txtAlternateID, alternateID);
        }
        public bool SetDateOfBirth(string dateOfBirth)
        {
            return sSendKeys(txtDateOfBirth, dateOfBirth);
        }
        public bool SelectGender(string gender)
        {
            return sSelectorSelect(selGender, gender);
        }

        // EMAIL SECTION
        public bool SetMainEmail(string mainEmail)
        {
            return sSendKeys(txtMainEmail, mainEmail);
        }
        public bool SetAlternateEmail(string alternateEmail)
        {
            return sSendKeys(txtAlternateEmail, alternateEmail);

        }

        // PRIMARY ADDRESS SECTION
        public bool SetOfficeNumber(string OfficeNumber)
        {
            return sSendKeys(txtOfficeNumber, OfficeNumber);
        }
        public bool Selectcountry(string contry)
        {
            return sSelectorSelect(selCountry, contry);
        }
        public bool SetAddressOne(string addressOne)
        {
            return sSendKeys(txtAddressOne, addressOne);
        }
        public bool SetAddressTwo(string addressTwo)
        {
            return sSendKeys(txtAddressTwo, addressTwo);
        }
        public bool SetCity(string city)
        {
            return sSendKeys(txtCity, city);
        }
        public bool SetCounty(string county)
        {
            return sSendKeys(txtCounty, county);
        }
        public bool SelectState(string state)
        {
            return sSelectorSelect(selState, state);
        }
        public bool SetPostalCode(string postalCode)
        {
            return sSendKeys(txtPostalCode, postalCode);
        }
        public bool SelectAddressType(string addressType)
        {
            return sSelectorSelect(selAddressType, addressType);
        }
        public bool SetAddressDescription(string addressDescription)
        {
            return sSendKeys(txtAddressDescription, addressDescription);
        }

        // PHONE NUMBERS SECTION
        public bool SetBusinessPhoneNumber(string businessPhoneNumber)
        {
            return sSendKeys(txtBusinessNumber, businessPhoneNumber);
        }
        public bool SetWorkPhoneNumber(string workPhoneNumber)
        {
            return sSendKeys(txtWorkNumber, workPhoneNumber);
        }
        public bool SetHomePhoneNumber(string homePhoneNumber)
        {
            return sSendKeys(txtHomeNumber, homePhoneNumber);
        }
        public bool SetMobilePhoneNumber(string mobilePhoneNumber)
        {
            return sSendKeys(txtMobileNumber, mobilePhoneNumber);
        }
        public bool SetFaxPhoneNumber(string faxPhoneNumber)
        {
            return sSendKeys(txtFaxNumber, faxPhoneNumber);
        }
        public bool SelectPrimaryPhoneNumber(string primaryPhoneNumber)
        {
            return sSelectorSelect(selPrimaryPhone, primaryPhoneNumber);
        }
        public bool SetSpeedDial(string speedDial)
        {
            return sSendKeys(txtSpeedDial, speedDial);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Create Account");
        }
        #endregion
    }
}
