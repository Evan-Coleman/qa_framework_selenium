using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC.NonPages
{
    public class ActionsMenuElement : PageBase
    {
        public ActionsMenuElement(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnActionsArrow => _webDriver.FindElementByCssSelector("span[id*=MenuActions][class*='x-btn-arrow']");
        public IWebElement btnNewSubmission => _webDriver.FindElementByCssSelector("span[id$='NewSubmission-textEl']");
        public IWebElement btnChangePolicy => _webDriver.FindElementByCssSelector("span[id$='Actions_ChangePolicy-textEl']");
        #endregion

        #region Page Methods
        public bool ClickNewSubmission()
        {
            if (sClick(btnActionsArrow))
                return sClick(btnNewSubmission);
            return false;
        }
        public bool ClickChangePolicy()
        {
            if (sClick(btnActionsArrow))
                return sClick(btnChangePolicy);
            return false;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("actionsButton");
        }
        #endregion
    }
}
