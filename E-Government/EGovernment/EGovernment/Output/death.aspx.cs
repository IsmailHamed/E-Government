using System;
using System.Linq;

namespace EGovernment.Output
{
    public partial class death : System.Web.UI.Page
    {
        string FatherNationalNumber = string.Empty;
        string ChildNationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.DeathOut)
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
                tblDeadRegistration deadRegistration = db.tblDeadRegistrations.Where(x => x.NationalNumber == ChildNationalNumber).FirstOrDefault();

                if (deadRegistration != null)
                    FillDocument(deadRegistration);
            }
        }

        private void FillDocument(tblDeadRegistration deadRegistration)
        {
            lbl_Amana.Text = labelIssuedBy.Text = labelIssuedBy1.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            lbl_Government.Text = labelGovernorate.Text = Helper.GetAffairsNameByEmp(Session["CurrUser"]);
            labelIdHusband.Text = deadRegistration.tblCitizen.NationalNumber;

            labelNameController.Text = Helper.GetControllerNameByEmp(Session["CurrUser"]);
            labelRegistrar.Text = Helper.GetCivilRegistrarByEmp(Session["CurrUser"]);
            labelFirstNameHusbasd.Text = deadRegistration.tblCitizen.FirstName;
            var father = Helper.GetCitizen(deadRegistration.tblCitizen.FatherNationalNumber);
            labelFatherNameHusband.Text = (father != null) ? father.FirstName : string.Empty;
            var mother = Helper.GetCitizen(deadRegistration.tblCitizen.MotherNationalNumber);
            labelMotherNameHusband.Text = (mother != null) ? mother.FirstName + " " + mother.LastName : string.Empty;
            labelLastNameHusband.Text = deadRegistration.tblCitizen.LastName;
            labelIdFatherHusband.Text = (father != null) ? father.NationalNumber : string.Empty;
            labelIdMotherHusband.Text = (mother != null) ? mother.NationalNumber : string.Empty;
            labelAlamanaHusband.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryHusband.Text = deadRegistration.tblCitizen.KiedPlace;
            labelRegistrationNumberHusbans.Text = deadRegistration.tblCitizen.KiedNumber;
            lblHusbandId.Text = deadRegistration.tblCitizen.Id.ToString();
            labelNotes.Text = deadRegistration.Notes;
            Gender.Text = deadRegistration.tblCitizen.Gender == "0" ? "أنثى" : "ذكر";
            label_DocumentNumber.Text = deadRegistration.tblCitizen.Id.ToString();
            lblMarrageDate.Text = deadRegistration.IncidentDate;
            lblDeadBirthday.Text = deadRegistration.tblCitizen.Birthday;
            lblDeadPlace.Text = deadRegistration.DeadPlace;
            Nationality.Text = (deadRegistration.tblCitizen.Gender == "0") ? "سورية" : "سوري";
        }
    }
}