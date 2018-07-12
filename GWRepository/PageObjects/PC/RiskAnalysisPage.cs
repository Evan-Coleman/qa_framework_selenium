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
    public class RiskAnalysisPage : PageBase
    {
        public RiskAnalysisPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        private string tableDivRiskIssues = "//div[contains(@id, 'RiskAnalysisCV:RiskEvaluationPanelSet:0-body')]";
        public IWebElement btnUWIssuesApprove => _webDriver.FindElementByCssSelector("span[id*='RiskAnalysisCV:RiskEvaluationPanelSet:Approve-btnInnerEl']");
        #endregion

        #region Page Methods
        public bool HandleAllRegularApprove()
        {
            NavigateToPage();

            bool done = false;
            int numIssues = 0;

            while (!done)
            {
                try
                {
                    _webDriver.FindElementByXPath(tableDivRiskIssues + $"//a[contains(@id, ':{numIssues + 1}:UWIssueRowSet:Approve')]");
                }
                catch (NoSuchElementException)
                {
                    done = true;
                }
                if (done == false)
                    numIssues++;
            }

            for (int IssueNumber = 1; IssueNumber <= numIssues; IssueNumber++)
            {
                sCheckboxCheck(tableDivRiskIssues + $"//a[contains(@id, ':{IssueNumber}:UWIssueRowSet:Approve')]" + "/ancestor::tr[1]//img[contains(@class, 'checkcolumn')]", true);
            }

            if(numIssues == 0)
                return false;

            sClick(btnUWIssuesApprove);

            return Pages.RiskApprovalDetailsPage.ClickOk();
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Job_RiskAnalysisScreen:RiskAnalysisCV");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickRiskAnalysis();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Risk Analysis page");
                    return false;
                }
            }
        }
        #endregion
    }
}
