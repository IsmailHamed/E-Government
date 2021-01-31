using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.CivilRegistry
{
    public partial class AddCivilRegistry : System.Web.UI.Page
    {
        bool EditPage = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CivilRegistrarId = (string)Session["CivilRegistry"];
            if (CivilRegistrarId != null)
            {
                EditPage = true;
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    int IdCivilRegistrar = int.Parse(CivilRegistrarId);
                    tblCivilRegistry CivilRegistrar = db.tblCivilRegistries.Where(y => y.Id == IdCivilRegistrar).FirstOrDefault();
                    txtName.Text = CivilRegistrar.Name;
                    txtArea.Text = CivilRegistrar.Area;
                    txtCivilRegistry.Text = CivilRegistrarId;

                    ddlCivilAffairs.SelectedValue = Convert.ToString(CivilRegistrar.CivilAffairsID);

                    btnAdd.Text = "حفظ التعديلات";
                    Session["CivilRegistry"] = null;

                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    tblCivilRegistry civilregistry = null;

                    EditPage = (btnAdd.Text == "حفظ التعديلات");

                    if (!EditPage)
                        civilregistry = new tblCivilRegistry();
                    else
                    {
                        int CivilRegistryid = int.Parse(txtCivilRegistry.Text);
                        civilregistry = db.tblCivilRegistries.Where(x => x.Id == CivilRegistryid).FirstOrDefault();

                    }
                    civilregistry.Name = txtName.Text;
                    civilregistry.Area = txtArea.Text;
                    civilregistry.CivilAffairsID = Int32.Parse(ddlCivilAffairs.SelectedValue);

                    if (!EditPage)
                        db.tblCivilRegistries.AddObject(civilregistry);

                    db.SaveChanges();
                }
                Response.Redirect("/Finish");
            }
        }
    }
}