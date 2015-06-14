using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HallOfImages.Model;

namespace HallOfImages
{
    public partial class Index : System.Web.UI.Page
    {
        private List<Category> allCategories;
        private List<Category> curCategories;
        private List<ImageFile> images;
        private User user;

        private const string ALL_CATEGORIZED_ID = "ALL";
        private const string ALL_UNCATEGORIZED_ID = "ALL2";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            if (!IsPostBack) {
                LoadDropDown();
                LoadRepeater(allCategories);
            }
        }

        private void LoadData()
        {
            images = ImageFile.GetAllImages(true);
            allCategories = Category.GetAllCategories();
        }

        private void LoadDropDown()
        {
            allCategories.Insert(0, new Category(ALL_CATEGORIZED_ID, "ALL CATEGORIES", true));
            //allCategories.Insert(1, new Category(ALL_UNCATEGORIZED_ID, "ALL (UNCATEGORIZED)", true));
            ddlCategory.DataSource = allCategories;
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();
        }

        private void LoadRepeater(List<Category> c)
        {
            rptCategoryImages.DataSource = c;
            rptCategoryImages.DataBind();
        }

        private void LoadRepeater(List<ImageFile> i)
        {
            rptCategoryImages.DataSource = i;
            rptCategoryImages.DataBind();
        }

        private void LoadRepeater(Category c)
        {
            List<Category> newCategories = new List<Category>();
            newCategories.Add(c);
            rptCategoryImages.DataSource = newCategories;
            rptCategoryImages.DataBind();
        }

        protected string GetHtmlForRepeaterItem(object obj)
        {
            if (obj.GetType() == typeof(Category)) {
                int numberOfCategories = ((List<Category>)(this.rptCategoryImages.DataSource)).Count;
                bool onlyOneCategory = (numberOfCategories == 1);
                Category cat = (Category)(obj);
                return cat.GetHtml(onlyOneCategory);
            }
            else {
                ImageFile img = (ImageFile)(obj);
                return img.GetThumbHtml();
            }
        }

        private Category GetCategoryFromCategoryID(string id)
        {
            Category cat = null;
            foreach (Category c in allCategories) {
                if (c.CategoryID == id) {
                    cat = c;
                    break;
                }
            }
            return cat;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category category = GetCategoryFromCategoryID(ddlCategory.SelectedValue);
            if (ddlCategory.SelectedValue == ALL_CATEGORIZED_ID) {
                LoadRepeater(allCategories);
            }
            else if (ddlCategory.SelectedValue == ALL_UNCATEGORIZED_ID) {
                LoadRepeater(images);
            }
            else if (category != null) {
                LoadRepeater(category);
            }
        }
    }
}