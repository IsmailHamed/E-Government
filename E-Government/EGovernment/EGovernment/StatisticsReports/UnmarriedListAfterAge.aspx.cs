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
    public partial class UnmarriedNumAfterAge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.StatisticsReports)
                Response.Redirect("/403");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            int age = -1;
            if (!int.TryParse(txtAge.Value, out age))
            {
                lblErrorMSG.Visible = true;
                lblErrorMSG1.Text = "العمر غير صحيح";
                return;
            }
            else
            {
                lblErrorMSG.Visible = false;
                MultiView1.ActiveViewIndex = 1;


                List<tblCitizen> lstCitizens = Helper.GetMarriedAfterAge(age);

                FillListBox(lstCitizens);
            }
        }

        private void FillListBox(List<tblCitizen> lstCitizens)
        {
            foreach (var item in lstCitizens)
            {
                lstValues.Items.Add(string.Format(@"{0} {1}, ""{2}""", item.FirstName, item.LastName, item.NationalNumber));
            }
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("الاسم,الكنية");
            for (int i = 0; i < lstValues.Items.Count; i++)
                sb.AppendLine(lstValues.Items[i].Text);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Temp\\تقرير_إحصائي.csv", sb.ToString(), Encoding.UTF8);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=تقرير_إحصائي.csv");
            Response.TransmitFile(AppDomain.CurrentDomain.BaseDirectory + "\\Temp\\تقرير_إحصائي.csv");
            Response.End();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}