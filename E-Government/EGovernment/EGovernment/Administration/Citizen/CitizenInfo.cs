using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EGovernment.Administration.Citizen
{
    public class CitizenInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherNationalNumber { get; set; }
        public string MotherNationalNumber { get; set; }
        public string NationalNumber { get; set; }
        public string Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string KiedPlace { get; set; }
        public string KiedNumber { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string SocialStatus { get; set; }
    }
}