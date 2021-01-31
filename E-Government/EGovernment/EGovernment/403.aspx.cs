using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EGovernment.Account
{
    public partial class _403 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel footerPanel = (Panel)this.Master.FindControl("footerPanel");
            if (footerPanel != null)
                footerPanel.Visible = false;
        }
    }
}