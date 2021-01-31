using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Transactions
{
    public partial class Birth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.BirthDoc)
                Response.Redirect("/403");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Penalty = Helper.GetPenalty(FatherNationalNumber.Text, (int)(DateTime.Today - DateTime.Parse(IncidentDate.Value)).TotalDays, IncidentType.Birth);
                if (!Helper.CheckBalance(FatherNationalNumber.Text, Penalty))
                {
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "لا يمكن تسجيل الولادة لأن حسابك لا يحوي على المبلغ الكافي لتسديد الضريبة";
                    return;
                }
                else
                    lblErrorMSG.Visible = false;

                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == FatherNationalNumber.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل للأب غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (db.tblCitizens.Where(x => x.NationalNumber == MotherNationalNumber.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل للأم غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.CheckIsWife(FatherNationalNumber.Text,MotherNationalNumber.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الأم ليست على ذمة هذا الرجل";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.CheckPregnancy(Pregnancy.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "مدة الحمل غير نظامية";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetDate(IncidentDate.Value) > DateTime.Now)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "تاريخ الولادة أكبر من التاريخ الحالي";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;   

                    tblCitizen father = Helper.GetCitizen(FatherNationalNumber.Text);

                    tblCitizen citize = new tblCitizen();
                    citize.NationalNumber = Helper.GetNationalNumber(db, new List<string>());
                    citize.KiedPlace = father.KiedPlace;
                    citize.KiedNumber = father.KiedNumber;
                    citize.LastName = father.LastName;
                    citize.BirthPlace = BirthPlace1.Text;
                    citize.Birthday = IncidentDate.Value;
                    citize.Gender = male.Checked ? "1" : "0";
                    citize.SocialStatus = "1";
                    citize.Religion = father.Religion;
                    citize.FirstName = ChildName.Text;
                    citize.FatherNationalNumber = FatherNationalNumber.Text;
                    citize.MotherNationalNumber = MotherNationalNumber.Text;
                    db.tblCitizens.AddObject(citize);
                    db.SaveChanges();


                    tblBirthRegistration birthRegistration = new tblBirthRegistration();
                    birthRegistration.NationalNumber = citize.NationalNumber;
                    birthRegistration.Pregnancy = int.Parse(Pregnancy.Text);
                    birthRegistration.Doctor = Doctor.Text;
                    birthRegistration.BirthPlace = ss1.Checked ? "1" : ss2.Checked ? "2" : "3";
                    birthRegistration.BirthType = ss4.Checked ? "1" : ss5.Checked ? "2" : "3";
                    birthRegistration.Notes = txtNotes.Text;
                    birthRegistration.IncidentDate = DateTime.Now.ToShortDateString();
                    db.tblBirthRegistrations.AddObject(birthRegistration);
                    db.SaveChanges();

                    Helper.Pay(FatherNationalNumber.Text, Penalty);

                    Response.Redirect("/Finish");
                }
            }
        }
    }
}