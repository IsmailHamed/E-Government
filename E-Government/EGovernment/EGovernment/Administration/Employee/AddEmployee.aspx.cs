using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Employee
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        bool EditPage = false;
        EmployeeInfo _EmployeeInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.AddEmployee)
                Response.Redirect("/403");


            if (!IsPostBack)
            {
                _EmployeeInfo = (EmployeeInfo)Session["EmployeeInfo"];
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    tblCivilAffair civilAffairs = new tblCivilAffair();
                    var c1 = db.tblCivilAffairs.ToList();
                    ddlCivilAffairs.DataValueField = "Id";
                    ddlCivilAffairs.DataTextField = "Name";
                    ddlCivilAffairs.DataSource = c1;
                    ddlCivilAffairs.DataBind();

                    if (_EmployeeInfo == null)
                    {
                        tblCivilRegistry civilregistry = new tblCivilRegistry();
                        int idCivilAffairs = int.Parse(ddlCivilAffairs.SelectedItem.Value);
                        var c = db.tblCivilRegistries.Where(b => b.CivilAffairsID == 1).ToList();
                        ddlCivilRegistry.DataValueField = "Id";
                        ddlCivilRegistry.DataTextField = "Name";
                        ddlCivilRegistry.DataSource = c;
                        ddlCivilRegistry.DataBind();
                    }

                    tblRole roles = new tblRole();
                    var temp = db.tblRoles.ToList();
                    ddlRole.DataValueField = "Id";
                    ddlRole.DataTextField = "Name";
                    ddlRole.DataSource = temp;
                    ddlRole.DataBind();


                }

                if (_EmployeeInfo != null)
                {
                    MultiView.ActiveViewIndex = 1;
                    btnPrevious.Visible = false;
                    divStatus.Visible = true;

                    EditPage = true;
                    labelNationalNum.Text = _EmployeeInfo.NationalNumber;
                    labelFirstName.Text = _EmployeeInfo.FirstName;
                    lableLastName.Text = _EmployeeInfo.LastName;
                    tblCitizen citizen = Helper.GetCitizen(_EmployeeInfo.NationalNumber);

                    try
                    {
                        lableFatherName.Text = Helper.GetCitizen(Helper.GetCitizen(_EmployeeInfo.NationalNumber).FatherNationalNumber).FirstName;
                        lableMotherName.Text = Helper.GetCitizen(Helper.GetCitizen(_EmployeeInfo.NationalNumber).MotherNationalNumber).FirstName;
                    }
                    catch { }

                    txtAddress.Text = _EmployeeInfo.Address;
                    txtPhoneNumber.Text = _EmployeeInfo.Phone;
                    txtSpecialization.Text = _EmployeeInfo.Specialization;

                    switch (_EmployeeInfo.Rank)
                    {
                        case "مدير":
                            rdoManager.Checked = true;
                            break;

                        case "مراقب":
                            rdoIsController.Checked = true;
                            break;

                        case "أمين السجل المدني":
                            rdoIsCivilRegisterer.Checked = true;
                            break;

                        case "موظف عادي":
                            rdoEmployee.Checked = true;
                            break;

                    }
                    ddlCivilAffairs.SelectedValue = _EmployeeInfo.CivilAffairs;

                    using (EGovernmentEntities db = new EGovernmentEntities())
                    {
                        tblCivilRegistry civilregistry = new tblCivilRegistry();
                        int idCivilAffairs = int.Parse(ddlCivilAffairs.SelectedItem.Value);
                        var c = db.tblCivilRegistries.Where(b => b.CivilAffairsID == idCivilAffairs).ToList();
                        ddlCivilRegistry.DataValueField = "Id";
                        ddlCivilRegistry.DataTextField = "Name";
                        ddlCivilRegistry.DataSource = c;
                        ddlCivilRegistry.DataBind();
                    }

                    ddlCivilRegistry.SelectedValue = _EmployeeInfo.CivilRegistry;
                    ddlRole.SelectedValue = _EmployeeInfo.Role;
                    CheckBox1.Checked = _EmployeeInfo.IsWorking;


                    btnAdd.Text = "حفظ التعديلات";

                    Session["CitizenInfo"] = null;
                }
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    var employee = db.tblCitizens.Where(x => x.NationalNumber == EmployeeNationalNum.Text).FirstOrDefault();
                    if (employee == null)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(EmployeeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني يعود إلى مواطن متوفى";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsEmployee(EmployeeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني يعود إلى مواطن موظف مسبقاً";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    String FatherNationalNum = employee.FatherNationalNumber;
                    if (FatherNationalNum != null)
                    {
                        var Father = db.tblCitizens.Where(x => x.NationalNumber == FatherNationalNum).FirstOrDefault();
                        if (Father != null) lableFatherName.Text = Father.FirstName;
                    }

                    String MotherNaionalNum = employee.MotherNationalNumber;
                    if (MotherNaionalNum != null)
                    {
                        var Mother = db.tblCitizens.Where(x => x.NationalNumber == MotherNaionalNum).FirstOrDefault();
                        if (Mother != null) lableMotherName.Text = Mother.FirstName + " " + Mother.LastName;
                    }
                    labelNationalNum.Text = employee.NationalNumber;
                    labelFirstName.Text = employee.FirstName;
                    lableLastName.Text = employee.LastName;

                }
            }

            MultiView.ActiveViewIndex = 1;

        }
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 2;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 0;
        }
        protected void btnPrevious1_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    EditPage = (btnAdd.Text == "حفظ التعديلات");
                    tblEmployee employee;
                    if (EditPage)
                        employee = db.tblEmployees.Where(x => x.NationalNumber == labelNationalNum.Text).FirstOrDefault();
                    else
                        employee = new tblEmployee();

                    var citizen = db.tblCitizens.Where(b => b.NationalNumber == EmployeeNationalNum.Text).FirstOrDefault();
                    employee.NationalNumber = labelNationalNum.Text;
                    employee.Address = txtAddress.Text;
                    employee.Specialization = txtSpecialization.Text;
                    employee.Phone = txtPhoneNumber.Text;

                    if (!EditPage)
                    {
                        if (db.tblEmployees.Where(x => x.NationalNumber == employee.NationalNumber).ToList().Count == 0)
                            db.tblEmployees.AddObject(employee);
                    }

                    tblEmployeesCivilRegistry empcivil;
                    if (EditPage)
                        empcivil = db.tblEmployeesCivilRegistries.Where(x => x.EmployeNationalNumber == labelNationalNum.Text).OrderByDescending(x => x.Id).FirstOrDefault();
                    else
                        empcivil = new tblEmployeesCivilRegistry();

                    empcivil.IsManager = rdoManager.Checked;
                    empcivil.IsCivilRegisterer = rdoIsCivilRegisterer.Checked;
                    empcivil.IsController = rdoIsController.Checked;
                    empcivil.RoleId = int.Parse(ddlRole.SelectedValue);
                    if (!CheckBox1.Checked)
                        empcivil.E_date = DateTime.Now;

                    int CivilRegistryID = int.Parse(ddlCivilRegistry.SelectedValue);
                    if (!rdoManager.Checked)
                        empcivil.CivilRegistryID = CivilRegistryID;

                    empcivil.EmployeNationalNumber = employee.NationalNumber;
                    empcivil.S_date = DateTime.Now;

                    if (!EditPage)
                        db.tblEmployeesCivilRegistries.AddObject(empcivil);

                    if (Convert.ToBoolean(empcivil.IsManager))
                    {
                        List<tblEmployee> lstEmployees = Helper.GetEmployeeByAffairs(CivilRegistryID);
                        Helper.UnManager(lstEmployees);
                    }

                    if (Convert.ToBoolean(empcivil.IsCivilRegisterer))
                    {
                        List<tblEmployee> lstEmployees = Helper.GetEmployeeByCivilRegisterar(CivilRegistryID);
                        Helper.UnCivilRegisterer(lstEmployees);
                    }

                    if (Convert.ToBoolean(empcivil.IsController))
                    {
                        List<tblEmployee> lstEmployees = Helper.GetEmployeeByCivilRegisterar(CivilRegistryID);
                        Helper.UnController(lstEmployees);
                    }



                    db.SaveChanges();

                    Response.Redirect("/Finish");
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
                ddlCivilRegistry.DataValueField = "Id";
                ddlCivilRegistry.DataTextField = "Name";
                ddlCivilRegistry.DataSource = c;
                ddlCivilRegistry.DataBind();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Text = (CheckBox1.Checked) ? "يعمل" : "لا يعمل";
        }

        protected void rdoManager_CheckedChanged(object sender, EventArgs e)
        {

            divCivilRegistry.Visible = !rdoManager.Checked;
        }

        protected void rdoIsCivilRegisterer_CheckedChanged(object sender, EventArgs e)
        {
            divCivilRegistry.Visible = true;


        }
    }
}