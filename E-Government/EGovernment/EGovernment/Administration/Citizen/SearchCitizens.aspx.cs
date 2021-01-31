using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace EGovernment.Administration.Citizen
{
    public partial class SearchCitizens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.SearchCitizens)
                Response.Redirect("/403");

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

            if (role != null && !role.EditCitizen)
                HideEditButton();
        }

        private void HideEditButton()
        {
            (GridView1.Columns
            .Cast<DataControlField>()
            .Where(fld => fld.HeaderText == "الأوامر")
            .SingleOrDefault()).Visible = false;
        }

        protected void btnEditCitizen_Click(object sender, EventArgs e)
        {

            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            if (gvr.Cells.Count <= 1)
                return;

            CitizenInfo _CitizenInfo = new CitizenInfo();
            _CitizenInfo.FirstName = gvr.Cells[1].Text;
            _CitizenInfo.LastName = gvr.Cells[2].Text;
            _CitizenInfo.FatherNationalNumber = gvr.Cells[3].Text.Replace("&nbsp;", string.Empty);
            _CitizenInfo.MotherNationalNumber = gvr.Cells[4].Text.Replace("&nbsp;", string.Empty);
            _CitizenInfo.NationalNumber = gvr.Cells[5].Text;
            _CitizenInfo.Birthday = gvr.Cells[6].Text;
            _CitizenInfo.BirthPlace = gvr.Cells[7].Text;
            _CitizenInfo.KiedPlace = gvr.Cells[8].Text;
            _CitizenInfo.KiedNumber = gvr.Cells[9].Text;
            _CitizenInfo.Gender = gvr.Cells[10].Text;
            _CitizenInfo.SocialStatus = gvr.Cells[11].Text;
            _CitizenInfo.Religion = gvr.Cells[12].Text;

            Session["CitizenInfo"] = _CitizenInfo;

            Response.Redirect("/Administration/Citizen/AddCitizen");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                IQueryable<tblCitizen> citizens;

                if (string.IsNullOrEmpty(search.Value.Trim()))
                    citizens = db.tblCitizens;
                else
                    citizens = db.tblCitizens.Where(x => x.NationalNumber.Contains(search.Value.Trim()));

                if (citizens.Count().ToString() == "0")
                {
                    lblNoData.Visible = true;
                    return;
                }


                foreach (var item in citizens.Where(w => w.Gender == "1"))
                    item.Gender = "ذكر";

                foreach (var item in citizens.Where(w => w.Gender == "0"))
                    item.Gender = "أنثى";

                foreach (var item in citizens.Where(w => w.SocialStatus == "1"))
                    item.SocialStatus = "عازب";

                foreach (var item in citizens.Where(w => w.SocialStatus == "2"))
                    item.SocialStatus = "متأهل";

                foreach (var item in citizens.Where(w => w.SocialStatus == "3"))
                    item.SocialStatus = "أرمل";

                foreach (var item in citizens.Where(w => w.SocialStatus == "4"))
                    item.SocialStatus = "مطلق";

                GridView1.DataSource = citizens;
                GridView1.DataBind();

            }


            //string constr = ConfigurationManager.ConnectionStrings["EGovernmentEntities"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "SELECT ContactName, City, Country FROM Customers WHERE ContactName LIKE '%' + @ContactName + '%'";
            //        cmd.Connection = con;
            //        cmd.Parameters.AddWithValue("@ContactName", search.Value.Trim());
            //        DataTable dt = new DataTable();
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //        }
            //    }
            //}
        }

    }
}