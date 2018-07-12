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
    public class PolicyContractWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public PolicyContractWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void FillOutPolicyContract(PolicyEntity policy, BaseObjects.WorkFlowsBase workflows)
        {
            if (policy.QuoteType != ResourcesBase.Enums.QuoteType.QuickQuote)
            {
                Pages.PolicyMemberPage.AddAdditionalPolicyMembers(policy);
                Pages.InsuranceScorePage.OrderInsuranceReportForAllPolicyMembers(policy);
            }
        }

        public void AddAdditionalPolicyMembers(PolicyEntity policy) // TODO: Stubbed out, don't need for now
        {

        }
        public void OrderInsuranceScore()
        {

        }
    }
}
