using GWRepository.BaseObjects;
using GWRepository.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class LocationInformationPage : PageBase
    {
        public LocationInformationPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement labelTitleBar => _webDriver.FindElementByXPath("//span[contains(@class, 'title')][contains(text(), 'Location Information')]");

        public IWebElement btnOk => _webDriver.FindElementByCssSelector("span[id*='Update-btnWrap']");
        public IWebElement btnCancel => _webDriver.FindElementByCssSelector("span[id*='ToolbarButton-btnWrap']");

        public IWebElement txtLocationName => _webDriver.FindElementByCssSelector("input[id*='locationName']");
        public IWebElement selLocationType => _webDriver.FindElementByCssSelector("input[id*='LocationType']");
        public IWebElement selLocationAddress => _webDriver.FindElementByCssSelector("input[id*='SelectedAddress']");
        public IWebElement txtAddressLineOne => _webDriver.FindElementByCssSelector("input[id*='AddressLine1']");
        public IWebElement txtAddressLineTwo => _webDriver.FindElementByCssSelector("input[id*='AddressLine2']");
        public IWebElement txtCity => _webDriver.FindElementByCssSelector("input[id*='City']");
        public IWebElement txtPostalCode => _webDriver.FindElementByCssSelector("input[id*='PostalCode']");
        public IWebElement selCounty => _webDriver.FindElementByCssSelector("input[id*='County']");
        public IWebElement btnStandardizeAddress => _webDriver.FindElementByCssSelector("span[id*='StandardizeAddress-btnWrap']");
        public IWebElement txtAcres => _webDriver.FindElementByCssSelector("input[id*='acres']");
        public IWebElement txtNumberOfResidence => _webDriver.FindElementByCssSelector("input[id*='NumberOfResidence']");
        #endregion

        #region Page Methods
        public bool FillLocationDetails(LocationSquireEntity location)
        {
            if (!IsAt())
                return false;
            sSendKeys(txtLocationName, location.LocationName);
            sSendKeys(txtAddressLineOne, location.Address.AddressOne);
            sSendKeys(txtPostalCode, location.Address.PostalCode);
            sSendKeys(txtCity, location.Address.City);
            sSendKeys(txtAcres, location.Acres);
            sSendKeys(txtNumberOfResidence, location.NumberOfResidence);
            sClick(btnStandardizeAddress);
            return sClick(btnOk);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            try
            {
                return labelTitleBar.Displayed;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
        }
        #endregion
    }
}
