using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HallOfImages.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace HallOfImages
{
    public partial class Upload : System.Web.UI.Page
    {
        private const int thumbMaxWidth = 150;
        private const int thumbMaxHeight = 150;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadDropDown();
            }
        }

        private void LoadDropDown()
        {
            List<Category> allCategories = Category.GetAllCategories();
            allCategories.Insert(0, new Category(String.Empty, "-- Select a category --", true));
            ddlCategory.DataSource = allCategories;
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProcessFile();
        }

        private void ProcessFile()
        {
            DateTime now = DateTime.Now;

            string imageFileName = "" + now.ToString("yyyyMMddHHmmssffffff") + (fuImage.FileName.Length <= 79 ? fuImage.FileName : fuImage.FileName.Substring(0, 79));
            string thumbFileName = "__" + now.ToString("yyyyMMddHHmmssffffff") + (fuImage.FileName.Length <= 79 ? fuImage.FileName : fuImage.FileName.Substring(0, 79));
            string imageFilePath = Server.MapPath("") + @"\Images\" + imageFileName;
            string thumbFilePath = Server.MapPath("") + @"\Images\" + thumbFileName;

            // Validate filename
            if (fuImage.FileName == null ||
                (!fuImage.FileName.EndsWith(".jpg") &&
                !fuImage.FileName.EndsWith(".jpeg") &&
                !fuImage.FileName.EndsWith(".gif") &&
                !fuImage.FileName.EndsWith(".png"))) {
                GiveError("Filename must end in .jpg, .gif, or .png.");
                return;
            }
            //if (fuImage.FileName.Length > 79) {
            //    GiveError("Filename may not be more than 79 characters.");
            //    return false;
            //}

            // Validate drop-down
            string categoryID = ddlCategory.SelectedValue;
            if (categoryID == String.Empty) {
                GiveError("Please select a category.");
                return;
            }

            // Save full-size image to server
            try {
                fuImage.SaveAs(imageFilePath);
            }
            catch {
                GiveError("Error in trying to upload file.");
                return;
            }

            // Save thumbnail image to server
            int imageWidth = 0;
            int imageHeight = 0;
            int thumbWidth = 0;
            int thumbHeight = 0;
            try {
                // Load original image to memory
                System.Drawing.Image image = new Bitmap(imageFilePath);

                // Calculate height and width for thumbnail
                imageWidth = image.Width;
                imageHeight = image.Height;
                thumbWidth = imageWidth;
                thumbHeight = imageHeight;
                double heightRatio = (double)(imageHeight) / (double)(thumbMaxHeight);
                double widthRatio = (double)(imageWidth) / (double)(thumbMaxWidth);
                if (heightRatio > 1.0 && heightRatio >= widthRatio) {
                    thumbHeight = thumbMaxHeight;
                    thumbWidth = (int)(Math.Round((thumbMaxHeight * (double)(imageWidth)) / (double)(imageHeight)));
                }
                else if (widthRatio > 1.0 && widthRatio >= heightRatio) {
                    thumbWidth = thumbMaxWidth;
                    thumbHeight = (int)(Math.Round((thumbMaxWidth * (double)(imageHeight)) / (double)(imageWidth)));
                }

                // Load thumbnail image to memory
                System.Drawing.Image.GetThumbnailImageAbort callback =
                    new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image thumb = image.GetThumbnailImage(thumbWidth, thumbHeight, callback, new IntPtr());

                // Save thumbnail image
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                thumb.Save(thumbFilePath, myImageCodecInfo, myEncoderParameters);
            }
            catch {
                GiveError("Error in trying to create thumbnail version of image.");
                return;
            }

            // Define comments and htmlComments
            string comments =
                (txtComments.Text.Length <= 70 ? txtComments.Text : txtComments.Text.Substring(0, 70)) +
                (txtComments.Text.Length == 0 ? "" : " - ") +
                "Uploaded to Hall of Images";
            string htmlComments = Server.HtmlEncode(comments);

            // At this point we can create a new ImageFile object and save it to the text file
            ImageFile imgFile = new ImageFile(categoryID, thumbWidth, thumbHeight, imageWidth, imageHeight, imageFileName, thumbFileName, comments, htmlComments);
            imgFile.WriteData();

            // Go back to home page
            Response.Redirect("~/Index.aspx");
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j) {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        private void GiveError(string str)
        {
            lblError.Visible = true;
            lblError.Text = "<span style='color: red;'>" + str + "</span>";
            pnlResults.Visible = false;
        }
        private void ClearError()
        {
            lblError.Visible = false;
            lblError.Text = "";
        }
    }
}