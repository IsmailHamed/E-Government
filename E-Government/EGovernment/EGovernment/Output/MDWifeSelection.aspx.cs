using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Output
{
    public partial class MDWifeSelection : System.Web.UI.Page
    {
        string HusbandNationalNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HusbandNationalNumber = (string)Session["SVCNationalNumber"];

                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    foreach (var item in db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNumber).ToList())
                    {
                        if (!Helper.CheckIsWife(item.HusbandNationalNum, item.WifeNationalNum))
                            continue;

                        var civil = db.tblCitizens.Where(x => x.NationalNumber == item.WifeNationalNum).FirstOrDefault();
                        if (civil != null)
                            lstWifes.Items.Add(new ListItem(string.Format("{0} {1} {2}", civil.FirstName, Helper.GetCitizen(civil.FatherNationalNumber).FirstName, civil.LastName), civil.NationalNumber));
                    }
                }
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstWifes.SelectedIndex == -1)
            {
                lblErrorMSG.Visible = true;
                lblErrorMSG1.Text = "حدد أحد الزوجات أولاً";
                return;
            }
            else
                lblErrorMSG.Visible = false;

            Session["SVCNationalNumber"] = (string)HusbandNationalNumber + ";" + lstWifes.SelectedValue;

            Response.Redirect("/Output/marrage");
        }
    }
}