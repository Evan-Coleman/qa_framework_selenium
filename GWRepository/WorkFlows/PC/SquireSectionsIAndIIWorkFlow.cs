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
    public class SquireSectionsIAndIIWorkFlow
    {
        public BaseObjects.PagesBase Pages { get; set; }

        public SquireSectionsIAndIIWorkFlow(BaseObjects.PagesBase pages)
        {
            Pages = pages;
        }

        public void FillOutSectionsIAndII(PolicyEntity myPolicyObject)
        {
            Pages.LocationSquireSectionIAndII.AddNewLocations(myPolicyObject.mySquireSectionsIAndII.LocationList, Pages);
            Pages.PropertyDetailSquireSectionIAndII.AddPropertyDetails(myPolicyObject, Pages); // TODO: Look into if this is needed for QQ
            Pages.CoveragesSquireSectionIAndII.FillOutcoverages(myPolicyObject.mySquireSectionsIAndII);
            Pages.CluePropertySectionIAndII.OrderClue();
        }
    }
}
