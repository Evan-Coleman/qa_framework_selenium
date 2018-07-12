
using GWRepository.BaseObjects;
using GWRepository.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class PolicyChangePage : PageBase
    {
        public PolicyChangePage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnNext => _webDriver.FindElementByCssSelector("span[id *= 'NewPolicyChange-btnInnerEl']");
        public IWebElement txtEffectiveDate => _webDriver.FindElementByCssSelector("input[id*='EffectiveDate_date-inputEl']");
        public IWebElement txtDescription => _webDriver.FindElementByCssSelector("input[id*='Description-inputEl']");
        #endregion

        #region Page Methods
        public bool InitiatePolicyChange(string effectiveDate, string description)
        {
            NavigateToPage();

            sSendKeys(txtEffectiveDate, effectiveDate);
            sSendKeys(txtDescription, description);
            return sClick(btnNext);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("StartPolicyChange:StartPolicyChangeScreen:ttlBar");
        }
        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.pcActions.ClickChangePolicy();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Policy Change page");
                    return false;
                }
            }
        }
        #endregion
    }
}
