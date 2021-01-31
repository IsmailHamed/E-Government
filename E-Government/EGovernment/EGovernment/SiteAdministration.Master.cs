using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment
{
    public partial class SiteAdministration : System.Web.UI.MasterPage
    {
        tblRole role;
        string UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            role = (tblRole)Session["Role"];
            UserName = (string)Session["UserName"];
            HideListItem();
        }

        protected void HideListItem()
        {
            if (role != null)
            {
                UserName1.Visible = true;
                UserName1.Text = UserName;
                Login.Visible = false;
                Logout.Visible = true;
                dropbtnServices.Visible = true;
                dropbtnDocument.Visible = true;
                dropbtnControlCitizens.Visible = true;
                dropbtnControlEmployees.Visible = true;
                dropbtnControlAffairs.Visible = true;
                StatisticsReports.Visible = true;
                if (!role.ICR_Out)
                    IndividualCivilRegistrationOut.Visible = false;
                if (!role.BirthOut)
                    birthOut.Visible = false;
                if (!role.DeathOut)
                    deathOut.Visible = false;
                if (!role.DivorceOut)
                    divorceOut.Visible = false;
                if (!role.MarriageOut)
                    marrageOut.Visible = false;

                if (!role.MarriageOut && !role.DivorceOut && !role.DeathOut && !role.ICR_Out && !role.BirthOut)
                    dropbtnServices.Visible = false;
                if (!role.MarriageDoc)
                    MarriageDoc.Visible = false;
                if (!role.DivorceDoc)
                    DivorceDoc.Visible = false;
                if (!role.BirthDoc)
                    BirthDoc.Visible = false;
                if (!role.DeathDoc)
                    DeathDoc.Visible = false;
                if (!role.MarriageDoc && !role.DivorceDoc && !role.DeathDoc && !role.BirthDoc)
                    dropbtnDocument.Visible = false;
                if (!role.AddCitizen)
                    AddCitizen.Visible = false;
                if (!role.SearchCitizens)
                    SearchCitizens.Visible = false;
                if (!role.AddCitizen && !role.SearchCitizens)
                    dropbtnControlCitizens.Visible = false;
                if (!role.AddEmployee)
                    AddEmployee.Visible = false;
                if (!role.SearchEmployee)
                    SearchEmployee.Visible = false;
                if (!role.AddRole)
                    Roles.Visible = false;
                if (!role.EditRole)
                    EditRoles.Visible = false;
                if (!role.AddEmployee && !role.SearchEmployee && !role.AddRole && !role.EditRole)
                    dropbtnControlEmployees.Visible = false;
                if (!role.AddCivilRegister)
                    AddCivilRegistry.Visible = false;
                if (!role.EditCivilRegister)
                    EditCivilRegistry.Visible = false;
                if (!role.EditCivilRegister && !role.AddCivilRegister)
                    dropbtnControlAffairs.Visible = false;
                if (!role.StatisticsReports)
                    StatisticsReports.Visible = false;
                if (!role.UserActivation)
                    AccountConfirmation.Visible = false;
            }

        }

        protected void AddEmployee_click(object sender, EventArgs e)
        {
            Session["EmployeeInfo"] = null;
            Response.Redirect("/Administration/Employee/AddEmployee");
        }

        protected void AddRole_click(object sender, EventArgs e)
        {
            Session["RoleToEdit"] = null;
            Response.Redirect("/Administration/Roles");
        }


        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["Role"] = null;
            Session["UserName"] = null;
            Session["CitizenNN"] = null;
            Response.Redirect("~/Administration/Default");
        }
    }
}