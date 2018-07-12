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
    public class JobCompleteScreenPage : PageBase
    {
        public JobCompleteScreenPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnViewJob => _webDriver.FindElementByCssSelector("div[id*='JobCompleteDV:ViewJob-inputEl']");
        public IWebElement btnViewPolicy => _webDriver.FindElementByCssSelector("div[id*='JobCompleteDV:ViewPolicy-inputEl']");
        #endregion

        #region Page Methods
        public bool ClickViewJob()
        {
            return sClick(btnViewJob);
        }

        public bool ClickViewPolicy()
        {
            return sClick(btnViewPolicy);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("JobComplete:JobCompleteScreen:ttlBar");
        }
        #endregion
    }
}
