using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Account
{
    public partial class AccountConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                var Citizen = db.tblCitizens.Where(x => x.NationalNumber == CitizenNationalNum.Text).FirstOrDefault();
                if (Citizen == null)
                {
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                    Accounts.Visible = false;
                    btnActive.Visible = false;
                    btnDisActive.Visible = false;
                    return;
                }
                else
                    lblErrorMSG.Visible = false;

                var Users = Helper.GetUsers(CitizenNationalNum.Text);
                if (Users.Count > 0)
                {

                    Accounts.Visible = true;
                    ddlAccounts.DataValueField = "Id";
                    ddlAccounts.DataTextField = "Username";
                    ddlAccounts.DataSource = Users;
                    ddlAccounts.DataBind();
                    ddlAccounts_SelectedIndexChanged(ddlAccounts, null);
                    btnSearch.Text = "إعادة البحث";

                }
                else
                {
                    Accounts.Visible = false;
                    btnActive.Visible = false;
                    btnDisActive.Visible = false;
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "لا يوجد أي حساب لهذا المواطن";
                    return;
                }
            }
        }
        protected void ddlAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                int userId = int.Parse(ddlAccounts.SelectedValue);
                tblCitizenRole CitizenRole = db.tblCitizenRoles.Where(y => y.UserId == userId).FirstOrDefault();
                if (CitizenRole != null)
                {
                    if (Convert.ToBoolean(CitizenRole.Taken))
                    {
                        btnActive.Visible = false;
                        btnDisActive.Visible = true;
                    }
                    else
                    {
                        btnActive.Visible = true;
                        btnDisActive.Visible = false;
                    }
                }


            }
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlAccounts.SelectedValue);
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizenRole CitizenRole = db.tblCitizenRoles.Where(y => y.UserId== id).FirstOrDefault();
                CitizenRole.Taken = true;
                db.SaveChanges();
                btnActive.Visible = false;
                btnDisActive.Visible = true;
            }
        }

        protected void btnDisActive_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlAccounts.SelectedValue);
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblCitizenRole CitizenRole = db.tblCitizenRoles.Where(y => y.UserId == id).FirstOrDefault();
                CitizenRole.Taken = false;
                db.SaveChanges();
                btnActive.Visible = true;
                btnDisActive.Visible = false;
            }
        }
    }
}