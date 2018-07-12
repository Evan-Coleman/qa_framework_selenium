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
    public class PolicyInfoPage : PageBase
    {
        public PolicyInfoPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        // TOP SECTION
        public IWebElement selOrganizationType => _webDriver.FindElementByCssSelector("input[id*='OrganizationType']");

        // PNI SECTION
        public IWebElement btnChangePrimaryNamedInsured => _webDriver.FindElementByCssSelector("a[id*='ChangePrimaryNamedInsuredButtonMenuIcon'] img");
        public IWebElement txtBusinessPhoneNumber => _webDriver.FindElementByCssSelector("input[id*='BusinessPhone']");
        public IWebElement txtWorkPhoneNumber => _webDriver.FindElementByCssSelector("input[id*='WorkPhone']");
        public IWebElement txtHomePhoneNumber => _webDriver.FindElementByCssSelector("input[id*='HomePhone']");
        public IWebElement txtMobilePhoneNumber => _webDriver.FindElementByCssSelector("input[id*='MobilePhone']");
        public IWebElement txtFaxPhoneNumber => _webDriver.FindElementByCssSelector("input[id*='FaxPhone']");

        // MAILING ADDRESS SECTION
        public IWebElement selRatingCounty => _webDriver.FindElementByCssSelector("input[id*='RatingCounty']");
        public IWebElement selBillingCounty => _webDriver.FindElementByCssSelector("input[id*='CountyList']");

        // POLICY DETAILS SECTION
        public IWebElement selTermType => _webDriver.FindElementByCssSelector("input[id*='TermType']");
        public IWebElement txtEffectiveDate => _webDriver.FindElementByCssSelector("input[id*='EffectiveDate']");
        public IWebElement txtWrittenDate => _webDriver.FindElementByCssSelector("input[id*='WrittenDate']");
        public IWebElement checkTransitionRenewal => _webDriver.FindElementByCssSelector("input[id*='TransitionRenewal']");
        public IWebElement checkTransferredFromAnotherPolicy => _webDriver.FindElementByCssSelector("input[id*='TransferredAnotherPolicy']");
        public IWebElement selPreferredLanguage => _webDriver.FindElementByCssSelector("input[id*='PrimaryLanguage']");
        
        // AGENT SECTION
        public IWebElement selAgentNumber => _webDriver.FindElementByCssSelector("input[id$='ProducerCode-inputEl']");
        public IWebElement selProducerOfService => _webDriver.FindElementByCssSelector("input[id*='ProducerCodeOfService']");

        // ADDITIONAL NAMED INSUREDS SECTION
        public IWebElement btnSearchAdditionalNamedInsureds => _webDriver.FindElementByXPath("//span[contains(@id, 'NamedInsureds')][contains(text(), 'Search')]");
        public IWebElement btnRemoveAdditionalNamedInsureds => _webDriver.FindElementByXPath("//span[contains(@id, 'NamedInsureds')][contains(text(), 'Remove')]");

        // MEMBERSHIP DUES SECTION
        public IWebElement btnAddMembershipDues => _webDriver.FindElementByCssSelector("a[id*='AddContactsButton']");
        public IWebElement btnRemoveMembershipDues => _webDriver.FindElementByCssSelector("a[id*='PolicyAssociatesLV_tb:Remove']");

        #endregion

        #region Page Methods
        public bool FillOutPolicyInfo(PolicyEntity policy)
        {
            NavigateToPage();

            sSelectorSelect(selOrganizationType, policy.OrganizationType);
            sSelectorSelect(selRatingCounty, policy.RatingCounty);
            sSelectorSelect(selTermType, policy.TermType);
            sSendKeys(txtEffectiveDate, policy.EffectiveDate);
            //sSendKeys(txtWrittenDate, policy.EffectiveDate); // TODO: Get date from center; Doesn't seem to be needed when in as agent
            if (policy.UserRole != ResourcesBase.Enums.UserRole.Agent && policy.UserRole != ResourcesBase.Enums.UserRole.Underwriter)
                sSelectorSelect(selAgentNumber, policy.AgentNumber);
            if (policy.UserRole != ResourcesBase.Enums.UserRole.Agent && policy.UserRole != ResourcesBase.Enums.UserRole.Underwriter)
                sSelectorSelect(selProducerOfService, policy.AgentNumber);
            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("SubmissionWizard_PolicyInfoScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickPolicyInfo();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Policy Info page");
                    return false;
                }
            }
        }
        #endregion
    }
}
