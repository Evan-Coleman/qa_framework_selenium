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
    public class SearchSubmissionsPage : PageBase
    {
        public SearchSubmissionsPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement txtAccountNumber => _webDriver.FindElementByCssSelector("input[id*='PolicySearchDV:AccountNumber-inputEl']");
        public IWebElement btnSearch => _webDriver.FindElementByCssSelector("a[id*='SearchLinksInputSet:Search'][class*='bigButton']");
        #endregion

        #region Page Methods
        public bool SearchAccountByAccountNumber(PolicyEntity policy)
        {
            NavigateToPage();
            sSendKeys(txtAccountNumber, policy.AccountNumber);
            return sClick(btnSearch);
        }

        public bool ClickSearchResultByRowNumber(int rowNumber) // Using 1 base system
        {
            return sClick(_webDriver.FindElementByCssSelector($"a[id*='PolicySearch_ResultsLV:{rowNumber - 1}:AccountNumber']"));
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("SubmissionSearchScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.pcTopMenu.clickSearchSubmission();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Submission search page");
                    return false;
                }
            }
        }
        #endregion
    }
}
