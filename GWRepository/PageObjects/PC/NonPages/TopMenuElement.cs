using GWRepository.BaseObjects;
using GWRepository.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC.NonPages
{
    public class TopMenuElement : PageBase
    {
        public TopMenuElement(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnDesktopTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:DesktopTab-btnWrap')]");
        public IWebElement btnSearchTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:SearchTab-btnWrap')]");
        public IWebElement btnAdministrationTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:AdminTab-btnWrap')]");
        public IWebElement btnAccountTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:AccountTab-btnWrap')]");
        public IWebElement btnPolicyTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:PolicyTab-btnWrap')]");
        public IWebElement btnContactTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:ContactTab-btnWrap')]");
        public IWebElement btnReinsuranceTab => _webDriver.FindElementByXPath("//span[starts-with(@id,'TabBar:ReinsuranceTab-btnWrap')]");
      //public IWebElement btnDesktopTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:DesktopTab')]");
      //public IWebElement btnSearchTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:SearchTab')]");
        public IWebElement btnTeamTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:TeamTab')]");
      //public IWebElement btnAdministrationTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:AdminTab')]");
      //public IWebElement btnAccountTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:AccountTab')]");
      //public IWebElement btnPolicyTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:PolicyTab')]");
        public IWebElement btnPoliciesTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:PoliciesTab')]");
      //public IWebElement btnContactTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:ContactTab')]");
      //public IWebElement btnReinsuranceTab => _webDriver.FindElementByXPath("//a[starts-with(@id,'TabBar:ReinsuranceTab')]");
        public IWebElement btnSubmissionSearch => _webDriver.FindElementByCssSelector("a[id*='SubmissionSearch']");
        public IWebElement btnOptionsCogWheelArrow => _webDriver.FindElementByCssSelector("span[id*=':TabLinkMenuButton-btnIconEl']");
        public IWebElement btnLogOut => _webDriver.FindElementByCssSelector("span[id*='TabBar:LogoutTabBarLink-textEl']");
        public IWebElement btnOKLogOut => _webDriver.FindElementByXPath("//div[contains(text(), 'log out')]/following::span[contains(text(), 'OK')]");

        #endregion

        #region Page Actions
        public bool clickDesktopTab()
        {
            return sClick(btnDesktopTab);           
        }

        public bool clickSearchTab()
        {
            return sClick(btnSearchTab);
        }

        public bool clickTeamTab()
        {
            return sClick(btnTeamTab);
        }

        public bool clickAdministrationTab()
        {
            return sClick(btnAdministrationTab);
        }

        public bool clickAccountTab()
        {
            return sClick(btnAccountTab);
        }

        public bool clickPolicyTab()
        { 
            return sClick(btnPolicyTab);
        }
        public bool clickPoliciesTab()
        {
            return sClick(btnPoliciesTab);
        }

        public bool clickContactTab()
        {
            return sClick(btnContactTab);
        }

        public bool clickReinsuranceTab()
        {
            return sClick(btnReinsuranceTab);
        }

        public bool clickSearchSubmission()
        {
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(_webDriver);

            builder.MoveToElement(btnSearchTab)
                   .MoveByOffset(30, 0)
                   .Click()
                   .Build()
                   .Perform();
            WaitUtilities.WaitForPostBack(_webDriver);
                return sClick(btnSubmissionSearch);
        }

        public bool LogOut()
        {
            if (sClick(btnOptionsCogWheelArrow))
                if (sClick(btnLogOut))
                {
                    try
                    {
                        return sClick(btnOKLogOut);
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                }
                    
            return false;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Go to (Alt+/)");
        }
        #endregion
    }
}
