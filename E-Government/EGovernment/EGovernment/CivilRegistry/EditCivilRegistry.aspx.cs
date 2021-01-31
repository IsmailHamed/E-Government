using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.CivilRegistry
{
    public partial class EditCivilRegistry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.EditCivilRegister || !role.SearchCivilRegister)
                Response.Redirect("/403");

            if (!IsPostBack)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    tblCivilAffair civilAffairs = new tblCivilAffair();
                    var c1 = db.tblCivilAffairs.ToList();
                    ddlCivilAffairs.DataValueField = "Id";
                    ddlCivilAffairs.DataTextField = "Name";
                    ddlCivilAffairs.DataSource = c1;
                    ddlCivilAffairs.DataBind();



                    tblCivilRegistry civilregistry = new tblCivilRegistry();
                    int idCivilAffairs = int.Parse(ddlCivilAffairs.SelectedItem.Value);
                    var c = db.tblCivilRegistries.Where(b => b.CivilAffairsID == 1).ToList();

                    if (c.Count == 0)
                    {
                        lblNoData.Visible = true;
                        divCivilRegistry.Visible = false;
                        btnEdit.Visible = false;
                    }
                    else
                    {
                        lblNoData.Visible = false;
                        divCivilRegistry.Visible = true;
                        btnEdit.Visible = true;

                    }
                    ddlCivilRegistry.DataValueField = "Id";
                    ddlCivilRegistry.DataTextField = "Name";
                    ddlCivilRegistry.DataSource = c;
                    ddlCivilRegistry.DataBind();
                }

            }
        }
        protected void ddlCivilAffairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCivilRegistry civilregistry = new tblCivilRegistry();
                int idCivilAffairs = int.Parse(ddlCivilAffairs.SelectedItem.Value);
                var c = db.tblCivilRegistries.Where(b => b.CivilAffairsID == idCivilAffairs).ToList();

                if (c.Count == 0)
                {
                    lblNoData.Visible = true;
                    divCivilRegistry.Visible = false;
                    btnEdit.Visible = false;
                }
                else
                {
                    lblNoData.Visible = false;
                    divCivilRegistry.Visible = true;
                    btnEdit.Visible = true;

                }

                ddlCivilRegistry.DataValueField = "Id";
                ddlCivilRegistry.DataTextField = "Name";
                ddlCivilRegistry.DataSource = c;
                ddlCivilRegistry.DataBind();
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Session["CivilRegistry"] = ddlCivilRegistry.SelectedValue;
            Response.Redirect("/CivilRegistry/AddCivilRegistry");
        }

    }
}