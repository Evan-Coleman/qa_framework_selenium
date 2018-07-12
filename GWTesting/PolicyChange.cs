using GWRepository.BaseObjects;
using NUnit.Framework;
using GWRepository.WorkFlows.PC;
using GWRepository.Entities;
using GWRepository.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GWTesting
{
    [TestFixture, Parallelizable]
    public class PolicyChange : TestBase
    {
        [Test, Parallelizable]
        public void PolicyChangeTest()
        {
            PolicyEntity myPolicyObject = new PolicyEntity()
            {
                QuoteType = ResourcesBase.Enums.QuoteType.PolicyIssued,
                ProductType = ResourcesBase.Enums.ProductType.Squire,
                SquireLines = new List<string>() { ResourcesBase.Enums.SquireLines.SectionsIAndII }
            };
            base.Initialize(ResourcesBase.Enums.CenterType.PC);

            WorkFlows.GeneratePolicyWorkFlow.DefaultGenerate(WorkFlows, myPolicyObject);
            WorkFlows.LoginWorkFlow.LoginAndSearchPolicyByAccountNumber(myPolicyObject, WorkFlows);

            // Methods to perform in the policy change
            List<Action> PolicyChangeMethods = new List<Action>();

            PolicyChangeMethods.Add(() => Pages.
                                          LocationSquireSectionIAndII.
                                          AddNewLocation(new LocationSquireEntity(), Pages));

            string newSectionICoverage = ResourcesBase.Enums.SectionIDeductables.d2500;
            myPolicyObject.mySquireSectionsIAndII.SectionIDeductibles = newSectionICoverage;

            PolicyChangeMethods.Add(() => Pages.
                                          CoveragesSquireSectionIAndII.FillOutcoverages(myPolicyObject.mySquireSectionsIAndII));

            // Performs policy change with date, description, and list of methods
            WorkFlows.PolicyChangeWorkFlow.ChangePolicy(PolicyChangeMethods, myPolicyObject, myPolicyObject.EffectiveDate, WorkFlows, "This is a test change!");


            Assert.True(_webDriver.PageSource.Contains("This is a test change!"), "Policy Change Description not on screen!");

            Pages.SideMenu.ClickCoveragesSectionsIAndII();
            IWebElement sectionIDeductibles = _webDriver.FindElementByXPath("//label[contains(text(), 'Deductible')][contains(@id, 'OptionTermInput')]/following::div[1]");
            Assert.True(sectionIDeductibles.Text == newSectionICoverage,
                        "The Section I Coverage did not get set correctly!");
        }
    }
}
