using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Output
{
    public partial class MDChildSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFatherId.Text = (string)Session["SVCNationalNumber"];

                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    foreach (var item in db.tblCitizens.Where(x => x.FatherNationalNumber == txtFatherId.Text).ToList())
                    {
                        lstChildren.Items.Add(new ListItem(string.Format("{0} {1} {2}", item.FirstName, Helper.GetCitizen(item.FatherNationalNumber).FirstName, item.LastName), item.NationalNumber));
                    }
                }
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstChildren.SelectedIndex == -1)
            {
                lblErrorMSG.Visible = true;
                lblErrorMSG1.Text = "حدد أحد الأولاد أولاً";
                return;
            }
            else
                lblErrorMSG.Visible = false;

            Session["SVCNationalNumber"] = txtFatherId.Text + ";" + lstChildren.SelectedValue;

            switch ((string)Session["Out_Id"])
            {
                case "birth":
                    Response.Redirect("/Output/Birth");
                    break;

                case "death":
                    Response.Redirect("/Output/death");
                    break;
            }
        }
    }
}