using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfImages.Model
{
    public class Category
    {
        // Properties:

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsPlaceholder { get; set; }

        // Constructor:

        public Category(string id, string name, bool isPlaceHolder)
        {
            CategoryID = id;
            CategoryName = name;
            IsPlaceholder = isPlaceHolder;
        }

        // Methods:

        public static List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("Ron", "Ron Swanson", false));
            categories.Add(new Category("Cat", "Cats", false));
            categories.Add(new Category("Other", "Other", false));
            return categories;
        }

        public List<ImageFile> GetAllImagesInCategory()
        {
            List<ImageFile> imagesInCategory = new List<ImageFile>();
            List<ImageFile> images = ImageFile.GetAllImages();
            foreach (ImageFile image in images) {
                if (image.CategoryID == this.CategoryID) {
                    imagesInCategory.Add(image);
                }
            }
            return imagesInCategory;
        }

        public string GetHtml(bool includeHeaderRegardless)
        {
            string str = "";
            List<ImageFile> imagesInCategory = GetAllImagesInCategory();
            if (includeHeaderRegardless || imagesInCategory.Count > 0) {
                str += "<p class='header'>" + CategoryName.ToUpper() + "</p>" + Environment.NewLine;
            }
            foreach (ImageFile image in imagesInCategory) {
                str += image.GetThumbHtml();
            }
            return str;
        }
    }
}