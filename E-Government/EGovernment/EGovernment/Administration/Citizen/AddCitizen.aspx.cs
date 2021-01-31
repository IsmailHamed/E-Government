using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Citizen
{
    public partial class AddCitizen : System.Web.UI.Page
    {
        bool EditPage = false;
        CitizenInfo _CitizenInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            tblRole role = (tblRole)Session["Role"];
            if (role == null || !role.AddCitizen)
                Response.Redirect("/403");


            _CitizenInfo = (CitizenInfo)Session["CitizenInfo"];
            if (_CitizenInfo != null)
            {
                EditPage = true;
                NationalNumber.Disabled = true;
                FirstName.Value = _CitizenInfo.FirstName;
                LastName.Value = _CitizenInfo.LastName;
                FatherNationalNumber.Value = _CitizenInfo.FatherNationalNumber;
                MotherNationalNumber.Value = _CitizenInfo.MotherNationalNumber;
                NationalNumber.Value = _CitizenInfo.NationalNumber;
                Birthday.Value = DateTime.Parse(_CitizenInfo.Birthday).ToString("yyyy-MM-dd");
                BirthPlace.Value = _CitizenInfo.BirthPlace;
                KiedPlace.Value = _CitizenInfo.KiedPlace;
                KiedNumber.Value = _CitizenInfo.KiedNumber;
                Religion.Value = _CitizenInfo.Religion;

                switch (_CitizenInfo.Gender)
                {
                    case "ذكر":
                        male.Checked = true;
                        break;

                    case "أنثى":
                        female.Checked = true;
                        break;
                }


                switch (_CitizenInfo.SocialStatus)
                {
                    case "عازب":
                        ss1.Checked = true;
                        break;

                    case "متأهل":
                        ss2.Checked = true;
                        break;

                    case "أرمل":
                        ss3.Checked = true;
                        break;

                    case "مطلق":
                        ss4.Checked = true;
                        break;
                }


                if (Directory.Exists(Server.MapPath("~/Images/" + _CitizenInfo.NationalNumber + "/")))
                    foreach (string item in Directory.GetFiles(Server.MapPath("~/Images/" + _CitizenInfo.NationalNumber + "/")))
                    {
                        if (Path.GetFileName(item).Contains("Profile"))
                        {
                            Image1.ImageUrl = "~/Images/" + _CitizenInfo.NationalNumber + "/" + Path.GetFileName(item);
                            break;
                        }
                    }

                btnAdd.Text = "حفظ التعديلات";

                Session["CitizenInfo"] = null;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                EditPage = (btnAdd.Text == "حفظ التعديلات");
                #region Checks
                if (!EditPage && db.tblCitizens.Where(x => x.NationalNumber == NationalNumber.Value).ToList().Count > 0)
                {
                    var cit = db.tblCitizens.Where(x => x.NationalNumber == NationalNumber.Value).FirstOrDefault();
                    lblErrorMSG.Visible = true;
                    lblErrorMSG1.Text = "الرقم الوطني المدخل موجود مسبقاً في قاعدة البيانات" + Environment.NewLine + "ويعود للمواطن " + string.Format("{0} {1} {2}", cit.FirstName, Helper.GetCitizen(cit.FatherNationalNumber).FirstName, cit.LastName);
                    return;
                }
                #endregion

                tblCitizen citizen;
                string NationalNum = string.Empty;

                if (EditPage)
                    citizen = db.tblCitizens.Where(x => x.NationalNumber == NationalNumber.Value).FirstOrDefault();
                else
                    citizen = new tblCitizen();
                
                citizen.Birthday = Birthday.Value;
                citizen.BirthPlace = BirthPlace.Value;
                citizen.FatherNationalNumber = FatherNationalNumber.Value; //
                citizen.FirstName = FirstName.Value;
                citizen.Gender = male.Checked ? "1" : "0";
                citizen.KiedPlace = KiedPlace.Value;
                citizen.KiedNumber = KiedNumber.Value;
                citizen.Religion = Religion.Value;
                citizen.LastName = LastName.Value;
                citizen.MotherNationalNumber = MotherNationalNumber.Value;//
                citizen.NationalNumber = NationalNumber.Value;
                citizen.SocialStatus = ss1.Checked ? "1" : ss2.Checked ? "2" : ss3.Checked ? "3" : "4";

                if (!EditPage)
                {
                    db.tblCitizens.AddObject(citizen);
                    RestHelper.AddCitizen(citizen);
                }
                else
                    RestHelper.EditCitizen(citizen);
                
                db.SaveChanges();

             
                if (!Helper.HasBalance(NationalNumber.Value))
                    Helper.AddBalance(NationalNumber.Value, 50000);


                if (Directory.Exists(Server.MapPath("~/Images/" + NationalNumber + "/")))
                    Directory.Delete(Server.MapPath("~/Images/" + NationalNumber + "/"));

                if (!string.IsNullOrEmpty(FileUploadControl.FileName))
                {
                    string filename = "Profile" + Path.GetExtension(FileUploadControl.FileName);

                    if (!Directory.Exists(Server.MapPath("~/Images/" + citizen.NationalNumber)))
                        Directory.CreateDirectory(Server.MapPath("~/Images/" + citizen.NationalNumber));

                    FileUploadControl.SaveAs(Server.MapPath("~/Images/" + citizen.NationalNumber + "/") + filename);
                }
                
                Session["CitizenInfo"] = null;
                Response.Redirect("/Finish");
            }
        }
    }
}