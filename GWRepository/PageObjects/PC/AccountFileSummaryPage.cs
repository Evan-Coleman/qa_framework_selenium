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
    public class AccountFileSummaryPage : PageBase
    {
        public AccountFileSummaryPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        private string radFarmRevenue = "//div[contains(text(),'Does the applicant have any farm revenue?')]";
        #endregion

        #region Page Methods
        public bool ClickCurrentActivityBySubject(string subject)
        {
            return sClick(_webDriver.FindElementByXPath($"//a[contains(text(), '{subject}')][1]"));
        }
        public bool ClickLatestPolicyTerm()
        {
            return sClick(_webDriver.FindElementByCssSelector("a[id*='AccountFile_Summary_PolicyTermsLV:0:PolicyNumber']"));
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("AccountFile_Summary:AccountFile_SummaryScreen:ttlBar");
        }
        #endregion
    }
}
