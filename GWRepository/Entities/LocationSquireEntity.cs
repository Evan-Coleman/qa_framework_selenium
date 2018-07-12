using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class LocationSquireEntity : BaseObjects.EntityBase
    {
        public LocationSquireEntity()
        {
            // With no params, will default to set values
            Address = new AddressEntity();
            LocationName = "Default Location";
            Acres = "1";
            NumberOfResidence = "1";
            PropertyList = new List<PropertySquireEntity>() { new PropertySquireEntity() };
        }

        public string LocationName { get; set; }
        public AddressEntity Address { get; set; }
        public string Acres { get; set; }
        public string NumberOfResidence { get; set; }
        public List<PropertySquireEntity> PropertyList { get; set; }
        public int LocationNumber { get; set; }
    }
}
