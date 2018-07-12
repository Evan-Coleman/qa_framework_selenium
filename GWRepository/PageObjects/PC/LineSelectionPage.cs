using GWRepository.BaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using static GWRepository.BaseObjects.ResourcesBase.Enums;

namespace GWRepository.PageObjects.PC
{
    public class LineSelectionPage : PageBase
    {
        public LineSelectionPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        private string checkSectionIAndII = "//div[contains(text(), 'Sections I & II - Property & Liability Line')]";
        private string checkSectionIII = "//div[contains(text(), 'Section III - Auto Line')]";
        private string checkSectionIV = "//div[contains(text(), 'Section IV - Inland Marine Line')]";
        #endregion

        #region Page Methods
        public bool CheckSquireLines(List<string> lines)
        {
            NavigateToPage();

            if (lines.Count == 3) // If it has all lines, just return since it defaults with them on
                return true;

            if (lines.Contains(ResourcesBase.Enums.SquireLines.SectionsIAndII))
                sCheckboxCheck(checkSectionIAndII, true);
            else
                sCheckboxCheck(checkSectionIAndII, false);
            if (lines.Contains(ResourcesBase.Enums.SquireLines.SectionIII))
                sCheckboxCheck(checkSectionIII, true);
            else
                sCheckboxCheck(checkSectionIII, false);
            if (lines.Contains(ResourcesBase.Enums.SquireLines.SectionIV))
                sCheckboxCheck(checkSectionIV, true);
            else
                sCheckboxCheck(checkSectionIV, false);

            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("LineSelectionScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickLineSelection();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Line Selection page");
                    return false;
                }
            }
        }
        #endregion
    }
}
