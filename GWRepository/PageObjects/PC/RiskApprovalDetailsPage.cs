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
    public class RiskApprovalDetailsPage : PageBase
    {
        public RiskApprovalDetailsPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnOk => _webDriver.FindElementByCssSelector("span[id*='RiskApprovalDetailsPopup:Update-btnInnerEl']");
        #endregion

        #region Page Methods
        public bool ClickOk()
        {
            return sClick(btnOk);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("RiskApprovalDetailsPopup:ttlBar");
        }
        #endregion
    }
}
