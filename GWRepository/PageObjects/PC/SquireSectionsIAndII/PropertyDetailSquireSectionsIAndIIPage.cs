
using GWRepository.BaseObjects;
using GWRepository.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class PropertyDetailSquireSectionsIAndIIPage : PageBase
    {
        public PropertyDetailSquireSectionsIAndIIPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnAddPropertyDetails => _webDriver.FindElementByCssSelector("span[id*='Add-btnWrap']");
        public IWebElement btnRemovePropertyDetails => _webDriver.FindElementByCssSelector("span[id*='Remove-btnWrap']");
        #endregion

        #region Page Methods

        public bool AddPropertyDetails(PolicyEntity policy, PagesBase pages)
        {
            NavigateToPage();

            if (policy.mySquireSectionsIAndII.LocationList.Count == 0)
                return false;
            foreach(LocationSquireEntity location in policy.mySquireSectionsIAndII.LocationList)
            {
                sClick(_webDriver.FindElementByXPath($"//div/a[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{location.Address.AddressOne.ToLower()}')]/following::div[4]")); // TODO: Watch this, lower function untested
                foreach(PropertySquireEntity property in location.PropertyList)
                {
                    property.PropertyNumber = policy.PropertyNumber++;
                    sClick(btnAddPropertyDetails);
                    pages.PropertyInformationSquireSectionIAndII.FillOutPropertyDetails(property, policy);
                }
            }
            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("HODwellingHOEScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickPropertyDetailSectionsIAndII();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Property Detail Sections I And II page");
                    return false;
                }
            }
        }
        #endregion
    }
}
