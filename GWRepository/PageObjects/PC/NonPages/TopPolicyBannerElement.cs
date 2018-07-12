using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC.NonPages
{
    public class TopPolicyBannerElement : PageBase
    {
        public TopPolicyBannerElement(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnActionsArrow => _webDriver.FindElementByCssSelector("span[id*=DesktopMenuActions][class*=x-btn-arrow]");
        public IWebElement btnNewSubmission => _webDriver.FindElementByCssSelector("span[id$=NewSubmission-textEl]");
        #endregion

        #region Page Methods
        public string GetAccountNumber()
        {
            return _webDriver.FindElementByXPath("//span[contains(@id, 'AccountNumber-btnEl')]//span[contains(text(), 'Account #')]/following-sibling::span[1]").Text;
        }
        
        public bool ClickAccountNumber(string accountNumber)
        {
            return sClick(_webDriver.FindElementByXPath($"//span/span/span[contains(text(), '{accountNumber}')]"));
        }
        #endregion

        #region Standard Page Methods
        #endregion
    }
}
