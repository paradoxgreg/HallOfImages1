using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HallOfImages.Model;

namespace HallOfImages.Controls
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        public User CurrentUser { get; private set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // For testing:
            //if (!IsPostBack && Session["User"] == null) {
            //    Session["User"] = new User("Standard User", false);
            //}

            try {
                CurrentUser = (User)(Session["User"]);
            }
            catch {
                CurrentUser = null;
            }

            if (CurrentUser == null) {
                pnlUserLogin.Visible = true;
                pnlUserLogout.Visible = false;
            }
            else {
                pnlUserLogin.Visible = false;
                pnlUserLogout.Visible = true;
                lblUserName.Text = CurrentUser.Name;
            }
        }

        protected void lbLogout_Click(object sender, System.EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect(Request.RawUrl);
        }

        protected void lbLogin_Click(object sender, System.EventArgs e)
        {
            string url = Request.RawUrl;
            string encodedUrl = Server.UrlEncode(url);
            Response.Redirect("~/Login.aspx?url=" + encodedUrl);
        }
    }
}