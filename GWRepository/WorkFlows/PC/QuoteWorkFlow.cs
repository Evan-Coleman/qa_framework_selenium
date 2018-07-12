using NUnit.Framework;
using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWRepository.Entities;

namespace GWRepository.WorkFlows.PC
{
    public class QuoteWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public QuoteWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void QuoteAndHandleRiskAnalysis(BaseObjects.WorkFlowsBase workFlows)
        {
            Pages.SideMenu.ClickRiskAnalysis();
            Pages.CommonTopButtons.ClickQuote();
            if (Pages.QuotePage.IsUWApprovalRequired())
            {
                workFlows.RiskAnalysisWorkFlow.HandleAll();
            }
        }
    }
}
