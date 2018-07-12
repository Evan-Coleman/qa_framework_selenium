using GWRepository.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class UserEntity : BaseObjects.EntityBase
    {
        public UserEntity()
        {
            // With no params, will default to set values
            UserName = "su";
            Password = "gw";
        }

        public UserEntity(string userRole)
        {
            if (userRole == ResourcesBase.Enums.UserRole.Agent)
                UserName = Database.GetRandomColumns("[PC_AgentsMaster]", "AgentUserName", 1)[0];
            else if (userRole == ResourcesBase.Enums.UserRole.Underwriter)
            {
                do
                {
                    UserName = Database.GetRandomColumns("[PC_UnderwritersMaster]", "UWUserName", 1)[0];
                } while (UserName == "jhurt");
            }
                
            else
                UserName = "su";

            Password = "gw";
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

