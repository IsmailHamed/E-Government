using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Output
{
    public partial class divorce : System.Web.UI.Page
    {
        string HusbandNationalNumber = string.Empty;
        string WifeNationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.DivorceOut)
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
                tblDivorceIncident divorceContract;
                if (!string.IsNullOrEmpty(WifeNationalNumber)) // لديه أكثر من زوجة
                    divorceContract = db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNumber).Where(x => x.WifeNationalNum == WifeNationalNumber).FirstOrDefault();
                else
                    divorceContract = db.tblDivorceIncidents.Where(x => x.HusbandNationalNum == HusbandNationalNumber).FirstOrDefault();

                if (divorceContract != null)
                    FillDocument(divorceContract);

            }
        }

        private void FillDocument(tblDivorceIncident divorceContract)
        {
            lbl_Amana.Text = labelIssuedBy.Text = labelIssuedBy1.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            lbl_Government.Text = labelGovernorate.Text = Helper.GetAffairsNameByEmp(Session["CurrUser"]);
            labelIdHusband.Text = divorceContract.HusbandNationalNum;
            labelIdWife.Text = divorceContract.WifeNationalNum;
            labelNameController.Text = Helper.GetControllerNameByEmp(Session["CurrUser"]);
            labelRegistrar.Text = Helper.GetCivilRegistrarByEmp(Session["CurrUser"]);
            labelFirstNameHusbasd.Text = divorceContract.tblCitizen.FirstName;
            var father = Helper.GetCitizen(divorceContract.tblCitizen.FatherNationalNumber);
            labelFatherNameHusband.Text = (father != null) ? father.FirstName : string.Empty;
            var mother = Helper.GetCitizen(divorceContract.tblCitizen.MotherNationalNumber);
            labelReligionHusband.Text = divorceContract.tblCitizen.Religion;
            labelAlamanaHusband.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryHusband.Text = divorceContract.tblCitizen.KiedPlace;
            labelRegistrationNumberHusbans.Text = divorceContract.tblCitizen.KiedNumber;
            lblHusbandId.Text = divorceContract.tblCitizen.Id.ToString();
            labelIdFatherHusband.Text = (father != null) ? father.NationalNumber : string.Empty;
            lblHusbandDivorcePlace.Text = divorceContract.DivorcePlace;
            lblHusbandDivorceDate.Text = divorceContract.IncidentDate;

            labelNotes.Text = divorceContract.Notes;
            labelRegistrationNumberWife.Text = divorceContract.tblCitizen1.KiedNumber;
            labelFirstNameWife.Text = divorceContract.tblCitizen1.FirstName;
            father = Helper.GetCitizen(divorceContract.tblCitizen1.FatherNationalNumber);
            labelFatherNameWife.Text = (father != null) ? father.FirstName : string.Empty;
            mother = Helper.GetCitizen(divorceContract.tblCitizen1.MotherNationalNumber);
            labelReligionWife.Text = divorceContract.tblCitizen1.Religion;
            labelLastNameWife.Text = divorceContract.tblCitizen1.LastName;
            labelIdFatherWife.Text = (father != null) ? father.NationalNumber : string.Empty;
            labelAlmanWife.Text = Helper.GetAmanaNameByEmp(Session["CurrUser"]);
            labelPlaceEntryWife.Text = divorceContract.tblCitizen1.KiedPlace;
            lblWifeId.Text = divorceContract.tblCitizen1.Id.ToString();

            lblReference.Text = divorceContract.Reference;
            DateDocument.Text = lblMarrageDate.Text = divorceContract.IncidentDate;
            label_DocumentNumber.Text = labelDocumentNumber.Text = divorceContract.IncidentNumber.ToString();
        }
    }
}