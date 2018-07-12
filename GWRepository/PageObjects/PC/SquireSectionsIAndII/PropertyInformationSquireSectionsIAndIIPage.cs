
using GWRepository.BaseObjects;
using GWRepository.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class PropertyInformationSquireSectionsIAndIIPage : PageBase
    {
        public PropertyInformationSquireSectionsIAndIIPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement labelTitleBar => _webDriver.FindElementByCssSelector("span[id*='HOBuilding_FBMPopup:ttlBar']");

        public IWebElement btnOk => _webDriver.FindElementByCssSelector("span[id*='Update-btnWrap']");
        public IWebElement btnCancel => _webDriver.FindElementByXPath("//a[contains(@id, 'Toolbar')]/descendant::span[contains(text(), 'Cancel')]");

        public IWebElement btnTabDetails => _webDriver.FindElementByCssSelector("span[id*='DwellingDetailsSingleIDTab-btnWrap']");
        public IWebElement btnTabPropertyConstruction => _webDriver.FindElementByCssSelector("span[id*='propertyConstructionTab-btnInnerEl']");
        public IWebElement btnTabProtectionDetails => _webDriver.FindElementByCssSelector("span[id*='DwellingSingleProtectionIdTab-btnInnerEl']");

        // DETAILS TAB SECTION
        public IWebElement btnSearchPropertyType => _webDriver.FindElementByCssSelector("div[id*='SelectpropertyType']");
        public IWebElement selManualPublicProtectionClassCode => _webDriver.FindElementByCssSelector("input[id*='ISRBFireProtectionClassManual']");
        private string radDwellingVacant = "//label[contains(@id, 'DwellingVacant-labelEl')]";
        public IWebElement selNumberOfUnitsInBuilding => _webDriver.FindElementByCssSelector("input[id*='NumUnits']");
        private string radWoodFireplaceOrWoodStove = "//label[contains(@id, 'FireWoodStove-labelEl')]";
        private string radSwimmingPool = "//label[contains(@id, 'SwimmingPool-labelEl')]";
        private string radWaterLeakage = "//label[contains(@id, 'WaterLeakage-labelEl')]";
        private string radExoticAnimalsPets = "//label[contains(@id, 'AnyAnimals-labelEl')]";

        public IWebElement btnDwellingOwnerAddExistingArrow => _webDriver.FindElementByCssSelector("span[id*='DwellingOwnerLV_tb:AddContactsButton-btnWrap']");
        public IWebElement btnAddExistingPolicyMembersArrow => _webDriver.FindElementByCssSelector("span[id*='DwellingOwnerLV_tb:AddContactsButton:AddExistingContact-textEl']");

        // PROPERTY CONSTRUCTION TAB SECTION
        public IWebElement txtYearBuilt => _webDriver.FindElementByCssSelector("input[id*='YearBuilt']");
        public IWebElement selConstructionType => _webDriver.FindElementByCssSelector("input[id*='ConstructionType']");
        public IWebElement txtSize => _webDriver.FindElementByCssSelector("input[id*='ApproxSqFoot']");
        public IWebElement selNumberOfStories => _webDriver.FindElementByCssSelector("input[id*='NumStories']");
        public IWebElement txtBasementPercentFinished => _webDriver.FindElementByCssSelector("input[id*='BasementPercentComplete']");
        public IWebElement selGarage => _webDriver.FindElementByCssSelector("input[id*='Garage']");
        private string radShedLargerThan200 = "//label[contains(text(), 'Is there a shed larger than 200 sq. ft. at this location?')]";
        private string radCoveredEnclosedPorches => "//label[contains(text(), 'Any covered/enclosed porches, patios, breezeways?')]";
        public IWebElement selFoundationType => _webDriver.FindElementByCssSelector("input[id*='FoundationType']");
        public IWebElement selRoofType => _webDriver.FindElementByCssSelector("input[id*='RoofType']");
        public IWebElement selKitchenClass => _webDriver.FindElementByCssSelector("input[id*='KitchenClass']");
        public IWebElement selBathClass => _webDriver.FindElementByCssSelector("input[id*='BathClass']");

        // PROTECTION DETAILS TAB SECTION
        public IWebElement selSprinklerSystemType => _webDriver.FindElementByCssSelector("input[id*='SprinklerSystemType-inputEl']");
        private string radFireExtinguishers = "//label[contains(text(), 'One or more fire extinguishers in the home?')]";
        private string radSmokeAlarms = "//label[contains(text(), 'Smoke Alarms')]";
        private string radNonSmoker = "//label[contains(text(), 'Non Smoker')]";
        private string radDeadBoltLocks = "//label[contains(text(), 'Dead bolt locks')]";
        private string radDefensibleSpace = "//label[contains(text(), 'Is defensible space maintained')]";

        #endregion

        #region Page Methods

        public bool FillOutPropertyDetails(PropertySquireEntity property, PolicyEntity policy)
        {
            if (!IsAt())
                return false;
            sClick(btnSearchPropertyType);
            sClick(_webDriver.FindElementByXPath($"//span[text()='{property.PropertyType}']/parent::td/preceding-sibling::td/a[@class='miniButton']"));
            sSelectorSelect(selManualPublicProtectionClassCode, property.ManualPublicProtectionCode);
            sSelectorSelect(selNumberOfUnitsInBuilding, property.NumberOfUnitsInBuilding); // TODO: Watch, may need a separate variable for this
            sRadioSelect(radWoodFireplaceOrWoodStove, property.WoodFireplaceOrWoodStove);

            if (policy.QuoteType != ResourcesBase.Enums.QuoteType.QuickQuote)
            {
                sRadioSelect(radDwellingVacant, property.DwellingVacant);
                sRadioSelect(radSwimmingPool, property.SwimmingPool);
                sRadioSelect(radWaterLeakage, property.WaterLeakage);
                sRadioSelect(radExoticAnimalsPets, property.ExoticAnimalsPets);

                sClick(btnDwellingOwnerAddExistingArrow); // TODO: When property owner gets implemented, change here
                sClick(btnAddExistingPolicyMembersArrow);
                sClick(_webDriver.FindElementByXPath($"//span[contains(text(), '{policy.PolicyMembers[0].FirstName}')][contains(@id, 'ExistingDwellingOwner')]"));
            }

            sClick(btnTabPropertyConstruction);
            sSendKeys(txtYearBuilt, property.Yearbuilt);
            sSelectorSelect(selConstructionType, property.ConstructionType);
            sSendKeys(txtSize, property.Size);

            if (policy.QuoteType != ResourcesBase.Enums.QuoteType.QuickQuote)
            {
                sSelectorSelect(selNumberOfStories, property.NumberOfStories);
                sSendKeys(txtBasementPercentFinished, property.BasementFinishedPercent);
                sSelectorSelect(selGarage, property.Garage);
                sRadioSelect(radShedLargerThan200, property.ShedLargerThan200);
                sRadioSelect(radCoveredEnclosedPorches, property.CoveredEnclosedPorches);
                sSelectorSelect(selFoundationType, property.FoundationType);
                sSelectorSelect(selRoofType, property.RoofType);
                sAltSelectorSelect(selKitchenClass, property.KitchenClass); // Special case for same input set
                sAltSelectorSelect(selBathClass, property.BathClass); // Special case for same input set

                sClick(btnTabProtectionDetails);
                sSelectorSelect(selSprinklerSystemType, property.InteriorSprinklerSystemType);
                sRadioSelect(radFireExtinguishers, property.FireExtinguishers);
                sRadioSelect(radSmokeAlarms, property.SmokeAlarms);
                sRadioSelect(radNonSmoker, property.NonSmoker);
                sRadioSelect(radDeadBoltLocks, property.DeadBoltLocks);
                sRadioSelect(radDefensibleSpace, property.DefensibleSpaceMaintained);
            }
            return sClick(btnOk);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("Property Information");
        }
        #endregion
    }
}
