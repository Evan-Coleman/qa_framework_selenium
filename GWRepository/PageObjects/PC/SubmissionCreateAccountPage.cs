using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class SubmissionCreateAccountPage : PageBase
    {
        public SubmissionCreateAccountPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement selType => _webDriver.FindElementByCssSelector("input[id*='ContactSubtype'][role='combobox'][type='text']");
        public IWebElement selTypeCompany => _webDriver.FindElementByXPath("//li[.='Company']");
        public IWebElement selTypePerson => _webDriver.FindElementByXPath("//li[.='Person']");

        public IWebElement txtCompanyAndLastName => _webDriver.FindElementByCssSelector("input[id*='Keyword'][type='text'][role='textbox']");
        public IWebElement txtFirstName => _webDriver.FindElementByCssSelector("input[id*=FirstName][role=textbox][name*=FirstName]");
        public IWebElement txtMiddleName => _webDriver.FindElementByCssSelector("input[id*=MiddleName][role=textbox][name*=MiddleName]");
        public IWebElement txtFormerName => _webDriver.FindElementByCssSelector("input[id*=FormerName][role=textbox][name*=FormerName]");
        public IWebElement txtAlternateName => _webDriver.FindElementByCssSelector("input[id*=AlternateName][role=textbox][name*=AlternateName]");

        public IWebElement selSSNTIN=> _webDriver.FindElementByCssSelector("input[id*=TaxReporting][type=text][role=combobox]");
        public IWebElement selSSN => _webDriver.FindElementByXPath("//li[.=Social Security Number]");
        public IWebElement txtSSN => _webDriver.FindElementByCssSelector("input[id$=SSN-inputEl][role=textbox]");
        public IWebElement selTIN => _webDriver.FindElementByXPath("//li[.='Tax ID Number']");
        public IWebElement txtTIN => _webDriver.FindElementByCssSelector("input[id$=TIN-inputEl][role=textbox]");

        public IWebElement selCountry => _webDriver.FindElementByCssSelector("input[id*='Country'][type='text'][role='combobox']");
        public IWebElement txtCity => _webDriver.FindElementByCssSelector("input[id*='City'][type='text'][role='combobox']");
        public IWebElement txtCounty => _webDriver.FindElementByCssSelector("input[id*='County'][type='text'][role='combobox']");
        public IWebElement selState => _webDriver.FindElementByCssSelector("input[id*='State'][type='text'][role='combobox']");
        public IWebElement txtPostalCode => _webDriver.FindElementByCssSelector("input[id*='PostalCode'][type='text'][role='combobox']");

        public IWebElement btnSearch => _webDriver.FindElementByCssSelector("a[id$='Set:Search'][class='bigButton']");
        public IWebElement btnReset => _webDriver.FindElementByCssSelector("a[id$='Set:Reset'][class='bigButton']");

        public IWebElement btnCreateNew => _webDriver.FindElementByCssSelector("a[class*=btn][id*=NewAccountButton]");
        public IWebElement btnCreateNewCompany => _webDriver.FindElementByCssSelector("span[id*=NewAccount_Company][class*=item-text]");
        public IWebElement btnCreateNewPerson => _webDriver.FindElementByCssSelector("span[id*=NewAccount_Person][class*=item-text]");

        public IWebElement divTableContacts => _webDriver.FindElementByCssSelector("div[id='FBNewSubmission:ContactSearchScreen:ContactSearchLV_FBMPanelSet_ref'][class*=container]");
        #endregion

        #region Page Methods
        public bool searchSelectCompany()
        {
            if (sClick(selType))
                return sClick(selTypeCompany);
            return false;
        }

        public bool searchSelectPerson()
        {
            if (sClick(selType))
                return sClick(selTypePerson);
            return false;
        }

        public bool FillOutComapnyAndLastName(string name)
        {
            return sSendKeys(txtCompanyAndLastName, name);
        }

        public bool FillOutFirstName(string name)
        {
            return sSendKeys(txtFirstName, name);
        }

        public bool FillOutMiddleName(string name)
        {
            return sSendKeys(txtMiddleName, name);
        }

        public bool FillOutFormerName(string name)
        {
            return sSendKeys(txtFormerName, name);
        }

        public bool FillOutAlternateName(string name)
        {
            return sSendKeys(txtAlternateName, name);
        }

        public bool SetSSN(string ssn)
        {
            if (sClick(selSSNTIN))
                if (sClick(selSSN))
                    return sSendKeys(txtSSN, ssn);
            return false;
        }

        public bool SetTIN(string tin)
        {
            if (sClick(selSSNTIN))
                if (sClick(selTIN))
                    return sSendKeys(txtTIN, tin);
            return false;
        }

        public bool SelectCountry(string country)
        {
            return sSelectorSelect(selCountry, country);
        }

        public bool FillOutCity(string city)
        {
            return sSendKeys(txtCity, city);
        }

        public bool FillOutCounty(string county)
        {
            return sSendKeys(txtCounty, county);
        }

        public bool SelectState(string state)
        {
            return sSelectorSelect(selState, state);
        }

        public bool FillOutPostalCode(string postalCode)
        {
            return sSendKeys(txtPostalCode, postalCode);
        }

        public bool ClickSearch()
        {
            return sClick(btnSearch);
        }

        public bool ClickReset()
        {
            return sClick(btnReset);
        }

        public bool ClickCreateNewCompany()
        {
            if (sClick(btnCreateNew))
                return sClick(btnCreateNewCompany);
            return false;
        }

        public bool ClickCreateNewPerson()
        {
            if (sClick(btnCreateNew))
                return sClick(btnCreateNewPerson);
            return false;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("New Submissions");
        }
        #endregion
    }
}
