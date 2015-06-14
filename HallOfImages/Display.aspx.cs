using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HallOfImages.Model;

namespace HallOfImages
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = "";
            ImageFile image = null;
            if (Request.QueryString["img"] != null) {
                filename = Request.QueryString["img"];
                image = ImageFile.FindByFilename(filename);
            }
            if (image != null) {
                lblImage.Text = image.GetImageHtml();
                lblHtmlComments.Text = image.HtmlComments;
            }

            User user = null;
            try {
                user = (User)Session["User"];
            }
            catch { }

            if (user == null || !user.IsAdmin) {
                pnlEdit.Visible = false;
            }
            else {
                pnlEdit.Visible = true;
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            string filename = "";
            ImageFile image = null;
            if (Request.QueryString["img"] != null) {
                filename = Request.QueryString["img"];
            }
            if (filename == null) {
                GiveError("Unable to determine image to delete.");
                return;
            }
            try {
                ImageFile.Delete(filename);
            }
            catch (Exception ex) {
                GiveError(ex.Message);
                return;
            }
            Response.Redirect("~/Index.aspx");
        }
        private void GiveError(string str)
        {
            lblError.Visible = true;
            lblError.Text = "<span style='color: red;'>" + str + "</span>";
        }
    }
}