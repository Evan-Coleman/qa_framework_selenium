
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
    public class PolicyMemberPage : PageBase
    {
        public PolicyMemberPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement asd => _webDriver.FindElementByCssSelector("");
        #endregion

        #region Page Methods

        public bool AddAdditionalPolicyMembers(PolicyEntity policy)
        {
            NavigateToPage();


            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("PolicyMembersScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickPolicyMembers();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Policy Members page");
                    return false;
                }
            }
        }
        #endregion
    }
}
