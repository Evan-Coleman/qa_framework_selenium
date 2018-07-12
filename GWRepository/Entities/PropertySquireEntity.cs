using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class PropertySquireEntity : BaseObjects.EntityBase
    {
        public PropertySquireEntity()
        {
            // With no params, will default to set values
            NumberOfUnitsInBuilding = "1";
            ManualPublicProtectionCode = "3";
            WoodFireplaceOrWoodStove = false;
            PropertyType = ResourcesBase.Enums.PropertyTypePL.ResidencePremises;
            Yearbuilt = "2015";
            ConstructionType = ResourcesBase.Enums.ConstructionType.Frame;
            Size = "1200";

            NumberOfStories = "1";
            BasementFinishedPercent = "100";
            Garage = ResourcesBase.Enums.GarageType.NoGarage;
            ShedLargerThan200 = false;
            CoveredEnclosedPorches = false;
            FoundationType = ResourcesBase.Enums.FoundationType.Foundation;
            RoofType = ResourcesBase.Enums.RoofType.SlateConcrete;
            KitchenClass = ResourcesBase.Enums.KitchenBathClass.Basic;
            BathClass = ResourcesBase.Enums.KitchenBathClass.Basic;
            DwellingVacant = false;
            SwimmingPool = false;
            WaterLeakage = false;
            ExoticAnimalsPets = false;

            InteriorSprinklerSystemType = ResourcesBase.Enums.InteriorSprinklerSystemType.Full;
            FireExtinguishers = true;
            SmokeAlarms = true;
            NonSmoker = true;
            DeadBoltLocks = true;
            DefensibleSpaceMaintained = true;

            // SECTION I COVERAGES
            CoverageALimit = "100000";
            CoverageAValuationMethod = ResourcesBase.Enums.ValuationMethod.ActualCashValue;
            CoverageACoverageType = ResourcesBase.Enums.CoverageType.BroadForm;
            CoverageCValuationMethod = ResourcesBase.Enums.ValuationMethod.ActualCashValue;
            CoverageCCoverageType = ResourcesBase.Enums.CoverageType.BroadForm;

        }

        public string OwnerFirstName { get; set; } // TODO: Implement this
        public string PropertyType { get; set; } // ENUM
        public string NumberOfUnitsInBuilding { get; set; }
        public string ManualPublicProtectionCode { get; set; }
        public bool WoodFireplaceOrWoodStove { get; set; }
        public string Yearbuilt { get; set; }
        public string ConstructionType { get; set; }
        public string Size { get; set; }
        public int PropertyNumber { get; set; }

        public string NumberOfStories { get; set; }
        public string BasementFinishedPercent { get; set; }
        public string Garage { get; set; }
        public bool ShedLargerThan200 { get; set; }
        public bool CoveredEnclosedPorches { get; set; }
        public string FoundationType { get; set; }
        public string RoofType { get; set; }
        public string KitchenClass { get; set; }
        public string BathClass { get; set; }

        public bool DwellingVacant { get; set; }
        public bool SwimmingPool { get; set; }
        public bool WaterLeakage { get; set; }
        public bool ExoticAnimalsPets { get; set; }

        public string InteriorSprinklerSystemType { get; set; }
        public bool FireExtinguishers { get; set; }
        public bool SmokeAlarms { get; set; }
        public bool NonSmoker { get; set; }
        public bool DeadBoltLocks { get; set; }
        public bool DefensibleSpaceMaintained { get; set; }

        // SECTION I COVERAGES
        public string CoverageALimit { get; set; }
        public string CoverageAValuationMethod { get; set; }
        public string CoverageACoverageType { get; set; }
        public string CoverageCValuationMethod { get; set; }
        public string CoverageCCoverageType { get; set; }
    }
}
