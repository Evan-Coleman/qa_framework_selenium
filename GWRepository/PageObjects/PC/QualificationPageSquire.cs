using GWRepository.BaseObjects;
using GWRepository.Entities;
using GWRepository.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GWRepository.PageObjects.PC
{
    public class QualificationPageSquire : PageBase
    {
        public QualificationPageSquire(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        // General Pre-Qualification Questions SECTION
        private string radCanceledInsuranceQuestion = "//div[contains(text(), 'Have you ever had insurance cancelled, refused or declined?')]";
        private string radBankruptcyQuestion = "//div[contains(text(), 'Have you filed for bankruptcy in the last five (5) years?')]";

        // Section I - Property Pre-Qualification Questions SECTION
        private string radPropertyLossesQuestion = "//div[contains(text(), 'Have you had any property losses in the past three (3) years?')]";

        private string radPriorPropertyInsuranceQuestion = "//div[contains(text(), 'Have you had prior property insurance?')]";
        public IWebElement btnNoPriorInsuranceTextBoxArrow => _webDriver.FindElementByXPath("//table/tbody/tr/td[2]/div[contains(text(), 'Reason for no ')]/parent::td/following-sibling::td");
        public IWebElement btnCompanyAndPolicyNumberTextBoxArrow => _webDriver.FindElementByXPath("//table/tbody/tr/td[2]/div[contains(text(), 'List company and policy number')]/parent::td/following-sibling::td");
        public IWebElement txtPriorInsurance => _webDriver.FindElementByXPath("//table/tbody/tr/td[2]/textarea");

        private string radExistingDamageQuestion = "//div[contains(text(), 'Is there any existing damage to insured property?')]";
        private string radFloodInsuranceQuestion = "//div[contains(text(), 'Do you want flood insurance?')]";
        private string radBusinessConductedQuestion = "//div[contains(text(), 'Is there business conducted in any buildings?')]";

        // Section II - General Liability Pre-Qualification Questions SECTION
        private string radLiabilityLossesQuestion = "//div[contains(text(), 'Have you had any liability losses in the past three (3) years?')]";
        private string radSpecialHazardsQuestion = "//div[contains(text(), 'Any special hazards on premises such as water features, slides or zip-lines?')]";
        private string radManufacturingProcessingRetailingQuestion = "//div[contains(text(), 'Any manufacturing, processing, or retailing on premises?')]";
        private string radBoardOrPastureHorsesQuestion = "//div[contains(text(), \"Do you board or pasture other people's horses?\")]";
        private string radOwnLivestockQuestion = "//div[contains(text(), 'Do you own livestock?')]";
        #endregion

        #region Page Methods
        public bool FillOutQualifications(PolicyEntity myPolicyObject)
        {
            NavigateToPage();

            // General Pre-Qualification Questions SECTION
            sRadioSelect(radCanceledInsuranceQuestion, myPolicyObject.CanceledInsurance);
            sRadioSelect(radBankruptcyQuestion, myPolicyObject.BankruptcyFiled);

            // Section I - Property Pre-Qualification Questions SECTION
            sRadioSelect(radPropertyLossesQuestion, myPolicyObject.mySquireSectionsIAndII.PropertyLosses);

            sRadioSelect(radPriorPropertyInsuranceQuestion, myPolicyObject.mySquireSectionsIAndII.PriorPropertyInsurance);

            if (myPolicyObject.mySquireSectionsIAndII.PriorPropertyInsurance)
                btnCompanyAndPolicyNumberTextBoxArrow.Click();
            else
                btnNoPriorInsuranceTextBoxArrow.Click();

            sSendKeys(txtPriorInsurance, myPolicyObject.mySquireSectionsIAndII.ReasonForNoPriorInsurance);

            sRadioSelect(radExistingDamageQuestion, myPolicyObject.mySquireSectionsIAndII.ExistingDamage);
            sRadioSelect(radFloodInsuranceQuestion, myPolicyObject.mySquireSectionsIAndII.FloodInsurance);
            sRadioSelect(radBusinessConductedQuestion, myPolicyObject.mySquireSectionsIAndII.BusinessConducted);

            // Section II - General Liability Pre-Qualification Questions SECTION
            sRadioSelect(radLiabilityLossesQuestion, myPolicyObject.mySquireSectionsIAndII.LiabilityLosses);
            sRadioSelect(radSpecialHazardsQuestion, myPolicyObject.mySquireSectionsIAndII.SpecialHazards);
            sRadioSelect(radManufacturingProcessingRetailingQuestion, myPolicyObject.mySquireSectionsIAndII.ManufacturingProcessingRetailing);
            sRadioSelect(radBoardOrPastureHorsesQuestion, myPolicyObject.mySquireSectionsIAndII.BoardOrPastureHorses);
            sRadioSelect(radOwnLivestockQuestion, myPolicyObject.mySquireSectionsIAndII.OwnLivestock);

            return true;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("PreQualificationScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickQualification();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Qualifications page");
                    return false;
                }
            }
        }
        #endregion
    }
}
