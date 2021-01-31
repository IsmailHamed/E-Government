using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.MarriageDocument
{
    public partial class Marriagedocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillFields();

        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnPrevious2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

            }
        }

        protected void FillFields()
        {

            NationalNumber.Text = "12345";
            txtFirstNameWife.Text = "soso";
            txtLastNameWife.Text = "soso";
            txtIdWife.Text = "54321";
            txtFatherNameWife.Text = "mohamd";
            txtIdFatherWife.Text = "5432";
            txtMotherNameWife.Text = "lana";
            txtIdMotherWife.Text = "52";
            txtPalceBirthWife.Text = "damas";
            BirthWife.Value = DateTime.Now.ToString("2010-11-10");
            txtReligionWife.Text = "Muslim";
            txtNationalityWife.Text = "syrian";
            txtAlmanWife.Text = "amara";
            txtPlaceEntryWife.Text = "kafarsosa";
            txtRegistrationNumberWife.Text = "2";
            txtIssuedBy.Text = "David";
            txtGovernorate.Text = "Damascus";
            txtFamilyNumber.Text = "852";
            DateContract.Value = DateTime.Now.ToString("2010-11-10");
            txtAuthorityAuthorizedContract.Text = "SS";
            txtDocumentNumber.Text = "2";
            DateDocument.Value = DateTime.Now.ToString("2010-11-10");
            txtNotes.Text = "Ni";
            txtNameController.Text = "mmm";
            txtRegistrarIn.Text = "Damas";
            txtNameRegistrar.Text = "NNN";
        }

    }
}