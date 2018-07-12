using GWRepository.BaseObjects;
using NUnit.Framework;
using GWRepository.WorkFlows.PC;
using GWRepository.Entities;
using GWRepository.Utilities;
using OpenQA.Selenium;

namespace GWTesting
{
    [TestFixture, Parallelizable] 
    public class US14895_SQ011Trigger : TestBase
    {
        [Test, Parallelizable]
        public void ValidateSQ011Trigger()
        {
            PolicyEntity myPolicyObject = new PolicyEntity()
            {
                QuoteType = ResourcesBase.Enums.QuoteType.PolicySubmitted
            };
            myPolicyObject.PolicyMembers[0].FirstName = "Bill";
            myPolicyObject.PolicyMembers[0].LastName = "Clinton";
            base.Initialize(ResourcesBase.Enums.CenterType.PC);

            //var loc = new LocationSquire();
            ////loc.PropertyList.Add(new PropertySquire());
            //loc.PropertyList[0].Size = "5000";
            //loc.Address.AddressOne = "132 N Main";
            ////loc.NumberOfResidence = "1";
            //loc.PropertyList[0].Yearbuilt = "1950";

            //myPolicyObject.mySquireSectionsIAndII.LocationList.Add(loc);

            WorkFlows.GeneratePolicyWorkFlow.DefaultGenerate(WorkFlows, myPolicyObject);

            WorkFlows.LoginWorkFlow.DefaultLogin(myPolicyObject);

            WorkFlows.SearchAccountWorkFlow.SearchAccountByAccountNumber(myPolicyObject);
            Pages.AccountFileSummaryPage.ClickCurrentActivityBySubject(ResourcesBase.Enums.CurrentActivitySubject.SubmittedFullApplication);
            Pages.InsuranceScorePage.StartEditInsuranceReport(myPolicyObject);
            Pages.CommonTopButtons.ClickQuote();
            Assert.True(_webDriver.PageSource.Contains("Policy: Credit Report is required to quote policy. (SQ011)"), "SQ011 Validation not on screen!");
        }
    }
}
