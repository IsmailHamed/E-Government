using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                tblUser user = new tblUser();

                if(!Helper.CheckIsCitizen(txtNationalNumber.Text))
                {
                    ErrorMessage.Text = "الرقم الوطني غير موجود في قاعدة البيانات";
                    return;
                }
                if (Helper.CheckUserName(txtUserName.Text))
                {
                    ErrorMessage.Text = "اسم المستخدم مستخدم مسبقاً";
                    return;
                }

                bool IsEmployee = Helper.IsEmployee(txtNationalNumber.Text);

                if (IsEmployee)
                    user.EmployeeId = txtNationalNumber.Text;
       

                user.Username = txtUserName.Text;
                user.Password = Password.Text;
                db.tblUsers.AddObject(user);
                db.SaveChanges();

                if (!IsEmployee)
                    Helper.AddNewCitizenUser(user.Id, txtNationalNumber.Text, 2);

                Response.Redirect("/Finish");


            }

        }
    }
}