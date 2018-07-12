using GWRepository.BaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class QuotePage : PageBase
    {
        public QuotePage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        #endregion

        #region Page Methods
        public bool IsUWApprovalRequired()
        {
            NavigateToPage();

            return _webDriver.PageSource.Contains("This quote will require underwriting approval prior to issuance.");
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("MultiLine_QuoteScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickQuote();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Quote page");
                    return false;
                }
            }
        }
        #endregion
    }
}
