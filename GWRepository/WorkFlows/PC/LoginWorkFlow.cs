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
    public class LoginWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public LoginWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void DefaultLogin(PolicyEntity policy)
        {
            Assert.That(Pages.LoginPage.IsAt(), Is.EqualTo(true), "Not at Login page!");
            Pages.LoginPage.Login(policy.myUser.UserName, policy.myUser.Password);
            while (!Pages.LoginPage.IsAt())
            {
                policy.myUser = new UserEntity();
                Pages.LoginPage.Login(policy.myUser.UserName, policy.myUser.Password);
            }
        }

        public void LoginAndSearchPolicyByAccountNumber(PolicyEntity policy, BaseObjects.WorkFlowsBase WorkFlows)
        {
            DefaultLogin(policy);
            WorkFlows.SearchAccountWorkFlow.SearchAccountByAccountNumber(policy);
            Pages.AccountFileSummaryPage.ClickLatestPolicyTerm();
        }
    }
}
