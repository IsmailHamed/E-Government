using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Transactions
{
    public partial class Marriagedocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.MarriageDoc)
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

                    if (db.tblMarriageContracts.Where(x => x.HusbandNationalNum == HusbandNationalNum.Text).ToList().Count == 4) // TODO: still check divorce
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لقد وصل هذا المواطن إلى الحد الأعلى من عدد الزوجات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.CheckAge(HusbandNationalNum.Text, 18))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحب هذا الرقم الوطني لأنه لم يكمل السن القانوني";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(HusbandNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحب هذا الرقم الوطني لأنه ميت";
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

                    if (Helper.CheckIsWife(HusbandNationalNum.Text, WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحبة هذا الرقم الوطني لأنها زوجته بالفعل";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetForbidden(HusbandNationalNum.Text).Contains(WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحبة هذا الرقم الوطني لأنها محرم عليه";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetForbidden(WifeNationalNum.Text).Contains(HusbandNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحب هذا الرقم الوطني لأنها محرم عليها";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (!Helper.CheckAge(WifeNationalNum.Text, 17))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحبة هذا الرقم الوطني لأنها لم تكمل السن القانوني";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsDead(WifeNationalNum.Text))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الزواج بصاحبه هذا الرقم الوطني لأنها ميتة";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (db.tblMarriageContracts.Where(x => x.WifeNationalNum == WifeNationalNum.Text).ToList().Count == 1)
                        if (!Helper.IsDivorced(HusbandNationalNum.Text, WifeNationalNum.Text))
                        {
                            lblErrorMSG.Visible = true;
                            lblErrorMSG1.Text = "هذه المواطنة هي متزوجة بالفعل، لا يمكن تسجيل عقد زواج جديد لها ما لم يتم تسجيل واقعة طلاق في البداية";
                            return;
                        }
                        else
                            lblErrorMSG.Visible = false;

                    if (Helper.IsDivorced(HusbandNationalNum.Text, WifeNationalNum.Text))
                        if (Helper.CheckDuration(HusbandNationalNum.Text, WifeNationalNum.Text, 30 * 3, IncidentType.Divorce))
                        {
                            lblErrorMSG.Visible = true;
                            lblErrorMSG1.Text = "لا يمكن الزواج بصاحبه هذا الرقم الوطني لأنها مطلقة ولم تكمل عدتها بعد";
                            return;
                        }
                        else
                            lblErrorMSG.Visible = false;

                    if (Helper.IsWidow(WifeNationalNum.Text))
                        if (Helper.CheckDuration(HusbandNationalNum.Text, WifeNationalNum.Text, 30 * 3 + 10, IncidentType.Death))
                        {
                            lblErrorMSG.Visible = true;
                            lblErrorMSG1.Text = "لا يمكن الزواج بصاحبه هذا الرقم الوطني لأنها أرملة ولم تكمل عدتها بعد";
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
                int Penalty = Helper.GetPenalty(HusbandNationalNum.Text, (int)(DateTime.Today - DateTime.Parse(IncidentDate.Value)).TotalDays, IncidentType.Marriage);
                if (!Helper.CheckBalance(HusbandNationalNum.Text, Penalty))
                {
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "لا يمكن تسجيل عقد الزواج لأن حسابك لا يحوي على المبلغ الكافي لتسديد الضريبة";
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

                    if (txtFirstWitness.Text == txtSecondWitness.Text)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن الشهادة بشخص واحد";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.IsMarriageBeforeDivorce(HusbandNationalNum.Text, WifeNationalNum.Text, IncidentDate.Value))
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن إتمام العملية، لأن تاريخ الزواج يسبق تاريخ آخر واقعة طلاق";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetDate(IncidentDate.Value) > DateTime.Now)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "تاريخ حدوث الواقعة أكبر من التاريخ الحالي";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    if (Helper.GetDate(MarriageLicenseDate.Value) > DateTime.Now)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "تاريخ رخصة الزواج أكبر من التاريخ الحالي";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                    tblMarriageContract marriageContract = new tblMarriageContract();

                    marriageContract.HusbandNationalNum = HusbandNationalNum.Text;
                    marriageContract.WifeNationalNum = WifeNationalNum.Text;
                    marriageContract.FamilyNumber = GenerateFamilyNumber(db);
                    marriageContract.ContractDate = DateTime.Now.ToShortDateString();
                    marriageContract.Reference = txtAuthorityAuthorizedContract.Text;
                    marriageContract.DocumentNumber = int.Parse(txtDocumentNumber.Text);
                    marriageContract.DocumentDate = DateTime.Now.ToShortDateString();
                    marriageContract.Notes = txtNotes.Text;
                    marriageContract.IncidentDate = IncidentDate.Value;
                    marriageContract.MarriageLicenseNumber = MarriageLicenseNumber.Text;
                    marriageContract.MarriageLicenseDate = MarriageLicenseDate.Value;
                    marriageContract.PreMoney = PreMoney.Text;
                    marriageContract.PostMoney = PostMoney.Text;
                    marriageContract.MoneyStatus = ss1.Checked ? "1" : "2";
                    marriageContract.FirstWitnessNationalNumber = txtFirstWitness.Text;
                    marriageContract.SecondWitnessNationalNumber = txtSecondWitness.Text;

                    db.tblMarriageContracts.AddObject(marriageContract);


                    Helper.EditSocialNumber(HusbandNationalNum.Text, SocialStatus.Marriad);
                    Helper.EditSocialNumber(WifeNationalNum.Text, SocialStatus.Marriad);

                    db.SaveChanges();

                    Helper.Pay(HusbandNationalNum.Text, Penalty);

                    Response.Redirect("/Finish");
                }
            }
        }

        private string GenerateFamilyNumber(EGovernmentEntities db)
        {
            Random r = new Random();
            string FamilyNumber = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();

            try
            {
                while (db.tblMarriageContracts.Where(x => x.FamilyNumber == FamilyNumber).ToList().Count > 0)
                    FamilyNumber = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();
            }
            catch { }

            return FamilyNumber;
        }
    }
}