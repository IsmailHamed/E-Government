using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.outMarriage
{
    public partial class outMarrage : System.Web.UI.Page
    {
        string HusbandNationalNumber = string.Empty;
        string WifeNationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.MarriageOut)
                Response.Redirect("/403");


            try
            {
                string NationalNumber = (string)Session["SVCNationalNumber"];
                string[] nums = NationalNumber.Split(';');
                HusbandNationalNumber = nums[0];
                WifeNationalNumber = nums[1];
            }
            catch { }

            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblMarriageContract marriageContract;
                if (!string.IsNullOrEmpty(WifeNationalNumber)) // لديه أكثر من زوجة
                    marriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNumber).Where(x => x.WifeNationalNum == WifeNationalNumber).FirstOrDefault();
                else
                    marriageContract = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNumber).FirstOrDefault();

                if (marriageContract != null)
                    FillDocument(marriageContract);

            }
        }

        private void FillDocument(tblMarriageContract marriageContract)
        {
            lbl_Amana.Text = labelIssuedBy.Text = labelIssuedBy1.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            lbl_Government.Text = labelGovernorate.Text = Helper.GetAffairsNameByEmp(Session["CurrUser"]);
            labelFamilyNumber.Text = marriageContract.FamilyNumber.ToString();
            labelIdHusband.Text = marriageContract.HusbandNationalNum;
            labelIdWife.Text = marriageContract.WifeNationalNum;
            labelNameController.Text = Helper.GetControllerNameByEmp(Session["CurrUser"]);
            labelRegistrar.Text = Helper.GetCivilRegistrarByEmp(Session["CurrUser"]);
            labelFirstNameHusbasd.Text = marriageContract.tblCitizen2.FirstName;
            var father = Helper.GetCitizen(marriageContract.tblCitizen2.FatherNationalNumber);
            labelFatherNameHusband.Text = (father != null) ? father.FirstName : string.Empty;
            var mother = Helper.GetCitizen(marriageContract.tblCitizen2.MotherNationalNumber);
            labelMotherNameHusband.Text = (mother != null) ? mother.FirstName + " " + mother.LastName : string.Empty;
            labelPlaceBirthHusband.Text = marriageContract.tblCitizen2.BirthPlace;
            labelReligionHusband.Text = marriageContract.tblCitizen2.Religion;
            DateContract.Text = marriageContract.ContractDate;
            labelLastNameHusband.Text = marriageContract.tblCitizen2.LastName;
            labelIdFatherHusband.Text = (father != null) ? father.NationalNumber : string.Empty;
            labelIdMotherHusband.Text = (mother != null) ? mother.NationalNumber : string.Empty;
            BirthdayHusband.Text = marriageContract.tblCitizen2.Birthday;
            labelAlamanaHusband.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryHusband.Text = marriageContract.tblCitizen2.KiedPlace;
            labelRegistrationNumberHusbans.Text = marriageContract.tblCitizen2.KiedNumber;
            lblHusbandId.Text = marriageContract.tblCitizen2.Id.ToString();
            labelNotes.Text = marriageContract.Notes;

            labelRegistrationNumberWife.Text = marriageContract.tblCitizen3.KiedNumber;
            labelFirstNameWife.Text = marriageContract.tblCitizen3.FirstName;
            father = Helper.GetCitizen(marriageContract.tblCitizen3.FatherNationalNumber);
            labelFatherNameWife.Text = (father != null) ? father.FirstName : string.Empty;
            mother = Helper.GetCitizen(marriageContract.tblCitizen3.MotherNationalNumber);
            labelMotherNameWife.Text = (mother != null) ? mother.FirstName + " " + mother.LastName : string.Empty;
            labelPalceBirthWife.Text = marriageContract.tblCitizen3.BirthPlace;
            labelReligionWife.Text = marriageContract.tblCitizen3.Religion;
            DateContract.Text = marriageContract.ContractDate;
            labelLastNameWife.Text = marriageContract.tblCitizen3.LastName;
            labelIdFatherWife.Text = (father != null) ? father.NationalNumber : string.Empty;
            labelIdMotherWife.Text = (mother != null) ? mother.NationalNumber : string.Empty;
            BirthWife.Text = marriageContract.tblCitizen3.Birthday;
            labelAlmanWife.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryWife.Text = marriageContract.tblCitizen3.KiedPlace;
            labelRegistrationNumberHusbans.Text = marriageContract.tblCitizen2.KiedNumber;
            lblWifeId.Text = marriageContract.tblCitizen3.Id.ToString();

            lblReference.Text = marriageContract.Reference;
            DateDocument.Text = lblMarrageDate.Text = marriageContract.ContractDate;
            label_DocumentNumber.Text = labelDocumentNumber.Text = marriageContract.IncidentNumber.ToString();
        }
    }
}