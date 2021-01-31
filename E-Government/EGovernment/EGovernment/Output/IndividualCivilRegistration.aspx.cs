using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Output
{
    public partial class IndividualCivilRegistration : System.Web.UI.Page
    {
        string _NationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.ICR_Out)
                Response.Redirect("/403");

            try
            {
                _NationalNumber = (string)Session["SVCNationalNumber"];
            }
            catch { }

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizen citizen = db.tblCitizens.Where(x => x.NationalNumber == _NationalNumber).FirstOrDefault();

                if (citizen != null)
                    FillDocument(citizen);
            }
        }

        private void FillDocument(tblCitizen citizen)
        {
            lblNameID.Text = citizen.Id.ToString();
            lblFirstName.Text = citizen.FirstName;
            lblLastName.Text = citizen.LastName;
            var father = Helper.GetCitizen(citizen.FatherNationalNumber);
            lblFatherName.Text = (father != null) ? father.FirstName : string.Empty;
            var mother = Helper.GetCitizen(citizen.MotherNationalNumber);
            lblMotherFullName.Text = (mother != null) ? mother.FirstName + " " + mother.LastName : string.Empty;
            lblControllerName.Text = Helper.GetControllerNameByEmp(Session["CurrUser"]);
            lblCivilRegisterer.Text = Helper.GetCivilRegistrarByEmp(Session["CurrUser"]);
            lbl_Amana.Text = lblAmana.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            lbl_Government.Text = Helper.GetAffairsNameByEmp(Session["CurrUser"]);
            lblKiedPlaceAndNumber.Text = citizen.KiedPlace + " " + citizen.KiedNumber;
            lblBirthdayPlace.Text = citizen.BirthPlace + " " + citizen.Birthday;
            lblNotes.Text = "لا يوجد";
            lblNationalNumber.Text = citizen.NationalNumber;
            lblGender.Text = (citizen.Gender == "1") ? "ذكر" : "أنثى";
            lblKiedDate.Text = citizen.Birthday;
            lblSocialStatus.Text = (citizen.SocialStatus == "1") ? "عازب" : (citizen.SocialStatus == "2") ? "متأهل" : (citizen.SocialStatus == "3") ? "أرمل" : (citizen.SocialStatus == "4") ? "مطلق" : "";
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblRelegion.Text = citizen.Religion;

        }
    }
}