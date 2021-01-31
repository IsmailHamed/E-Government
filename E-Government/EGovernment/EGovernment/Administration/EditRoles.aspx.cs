using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Administration.Transactions
{
    public partial class EditRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            using (EGovernmentEntities db = new EGovernmentEntities())
            {
                Session["RoleToEdit"] = Helper.GetRoleById(Convert.ToInt32(ddlRoles.SelectedValue));
                Response.Redirect("/Administration/Roles");
            }
        }

    }
}