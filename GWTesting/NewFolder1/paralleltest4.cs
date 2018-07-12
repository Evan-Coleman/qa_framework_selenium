using GWRepository.BaseObjects;
using NUnit.Framework;
using GWRepository.WorkFlows.PC;
using GWRepository.Entities;
using GWRepository.Utilities;
using OpenQA.Selenium;

namespace GWTesting
{
    [TestFixture, Parallelizable]
    public class paralleltest4 : TestBase
    {
        [Test]
        public void TestGenerateWithMultipleLocationsAndProperties()
        {
            PolicyEntity myPolicyObject = new PolicyEntity()
            {
                QuoteType = ResourcesBase.Enums.QuoteType.PolicySubmitted
            };

            base.Initialize(ResourcesBase.Enums.CenterType.PC);

            var loc = new LocationSquireEntity();
            loc.PropertyList.Add(new PropertySquireEntity());
            loc.PropertyList[0].Size = "5000";
            loc.Address.AddressOne = "132 N Main";
            loc.NumberOfResidence = "2";
            loc.PropertyList[0].Yearbuilt = "1950";

            myPolicyObject.mySquireSectionsIAndII.LocationList.Add(loc);

            WorkFlows.GeneratePolicyWorkFlow.DefaultGenerate(WorkFlows, myPolicyObject);
        }
    }
}
