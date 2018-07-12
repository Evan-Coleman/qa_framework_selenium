using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class AddressEntity : BaseObjects.EntityBase
    {
        private Dictionary<string, string> _addressFromDatabase;
        public AddressEntity()
        {
            _addressFromDatabase = Database.GetColumnsFromRandomRow("[Addresses]", new List<string>() { "[Id]", "[Address]", "[City]", "[State]", "[Zip]", "[County]" });
            // With no params, will default to set values
            City = _addressFromDatabase["City"];
            AddressOne = _addressFromDatabase["Address"];
            State = _addressFromDatabase["State"];
            PostalCode = _addressFromDatabase["Zip"];
        }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressOne { get; set; }
        public string State { get; set; }
    }
}
