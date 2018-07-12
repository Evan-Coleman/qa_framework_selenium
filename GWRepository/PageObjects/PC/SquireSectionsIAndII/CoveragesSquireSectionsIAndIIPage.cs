
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
    public class CoveragesSquireSectionsIAndIIPage : PageBase
    {
        public CoveragesSquireSectionsIAndIIPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnPropertyDetailCoverages => _webDriver.FindElementByCssSelector("span[id*='HOPolicyLevelCoveragesIDTab-btnInnerEl']");
        public IWebElement btnTabSectionIICoverages => _webDriver.FindElementByCssSelector("span[id*='SectionIITab-btnWrap']");
        public IWebElement btnExclusionsAndConditions => _webDriver.FindElementByCssSelector("span[id*='HOPolicyLevelCoveragesIDTab-btnInnerEl']");

        public IWebElement selSectionIDeductibles => _webDriver.FindElementByXPath("//label[contains(text(), 'Deductible')]/parent::td/following-sibling::td/descendant::input[contains(@id, 'CovPatternInputGroup:0:')]");

        // SECTION I COVERAGES **PER PROPERTY
        public IWebElement txtCoverageALimit => _webDriver.FindElementByCssSelector("input[id*='limitTerm']");
        public IWebElement selCoverageAValuationMethod => _webDriver.FindElementByXPath("//label[contains(text(), 'Valuation Method')]/parent::td/following-sibling::td/descendant::input[contains(@id, 'CovPatternInputGroup:0:')]");
        public IWebElement selCoverageCValuationMethod => _webDriver.FindElementByXPath("//label[contains(text(), 'Valuation Method')]/parent::td/following-sibling::td/descendant::input[contains(@id, 'CovPatternInputGroup:1:')]");
        #endregion

        #region Page Methods

        public bool FillOutcoverages(SquireSectionsIAndIIEntity squireSectionsIAndII)
        {
            NavigateToPage();

            sSelectorSelect(selSectionIDeductibles, squireSectionsIAndII.SectionIDeductibles);

            foreach (LocationSquireEntity location in squireSectionsIAndII.LocationList)
            {
                foreach (PropertySquireEntity property in location.PropertyList)
                { // TODO: For policies where some locations/properties are removed, the numbers may not match up
                    sClick(_webDriver.FindElementByXPath($"//tbody[contains(@id, 'gridview')]/descendant::div[text()='{location.LocationNumber}']/parent::td/following-sibling::td/div[text()='{property.PropertyNumber}']"));
                    sSendKeys(txtCoverageALimit, property.CoverageALimit);
                    sSelectorSelect(selCoverageAValuationMethod, property.CoverageAValuationMethod);
                    sSelectorSelect(selCoverageCValuationMethod, property.CoverageCValuationMethod);
                }
            }
            sClick(btnTabSectionIICoverages);
            return true;
        }

        public bool ClickSectionIICoverages()
        {
            return sClick(btnTabSectionIICoverages);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("HOCoveragesHOEScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickCoveragesSectionsIAndII();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Coverages Sections I And II page");
                    return false;
                }
            }
        }
        #endregion
    }
}
