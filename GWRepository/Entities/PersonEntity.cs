using GWRepository.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class PersonEntity : BaseObjects.EntityBase
    {
        public PersonEntity()
        {
            // With no params, will default to set values
            Address = new AddressEntity();
            List<string> firstLastNames = new List<string>(Database.GetRandomColumns("[Words]", "Word", 2));

            //string TimestampToAddToNames = DateTime.Now.ToString();
            string TimestampToAddToNames = "scope creep";
            //if (firstLastNames[0].Length > 6)
            //    FirstName = (firstLastNames[0].Substring(0,5) + TimestampToAddToNames.Split(' ')[0]).Replace(" ", "").Replace("/", "").Replace(":", "");
            //else
            FirstName = (firstLastNames[0] + TimestampToAddToNames.Split(' ')[0]).Replace(" ", "").Replace("/", "").Replace(":", "").Replace("-", "");
            //if (firstLastNames[1].Length > 6)
            //    LastName = (firstLastNames[1].Substring(0, 5) + TimestampToAddToNames.Split(' ')[1]).Replace(" ", "").Replace("/", "").Replace(":", "");
            //else
                LastName = (firstLastNames[1] + TimestampToAddToNames.Split(' ')[1]).Replace(" ", "").Replace("/", "").Replace(":", "").Replace("-", "");

            if (FirstName.Length > 10)
                FirstName = FirstName.Substring(0, 10);
            if (LastName.Length > 10)
                LastName = LastName.Substring(0, 10);

            var DateOfBirthTemp = DateTime.Today.Subtract(new TimeSpan(10950, 0,0,0)).ToString().Split(' ')[0];
            DateOfBirth = StringUtilities.FixDateString(DateOfBirthTemp);

            TIN = "000000000";

            BusinessPhoneNumber = "";
            WorkPhoneNumber = "";
            HomePhoneNumber = "";
            MobilePhoneNumber = "";
            FaxPhoneNumber = "";
            CurrentAddressMoreThan6Months = false;
            NameChanged6Months = false;
        }

        public AddressEntity Address { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string TIN { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FaxPhoneNumber { get; set; }
        public bool CurrentAddressMoreThan6Months { get; set; }
        public bool NameChanged6Months { get; set; }
    }
}
