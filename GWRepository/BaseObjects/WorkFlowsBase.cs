using GWRepository.BaseObjects;
using GWRepository.WorkFlows.PC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.BaseObjects
{
    public class WorkFlowsBase
    {
        public PagesBase Pages { get; set; }
        public WorkFlowsBase(PagesBase pages)
        {
            Pages = pages;
        }

        #region WorkFlows
        public PolicyChangeWorkFlow PolicyChangeWorkFlow
        {
            get
            {
                return new PolicyChangeWorkFlow(Pages);
            }
        }
        public SearchAccountWorkFlow SearchAccountWorkFlow
        {
            get
            {
                return new SearchAccountWorkFlow(Pages);
            }
        }
        public GeneratePolicyWorkFlow GeneratePolicyWorkFlow
        {
            get
            {
                return new GeneratePolicyWorkFlow(Pages);
            }
        }
        public LogOutWorkFlow LogOutWorkFlow
        {
            get
            {
                return new LogOutWorkFlow(Pages);
            }
        }
        public LoginWorkFlow LoginWorkFlow
        {
            get
            {
                return new LoginWorkFlow(Pages);
            }
        }
        public CreateAccountWorkFlow CreateAccountWorkFlow
        {
            get
            {
                return new CreateAccountWorkFlow(Pages);
            }
        }
        public SquireWorkFlow SquireWorkFlow
        {
            get
            {
                return new SquireWorkFlow(Pages);
            }
        }
        public SquireSectionsIAndIIWorkFlow SquireSectionsIAndIIWorkFlow
        {
            get
            {
                return new SquireSectionsIAndIIWorkFlow(Pages);
            }
        }
        public PolicyContractWorkFlow PolicyContractWorkFlow
        {
            get
            {
                return new PolicyContractWorkFlow(Pages);
            }
        }
        public QuoteWorkFlow QuoteWorkFlow
        {
            get
            {
                return new QuoteWorkFlow(Pages);
            }
        }
        public RiskAnalysisWorkFlow RiskAnalysisWorkFlow
        {
            get
            {
                return new RiskAnalysisWorkFlow(Pages);
            }
        }
        public PaymentWorkFlow PaymentWorkFlow
        {
            get
            {
                return new PaymentWorkFlow(Pages);
            }
        }
        #endregion
    }
}
