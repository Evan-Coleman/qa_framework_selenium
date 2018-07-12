using GWRepository.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.BaseObjects
{
    public class EntityBase
    {
        public EntityBase()
        {
            Database = new DatabaseUtilities();
        }

        public DatabaseUtilities Database { get; set; }
    }
}
