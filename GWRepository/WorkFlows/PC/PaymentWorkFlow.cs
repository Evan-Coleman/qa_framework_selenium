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
    public class PaymentWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public PaymentWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void AddDownPayment(PolicyEntity policy)
        {
            Pages.PaymentPage.SelectPaymentPlanType(policy.PaymentPlanType);
            Pages.PaymentPage.AddDownPayment(policy);
        }
    }
}
