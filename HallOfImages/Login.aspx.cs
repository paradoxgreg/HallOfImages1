using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HallOfImages.Model;

namespace HallOfImages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbLoginAsStandard_Click(object sender, System.EventArgs e)
        {
            string redirectTarget = GetRedirectTarget();
            Session["User"] = new User("Standard User", false);
            Response.Redirect(redirectTarget);
        }

        protected void lbLoginAsAdmin_Click(object sender, System.EventArgs e)
        {
            string redirectTarget = GetRedirectTarget();
            Session["User"] = new User("Administrator", true);
            Response.Redirect(redirectTarget);
        }

        private string GetRedirectTarget()
        {
            string redirectTarget = "~/Index.aspx";
            try {
                if (Request.QueryString["url"] != null) {
                    redirectTarget = Request.QueryString["url"];
                }
            }
            catch { }
            return redirectTarget;
        }
    }
}