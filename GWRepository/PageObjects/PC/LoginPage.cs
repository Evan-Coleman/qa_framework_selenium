using GWRepository.BaseObjects;
using GWRepository.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GWRepository.PageObjects.PC
{
    public class LoginPage : PageBase
    {
        public LoginPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement txtUserName => _webDriver.FindElementByXPath("//input[starts-with(@id,'Login:LoginScreen:LoginDV:username-inputEl')]");
        public IWebElement txtPassword => _webDriver.FindElementByXPath("//input[starts-with(@id,'Login:LoginScreen:LoginDV:password-inputEl')]");
        public IWebElement btnUserName => _webDriver.FindElementByXPath("//a[starts-with(@id,'Login:LoginScreen:LoginDV:submit')]");
        #endregion

        #region Page Methods
        public bool Login(string User, string Password)
        {
            if (IsAt() && (txtUserName.Displayed && txtPassword.Displayed && btnUserName.Displayed))
            {
                WaitUtilities.WaitForPostBack(_webDriver);
                sSendKeys(txtUserName, User);
                sSendKeys(txtPassword, Password);
                sClick(btnUserName);
                WaitUtilities.WaitForPostBack(_webDriver);
                return true;
            }
            else
            {
                Debug.WriteLine("ERROR: Unable to login!");
                return false;
            }
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Login:LoginScreen:LoginDV:submit");
        }
        #endregion
    }
}
