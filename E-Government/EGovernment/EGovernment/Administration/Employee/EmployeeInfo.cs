using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGovernment.Administration.Employee
{
    public class EmployeeInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public DateTime S_Date { get; set; }
        public DateTime E_Date { get; set; }
        public string Rank { get; set; }
        public string CivilAffairs { get; set; }
        public string CivilRegistry { get; set; }
        public string Role { get; set; }
        public bool IsWorking { get; set; }
    }
}
