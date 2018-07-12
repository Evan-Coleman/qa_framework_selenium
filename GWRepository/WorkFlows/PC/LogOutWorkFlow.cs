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
    public class LogOutWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public LogOutWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void DefaultLogOut()
        {
            Pages.pcTopMenu.LogOut();
        }
    }
}
