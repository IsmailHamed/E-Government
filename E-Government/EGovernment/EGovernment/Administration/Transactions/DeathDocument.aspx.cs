using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Transactions
{
    public partial class Death : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.DeathDoc)
                Response.Redirect("/403");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string FatherNationalNumber = Helper.GetCitizen(DeadNationalNumber.Text).FatherNationalNumber;
                int Penalty = Helper.GetPenalty(FatherNationalNumber, (int)(DateTime.Today - DateTime.Parse(DeadDate.Value)).TotalDays, IncidentType.Death);
                if (!Helper.CheckBalance(FatherNationalNumber, Penalty))
                {
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "لا يمكن تسجيل الوفاة لأن حسابك لا يحوي على المبلغ الكافي لتسديد الضريبة";
                    return;
                }
                else
                    lblErrorMSG.Visible = false;

                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == DeadNationalNumber.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;



                    if (Helper.GetDate(DeadDate.Value) > DateTime.Now)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "تاريخ الوفاة أكبر من التاريخ الحالي";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    

                    tblDeadRegistration deadRegistration = new tblDeadRegistration();
                    deadRegistration.NationalNumber = DeadNationalNumber.Text;
                    deadRegistration.PoliceReportNum = PoliceReportNum.Text;
                    deadRegistration.DeadPlace = DeadPlace.Text;
                    deadRegistration.DeadDate = DeadDate.Value;
                    deadRegistration.DoctorName = DoctorName.Text;
                    deadRegistration.DeadReason = DeadReason.Text;
                    deadRegistration.Notes = Notes.Text;
                    deadRegistration.IncidentDate = DateTime.Now.ToShortDateString();

                    db.tblDeadRegistrations.AddObject(deadRegistration);
                    db.SaveChanges();

                    List<string> lstWifes = Helper.GetActualWifes(DeadNationalNumber.Text);

                    foreach (string wife in lstWifes)
                        Helper.EditSocialNumber(wife, SocialStatus.Widow);


                    Helper.Pay(FatherNationalNumber, Penalty);

                    Response.Redirect("/Finish");
                }
            }
        }
    }
}