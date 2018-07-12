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
    public class UWActivityPage : PageBase
    {
        public UWActivityPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnRelease => _webDriver.FindElementByCssSelector("span[id='UWActivityPopup:Update-btnInnerEl']");
        public IWebElement txtUWActivityText => _webDriver.FindElementByCssSelector("textarea[id='UWActivityPopup:ActivityDetailNoteDV:Text-inputEl']");
        #endregion

        #region Page Methods
        public bool ReleaseLock()
        {
            sSendKeys(txtUWActivityText, "Releasing this lock, FLY AWAY!!!");
            return sClick(btnRelease);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("UWActivityPopup:ttlBar");
        }
        #endregion
    }
}
