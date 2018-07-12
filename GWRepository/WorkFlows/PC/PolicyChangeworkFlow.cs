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
    public class PolicyChangeWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public PolicyChangeWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void ChangePolicy(List<Action> policyChangeSteps,
                                 PolicyEntity policy,
                                 string policyChangeEffectiveDate,
                                 BaseObjects.WorkFlowsBase workFlows,
                                 string policyChangeDescription = "Just a normal policy change, nothing to look at here!"
                                 )
        {
            Pages.PolicyChangePage.InitiatePolicyChange(policyChangeEffectiveDate, policyChangeDescription);

            foreach(Action step in policyChangeSteps)
            {
                step();
            }

            workFlows.QuoteWorkFlow.QuoteAndHandleRiskAnalysis(workFlows);
            Pages.SideMenu.ClickForms();
            Pages.CommonTopButtons.ClickIssuePolicyChange();
            Pages.JobCompleteScreenPage.ClickViewPolicy();
        }
    }
}
