using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace EGovernment
{
    public class RestHelper
    {
        public static string AddCitizen(tblCitizen citizen)
        {
            string ErrorMsg = string.Empty;
            try
            {
                var client = new RestClient("http://fv4online.com/egov_api/v2/");
                var request = new RestRequest("civilians", Method.POST);
                request.AddParameter("first_name", citizen.FirstName);
                request.AddParameter("last_name", citizen.LastName);
                request.AddParameter("father_id", GetCitizenByNN(citizen.NationalNumber).Id);
                request.AddParameter("mother_id", GetCitizenByNN(citizen.NationalNumber).Id);
                request.AddParameter("birth_date", citizen.Birthday);
                request.AddParameter("birth_place", citizen.BirthPlace);
                request.AddParameter("register_place", citizen.KiedPlace);
                request.AddParameter("register_no", citizen.KiedNumber);
                request.AddParameter("id_card_no", GenerateRandomNumber(8));
                request.AddParameter("nationality", (citizen.Gender == "0") ? "سورية" : "سوري");
                request.AddParameter("secretariate", "دمشق");
                request.AddParameter("national_no", citizen.NationalNumber);
                request.AddParameter("gender", (citizen.Gender == "0") ? "female" : "male");
                request.AddParameter("address", citizen.KiedPlace);
                request.AddParameter("tel", "09" + GenerateRandomNumber(8));
                request.AddParameter("granting_date", RandomDay());

                IRestResponse response = client.Execute(request);
                var content = response.Content;

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
            return ErrorMsg;
        }

        public static string EditCitizen(tblCitizen citizen)
        {
            string ErrorMsg = string.Empty;
            try
            {
                string id = GetCitizenByNN(citizen.NationalNumber).Id.ToString();
                var client = new RestClient("http://fv4online.com/egov_api/v2/");
                var request = new RestRequest("civilians/" + id, Method.PUT);
                request.AddParameter("first_name", citizen.FirstName);
                request.AddParameter("last_name", citizen.LastName);
                request.AddParameter("father_id", GetCitizenByNN(citizen.NationalNumber).Id);
                request.AddParameter("mother_id", GetCitizenByNN(citizen.NationalNumber).Id);
                request.AddParameter("birth_date", citizen.Birthday);
                request.AddParameter("birth_place", citizen.BirthPlace);
                request.AddParameter("register_place", citizen.KiedPlace);
                request.AddParameter("register_no", citizen.KiedNumber);
                request.AddParameter("id_card_no", GenerateRandomNumber(8));
                request.AddParameter("nationality", (citizen.Gender == "0") ? "سورية" : "سوري");
                request.AddParameter("secretariate", "دمشق");
                request.AddParameter("national_no", citizen.NationalNumber);
                request.AddParameter("gender", (citizen.Gender == "0") ? "female" : "male");
                request.AddParameter("address", citizen.KiedPlace);
                request.AddParameter("tel", "09" + GenerateRandomNumber(8));
                request.AddParameter("granting_date", RandomDay());

                IRestResponse response = client.Execute(request);
                var content = response.Content;

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
            return ErrorMsg;
        }


        private static Random gen = new Random();
        static string RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString("yyyy-MM-dd");
        }

        private static string GenerateRandomNumber(int length)
        {
            string res = string.Empty;

            for (int i = 0; i < length; i++)
                res += gen.Next(0, 10);

            return res;
        }

        public static tblCitizen GetCitizenByNN(string NationalNumber)
        {
            tblCitizen citizen = new tblCitizen();

            var client = new RestClient("http://fv4online.com/egov_api/v2/");
            var request = new RestRequest("civilians/" + NationalNumber + "/info", Method.GET);
            var queryResult = client.Execute<List<Citizen>>(request).Content;
            Citizen temp = JsonConvert.DeserializeObject<Citizen>(queryResult);
            citizen = ConvertToCitizenRow(temp);

            return citizen;
        }

        public static tblCitizen GetCitizenById(string Id)
        {
            tblCitizen citizen = new tblCitizen();

            var client = new RestClient("http://fv4online.com/egov_api/v2/");
            var request = new RestRequest("civilians/" + Id, Method.GET);
            var queryResult = client.Execute<List<Citizen>>(request).Content;
            Citizen temp = JsonConvert.DeserializeObject<Citizen>(queryResult);
            citizen = ConvertToCitizenRow(temp);

            return citizen;
        }

        public static List<tblCitizen> GetCitizens()
        {
            List<tblCitizen> lstCitizens = new List<tblCitizen>();

            var client = new RestClient("http://fv4online.com/egov_api/v2/");
            var request = new RestRequest("civilians", Method.GET);
            var queryResult = client.Execute<List<Citizen>>(request).Content;
            List<Citizen> lstTemp = JsonConvert.DeserializeObject<List<Citizen>>(queryResult);

            if (lstTemp != null)
                foreach (Citizen citizen in lstTemp)
                {
                    lstCitizens.Add(ConvertToCitizenRow(citizen));
                }

            return lstCitizens;
        }

        private static tblCitizen ConvertToCitizenRow(Citizen citizen)
        {
            tblCitizen _citizen = new tblCitizen();

            _citizen.FirstName = citizen.first_name;
            _citizen.LastName = citizen.last_name;
            _citizen.FatherNationalNumber = citizen.father_no;
            _citizen.MotherNationalNumber = citizen.mother_no;
            _citizen.NationalNumber = citizen.national_no;
            _citizen.Birthday = citizen.birth_date;
            _citizen.BirthPlace = citizen.birth_place;
            _citizen.KiedPlace = citizen.register_place;
            _citizen.KiedNumber = citizen.register_no;
            _citizen.Gender = (citizen.gender == "male") ? "1" : "0";
            _citizen.SocialStatus = "1";
            _citizen.Religion = "مسلم";

            return _citizen;
        }


    }
}