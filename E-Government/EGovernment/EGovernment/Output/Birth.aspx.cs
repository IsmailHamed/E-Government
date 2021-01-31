using System;
using System.Linq;

namespace EGovernment.Output
{
    public partial class Birth : System.Web.UI.Page
    {
        string FatherNationalNumber = string.Empty;
        string ChildNationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.BirthOut)
                Response.Redirect("/403");

            try
            {
                string NationalNumber = (string)Session["SVCNationalNumber"];
                string[] nums = NationalNumber.Split(';');
                FatherNationalNumber = nums[0];
                ChildNationalNumber = nums[1];
            }
            catch { }

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblBirthRegistration birthRegistration;
                if (!string.IsNullOrEmpty(ChildNationalNumber)) // لديه أكثر من ولد
                    birthRegistration = db.tblBirthRegistrations.Where(x => x.tblCitizen.FatherNationalNumber == FatherNationalNumber).Where(x => x.tblCitizen.NationalNumber == ChildNationalNumber).FirstOrDefault();
                else
                    birthRegistration = db.tblBirthRegistrations.Where(x => x.tblCitizen.FatherNationalNumber == FatherNationalNumber).FirstOrDefault();

                if (birthRegistration != null)
                    FillDocument(birthRegistration);
            }
        }

        private void FillDocument(tblBirthRegistration birthRegistration)
        {
            lbl_Amana.Text = labelIssuedBy.Text = labelIssuedBy1.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            lbl_Government.Text = labelGovernorate.Text = Helper.GetAffairsNameByEmp(Session["CurrUser"]);
            labelIdHusband.Text = birthRegistration.tblCitizen.NationalNumber;

            labelNameController.Text = Helper.GetControllerNameByEmp(Session["CurrUser"]);
            labelRegistrar.Text = Helper.GetCivilRegistrarByEmp(Session["CurrUser"]);
            labelFirstNameHusbasd.Text = birthRegistration.tblCitizen.FirstName;
            var father = Helper.GetCitizen(birthRegistration.tblCitizen.FatherNationalNumber);
            labelFatherNameHusband.Text = (father != null) ? father.FirstName : string.Empty;
            var mother = Helper.GetCitizen(birthRegistration.tblCitizen.MotherNationalNumber);
            labelMotherNameHusband.Text = (mother != null) ? mother.FirstName + " " + mother.LastName : string.Empty;
            labelPlaceBirthHusband.Text = birthRegistration.tblCitizen.BirthPlace;
            labelLastNameHusband.Text = birthRegistration.tblCitizen.LastName;
            labelIdFatherHusband.Text = (father != null) ? father.NationalNumber : string.Empty;
            labelIdMotherHusband.Text = (mother != null) ? mother.NationalNumber : string.Empty;
            labelAlamanaHusband.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryHusband.Text = birthRegistration.tblCitizen.KiedPlace;
            labelRegistrationNumberHusbans.Text = birthRegistration.tblCitizen.KiedNumber;
            lblHusbandId.Text = birthRegistration.tblCitizen.Id.ToString();
            labelNotes.Text = birthRegistration.Notes;
            labelRegistrationNumberHusbans.Text = birthRegistration.tblCitizen.KiedNumber;
            Birthday .Text= birthRegistration.tblCitizen.Birthday.ToString();
            Gender.Text = birthRegistration.tblCitizen.Gender == "0" ? "أنثى" : "ذكر";
            label_DocumentNumber.Text = birthRegistration.tblCitizen.Id.ToString();
            lblMarrageDate.Text = birthRegistration.IncidentDate;
        }
    }
}