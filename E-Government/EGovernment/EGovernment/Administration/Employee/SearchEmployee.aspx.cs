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
using System.Globalization;

namespace EGovernment.Administration.Employee
{
    public partial class SearchEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.SearchEmployee)
                Response.Redirect("/403");

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

            if (role != null && !role.EditEmployee)
                HideEditButton();
        }

        private void HideEditButton()
        {
            (GridView1.Columns
            .Cast<DataControlField>()
            .Where(fld => fld.HeaderText == "الأوامر")
            .SingleOrDefault()).Visible = false;
        }

        protected void btnEditEmployee_Click(object sender, EventArgs e)
        {

            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            if (gvr.Cells.Count <= 1)
                return;

            EmployeeInfo _EmployeeInfo = new EmployeeInfo();
            _EmployeeInfo.FirstName = gvr.Cells[0].Text;
            _EmployeeInfo.LastName = gvr.Cells[1].Text;
            _EmployeeInfo.NationalNumber = gvr.Cells[2].Text;
            _EmployeeInfo.Phone = gvr.Cells[3].Text;
            _EmployeeInfo.Address = gvr.Cells[4].Text;
            _EmployeeInfo.Specialization = gvr.Cells[5].Text;
            _EmployeeInfo.S_Date = DateTime.Parse(gvr.Cells[6].Text, new CultureInfo("en-us"));
            if (gvr.Cells[7].Text != "&nbsp;")
                _EmployeeInfo.E_Date = DateTime.Parse(gvr.Cells[7].Text, new CultureInfo("en-us"));
            _EmployeeInfo.Rank = gvr.Cells[8].Text;

            _EmployeeInfo.CivilAffairs = Helper.CivilAffairId(gvr.Cells[9].Text).ToString();
            _EmployeeInfo.CivilRegistry = Helper.CivilRegistryId(gvr.Cells[10].Text).ToString();
            _EmployeeInfo.Role = Helper.GetRoleId(gvr.Cells[11].Text).ToString();

            _EmployeeInfo.IsWorking = (gvr.Cells[12].Text == "يعمل") ? true : false;

            Session["EmployeeInfo"] = _EmployeeInfo;

            Response.Redirect("/Administration/Employee/AddEmployee");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                IQueryable<tblEmployee> Employees;

                if (string.IsNullOrEmpty(search.Value.Trim()))
                    Employees = db.tblEmployees;
                else
                    Employees = db.tblEmployees.Where(x => x.NationalNumber.Contains(search.Value.Trim()));

                if (Employees.Count().ToString() == "0")
                {
                    lblNoData.Visible = true;
                    return;
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(System.String));
                dt.Columns.Add("FirstName", typeof(System.String));
                dt.Columns.Add("LastName", typeof(System.String));
                dt.Columns.Add("NationalNumber", typeof(System.String));
                dt.Columns.Add("Phone", typeof(System.String));
                dt.Columns.Add("Address", typeof(System.String));
                dt.Columns.Add("Specialization", typeof(System.String));
                dt.Columns.Add("S_Date", typeof(System.String));
                dt.Columns.Add("E_Date", typeof(System.String));
                dt.Columns.Add("Rank", typeof(System.String));
                dt.Columns.Add("CivilAffairs", typeof(System.String));
                dt.Columns.Add("CivilRegistry", typeof(System.String));
                dt.Columns.Add("Role", typeof(System.String));
                dt.Columns.Add("IsWorking", typeof(System.String));


                foreach (var emp in Employees)
                {
                    if (emp.NationalNumber == "85220939995")// لا تقوم بجلب مدير النظام
                        continue;

                    DataRow row1 = dt.NewRow();
                    row1["Id"] = emp.NationalNumber;
                    row1["FirstName"] = emp.tblCitizen.FirstName;
                    row1["LastName"] = emp.tblCitizen.LastName;
                    row1["NationalNumber"] = emp.NationalNumber;

                    row1["Phone"] = emp.Phone;
                    row1["Address"] = emp.Address;
                    row1["Specialization"] = emp.Specialization;
                    var empCivilReg = emp.tblEmployeesCivilRegistries.OrderByDescending(x => x.Id).FirstOrDefault();

                    if (empCivilReg.S_date != null)
                        row1["S_Date"] = Convert.ToDateTime(empCivilReg.S_date).ToShortDateString();

                    if (empCivilReg.E_date != null)
                        row1["E_Date"] = Convert.ToDateTime(empCivilReg.E_date).ToShortDateString();

                    row1["Rank"] = Helper.GetRank(empCivilReg);
                    row1["CivilAffairs"] = Helper.CivilAffairs(empCivilReg.CivilRegistryID);
                    row1["CivilRegistry"] = Helper.CivilRegistry(empCivilReg.CivilRegistryID);

                    row1["Role"] = empCivilReg.tblRole.Name;

                    if (empCivilReg.E_date != null)
                        row1["IsWorking"] = (empCivilReg.E_date == null) ? "يعمل" : "لا يعمل";
                    else
                        row1["IsWorking"] = "يعمل";
                    dt.Rows.Add(row1);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}