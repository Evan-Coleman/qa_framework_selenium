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
    public class SquireWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public SquireWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void FillOutSquire(PolicyEntity policy, BaseObjects.WorkFlowsBase workFlows)
        {
            Pages.SquireEligibilityPage.ChooseFarmRevenue(false);
            Pages.LineSelectionPage.CheckSquireLines(policy.SquireLines);
            if (policy.QuoteType != ResourcesBase.Enums.QuoteType.QuickQuote)
                Pages.QualificationPageSquire.FillOutQualifications(policy);
            Pages.PolicyInfoPage.FillOutPolicyInfo(policy);
            workFlows.SquireSectionsIAndIIWorkFlow.FillOutSectionsIAndII(policy);
        }
    }
}
