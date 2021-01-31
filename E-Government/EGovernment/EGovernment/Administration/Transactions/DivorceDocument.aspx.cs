using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Transactions
{
    public partial class DivorceDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.DivorceDoc)
                Response.Redirect("/403");
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == HusbandNationalNum.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (db.tblCitizens.Where(x => x.NationalNumber == HusbandNationalNum.Text).FirstOrDefault().Gender.Trim() == "0")
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل خاص بأنثى";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(HusbandNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الطلاق من صاحب هذا الرقم الوطني لأنه ميت";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.IsHusbandMarried(HusbandNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الطلاق من صاحب هذا الرقم الوطني لأنه غير متزوج";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;
                }
            }

            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == WifeNationalNum.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (db.tblCitizens.Where(x => x.NationalNumber == WifeNationalNum.Text).FirstOrDefault().Gender.Trim() == "1")
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل خاص بذكر";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الطلاق من صاحبة هذا الرقم الوطني لأنها ميتة";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;


                    if (!Helper.IsWifeMarried(WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الطلاق من صاحبة هذا الرقم الوطني لأنها غير متزوجة";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;
                    // مطلقة لم تكمل العدة  3أشهر إذا مطلقة و3 أشهر وعشر أيام أرملة
                }
            }

            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnPrevious2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Penalty = Helper.GetPenalty(HusbandNationalNum.Text, (int)(DateTime.Today - DateTime.Parse(IncidentDate.Value)).TotalDays, IncidentType.Divorce);
                if (!Helper.CheckBalance(HusbandNationalNum.Text, Penalty))
                {
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "لا يمكن إتمام واقعة الطلاق لأن حسابك لا يحوي على المبلغ الكافي لتسديد الضريبة";
                    return;
                }
                else
                    lblErrorMSG.Visible = false;
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == txtFirstWitness.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل للشاهد الأول غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (db.tblCitizens.Where(x => x.NationalNumber == txtSecondWitness.Text).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل للشاهد الثاني غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;


                    if (HusbandNationalNum.Text == txtFirstWitness.Text || HusbandNationalNum.Text == txtSecondWitness.Text)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن للزوج بأن يكون أحد الشهود";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (WifeNationalNum.Text == txtFirstWitness.Text || WifeNationalNum.Text == txtSecondWitness.Text)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن للزوجة بأن تكون أحد الشهود";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;


                    if (txtFirstWitness.Text == txtSecondWitness.Text)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الشهادة بشخص واحد";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(txtFirstWitness.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الشاهد الأول هو شخص متوفى";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(txtSecondWitness.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الشاهد الثاني هو شخص متوفى";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.CheckIsWife(HusbandNationalNum.Text, WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن إتمام العملية، لأن هذه المواطنة ليست على ذمة هذا الرجل";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDivorceBeforeMarriage(HusbandNationalNum.Text, WifeNationalNum.Text, IncidentDate.Value))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن إتمام العملية، لأن تاريخ الطلاق يسبق تاريخ آخر واقعة زواج";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetDate(IncidentDate.Value) > DateTime.Now)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "تاريخ الطلاق أكبر من التاريخ الحالي";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;   

                    tblDivorceIncident divorceIncident = new tblDivorceIncident();

                    divorceIncident.HusbandNationalNum = HusbandNationalNum.Text;
                    divorceIncident.WifeNationalNum = WifeNationalNum.Text;
                    divorceIncident.IncidentDate = IncidentDate.Value;
                    divorceIncident.DivorceType = ss1.Checked ? "1" : "0";
                    divorceIncident.DivorcePlace = txtDivorcePlace.Text;
                    divorceIncident.DivorceReason = txtDivorceReason.Text;
                    divorceIncident.Notes = txtNotes.Text;
                    divorceIncident.Reference = txtAuthorityAuthorizedContract.Text;
                    divorceIncident.DocumentNumber = int.Parse(txtDocumentNumber.Text);
                    divorceIncident.DocumentDate = DateTime.Now.ToShortDateString();

                    int temp = -1;
                    int.TryParse(txtAdvocacyNum.Text, out temp);

                    if (temp != -1)
                        divorceIncident.AdvocacyNum = temp;

                    divorceIncident.FirstWitnessNationalNumber = txtFirstWitness.Text;
                    divorceIncident.SecondWitnessNationalNumber = txtSecondWitness.Text;

                    db.tblDivorceIncidents.AddObject(divorceIncident);

                    if (Helper.GetActualWifes(HusbandNationalNum.Text).Count == 0)
                        Helper.EditSocialNumber(HusbandNationalNum.Text, SocialStatus.Divorced);

                    Helper.EditSocialNumber(WifeNationalNum.Text, SocialStatus.Divorced);

                    db.SaveChanges();

                    Helper.Pay(HusbandNationalNum.Text, Penalty);

                    Response.Redirect("/Finish");
                }
            }
        }
    }
}