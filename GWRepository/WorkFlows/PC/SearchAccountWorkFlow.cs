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
    public class SearchAccountWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public SearchAccountWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void SearchAccountByAccountNumber(PolicyEntity policy)
        {
            Pages.SearchSubmissionsPage.SearchAccountByAccountNumber(policy);
            Pages.SearchSubmissionsPage.ClickSearchResultByRowNumber(1);
        }
    }
}
