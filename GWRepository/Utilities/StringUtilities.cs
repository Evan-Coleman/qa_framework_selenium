using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Utilities
{
    public static class StringUtilities
    {
        public static string FixDateString(string date)
        {
            string DateToReturn = "";

            if (date.Split('/')[0].Length == 1)
                DateToReturn = "0" + DateToReturn + date.Split('/')[0] + "/";
            else
                DateToReturn = DateToReturn + date.Split('/')[0] + "/";

            if (date.Split('/')[1].Length == 1)
                DateToReturn = "0" + DateToReturn + date.Split('/')[1] + "/";
            else
                DateToReturn = DateToReturn + date.Split('/')[1] + "/";

            DateToReturn += date.Split('/')[2];

            return DateToReturn;
        }
    }
}
