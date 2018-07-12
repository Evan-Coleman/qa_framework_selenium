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
    public class CluePropertySectionsIAndIIPage : PageBase
    {
        public CluePropertySectionsIAndIIPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnOrderClue => _webDriver.FindElementByCssSelector("span[id*='ClueButton-btnWrap']");
        #endregion

        #region Page Methods
        public bool OrderClue()
        {
            NavigateToPage();

            return sClick(btnOrderClue); ;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("HOPriorLossExtScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickCluePropertySectionsIAndII();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Clue Property page");
                    return false;
                }
            }
        }
        #endregion
    }
}
