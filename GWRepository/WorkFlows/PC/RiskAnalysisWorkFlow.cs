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
    public class RiskAnalysisWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public RiskAnalysisWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void HandleAll()
        {
            Pages.RiskAnalysisPage.HandleAllRegularApprove();
            //Pages.UWActivityPage.ReleaseLock(); // TODO: NEEDED?
            //Pages.JobCompleteScreenPage.ClickViewJob();
        }
    }
}
