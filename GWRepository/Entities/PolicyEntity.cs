using GWRepository.BaseObjects;
using GWRepository.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Entities
{
    public class PolicyEntity : BaseObjects.EntityBase
    {
        public PolicyEntity()
        {
            // With no params, will default to set values
            PolicyMembers = new List<PersonEntity>() { new PersonEntity() }; // TODO: Making assumption that first member is PNI, maybe change this to a flag in the person class
            UserRole = ResourcesBase.Enums.UserRole.Underwriter;
            myUser = new UserEntity(UserRole);

            QuoteType = ResourcesBase.Enums.QuoteType.QuickQuote;
            ProductType = ResourcesBase.Enums.ProductType.Squire;
            SquireLines = new List<string>() { ResourcesBase.Enums.SquireLines.SectionsIAndII };
            RatingCounty = ResourcesBase.Enums.CountyIdaho.Bannock;
            OrganizationType = ResourcesBase.Enums.OrganizationType.Individual;
            TermType = ResourcesBase.Enums.TermType.Annual;
            NewSubmissionType = "Person";
            AgentNumber = Database.GetRandomColumns("[PC_AgentsMaster]", "AgentNum", 1)[0];
            SearchBySSNTIN = "";
            EffectiveDate = "09/12/2033";
            mySquireSectionsIAndII = new SquireSectionsIAndIIEntity();
            PropertyNumber = 1;
            PaymentPlanType = ResourcesBase.Enums.PaymentPlanType.Annual;
            DownPaymentType = ResourcesBase.Enums.DownPaymentType.Cash;
            IsDraft = false;

            // General Pre-Qualification Questions
            CanceledInsurance = false;
            BankruptcyFiled = false;
    }

        public List<PersonEntity> PolicyMembers { get; set; }
        public UserEntity myUser { get; set; }

        public string QuoteType { get; set; } // ENUM
        public string ProductType { get; set; } // ENUM
        public List<string> SquireLines { get; set; } // ENUM
        public string TermType { get; set; }
        public string OrganizationType { get; set; }
        public string RatingCounty { get; set; }
        public string NewSubmissionType { get; set; }
        public string AgentNumber { get; set; }
        public string SearchBySSNTIN { get; set; }
        public string EffectiveDate { get; set; } // TODO: Potentially change to DateTime
        public SquireSectionsIAndIIEntity mySquireSectionsIAndII { get; set; }
        public int PropertyNumber { get; set; }
        public string UserRole { get; set; }
        public bool IsDraft { get; set; }
        public string PaymentPlanType { get; set; }
        public string DownPaymentType { get; set; }
        public string AccountNumber { get; set; }
        public string PolicyNumber { get; set; }

        // General Pre-Qualification Questions
        public bool CanceledInsurance { get; set; }
        public bool BankruptcyFiled { get; set; }
    }
}

