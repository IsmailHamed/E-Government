using System;
using System.Web;
using System.Web.UI;
using System.Linq;

namespace EGovernment.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                bool IsCitizen = true;
                if (Helper.CheckUserName(txtUserName.Value))
                    if (Helper.CheckPassWord(txtPassword.Value, txtUserName.Value))
                    {
                        //Session["UserName"] = txtUserName.Value;
                        string nationalNum = Helper.GetEmployeeId(txtUserName.Value);
                        tblEmployee emp = Helper.GetEmployee(nationalNum);
                        if (emp != null)
                        {
                            tblEmployeesCivilRegistry employeeCivilRegistry = Helper.GetActiveEmployeeRecord(nationalNum);

                            if (employeeCivilRegistry != null)
                            {
                                Session["CurrUser"] = emp;

                                Session["Role"] = Helper.GetRoleById(employeeCivilRegistry.RoleId);

                                IsCitizen = false;
                            }
                        }
                        else if (IsCitizen)
                        {
                            bool ConfirmUser = Helper.IsConfirm(txtUserName.Value);
                            if (ConfirmUser)
                                Session["Role"] = Helper.GetRoleById(2);
                            else
                                Response.Redirect("/403");

                        }

                        Session["CitizenNN"] = Helper.GetNNByUserName(txtUserName.Value);
                        Session["UserName"] = txtUserName.Value;
                        Response.Redirect("/Administration/Default");
                    }
                    else
                    {
                        FailureText.Text = "كلمة المرور خاطئة";
                        ErrorMessage.Visible = true;
                    }
                else
                {
                    FailureText.Text = "اسم المستخدم غير موجود";
                    ErrorMessage.Visible = true;

                }
            }
        }
    }
}