using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.StatisticsReports
{
    public partial class DivorceToMarriageRatioByYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.StatisticsReports)
                Response.Redirect("/403");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            lblResult.Text = Helper.GetDivorceToMarriageRatioByYear(int.Parse(txtYear.Value)).ToString() + "%";
        }
        
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}