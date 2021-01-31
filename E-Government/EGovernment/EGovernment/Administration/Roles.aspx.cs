using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration
{
    public partial class Roles : System.Web.UI.Page
    {
        bool EditPage = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole Role = (tblRole)Session["RoleToEdit"];
            if (Role != null)
            {
                EditPage = true;

                txtRole.Text = Role.Name;
                txtRoleId.Text = Role.Id.ToString();

                chklPermission.Items[0].Selected = Role.AddCitizen;
                chklPermission.Items[1].Selected = Role.SearchCitizens;
                chklPermission.Items[2].Selected = Role.EditCitizen;
                chklPermission.Items[3].Selected = Role.MarriageDoc;
                chklPermission.Items[4].Selected = Role.DivorceDoc;
                chklPermission.Items[5].Selected = Role.BirthDoc;
                chklPermission.Items[6].Selected = Role.DeathDoc;
                chklPermission.Items[7].Selected = Role.MarriageOut;
                chklPermission.Items[8].Selected = Role.DivorceOut;
                chklPermission.Items[9].Selected = Role.BirthOut;
                chklPermission.Items[10].Selected = Role.DeathOut;
                chklPermission.Items[11].Selected = Role.ICR_Out;
                chklPermission.Items[12].Selected = Role.AddEmployee;
                chklPermission.Items[13].Selected = Role.SearchEmployee;
                chklPermission.Items[14].Selected = Role.EditEmployee;
                chklPermission.Items[15].Selected = Role.AddCivilRegister;
                chklPermission.Items[16].Selected = Role.EditCivilRegister;
                chklPermission.Items[17].Selected = Role.SearchCivilRegister;
                chklPermission.Items[18].Selected = Role.StatisticsReports;
                chklPermission.Items[19].Selected = Role.UserActivation;

                btnAdd.Text = "حفظ التعديلات";

                Session["RoleToEdit"] = null;
            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblRole role = null;

                EditPage = (btnAdd.Text == "حفظ التعديلات");

                if (!EditPage)
                    role = new tblRole();
                else
                {
                    int RoleId = int.Parse(txtRoleId.Text);
                    role = db.tblRoles.Where(x => x.Id == RoleId).FirstOrDefault();
                    role.AddCitizen = role.AddCivilRegister = role.AddEmployee = role.BirthDoc = role.BirthOut = role.DeathDoc = role.DeathOut = role.DivorceDoc = role.DivorceOut = role.EditCitizen = role.EditCivilRegister = role.EditEmployee = role.ICR_Out = role.MarriageDoc = role.MarriageOut = role.SearchCitizens = role.SearchCivilRegister = role.SearchEmployee = role.StatisticsReports = role.UserActivation = false;
                }

                List<ListItem> lstSelectedItems = chklPermission.Items.Cast<ListItem>()
                                .Where(x => x.Selected).ToList();

                foreach (var item in lstSelectedItems)
                {
                    switch (item.Value)
                    {
                        case "إضافة مواطن":
                            role.AddCitizen = true;
                            break;
                        case "بحث عن مواطن":
                            role.SearchCitizens = true;
                            break;
                        case "تعديل مواطن":
                            role.EditCitizen = true;
                            break;
                        case "تسجيل واقعة الزواج":
                            role.MarriageDoc = true;
                            break;
                        case "تسجيل واقعة طلاق":
                            role.DivorceDoc = true;
                            break;
                        case "تسجيل بيان ولادة":
                            role.BirthDoc = true;
                            break;
                        case "تسجيل بيان وفاة":
                            role.DeathDoc = true;
                            break;
                        case "إصدار بيان زواج":
                            role.MarriageOut = true;
                            break;
                        case "إصدار بيان طلاق":
                            role.DivorceOut = true;
                            break;

                        case "إصدار بيان ولادة":
                            role.BirthOut = true;
                            break;

                        case "إصدار بيان وفاة":
                            role.DeathOut = true;
                            break;

                        case "إخراج قيد":
                            role.ICR_Out = true;
                            break;
                        case "إضافة موظف":
                            role.AddEmployee = true;
                            break;
                        case "بحث عن موظف":
                            role.SearchEmployee = true;
                            break;
                        case "تعديل بيانات موظف":
                            role.EditEmployee = true;
                            break;
                        case "إضافة سجل مدني":
                            role.AddCivilRegister = true;
                            break;
                        case "تعديل سجل مدني":
                            role.EditCivilRegister = true;
                            break;
                        case "بحث عن سجل مدني":
                            role.SearchCivilRegister = true;
                            break;

                        case "التقارير الإحصائية":
                            role.StatisticsReports = true;
                            break;

                        case "تفعيل حساب مواطن":
                            role.UserActivation = true;
                            break;
                    }
                }

                role.Name = txtRole.Text;

                if (!EditPage)
                    db.tblRoles.AddObject(role);

                db.SaveChanges();
            }

            Response.Redirect("/Finish");
        }
    }
}
