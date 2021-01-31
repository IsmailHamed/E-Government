using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration
{
    public partial class Default : System.Web.UI.Page
    {
        tblRole role;

        protected void Page_Load(object sender, EventArgs e)
        {
            role = (tblRole)Session["Role"];

        }

        protected void IndividualCivilRegistration_Click(object sender, EventArgs e)
        {
            if (role != null)
                Response.Redirect("/Output/NationalNumber?id=IndividualCivilRegistration");
            else
                Response.Redirect("/Account/Login");

        }

        protected void birth_Click(object sender, EventArgs e)
        {
            if (role != null)
                Response.Redirect("/Output/NationalNumber?id=birth");
            else
                Response.Redirect("/Account/Login");

        }

        protected void death_Click(object sender, EventArgs e)
        {
            if (role != null)
                Response.Redirect("/Output/NationalNumber?id=death");
            else
                Response.Redirect("/Account/Login");

        }

        protected void divorce_Click(object sender, EventArgs e)
        {
            if (role != null)
                Response.Redirect("/Output/NationalNumber?id=divorce");
            else
                Response.Redirect("/Account/Login");

        }
        protected void marrage_Click(object sender, EventArgs e)
        {

            if (role != null)
                Response.Redirect("/Output/NationalNumber?id=marrage");
            else
                Response.Redirect("/Account/Login");
        }
    }

}