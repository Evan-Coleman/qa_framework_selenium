using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC.NonPages
{
    public class SideMenuElement : PageBase
    {
        public SideMenuElement(RemoteWebDriver driver, PagesBase pages)
        {
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnSquireEligibility => _webDriver.FindElementByXPath("//span[contains(text(), 'Squire Eligibility')][contains(@class, 'tree-node')]");
        public IWebElement btnLineSelection => _webDriver.FindElementByXPath("//span[contains(text(), 'Line Selection')][contains(@class, 'tree-node')]");
        public IWebElement btnQualification => _webDriver.FindElementByXPath("//span[contains(text(), 'Qualification')][contains(@class, 'tree-node')]");
        public IWebElement btnPolicyContractArrow => _webDriver.FindElementByXPath("//span[contains(text(), 'Policy Contract')][contains(@class, 'tree-node')]");
        public IWebElement btnPolicyInfo => _webDriver.FindElementByXPath("//span[contains(text(), 'Policy Info')][contains(@class, 'tree-node')]");
        public IWebElement btnPolicyMembers => _webDriver.FindElementByXPath("//span[contains(text(), 'Policy Members')][contains(@class, 'tree-node')]");
        public IWebElement btnInsuranceScore => _webDriver.FindElementByXPath("//span[contains(text(), 'Insurance Score')][contains(@class, 'tree-node')]");
        public IWebElement btnSectionsIAndIIArrow => _webDriver.FindElementByXPath("//span[contains(text(), 'Sections I & II - Property & Liability')][contains(@class, 'tree-node')]");
        public IWebElement btnLocationsSectionsIAndII => _webDriver.FindElementByXPath("//span[contains(text(), 'Locations')][contains(@class, 'tree-node')]");
        public IWebElement btnPropertydetailSectionsIAndII => _webDriver.FindElementByXPath("//span[contains(text(), 'Property Detail')][contains(@class, 'tree-node')]");
        public IWebElement btnCoveragesSectionsIAndII => _webDriver.FindElementByXPath("//span[contains(text(), 'Coverages')][contains(@class, 'tree-node')]");
        public IWebElement btnCluePropertySectionsIAndII => _webDriver.FindElementByXPath("//span[contains(text(), 'CLUE Property')][contains(@class, 'tree-node')]");
        public IWebElement btnLineReviewSectionsIAndII => _webDriver.FindElementByXPath("//span[contains(text(), 'Line Review')][contains(@class, 'tree-node')]");
        public IWebElement btnModifiers => _webDriver.FindElementByXPath("//span[contains(text(), 'Modifiers')][contains(@class, 'tree-node')]");
        public IWebElement btnRiskanalysis => _webDriver.FindElementByXPath("//td[contains(@id, 'RiskAnalysis')]/div/span[contains(text(), 'Risk Analysis')][contains(@class, 'tree-node')]");
        public IWebElement btnQuote => _webDriver.FindElementByXPath("//span[contains(text(), 'Quote')][contains(@class, 'tree-node')]");
        public IWebElement btnPayment => _webDriver.FindElementByXPath("//span[contains(text(), 'Payment')][contains(@class, 'tree-node')]");
        public IWebElement btnForms => _webDriver.FindElementByXPath("//span[contains(text(), 'Forms')][contains(@class, 'tree-node')]");

        #endregion

        #region Page Methods
        public bool ClickSquireEligibility()
        {
            return sClick(btnSquireEligibility);
        }
        public bool ClickLineSelection()
        {
            return sClick(btnLineSelection);
        }
        public bool ClickQualification()
        {
            return sClick(btnQualification);
        }
        public bool ClickPolicyInfo()
        {
            sClick(btnPolicyContractArrow);
            return sClick(btnPolicyInfo);
        }
        public bool ClickPolicyMembers()
        {
            sClick(btnPolicyContractArrow);
            return sClick(btnPolicyMembers);
        }
        public bool ClickInsuranceScore()
        {
            sClick(btnPolicyContractArrow);
            return sClick(btnInsuranceScore);
        }
        public bool ClickLocationsSectionsIAndII()
        {
            sClick(btnSectionsIAndIIArrow);
            return sClick(btnLocationsSectionsIAndII);
        }
        public bool ClickPropertyDetailSectionsIAndII()
        {
            sClick(btnSectionsIAndIIArrow);
            return sClick(btnPropertydetailSectionsIAndII);
        }
        public bool ClickCoveragesSectionsIAndII()
        {
            sClick(btnSectionsIAndIIArrow);
            return sClick(btnCoveragesSectionsIAndII);
        }
        public bool ClickCluePropertySectionsIAndII()
        {
            sClick(btnSectionsIAndIIArrow);
            return sClick(btnCluePropertySectionsIAndII);
        }
        public bool ClickLinereviewSectionsIAndII()
        {
            sClick(btnSectionsIAndIIArrow);
            return sClick(btnLineReviewSectionsIAndII);
        }
        public bool ClickModifiers()
        {
            return sClick(btnModifiers);
        }
        public bool ClickRiskAnalysis()
        {
            return sClick(btnRiskanalysis);
        }
        public bool ClickQuote()
        {
            return sClick(btnQuote);
        }
        public bool ClickForms()
        {
            return sClick(btnForms);
        }
        public bool ClickPayment()
        {
            return sClick(btnPayment);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        { // TODO: Fix these... at least a trycatch
            return btnSquireEligibility.Displayed || btnLineSelection.Displayed || btnPolicyContractArrow.Displayed || btnInsuranceScore.Displayed ||
                   btnQuote.Displayed || btnRiskanalysis.Displayed;
        }
        #endregion
    }
}
