
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
    public class InsuranceScorePage : PageBase
    {
        public InsuranceScorePage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement selIndividualForCreditReport => _webDriver.FindElementByCssSelector("input[id*='CreditReportContact-inputEl']");
        private string radCurrentAddressMoreThan6Months = "//label[contains(text(), 'Has this person lived at this address for less than 6 months?')]";
        private string radNameChanged6Months = "//label[contains(text(), \"Has this person's name changed in the last 6 months?\")]";
        public IWebElement btnOrderInsuranceReport => _webDriver.FindElementByCssSelector("a[id*='OrderCreditReportButton']");
        public IWebElement btnEditInsuranceReport => _webDriver.FindElementByXPath("//a[contains(@id, ':CreditReportScreen:CreditReportPanelSet:EditDetailsButton')]");
        #endregion

        #region Page Methods
        public bool OrderInsuranceReportForAllPolicyMembers(PolicyEntity policy)
        {
            NavigateToPage();

            foreach (PersonEntity member in policy.PolicyMembers)
            {
                sSelectorSelect(selIndividualForCreditReport, member.FirstName);
                sRadioSelect(radCurrentAddressMoreThan6Months, member.CurrentAddressMoreThan6Months);
                sRadioSelect(radNameChanged6Months, member.NameChanged6Months);
                sClick(btnOrderInsuranceReport);
            }

            return true;
        }
        public bool StartEditInsuranceReport(PolicyEntity policy)
        {
            NavigateToPage();

            foreach (PersonEntity member in policy.PolicyMembers)
            {
                sClick(btnEditInsuranceReport);
                sSelectorSelect(selIndividualForCreditReport, member.FirstName);
            }

            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("CreditReportScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickInsuranceScore();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Insurance Score Sections I And II page");
                    return false;
                }
            }
        }
        #endregion
    }
}
