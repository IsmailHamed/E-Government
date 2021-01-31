using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitizensGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                if (chkClear.Checked)
                    foreach (tblCitizen item in db.tblCitizen)
                        db.tblCitizen.DeleteObject(item);

                Random r = new Random();
                List<string> lstNationalNumbers = new List<string>();
                for (int i = 0; i < numRows.Value; i++)
                {
                    tblCitizen newCitizen = new tblCitizen();
                    newCitizen.Gender = (i % 2 == 0) ? "1" : "0";

                    if (newCitizen.Gender == "1")
                        newCitizen.FirstName = lstMaleNames[r.Next(0, lstMaleNames.Count)];
                    else
                        newCitizen.FirstName = lstFemaleNames[r.Next(0, lstFemaleNames.Count)];

                    newCitizen.LastName = lstMaleNames[r.Next(0, lstMaleNames.Count)];
                    //newCitizen.FatherName = lstMaleNames[r.Next(0, lstMaleNames.Count)];
                    //newCitizen.MotherName = lstFemaleNames[r.Next(0, lstFemaleNames.Count)];
                    newCitizen.NationalNumber = GetNationalNumber(db, lstNationalNumbers);
                    lstNationalNumbers.Add(newCitizen.NationalNumber);
                    newCitizen.Birthday = GetRandomDateTime();
                    newCitizen.BirthPlace = lstGovernorate[r.Next(0, lstGovernorate.Count)];
                    newCitizen.Amana = "الأمانة المركزية";
                    newCitizen.KiedPlace = newCitizen.BirthPlace;
                    newCitizen.KiedNumber = r.Next(1, 60).ToString();
                    newCitizen.SocialStatus = r.Next(1, 5).ToString();
                    newCitizen.Religion = lstReligion[r.Next(0, 3)];

                    db.tblCitizen.AddObject(newCitizen);
                }
                db.SaveChanges();


                foreach (var item in db.tblCitizen)
                {
                    tblCitizen newCitizen;
                    #region Father
                    newCitizen = new tblCitizen();
                    newCitizen.Gender = "1";
                    newCitizen.SocialStatus = "2";
                    newCitizen.Religion = lstReligion[r.Next(0, 3)];
                    newCitizen.KiedPlace = item.KiedPlace;
                    newCitizen.KiedNumber = item.KiedNumber;
                    newCitizen.Amana = "الأمانة المركزية";
                    newCitizen.BirthPlace = newCitizen.KiedPlace;
                    newCitizen.Birthday = DateTime.Parse(item.Birthday).AddYears(-15).AddMonths(-5).AddDays(-3).ToShortDateString();
                    newCitizen.LastName = item.LastName;
                    newCitizen.FirstName = lstMaleNames[r.Next(0, lstMaleNames.Count)];
                    newCitizen.NationalNumber = GetNationalNumber(db, lstNationalNumbers);
                    item.FatherNationalNumber = newCitizen.NationalNumber;

                    lstNationalNumbers.Add(newCitizen.NationalNumber);

                    db.tblCitizen.AddObject(newCitizen);
                    #endregion

                    #region Mother
                    newCitizen = new tblCitizen();
                    newCitizen.Gender = "0";
                    newCitizen.SocialStatus = "2";
                    newCitizen.Religion = lstReligion[r.Next(0, 3)];
                    newCitizen.KiedPlace = item.KiedPlace;
                    newCitizen.KiedNumber = r.Next(1, 60).ToString();
                    newCitizen.Amana = "الأمانة المركزية";
                    newCitizen.BirthPlace = newCitizen.KiedPlace;
                    newCitizen.Birthday = DateTime.Parse(item.Birthday).AddYears(-10).AddMonths(-3).AddDays(-1).ToShortDateString();
                    newCitizen.LastName = lstMaleNames[r.Next(0, lstMaleNames.Count)];
                    newCitizen.FirstName = lstFemaleNames[r.Next(0, lstFemaleNames.Count)];
                    newCitizen.NationalNumber = GetNationalNumber(db, lstNationalNumbers);
                    item.MotherNationalNumber = newCitizen.NationalNumber;

                    lstNationalNumbers.Add(newCitizen.NationalNumber);

                    db.tblCitizen.AddObject(newCitizen);
                    #endregion


                    db.tblCitizen.AddObject(newCitizen);
                }
                db.SaveChanges();
                MessageBox.Show("تم الحفظ بنجاح");
            }
        }


        private string GetNationalNumber(EGovernmentEntities db, List<string> lstNationalNumbers)
        {
            Random r = new Random();
            string nationalNum = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();

            try
            {
                while (db.tblCitizen.Where(x => x.NationalNumber == nationalNum).ToList().Count > 0 || lstNationalNumbers.Contains(nationalNum))
                    nationalNum = r.Next(11111, 99999).ToString() + r.Next(111111, 999999).ToString();
            }
            catch { }

            return nationalNum;
        }

        private Random ran = new Random();
        int range = (DateTime.Today - new DateTime(1995, 1, 1)).Days;
        private string GetRandomDateTime()
        {
            return new DateTime(1995, 1, 1).AddDays(ran.Next(range)).ToShortDateString();
        }

        private string FixedString(string prefix, string value, int length)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(prefix);

            for (int i = length - (prefix.Length + value.Length); i < length; i++)
                sb.Append("0");

            sb.Append(value);

            return sb.ToString();
        }

        List<string> lstReligion = new List<string>
        {
            "مسلم",
            "مسيحي",
            "درزي"
        };

        List<string> lstGovernorate = new List<string> 
        {
            "دمشق",
            "درعا",
            "حمص",
            "حلب",
            "اللاذقية",
            "طرطوس",
            "إدلب",
            "دير الزور",
            "القنيطرة",
            "البوكمال",
            "حماة",
            "السويداء",
            "الرقة",
            "الحسكة"
        };

        List<string> lstFemaleNames = new List<string> 
        {
            "رواح"
,"مرجان"
,"آيه"
,"آيات"
,"آلأء"
,"آمنه"
,"ابرار"
,"إحسان"
,"أحلام"
,"اخلاص"
,"اسراء"
,"أسماء"
,"اسلام"
,"إشراق"
,"أفنان"
,"إكرام"
,"أماني"
,"أنعام"
,"إيمان"
,"ايلاف"
,"براءة"
,"بشرى"
,"بيان"
,"تحية"
,"اسلام"
,"تحاسين"
,"تحرير"
,"جهاد"
,"تمام"
,"نهاد"
,"حماس"
,"سهيل"
,"رال"
,"حياتي"
,"رجاء"
,"عفلق"
,"رماح"
,"غدق"
,"سرور"
,"مكارم"
,"سلام"
,"مبروكة"
,"مروة"
,"مروى"
,"مناصف"
,"منى"
,"مها"
,"مهيبة"
,"ميا"
,"ميساء"
,"ميمونة"
        };


        List<string> lstMaleNames = new List<string> 
        {
            "سليم"
,"وهب"
,"رمضان"
,"منير"
,"جلال"
,"مرشد"
,"نجم"
,"قمر"
,"بحر"
,"جمال"
,"سراج"
,"احمد"
,"علي"
,"حسن"
,"يوسف"
,"ابراهيم"
,"نوح"
,"آدم"
,"عيسى"
,"شعيب"
,"ايوب"
,"يعقوب"
,"يونس"
,"موسى"
,"داوود"
,"سليمان"
,"عزيز"
,"زكريا"
,"يحيى"
,"حكيم"
,"سلطان"
,"عمران"
,"قارون"
,"عبدالله"
,"محسن"
,"رسول"
,"نور"
,"هارون"
,"ضياء"
,"بدر"
,"اسماعيل"
,"اسحاق"
,"عذاب"
,"معمر"
,"وحيد"
,"منتصر"
,"معين"
,"طيب"
,"هادي"
,"فؤاد"
,"بصير"
,"جميل"
,"محمود"
,"ساجد"
,"وليد"
,"حبيب"
,"صابر"
,"صالح"
,"محفوظ"
,"صادق"
,"فضل"
,"مجيد"
,"سعيد"
,"خليل"
,"ناصر"
,"صباح"
,"شهيد"
,"عالم"
,"فرج"
,"لطيف"
,"كريم"
,"جواد"
,"مبارك"
,"ادريس"
,"إلياس"
,"عماد"
,"مطر"
,"رعد"
,"منصور"
,"شاهد"
,"بديع"
,"ناصح"
,"صديق"
,"شهاب"
,"حرب"
,"جهاد"
,"نصير"
,"بشير"
,"نذير"
,"منذر"
        };
    }
}
