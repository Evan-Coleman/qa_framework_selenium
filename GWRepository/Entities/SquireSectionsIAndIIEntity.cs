using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class SquireSectionsIAndIIEntity : BaseObjects.EntityBase
    {
        public SquireSectionsIAndIIEntity()
        {
            // With no params, will default to set values
            LocationList = new List<LocationSquireEntity>() { new LocationSquireEntity() };
            SectionIDeductibles = ResourcesBase.Enums.SectionIDeductables.d500;


            // Section I - Property Pre-Qualificiation Questions
            PropertyLosses = false;
            PriorPropertyInsurance = true;
            ReasonForNoPriorInsurance = "Grew up as a feral child";
            ExistingDamage = false;
            FloodInsurance = false;
            BusinessConducted = false;

            // Section II - General Liability Pre-Qualification Questions
            LiabilityLosses = false;
            SpecialHazards = false;
            ManufacturingProcessingRetailing = false;
            BoardOrPastureHorses = false;
            OwnLivestock = false;
        }

        public List<LocationSquireEntity> LocationList { get; set; }
        public string SectionIDeductibles { get; set; }

        // Section I - Property Pre-Qualificiation Questions
        public bool PropertyLosses { get; set; }
        public bool PriorPropertyInsurance { get; set; }
        public string ReasonForNoPriorInsurance { get; set; }
        public bool ExistingDamage { get; set; }
        public bool FloodInsurance { get; set; }
        public bool BusinessConducted { get; set; }

        // Section II - General Liability Pre-Qualification Questions
        public bool LiabilityLosses { get; set; }
        public bool SpecialHazards { get; set; }
        public bool ManufacturingProcessingRetailing { get; set; }
        public bool BoardOrPastureHorses { get; set; }
        public bool OwnLivestock { get; set; }
    }
}
