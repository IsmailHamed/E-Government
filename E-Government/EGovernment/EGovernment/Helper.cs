using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EGovernment
{
    public class Helper
    {
        public static List<tblCitizen> GetCitizens()
        {
            SyncCitizens();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblCitizens.ToList();
            }
        }

        public static tblCitizen GetCitizen(string NationalNumber)
        {
            SyncCitizens();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblCitizens.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();
            }
        }

        public static void SyncCitizens()
        {
            List<tblCitizen> lstCitizens = RestHelper.GetCitizens();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                foreach (tblCitizen citizen in lstCitizens)
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == citizen.NationalNumber).ToList().Count == 0)
                    {
                        db.tblCitizens.AddObject(citizen);
                        db.SaveChanges();
                    }
                    else
                    {
                        tblCitizen _tblCitizen = db.tblCitizens.Where(x => x.NationalNumber == citizen.NationalNumber).FirstOrDefault();
                        _tblCitizen.FirstName = citizen.FirstName;
                        _tblCitizen.LastName = citizen.LastName;
                        _tblCitizen.FatherNationalNumber = citizen.FatherNationalNumber;
                        _tblCitizen.MotherNationalNumber = citizen.MotherNationalNumber;
                        _tblCitizen.Birthday = citizen.Birthday;
                        _tblCitizen.BirthPlace = citizen.BirthPlace;
                        _tblCitizen.KiedPlace = citizen.KiedPlace;
                        _tblCitizen.KiedNumber = citizen.KiedNumber;
                        _tblCitizen.Gender = citizen.Gender;

                        db.SaveChanges();
                    }
                }
            }
        }

        public static List<tblCitizen> GetCitizensByFatherNationalNumber(string NationalNumber)
        {
            SyncCitizens();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblCitizens.Where(x => x.FatherNationalNumber == NationalNumber).ToList();
            }
        }

        public static tblRole GetEmployeeRole(string NationalNumber)
        {
            tblRole role = null;
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblEmployeesCivilRegistry employeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == NationalNumber).Where(y => y.E_date == null).FirstOrDefault();
                if (employeesCivilRegistry != null)
                    role = db.tblRoles.Where(x => x.Id == employeesCivilRegistry.RoleId).FirstOrDefault();
            }

            return role;
        }

        public static List<string> GetChildren(Gender gender, string FatherNationalNumber, string MotherNationalNumber)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var Children = db.tblCitizens.Where(x => x.FatherNationalNumber == FatherNationalNumber).Where(y => y.MotherNationalNumber == MotherNationalNumber).ToList();
                if (Children != null)
                {
                    switch (gender)
                    {
                        case Gender.Male:
                            return Children.Where(x => x.Gender == "1").Select(y => y.NationalNumber).ToList();

                        case Gender.Female:
                            return Children.Where(x => x.Gender == "0").Select(y => y.NationalNumber).ToList();

                        case Gender.All:
                            return Children.Select(y => y.NationalNumber).ToList();
                    }
                }
            }
            return new List<string>();
        }

        public static List<string> GetSibiling(Gender gender, string NationalNumber)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var citizen = GetCitizen(NationalNumber);
                if (citizen != null)
                {
                    var citizens = GetCitizensByFatherNationalNumber(citizen.FatherNationalNumber);
                    switch (gender)
                    {
                        case Gender.Male:
                            return citizens.Where(x => x.Gender == "1").Select(y => y.NationalNumber).ToList();

                        case Gender.Female:
                            return citizens.Where(x => x.Gender == "0").Select(y => y.NationalNumber).ToList();

                        case Gender.All:
                            return citizens.Select(y => y.NationalNumber).ToList();
                    }
                }
            }
            return new List<string>();
        }

        public static List<string> GetForbidden(string NationalNumber)
        {
            List<string> lstForbidden = new List<string>();
            //خالة عمة أم ست أخت
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizen citizen = GetCitizen(NationalNumber);

                if (citizen != null)
                {
                    if (citizen.Gender == "1") // ذكر
                    {
                        var mother = GetCitizen(citizen.MotherNationalNumber);
                        if (mother != null)
                            lstForbidden.AddRange(GetSibiling(Gender.Female, mother.NationalNumber)); // خالاته

                        var father = GetCitizen(citizen.FatherNationalNumber);
                        if (father != null)
                            lstForbidden.AddRange(GetSibiling(Gender.Female, father.NationalNumber)); // عماته

                        lstForbidden.Add(mother.NationalNumber); // الأم

                        lstForbidden.AddRange(GetSibiling(Gender.Female, NationalNumber)); // الأخوات

                        var grandMother = GetCitizen(mother.MotherNationalNumber);
                        if (grandMother != null)
                            lstForbidden.Add(grandMother.NationalNumber); // الجدة
                    }
                    else // أنثى
                    {
                        var mother = GetCitizen(citizen.MotherNationalNumber);
                        if (mother != null)
                            lstForbidden.AddRange(GetSibiling(Gender.Male, mother.NationalNumber)); // خوالها

                        var father = GetCitizen(citizen.FatherNationalNumber);
                        if (father != null)
                        {
                            lstForbidden.AddRange(GetSibiling(Gender.Male, father.NationalNumber)); // عمومها

                            lstForbidden.Add(father.NationalNumber); // الأب

                            var grandFather = GetCitizen(father.MotherNationalNumber);
                            if (grandFather != null)
                                lstForbidden.Add(grandFather.NationalNumber); // الجد
                        }

                        lstForbidden.AddRange(GetSibiling(Gender.Male, NationalNumber)); // الأخوة

                    }
                }
            }

            return lstForbidden;
        }

        public static bool CheckAge(string NationalNumber, int minAge)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizen citizen = GetCitizen(NationalNumber);

                var today = DateTime.Today;

                var age = today.Year - DateTime.Parse(citizen.Birthday).Year;

                if (age < minAge)
                    res = false;
                else
                    res = true;
            }

            return res;
        }

        public static bool CheckIsWife(string HusbandNationalNum, string WifeNationalNum)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContracts = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentDate).FirstOrDefault();
                tblDivorceIncident divorceIncidents = db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentDate).FirstOrDefault();

                if (divorceIncidents == null && marriageContracts != null)
                    res = true;

                if (marriageContracts != null && divorceIncidents != null)
                    res = GetDate(marriageContracts.IncidentDate) > GetDate(divorceIncidents.IncidentDate);
            }

            return res;
        }

        public static bool IsMarriageBeforeDivorce(string HusbandNationalNum, string WifeNationalNum, string IncidentDate)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblDivorceIncident divorceIncidents = db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentDate).FirstOrDefault(); // آخر واقعة طلاق

                if (divorceIncidents == null)
                    return false;

                res = GetDate(divorceIncidents.IncidentDate) > GetDate(IncidentDate);
            }

            return res;
        }

        public static bool IsDivorceBeforeMarriage(string HusbandNationalNum, string WifeNationalNum, string IncidentDate)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContracts = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentDate).FirstOrDefault(); // آخر واقعة زواج

                res = GetDate(IncidentDate) < GetDate(marriageContracts.IncidentDate);
            }

            return res;
        }

        public static int GetPenalty(string NationalNumber, int Days, IncidentType _IncidentType) // الغرامة
        {
            int penalty = 0;

            if (string.IsNullOrEmpty(NationalNumber))
                return 0;

            switch (_IncidentType)
            {
                case IncidentType.Marriage:
                case IncidentType.Divorce:
                case IncidentType.Death:
                    if (Days > 30 && Days < 365)
                        penalty = 3000;
                    else if (Days > 365)
                        penalty = 10000;
                    break;


                case IncidentType.Birth:
                    int years = (Days / 365);

                    if (Days > 30 && Days < 365)
                        penalty = 3000;
                    else if (years > 1 && years < 18)
                        penalty = 10100;
                    else if (years > 18)
                        penalty = 15100;
                    break;

                default:
                    penalty = 100;
                    break;
            }

            return penalty;
        }

        public static bool CheckDuration(string HusbandNationalNum, string WifeNationalNum, int Days, IncidentType _IncidentType)
        {
            bool res = true;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                switch (_IncidentType)
                {
                    case IncidentType.Divorce:
                        tblDivorceIncident divorceIncident = GetLastDivorceIncident(HusbandNationalNum, WifeNationalNum);
                        if (divorceIncident != null)
                            res = (DateTime.Now - DateTime.Parse(divorceIncident.IncidentDate)).TotalDays >= Days;
                        break;

                    case IncidentType.Death:
                        tblMarriageContract marriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentNumber).FirstOrDefault();
                        if (marriageContract != null)
                        {
                            if (IsDead(marriageContract.HusbandNationalNum))
                            {
                                tblDeadRegistration deadRegistration = db.tblDeadRegistrations.Where(x => x.NationalNumber == HusbandNationalNum).FirstOrDefault();
                                if (deadRegistration != null)
                                {
                                    res = (DateTime.Now - DateTime.Parse(deadRegistration.DeadDate)).TotalDays >= Days;
                                }
                            }
                        }
                        break;
                }
            }

            return res;
        }

        // لمعرفة فيما إذا كان المواطن متزوج أم لا
        private static tblMarriageContract GetLastMarriageContract(string NationalNum)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract husbandMarriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == NationalNum).OrderByDescending(z => z.IncidentNumber).FirstOrDefault();

                if (husbandMarriageContract != null)
                    if (!IsDivorced(husbandMarriageContract.HusbandNationalNum, husbandMarriageContract.WifeNationalNum))
                        return husbandMarriageContract;
                    else
                        return null;


                tblMarriageContract wifeMarriageContract = db.tblMarriageContracts.Where(x => x.WifeNationalNum == NationalNum).OrderByDescending(z => z.IncidentNumber).FirstOrDefault();

                if (wifeMarriageContract != null)
                    if (!IsDivorced(wifeMarriageContract.HusbandNationalNum, wifeMarriageContract.WifeNationalNum))
                        return wifeMarriageContract;
                    else
                        return null;
            }

            return null;
        }

        private static tblMarriageContract GetLastMarriageContract(string HusbandNationalNum, string WifeNationalNum)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentNumber).FirstOrDefault();

                if (marriageContract == null)
                    return null;

                //if (!IsDivorced(marriageContract.HusbandNationalNum, marriageContract.WifeNationalNum))
                return marriageContract;
                //else
                //return null;
            }
        }

        private static tblDivorceIncident GetLastDivorceIncident(string HusbandNationalNum, string WifeNationalNum)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNum).Where(y => y.WifeNationalNum == WifeNationalNum).OrderByDescending(z => z.IncidentDate).FirstOrDefault();
            }
        }

        public static bool IsDivorced(string HusbandNationalNum, string WifeNationalNum)
        {
            tblMarriageContract marriageContract = GetLastMarriageContract(HusbandNationalNum, WifeNationalNum);

            if (marriageContract == null)
                return false;


            return IsMarriageBeforeDivorce(HusbandNationalNum, WifeNationalNum, marriageContract.IncidentDate);
        }

        public static bool IsWidow(string WifeNationalNum)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContract = db.tblMarriageContracts.Where(x => x.WifeNationalNum == WifeNationalNum).OrderByDescending(y => y.IncidentNumber).FirstOrDefault();

                if (marriageContract != null)
                    res = IsDead(marriageContract.HusbandNationalNum);
            }

            return res;
        }

        public static bool IsDead(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblDeadRegistrations.Where(x => x.NationalNumber == NationalNumber).ToList().Count > 0;
            }

            return res;
        }

        public static bool HasBalance(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblBalance balance = db.tblBalances.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();

                res = balance != null;
            }

            return res;
        }

        public static void AddBalance(string NationalNumber, int Balance)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblBalance balance = new tblBalance();
                balance.NationalNumber = NationalNumber;
                balance.Balance = Balance;

                db.tblBalances.AddObject(balance);

                db.SaveChanges();
            }
        }

        public static void CheckBalances(int Balance)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                foreach (tblCitizen citizen in db.tblCitizens)
                {
                    if (!HasBalance(citizen.NationalNumber))
                        AddBalance(citizen.NationalNumber, Balance);
                }
            }
        }

        public static bool CheckBalance(string NationalNumber, int Penalty)
        {
            bool res = false;

            if (string.IsNullOrEmpty(NationalNumber))
                return true;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblBalance balance = db.tblBalances.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();

                if (balance != null)
                {
                    res = balance.Balance > Penalty; // الميزانية أكبر من الغرامة
                }
            }

            return res;
        }

        public static void Pay(string NationalNumber, int Penalty)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblBalance balance = db.tblBalances.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();

                if (balance != null)
                    balance.Balance = balance.Balance - Penalty;

                db.SaveChanges();
            }
        }

        public static bool IsEmployee(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblEmployeesCivilRegistry employee = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == NationalNumber).OrderByDescending(x => x.Id).FirstOrDefault();

                if (employee != null)
                {
                    res = employee.E_date == null;
                }
            }

            return res;
        }

        public static List<tblEmployee> GetEmployeeByAffairs(int CivilRegistryID)
        {
            List<tblEmployee> lstEmployees = new List<tblEmployee>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryID).FirstOrDefault(); // جلب السجل المدني الموافق رقمه لل CivilRegistryID

                tblCivilAffair civilAffair = db.tblCivilAffairs.Where(x => x.Id == civilRegistry.CivilAffairsID).FirstOrDefault(); // جلب الشؤون المدنية التي رقمها موافق لرقم السجل المدني civilRegistry

                List<tblCivilRegistry> lstCivilRegistry = db.tblCivilRegistries.Where(x => x.CivilAffairsID == civilAffair.Id).ToList(); // جلب السجلات المدنية التابعة لهذه الشؤون المدنية civilAffair

                foreach (tblCivilRegistry item in lstCivilRegistry) // جلب موظفين السجلات المدنية التالية lstCivilRegistry
                {
                    List<tblEmployeesCivilRegistry> lstEmployeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.CivilRegistryID == item.Id).ToList(); // جلب سجلات كسر الموظفين للسجل المدني item

                    foreach (var subitem in lstEmployeesCivilRegistry)
                    {
                        if (subitem.E_date == null) // الموظف يعمل
                        {
                            tblEmployee emp = db.tblEmployees.Where(x => x.NationalNumber == subitem.EmployeNationalNumber).FirstOrDefault();
                            if (emp != null)
                                lstEmployees.Add(emp);
                        }
                    }
                }
            }

            return lstEmployees;
        }

        public static void UnManager(List<tblEmployee> lstEmployees)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                foreach (tblEmployee emp in lstEmployees)
                {
                    tblEmployeesCivilRegistry employeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == emp.NationalNumber).Where(y => y.E_date == null).FirstOrDefault();

                    employeesCivilRegistry.IsManager = false;
                }
                db.SaveChanges();
            }
        }

        public static string CivilRegistry(int? CivilRegistryNum)
        {
            string res = string.Empty;

            if (CivilRegistryNum == null)
                return string.Empty;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var temp = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryNum).FirstOrDefault();
                if (temp != null)
                    res = temp.Name;
            }

            return res;
        }

        public static int CivilAffairId(string CivilAffairName)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblCivilAffairs.Where(x => x.Name == CivilAffairName).FirstOrDefault().Id;
            }
        }

        public static string CivilAffairs(int? CivilRegistryNum)
        {
            string res = string.Empty;

            if (CivilRegistryNum == null)
                return string.Empty;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var temp = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryNum).FirstOrDefault();
                if (temp != null)
                {
                    var CivilAffair = db.tblCivilAffairs.Where(x => x.Id == temp.CivilAffairsID).FirstOrDefault();
                    if (CivilAffair != null)
                        res = CivilAffair.Name;
                }
            }

            return res;
        }

        public static string GetAffairsNameByEmp(object CurrUser)
        {
            string res = string.Empty;

            try
            {
                tblEmployee emp = (tblEmployee)CurrUser;

                tblEmployeesCivilRegistry employeesCivilRegistry = GetCivilRegistryEmployee(emp.NationalNumber);

                if (employeesCivilRegistry != null)
                {
                    using (EGovernmentEntities db = new EGovernmentEntities())
                    {
                        tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == employeesCivilRegistry.CivilRegistryID).FirstOrDefault();

                        if (civilRegistry != null)
                        {
                            tblCivilAffair civilAffair = db.tblCivilAffairs.Where(x => x.Id == civilRegistry.CivilAffairsID).FirstOrDefault();

                            if (civilAffair != null)
                                res = civilAffair.Name;
                        }
                    }
                }
            }
            catch { res = "دمشق"; }

            return res;
        }

        public static string GetAmanaNameByEmp(object CurrUser)
        {
            string res = string.Empty;

            try
            {
                tblEmployee emp = (tblEmployee)CurrUser;

                tblEmployeesCivilRegistry employeesCivilRegistry = GetCivilRegistryEmployee(emp.NationalNumber);

                if (employeesCivilRegistry != null)
                {
                    using (EGovernmentEntities db = new EGovernmentEntities())
                    {
                        tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == employeesCivilRegistry.CivilRegistryID).FirstOrDefault();
                        if (civilRegistry != null)
                            res = civilRegistry.Name;
                    }
                }
            }
            catch { res = "الأمانة المركزية"; }

            return res;
        }

        public static string GetControllerNameByEmp(object CurrUser)
        {
            string res = string.Empty;

            try
            {
                tblEmployee emp = (tblEmployee)CurrUser;

                tblEmployeesCivilRegistry employeesCivilRegistry = GetCivilRegistryEmployee(emp.NationalNumber);

                if (employeesCivilRegistry != null)
                    res = GetCivilControllerById(Convert.ToInt32(employeesCivilRegistry.CivilRegistryID));
            }
            catch { res = "محمد حامد"; }

            return res;
        }

        private static string GetCivilControllerById(int CivilRegistryID)
        {
            string res = string.Empty;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryID).FirstOrDefault();

                if (civilRegistry != null)
                {
                    List<tblEmployeesCivilRegistry> lstEmployeesCivilRegistry = GetCivilRegistryEmployeesById(civilRegistry.Id);

                    foreach (var item in lstEmployeesCivilRegistry)
                    {
                        if (item.IsController == true)
                        {
                            tblCitizen temp = GetCitizen(db.tblEmployees.Where(x => x.NationalNumber == item.EmployeNationalNumber).FirstOrDefault().NationalNumber);

                            if (temp != null)
                                res = string.Format("{0} {1}", temp.FirstName, temp.LastName);

                            break;
                        }
                    }
                }
            }

            return res;
        }

        public static string GetCivilRegistrarByEmp(object CurrUser)
        {
            string res = string.Empty;

            try
            {
                tblEmployee emp = (tblEmployee)CurrUser;

                tblEmployeesCivilRegistry employeesCivilRegistry = GetCivilRegistryEmployee(emp.NationalNumber);

                if (employeesCivilRegistry != null)
                    res = GetCivilRegistrarById(Convert.ToInt32(employeesCivilRegistry.CivilRegistryID));
            }
            catch { res = "نزار المسعود"; }

            return res;
        }

        public static string GetCivilRegistrarById(int CivilRegistryID)
        {
            string res = string.Empty;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryID).FirstOrDefault();

                if (civilRegistry != null)
                {
                    List<tblEmployeesCivilRegistry> lstEmployeesCivilRegistry = GetCivilRegistryEmployeesById(civilRegistry.Id);

                    foreach (var item in lstEmployeesCivilRegistry)
                    {
                        if (item.IsCivilRegisterer == true)
                        {
                            tblCitizen temp = GetCitizen(db.tblEmployees.Where(x => x.NationalNumber == item.EmployeNationalNumber).FirstOrDefault().NationalNumber);

                            if (temp != null)
                                res = string.Format("{0} {1}", temp.FirstName, temp.LastName);

                            break;
                        }
                    }
                }
            }

            return res;
        }

        private static List<tblEmployeesCivilRegistry> GetCivilRegistryEmployeesById(int CivilRegistryId)
        {
            List<tblEmployeesCivilRegistry> lstEmployeesCivilRegistry = new List<tblEmployeesCivilRegistry>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                lstEmployeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.CivilRegistryID == CivilRegistryId).Where(y => y.E_date == null).ToList();
            }

            return lstEmployeesCivilRegistry;
        }

        public static tblEmployeesCivilRegistry GetCivilRegistryEmployee(string NationalNumber)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == NationalNumber).OrderByDescending(y => y.Id).Where(z => z.E_date == null).FirstOrDefault();
            }
        }

        public static List<tblEmployee> GetEmployeeByCivilRegisterar(int CivilRegistryID)
        {
            List<tblEmployee> lstEmployees = new List<tblEmployee>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCivilRegistry civilRegistry = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryID).FirstOrDefault(); // جلب السجل المدني الموافق رقمه لل CivilRegistryID

                List<tblEmployeesCivilRegistry> lstEmployeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.CivilRegistryID == civilRegistry.Id).ToList(); // جلب سجلات كسر الموظفين للسجل المدني civilRegistry

                foreach (var subitem in lstEmployeesCivilRegistry)
                {
                    if (subitem.E_date == null) // الموظف يعمل
                    {
                        tblEmployee emp = db.tblEmployees.Where(x => x.NationalNumber == subitem.EmployeNationalNumber).FirstOrDefault();
                        if (emp != null)
                            lstEmployees.Add(emp);
                    }
                }
            }

            return lstEmployees;
        }

        public static void UnCivilRegisterer(List<tblEmployee> lstEmployees)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                foreach (tblEmployee emp in lstEmployees)
                {
                    tblEmployeesCivilRegistry employeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == emp.NationalNumber).Where(y => y.E_date == null).FirstOrDefault();

                    employeesCivilRegistry.IsCivilRegisterer = false;
                }
                db.SaveChanges();
            }
        }

        public static void UnController(List<tblEmployee> lstEmployees)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                foreach (tblEmployee emp in lstEmployees)
                {
                    tblEmployeesCivilRegistry employeesCivilRegistry = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == emp.NationalNumber).Where(y => y.E_date == null).FirstOrDefault();

                    employeesCivilRegistry.IsController = false;
                }
                db.SaveChanges();
            }
        }

        public static bool HasAtleastOneDivorce(string HusbandNationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                res = db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNumber).ToList().Count > 0;
            }

            return res;
        }

        public static tblRole GetRoleById(int? RoleId)
        {
            tblRole role = null;

            if (RoleId != null)
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    role = db.tblRoles.Where(x => x.Id == RoleId).FirstOrDefault();
                }

            return role;
        }

        public static string GetRank(tblEmployeesCivilRegistry tblEmployeesCivilRegistry)
        {
            string rank = string.Empty;

            if (tblEmployeesCivilRegistry.IsManager == true)
                rank = "مدير";
            else if (tblEmployeesCivilRegistry.IsController == true)
                rank = "مراقب";
            else if (tblEmployeesCivilRegistry.IsCivilRegisterer == true)
                rank = "أمين السجل المدني";
            else
                rank = "موظف عادي";
            return rank;
        }

        public static int CivilRegistryId(string CivilRegistryName)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblCivilRegistries.Where(x => x.Name == CivilRegistryName).FirstOrDefault().Id;
            }
        }

        public static int GetRoleId(string RoleName)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblRoles.Where(x => x.Name == RoleName).FirstOrDefault().Id;
            }
        }

        public static tblEmployee GetEmployeeByNationalNumber(string NationalNumber)
        {
            tblEmployee emp = new tblEmployee();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                emp = db.tblEmployees.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();
            }

            return emp;
        }

        public static bool IsHusbandMarried(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                res = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == NationalNumber).ToList().Count > 0;
            }

            return res;
        }

        public static bool IsWifeMarried(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                res = db.tblMarriageContracts.Where(x => x.WifeNationalNum == NationalNumber).ToList().Count > 0;
            }

            return res;
        }

        public static DateTime GetDate(string date)
        {
            return DateTime.Parse(date, new CultureInfo("en-us"));
        }

        public static string GetNationalNumber(EGovernmentEntities db, List<string> lstNationalNumbers)
        {
            Random r = new Random();
            string nationalNum = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();

            try
            {
                while (db.tblCitizens.Where(x => x.NationalNumber == nationalNum).ToList().Count > 0 || lstNationalNumbers.Contains(nationalNum))
                    nationalNum = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();
            }
            catch { }

            return nationalNum;
        }

        public static bool CheckPregnancy(string Pregnancy)
        {
            bool res = false;

            try
            {
                int num = Convert.ToInt32(Pregnancy);

                res = num >= 1 && num <= 9;
            }
            catch { }

            return res;
        }

        public static bool CheckUserName(string UserName)
        {
            bool res = false;
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblUser user = db.tblUsers.Where(x => x.Username == UserName).FirstOrDefault();
                if (user != null)
                    return true;
            }
            return res;
        }

        public static bool CheckPassWord(string Password, string UserName)
        {
            bool res = false;
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblUser user = db.tblUsers.Where(x => x.Username == UserName).FirstOrDefault();
                if (user != null)
                    return res = user.Password.Equals(Password);
            }
            return res;

        }

        public static bool CheckIsCitizen(string NationalNum)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var citizen = GetCitizen(NationalNum);
                res = citizen != null;
            }

            return res;
        }

        public static string GetEmployeeId(string UserName)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblUsers.Where(x => x.Username == UserName).FirstOrDefault().EmployeeId;
            }
        }

        public static void AddNewCitizenUser(int UserId, string NationalNum, int RoleId)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizenRole citizenRole = new tblCitizenRole();
                citizenRole.UserId = UserId;
                citizenRole.NationalNumber = NationalNum;
                citizenRole.RoleId = RoleId;
                citizenRole.Taken = false;
                db.tblCitizenRoles.AddObject(citizenRole);
                db.SaveChanges();
            }
        }

        public static void EditSocialNumber(string NationalNumber, SocialStatus _SocialStatus)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizen citizen = db.tblCitizens.Where(x => x.NationalNumber == NationalNumber).FirstOrDefault();

                switch (_SocialStatus)
                {
                    case SocialStatus._Single:
                        citizen.SocialStatus = "1";
                        break;

                    case SocialStatus.Marriad:
                        citizen.SocialStatus = "2";
                        break;

                    case SocialStatus.Widow:
                        citizen.SocialStatus = "3";
                        break;

                    case SocialStatus.Divorced:
                        citizen.SocialStatus = "4";
                        break;
                }
                db.SaveChanges();
            }
        }

        public static tblEmployee GetEmployee(string EmployeeId)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblEmployees.Where(x => x.NationalNumber == EmployeeId).FirstOrDefault();
            }
        }

        public static List<string> GetActualWifes(string HusbandNationalNum)
        {
            List<string> lstWifes = new List<string>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblMarriageContract> lstMarriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum).ToList();
                foreach (tblMarriageContract marriageContract in lstMarriageContract)
                {
                    if (CheckIsWife(HusbandNationalNum, marriageContract.WifeNationalNum))
                        lstWifes.Add(marriageContract.WifeNationalNum);
                }
            }

            return lstWifes;
        }

        public static tblEmployeesCivilRegistry GetActiveEmployeeRecord(string nationalNum)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                return db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == nationalNum).Where(x => x.E_date == null).FirstOrDefault();
            }
        }

        // قائمة بالمتزوجين في عمر معين
        public static List<tblCitizen> GetMarriedByAge(int age)
        {
            List<tblCitizen> lstRes = new List<tblCitizen>();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblMarriageContract> lstMarriageContract = db.tblMarriageContracts.ToList();
                foreach (tblMarriageContract item in lstMarriageContract)
                {
                    if (IsDivorced(item.HusbandNationalNum, item.WifeNationalNum))
                        continue;


                    tblCitizen ctzn = GetCitizen(item.HusbandNationalNum);

                    int CitizenAge = (DateTime.Now - DateTime.Parse(ctzn.Birthday)).Days / 365;

                    if (CitizenAge == age)
                        lstRes.Add(ctzn);


                    ctzn = GetCitizen(item.WifeNationalNum);
                    CitizenAge = (DateTime.Now - DateTime.Parse(ctzn.Birthday)).Days / 365;

                    if (CitizenAge == age)
                        lstRes.Add(ctzn);
                }
            }
            return lstRes;
        }


        // قائمة بغير المتزوجين بعد تجاوز عمر معين
        public static List<tblCitizen> GetMarriedAfterAge(int age)
        {
            List<tblCitizen> lstRes = new List<tblCitizen>();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblCitizen> lstCitizens = GetCitizens();
                foreach (tblCitizen item in lstCitizens)
                {
                    if (!IsMarriage(item.NationalNumber))
                    {
                        int CitizenAge = (DateTime.Now - DateTime.Parse(item.Birthday)).Days / 365;

                        if (CitizenAge >= age)
                            lstRes.Add(item);
                    }
                }
            }
            return lstRes;
        }

        public static bool IsMarriage(string NationalNumber)
        {
            bool res = false;

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContract = GetLastMarriageContract(NationalNumber);
                res = (marriageContract == null) ? false : true;
            }

            return res;
        }

        public static List<tblCitizen> MortalityAtAnEarlyAge(int age, int year)
        {
            List<tblCitizen> lstRes = new List<tblCitizen>();
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblDeadRegistration> deadRegistration = db.tblDeadRegistrations.ToList();

                foreach (var item in deadRegistration)
                {
                    tblCitizen citizen = GetCitizen(item.NationalNumber);

                    int CitizenAge = (GetDate(item.DeadDate) - DateTime.Parse(citizen.Birthday)).Days / 365;


                    if (GetDate(item.DeadDate).Year == year && CitizenAge == age)
                        lstRes.Add(citizen);
                }
            }
            return lstRes;
        }

        public static double GetDivorceToMarriageRatioByYear(int year)
        {
            double ratio = 0.0;

            List<string> lstMarriedPeople = GetMarriedPeopleByYear(year);

            List<string> lstDivorcedPeople = GetDivorcedPeopleByYear(year);

            ratio = Convert.ToDouble(lstDivorcedPeople.Count) / ((lstMarriedPeople.Count == 0) ? 1 : lstMarriedPeople.Count);

            return ratio;
        }

        private static List<string> GetMarriedPeopleByYear(int year)
        {
            List<string> lstNationalNumbers = new List<string>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblMarriageContract> lstMarriedContracts = db.tblMarriageContracts.ToList().Where(x => GetDate(x.IncidentDate).Year == year).ToList();

                foreach (var item in lstMarriedContracts)
                {
                    if (!IsDivorced(item.HusbandNationalNum, item.WifeNationalNum))
                    {
                        lstNationalNumbers.Add(item.HusbandNationalNum);
                        lstNationalNumbers.Add(item.WifeNationalNum);
                    }
                }
            }

            return lstNationalNumbers;
        }

        public static List<string> GetDivorcedPeopleByYear(int year)
        {
            List<string> lstNationalNumbers = new List<string>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblDivorceIncident> lstDivorceIncident = db.tblDivorceIncidents.ToList().Where(x => GetDate(x.IncidentDate).Year == year).ToList();

                foreach (var item in lstDivorceIncident)
                {
                    if (!IsMarriage(item.HusbandNationalNum))
                        lstNationalNumbers.Add(item.HusbandNationalNum);

                    if (!IsMarriage(item.WifeNationalNum))
                        lstNationalNumbers.Add(item.WifeNationalNum);
                }
            }

            return lstNationalNumbers;
        }

        public static bool IsConfirm(string UserName)
        {
            bool res = false;
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblUser user = db.tblUsers.Where(x => x.Username == UserName).FirstOrDefault();

                if (user != null)
                    res = user.tblCitizenRoles.Where(x => x.UserId == user.Id).FirstOrDefault().Taken;
            }
            return res;
        }

        public static string GetNNByUserName(string UserName)
        {
            string NationalNumber = string.Empty;
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblUser user = db.tblUsers.Where(x => x.Username == UserName).FirstOrDefault();

                if (user != null)
                {
                    var temp = user.tblCitizenRoles.Where(x => x.UserId == user.Id).FirstOrDefault();
                    if (temp != null)
                        NationalNumber = temp.NationalNumber;
                }
            }
            return NationalNumber;
        }

        public static List<tblUser> GetUsers(string NationalNumber)
        {
            List<tblUser> lstUsers = new List<tblUser>();

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                List<tblCitizenRole> lstCitizenRole = db.tblCitizenRoles.Where(y => y.NationalNumber == NationalNumber).ToList();
                foreach (tblCitizenRole CitizenRole in lstCitizenRole)
                {
                    var user = db.tblUsers.Where(y => y.Id == CitizenRole.UserId).FirstOrDefault();
                    if (user != null)
                        lstUsers.Add(user);
                }
            }

            return lstUsers;
        }
    }

    public enum Gender
    {
        Male,
        Female,
        All
    }

    public enum IncidentType
    {
        Marriage,
        Divorce,
        Death,
        Birth
    }

    public enum SocialStatus
    {
        _Single = 1,
        Marriad = 2,
        Widow = 3,
        Divorced = 4
    }

    public enum TransactionType
    {
        Registration,
        Report
    }
}