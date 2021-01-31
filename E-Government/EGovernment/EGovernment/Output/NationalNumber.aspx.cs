using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Output
{
    public partial class NationalNumber : System.Web.UI.Page
    {
        string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = Request.QueryString["id"];
                if (id.ToLower() == "death")
                    chkForWhome.Visible = true;
            }
            catch { }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EGovernmentEntities db = new EGovernmentEntities())
                {
                    if (db.tblCitizens.Where(x => x.NationalNumber == txtNationalNumber.Value).ToList().Count == 0)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "الرقم الوطني المدخل غير موجود في قاعدة البيانات";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;
                }

                if (Session["CitizenNN"] != null && !string.IsNullOrEmpty((string)Session["CitizenNN"]))
                    if ((string)Session["CitizenNN"] != txtNationalNumber.Value)
                    {
                        lblErrorMSG.Visible = true;
                        lblErrorMSG1.Text = "لا يمكن استخراج استمارات لمواطنين آخرين";
                        return;
                    }
                    else
                        lblErrorMSG.Visible = false;

                Session["SVCNationalNumber"] = txtNationalNumber.Value;
                switch (id.ToLower())
                {
                    case "individualcivilregistration":
                        Response.Redirect("/Output/IndividualCivilRegistration");
                        break;

                    case "birth":
                        Session["Out_Id"] = "birth";
                        using (EGovernmentEntities db = new EGovernmentEntities())
                        {
                            int childrenCount = db.tblCitizens.Where(x => x.FatherNationalNumber == txtNationalNumber.Value).ToList().Count;
                            lblErrorMSG.Visible = false;
                            if (childrenCount == 0)
                            {
                                lblErrorMSG.Visible = true;
                                lblErrorMSG1.Text = "لا يوجد أية أولاد مرتبطة بالرقم الوطني للأب المدخل";
                                return;
                            }
                            else
                            {
                                if (childrenCount > 1) // لديه أكثر من ولد
                                    Response.Redirect("/Output/MDChildSelection");
                                else
                                    Response.Redirect("/Output/Birth");
                            }
                        }

                        break;

                    case "death":
                        if (id.ToLower() == "death")
                            if (!Helper.IsDead(txtNationalNumber.Value))
                            {
                                lblErrorMSG.Visible = true;
                                if (!chkForWhome.Checked)
                                    lblErrorMSG1.Text = "الرقم الوطني المدخل يخص مواطن غير متوفى";
                                else
                                    lblErrorMSG1.Text = "الرقم الوطني للأب المدخل ليس لديه أي أولاد توفوا من قبل";
                                return;
                            }
                            else
                                lblErrorMSG.Visible = false;

                        Session["Out_Id"] = "death";
                        using (EGovernmentEntities db = new EGovernmentEntities())
                        {
                            if (!chkForWhome.Checked)
                            {
                                Session["SVCNationalNumber"] += ";" + db.tblCitizens.Where(x => x.NationalNumber == txtNationalNumber.Value).FirstOrDefault().NationalNumber;
                                Response.Redirect("/Output/death");
                            }
                            else
                            {
                                int childrenCount = db.tblCitizens.Where(x => x.FatherNationalNumber == txtNationalNumber.Value).ToList().Count;
                                lblErrorMSG.Visible = false;
                                if (childrenCount == 0)
                                {
                                    lblErrorMSG.Visible = true;
                                    lblErrorMSG1.Text = "لا يوجد أية أولاد مرتبطة بالرقم الوطني للأب المدخل";
                                    return;
                                }
                                else
                                {
                                    if (childrenCount > 1) // لديه أكثر من ولد
                                        Response.Redirect("/Output/MDChildSelection");
                                    else
                                    {
                                        Session["SVCNationalNumber"] += ";" + db.tblCitizens.Where(x => x.FatherNationalNumber == txtNationalNumber.Value).FirstOrDefault().NationalNumber;
                                        Response.Redirect("/Output/death");
                                    }
                                }
                            }
                        }
                        break;

                    case "divorce":
                        if (!Helper.HasAtleastOneDivorce(txtNationalNumber.Value))
                        {
                            lblErrorMSG.Visible = true;
                            lblErrorMSG1.Text = "لم يقم هذا الزواج بالطلاق مطلقاً إلى الآن";
                            return;
                        }
                        else
                            Response.Redirect("/Output/divorce");
                        break;

                    case "marrage":
                        using (EGovernmentEntities db = new EGovernmentEntities())
                        {
                            int wifesCount = db.tblMarriageContracts.Where(x => x.HusbandNationalNum == txtNationalNumber.Value).ToList().Count;
                            lblErrorMSG.Visible = false;
                            if (wifesCount == 0)
                            {
                                lblErrorMSG.Visible = true;
                                lblErrorMSG1.Text = "لا يوجد أي زوجة مرتبطة بالرقم الوطني للزوج المدخل";
                                return;
                            }
                            else if (wifesCount > 1) // لديه أكثر من زوجة
                            {
                                Response.Redirect("/Output/MDWifeSelection");
                            }
                        }
                        Response.Redirect("/Output/marrage");
                        break;
                }
            }
        }

        protected void chkForWhome_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForWhome.Checked)
                chkForWhome.Text = "هذا الرقم يعود لوالد المتوفى";
            else
                chkForWhome.Text = "هذا الرقم يخص المتوفى بحد ذاته";
        }
    }
}