
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
    public class LocationSquireSectionsIAndIIPage : PageBase
    {
        public LocationSquireSectionsIAndIIPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnNewLocation => _webDriver.FindElementByCssSelector("span[id*='LocationsEdit_DP_tb:Add-btnWrap']");
        public IWebElement btnRemoveLocation => _webDriver.FindElementByCssSelector("span[id*='LocationsEdit_DP_tb:Remove-btnWrap']");
        public IWebElement btnSetAsPrimary => _webDriver.FindElementByCssSelector("span[id*='LocationsEdit_DP_tb:setToPrimary-btnWrap']");
        public IWebElement btnAddExistingLocationArrow => _webDriver.FindElementByCssSelector("span[id*='addLocationButton-btnWrap']");
        #endregion

        #region Page Methods
        public bool AddNewLocations(List<LocationSquireEntity> locations, PagesBase pages)
        {
            NavigateToPage();

            int LocationNumber = 1;

            foreach (LocationSquireEntity location in locations)
            {
                location.LocationNumber = LocationNumber++;
                sClick(btnNewLocation);
                pages.LocationInformationPage.FillLocationDetails(location);
            }
            return true;
        }
        public bool AddNewLocation(LocationSquireEntity location, PagesBase pages)
        {
            NavigateToPage();
            sClick(btnNewLocation);
            return pages.LocationInformationPage.FillLocationDetails(location);
        }
        public bool AddExistingLocationByIndex(int i)
        {
            NavigateToPage();

            sClick(btnAddExistingLocationArrow);
            return sClick(_webDriver.FindElementByCssSelector($"span[id*='addLocationButton:{i}:UnassignedAccountLocation-textEl']"));
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("HOLocationsScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickLocationsSectionsIAndII();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Locations Sections I And II page");
                    return false;
                }
            }
        }
        #endregion
    }
}
