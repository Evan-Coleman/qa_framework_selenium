using GWRepository.BaseObjects;
using GWRepository.PageObjects.PC.NonPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class SquireEligibilityPage : PageBase
    {
        public SquireEligibilityPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        private string radFarmRevenue = "//div[contains(text(),'Does the applicant have any farm revenue?')]";
        #endregion

        #region Page Methods
        public bool ChooseFarmRevenue(bool yesNo)
        {
            NavigateToPage();
            return sRadioSelect(radFarmRevenue, yesNo);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("SquireEligibilityScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickSquireEligibility();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Squire Eligibility page");
                    return false;
                }
            }
        }
        #endregion
    }
}
