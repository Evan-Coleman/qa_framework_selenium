using NUnit.Framework;
using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWRepository.Entities;
using OpenQA.Selenium;
using GWRepository.Utilities;

namespace GWRepository.WorkFlows.PC
{
    public class CreateAccountWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public CreateAccountWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void DefaultCreateAccount(PolicyEntity policy)
        {
            Assert.That(Pages.pcActions.IsAt(), Is.EqualTo(true), "Actions not available");
            Pages.pcActions.ClickNewSubmission();

            Assert.That(Pages.SubmissionCreateAccountPage.IsAt(), Is.EqualTo(true), "Not on new submission page");
            Pages.SubmissionCreateAccountPage.searchSelectPerson();
            Pages.SubmissionCreateAccountPage.FillOutFirstName(policy.PolicyMembers[0].FirstName);
            Pages.SubmissionCreateAccountPage.FillOutComapnyAndLastName(policy.PolicyMembers[0].LastName);
            Pages.SubmissionCreateAccountPage.ClickSearch();
            Pages.SubmissionCreateAccountPage.ClickCreateNewPerson();

            Assert.That(Pages.CreateAccountPage.IsAt(), Is.EqualTo(true), "Not on new create account page");
            if (policy.UserRole != ResourcesBase.Enums.UserRole.Agent)
            {
                bool done = false;
                int maxTryCount = 0;
                while (!done && maxTryCount < 100)
                {
                    try
                    {
                        Pages.CreateAccountPage.SelectAgentNumber(policy.AgentNumber);
                        
                        done = true;
                    }
                    catch (WebDriverException)
                    {
                        policy.AgentNumber = new DatabaseUtilities().GetRandomColumns("[PC_AgentsMaster]", "AgentNum", 1)[0];
                        Pages.CreateAccountPage.SelectAgentNumber(policy.AgentNumber);
                        continue;
                    }
                    maxTryCount++;
                }
            }
                
            Pages.CreateAccountPage.SetFirstName(policy.PolicyMembers[0].FirstName);
            Pages.CreateAccountPage.SetLastName(policy.PolicyMembers[0].LastName);
            Pages.CreateAccountPage.SetDateOfBirth(policy.PolicyMembers[0].DateOfBirth);
            Pages.CreateAccountPage.SetPostalCode(policy.PolicyMembers[0].Address.PostalCode);
            Pages.CreateAccountPage.SetCity(policy.PolicyMembers[0].Address.City);
            Pages.CreateAccountPage.SetAddressOne(policy.PolicyMembers[0].Address.AddressOne);
            Pages.CreateAccountPage.SetTIN(policy.PolicyMembers[0].TIN);
            Pages.CreateAccountPage.SelectAddressType(ResourcesBase.Enums.AddressType.Mailing);
            Pages.CreateAccountPage.ClickUpdate();

            // TODO: Keep this in mind for workflows, important step
            if (Pages.MatchingContactsPage.IsAt())
            {
                // Here check ( Resources.Enums.CreateNew ) for options
                Pages.MatchingContactsPage.ClickReturnToCreateAccount();
                Pages.CreateAccountPage.ClickUpdate();

                if (Pages.MatchingContactsPage.IsAt())
                {
                    Pages.MatchingContactsPage.ClickFirstDuplicateContact();
                    Pages.CreateAccountPage.ClickUpdate();
                }
            }

            Assert.That(Pages.NewSubmissionsPage.IsAt(), Is.EqualTo(true), "Not on new submissions page");
            if (policy.UserRole != ResourcesBase.Enums.UserRole.Agent)
            {
                Pages.NewSubmissionsPage.SelectAgentNumber(policy.AgentNumber);
            }
                
            if (policy.QuoteType != ResourcesBase.Enums.QuoteType.QuickQuote)
                Pages.NewSubmissionsPage.SetQuoteType(ResourcesBase.Enums.QuoteType.FullApplication);
            else
                Pages.NewSubmissionsPage.SetQuoteType(policy.QuoteType);
            Pages.NewSubmissionsPage.SetState(policy.PolicyMembers[0].Address.State);
            policy.EffectiveDate = Pages.NewSubmissionsPage.GetCenterDate(); // TODO: Need a better way to get center date!
            Pages.NewSubmissionsPage.SetEffectiveDate(policy.EffectiveDate); // TODO: Get date from centers
            Pages.NewSubmissionsPage.ClickProduct(policy.ProductType);
        }
    }
}
