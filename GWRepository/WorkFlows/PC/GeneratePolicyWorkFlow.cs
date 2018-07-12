using NUnit.Framework;
using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWRepository.Entities;
using GWRepository.Utilities;

namespace GWRepository.WorkFlows.PC
{
    public class GeneratePolicyWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public GeneratePolicyWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void DefaultGenerate(BaseObjects.WorkFlowsBase WorkFlows, PolicyEntity myPolicyObject)
        {
            WorkFlows.LoginWorkFlow.DefaultLogin(myPolicyObject);
            WorkFlows.CreateAccountWorkFlow.DefaultCreateAccount(myPolicyObject);
            myPolicyObject.AccountNumber = Pages.TopPolicyBanner.GetAccountNumber();
            if (myPolicyObject.ProductType == ResourcesBase.Enums.ProductType.Squire)
                WorkFlows.SquireWorkFlow.FillOutSquire(myPolicyObject, WorkFlows);
            WorkFlows.PolicyContractWorkFlow.FillOutPolicyContract(myPolicyObject, WorkFlows);

            if (myPolicyObject.IsDraft == false || myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.PolicySubmitted || myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.PolicyIssued)
                WorkFlows.QuoteWorkFlow.QuoteAndHandleRiskAnalysis(WorkFlows);

            if (myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.QuickQuote || myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.FullApplication)
            {
                WorkFlows.LogOutWorkFlow.DefaultLogOut();
                return;
            }

            WorkFlows.PaymentWorkFlow.AddDownPayment(myPolicyObject);

            Pages.SideMenu.ClickForms();
            if (myPolicyObject.IsDraft == false || myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.PolicyIssued)
                Pages.CommonTopButtons.ClickSubmit();

            if (myPolicyObject.QuoteType == ResourcesBase.Enums.QuoteType.PolicySubmitted)
            {
                WorkFlows.LogOutWorkFlow.DefaultLogOut();
                return;
            }

            Pages.TopPolicyBanner.ClickAccountNumber(myPolicyObject.AccountNumber);
            Pages.AccountFileSummaryPage.ClickCurrentActivityBySubject(ResourcesBase.Enums.CurrentActivitySubject.SubmittedFullApplication);
            WorkFlows.QuoteWorkFlow.QuoteAndHandleRiskAnalysis(WorkFlows);

            if (myPolicyObject.IsDraft == false)
                Pages.CommonTopButtons.ClickIssueNoActionRequired();

            WorkFlows.LogOutWorkFlow.DefaultLogOut();
        }
    }
}
