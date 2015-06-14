using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace HallOfImages.Model
{
    public class ImageFile
    {
        #region Properties / Class Variables

        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ThumbFileName { get; set; }
        public int ThumbWidth { get; set; }
        public int ThumbHeight { get; set; }
        public string CategoryID { get; set; }
        public string Comments { get; set; }
        public string HtmlComments { get; set; }

        private static List<ImageFile> _AllImages = null;

        private const int thumbMarginHorizontal = 7;
        private const int thumbMarginVertical = 7;
        private const int thumbMaxWidth = 150;
        private const int thumbMaxHeight = 150;

        #endregion

        #region Constructors

        public ImageFile()
        {
            // empty constructor
        }

        public ImageFile(string categoryID, string fileName, string thumbFileName, string comments, string htmlComments)
        {
            this.FileName = fileName;
            this.ThumbFileName = thumbFileName;
            this.CategoryID = categoryID;
            this.Comments = comments;
            this.HtmlComments = htmlComments;
        }

        public ImageFile(string categoryID, int thumbWidth, int thumbHeight, int width, int height, string fileName, string thumbFileName, string comments, string htmlComments)
        {
            this.FileName = fileName;
            this.ThumbWidth = thumbWidth;
            this.ThumbHeight = thumbHeight;
            this.Width = width;
            this.Height = height;
            this.ThumbFileName = thumbFileName;
            this.CategoryID = categoryID;
            this.Comments = comments;
            this.HtmlComments = htmlComments;
        }

        #endregion

        #region Data Access

        public static List<ImageFile> GetAllImages()
        {
            return GetAllImages(false);
        }

        public static List<ImageFile> GetAllImages(bool forceRefresh)
        {
            if (forceRefresh || _AllImages == null) {
                RefreshAllImages();
            }
            return _AllImages;
        }

        public static void RefreshAllImages()
        {
            List<ImageFile> images;

            try {
                images = new List<ImageFile>();
                // TODO: Change this
                //string filename = @"C:\cs\c#\HallOfMemes1\HallOfMemes1\DataFiles";
                string filename = Path.Combine(HttpRuntime.AppDomainAppPath, @"DataFiles\Images.txt");
                string line = null;
                StreamReader sr = new StreamReader(filename);

                while ((line = sr.ReadLine()) != null) {
                    if (line.Length >= 550) {
                        ImageFile img = new ImageFile();
                        img.CategoryID = line.Substring(0, 10).TrimEnd();
                        img.ThumbWidth = Int32.Parse(line.Substring(10, 10));
                        img.ThumbHeight = Int32.Parse(line.Substring(20, 10));
                        img.Width = Int32.Parse(line.Substring(30, 10));
                        img.Height = Int32.Parse(line.Substring(40, 10));
                        img.FileName = line.Substring(50, 99).TrimEnd();
                        img.ThumbFileName = line.Substring(149, 101).TrimEnd();
                        img.Comments = line.Substring(250, 100).TrimEnd();
                        img.HtmlComments = line.Substring(350, 200).TrimEnd();
                        //img.CategoryID = line.Substring(0, 10).TrimEnd();
                        //img.FileName = line.Substring(10, 99).TrimEnd();
                        //img.ThumbFileName = line.Substring(109, 101).TrimEnd();
                        //img.Comments = line.Substring(210, 100).TrimEnd();
                        //img.HtmlComments = line.Substring(310, 200).TrimEnd();
                        images.Add(img);
                    }
                }
                sr.Close();
                sr.Dispose();
            }
            catch {
                images = new List<ImageFile>();
                images.Add(new ImageFile("Ron", 113, 150, 250, 333, "swanson01.jpg", "__swanson01.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:RonSwanson.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Ron", 150, 113, 288, 216, "GoBig.jpg", "__GoBig.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Go_big_or_go_home_parks_and_recreation.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 115, 150, 460, 599, "Grumpy_Cat.jpg", "__Grumpy_Cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Grumpy_Cat_by_Gage_Skidmore.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 150, 110, 800, 589, "Girl_and_cat.jpg", "__Girl_and_cat.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Girl_and_cat.jpg\">Wikimedia</a>"));
                images.Add(new ImageFile("Cat", 150, 108, 800, 577, "Mr_Maji.jpg", "__Mr_Maji.jpg", "From Wikipedia", "From <a href=\"https://fa.wikipedia.org/wiki/%D9%BE%D8%B1%D9%88%D9%86%D8%AF%D9%87:Mr._Maji,_a_long-haired_orange_cat_with_white_muzzle.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 150, 101, 800, 536, "bad_cat.jpg", "__bad_cat.jpg", "From Wikipedia", "From <a href=\"http://pl.wikipedia.org/wiki/Plik:Bad_Cat!_(568877582).jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 150, 149, 603, 599, "Cat_March_2010-1a.jpg", "__Cat_March_2010-1a.jpg", "From Wikipedia", "From <a href=\"http://de.wikipedia.org/wiki/Datei:Cat_March_2010-1a.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 129, 150, 515, 600, "tabby_cat.jpg", "__tabby_cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Orange_and_white_tabby_cat_with_the_impressive_tail-Hisashi-01A.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 150, 107, 1280, 915, "Black_and_white_cat.jpg", "__Black_and_white_cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Black_and_white_cat.jpg\">Wikipedia</a>"));
                images.Add(new ImageFile("Cat", 150, 112, 873, 654, "Neighbours_Siamese.jpg", "__Neighbours_Siamese.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Neighbours_Siamese.jpg\">Wikimedia</a>"));
                images.Add(new ImageFile("Cat", 150, 106, 800, 565, "Red_Cat.jpg", "__Red_Cat.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Red_Cat_in_Torzhok_City.jpg\">Wikimedia</a>"));
                //images.Add(new ImageFile("Ron", "swanson01.jpg", "__swanson01.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:RonSwanson.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Ron", "GoBig.jpg", "__GoBig.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Go_big_or_go_home_parks_and_recreation.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "Grumpy_Cat.jpg", "__Grumpy_Cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Grumpy_Cat_by_Gage_Skidmore.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "Girl_and_cat.jpg", "__Girl_and_cat.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Girl_and_cat.jpg\">Wikimedia</a>"));
                //images.Add(new ImageFile("Cat", "Mr_Maji.jpg", "__Mr_Maji.jpg", "From Wikipedia", "From <a href=\"https://fa.wikipedia.org/wiki/%D9%BE%D8%B1%D9%88%D9%86%D8%AF%D9%87:Mr._Maji,_a_long-haired_orange_cat_with_white_muzzle.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "bad_cat.jpg", "__bad_cat.jpg", "From Wikipedia", "From <a href=\"http://pl.wikipedia.org/wiki/Plik:Bad_Cat!_(568877582).jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "Cat_March_2010-1a.jpg", "__Cat_March_2010-1a.jpg", "From Wikipedia", "From <a href=\"http://de.wikipedia.org/wiki/Datei:Cat_March_2010-1a.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "tabby_cat.jpg", "__tabby_cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Orange_and_white_tabby_cat_with_the_impressive_tail-Hisashi-01A.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "Black_and_white_cat.jpg", "__Black_and_white_cat.jpg", "From Wikipedia", "From <a href=\"http://en.wikipedia.org/wiki/File:Black_and_white_cat.jpg\">Wikipedia</a>"));
                //images.Add(new ImageFile("Cat", "Neighbours_Siamese.jpg", "__Neighbours_Siamese.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Neighbours_Siamese.jpg\">Wikimedia</a>"));
                //images.Add(new ImageFile("Cat", "Red_Cat.jpg", "__Red_Cat.jpg", "From Wikimedia", "From <a href=\"http://commons.wikimedia.org/wiki/File:Red_Cat_in_Torzhok_City.jpg\">Wikimedia</a>"));
            }

            _AllImages = images;
        }

        public static ImageFile FindByFilename(string str)
        {
            ImageFile matchingImage = null;
            string filename = Path.Combine(HttpRuntime.AppDomainAppPath, @"DataFiles\Images.txt");
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null) {
                if (line.Length >= 550) {
                    if (line.Substring(50, 99).TrimEnd() == str) {
                        ImageFile img = new ImageFile();
                        img.CategoryID = line.Substring(0, 10).TrimEnd();
                        img.ThumbWidth = Int32.Parse(line.Substring(10, 10));
                        img.ThumbHeight = Int32.Parse(line.Substring(20, 10));
                        img.Width = Int32.Parse(line.Substring(30, 10));
                        img.Height = Int32.Parse(line.Substring(40, 10));
                        img.FileName = line.Substring(50, 99).TrimEnd();
                        img.ThumbFileName = line.Substring(149, 101).TrimEnd();
                        img.Comments = line.Substring(250, 100).TrimEnd();
                        img.HtmlComments = line.Substring(350, 200).TrimEnd();
                        //img.CategoryID = line.Substring(0, 10).TrimEnd();
                        //img.FileName = line.Substring(10, 99).TrimEnd();
                        //img.ThumbFileName = line.Substring(109, 101).TrimEnd();
                        //img.Comments = line.Substring(210, 100).TrimEnd();
                        //img.HtmlComments = line.Substring(310, 200).TrimEnd();
                        matchingImage = img;
                    }
                }
            }
            sr.Close();
            sr.Dispose();
            return matchingImage;
        }

        // Don't call this unless you're sure the data isn't already in the data file
        public void WriteData()
        {
            string filename = Path.Combine(HttpRuntime.AppDomainAppPath, @"DataFiles\Images.txt");
            using (StreamWriter sw = File.AppendText(filename)) {
                sw.WriteLine(
                    this.CategoryID.PadRight(10, ' ') +
                    this.ThumbWidth.ToString().PadRight(10, ' ') +
                    this.ThumbHeight.ToString().PadRight(10, ' ') +
                    this.Width.ToString().PadRight(10, ' ') +
                    this.Height.ToString().PadRight(10, ' ') +
                    this.FileName.PadRight(99, ' ') +
                    this.ThumbFileName.PadRight(101, ' ') +
                    this.Comments.PadRight(100, ' ') +
                    this.HtmlComments.PadRight(200, ' '));
            }
        }

        public static void Delete(string str)
        {
            ImageFile matchingImage = null;
            string filename = Path.Combine(HttpRuntime.AppDomainAppPath, @"DataFiles\Images.txt");
            string tempFilename = Path.Combine(HttpRuntime.AppDomainAppPath, @"DataFiles\Images_temp.txt");

            string line;
            try {
                StreamReader sr = new StreamReader(filename);
                StreamWriter sw = new StreamWriter(tempFilename);
                while ((line = sr.ReadLine()) != null) {
                    if (line.Length >= 550) {
                        if (line.Substring(50, 99).TrimEnd() == str) {
                            ImageFile img = new ImageFile();
                            img.CategoryID = line.Substring(0, 10).TrimEnd();
                            img.ThumbWidth = Int32.Parse(line.Substring(10, 10));
                            img.ThumbHeight = Int32.Parse(line.Substring(20, 10));
                            img.Width = Int32.Parse(line.Substring(30, 10));
                            img.Height = Int32.Parse(line.Substring(40, 10));
                            img.FileName = line.Substring(50, 99).TrimEnd();
                            img.ThumbFileName = line.Substring(149, 101).TrimEnd();
                            img.Comments = line.Substring(250, 100).TrimEnd();
                            img.HtmlComments = line.Substring(350, 200).TrimEnd();
                            //img.CategoryID = line.Substring(0, 10).TrimEnd();
                            //img.FileName = line.Substring(10, 99).TrimEnd();
                            //img.ThumbFileName = line.Substring(109, 101).TrimEnd();
                            //img.Comments = line.Substring(210, 100).TrimEnd();
                            //img.HtmlComments = line.Substring(310, 200).TrimEnd();
                            matchingImage = img;
                        }
                        else {
                            sw.WriteLine(line);
                        }
                    }
                }
                sr.Close();
                sr.Dispose();
                sw.Close();
                sw.Dispose();
            }
            catch {
                throw new Exception("Error in attempting to read and copy the data file.");
            }

            try {
                File.Delete(filename);
                File.Copy(tempFilename, filename);
                File.Delete(tempFilename);
            }
            catch {
                throw new Exception("Error in attempting to update the data file.");
            }

            if (matchingImage != null) {
                // Don't physically delete the image if it is one of the core images 
                // that came with the application
                // This "if" condition is lazy, but it works
                if (!matchingImage.HtmlComments.Contains("edia</a>")) {
                    try {
                        File.Delete(Path.Combine(HttpRuntime.AppDomainAppPath, @"Images\" + matchingImage.FileName));
                        File.Delete(Path.Combine(HttpRuntime.AppDomainAppPath, @"Images\" + matchingImage.ThumbFileName));
                        //File.Delete(@"Images\" + matchingImage.FileName);
                        //File.Delete(@"Images\" + matchingImage.ThumbFileName);
                    }
                    catch {
                        // No need to report error here
                    }
                }
            }
        }

        #endregion

        #region Display

        public string GetThumbHtml()
        {
            string str = "";
            str += "<a href='Display.aspx?img=" +
                WebUtility.HtmlEncode(this.FileName)
                + "'>";
            str += "<img src='Images/" + this.ThumbFileName +
                "' width='" + this.ThumbWidth + "' height='" + this.ThumbHeight +
                "' align='middle' " +
                "alt='" + TextToHtml(this.Comments) + "' " +
                "style='" +
                "margin-top: " + GetTopMargin() + "px; " +
                "margin-bottom: " + GetBottomMargin() + "px; " +
                "margin-left: " + GetLeftMargin() + "px; " +
                "margin-right: " + GetRightMargin() + "px;' />";
            str += "</a>";
            str += Environment.NewLine;
            return str;
        }
        public string GetImageHtml()
        {
            string str = "";
            str += "<img src='Images/" + this.FileName +
                "' width='" + this.Width + "' height='" + this.Height +
                "' align='middle' " +
                "alt='" + TextToHtml(this.Comments) + "' />";
            str += Environment.NewLine;
            return str;
        }

        private int GetTopMargin()
        {
            double baseMargin = (double)(thumbMaxHeight - ThumbHeight) / 2.0;
            return (int)(Math.Ceiling(baseMargin)) + thumbMarginVertical;
        }
        private int GetBottomMargin()
        {
            double baseMargin = (double)(thumbMaxHeight - ThumbHeight) / 2.0;
            return (int)(Math.Floor(baseMargin)) + thumbMarginVertical;
        }
        private int GetLeftMargin()
        {
            double baseMargin = (double)(thumbMaxWidth - ThumbWidth) / 2.0;
            return (int)(Math.Ceiling(baseMargin)) + thumbMarginHorizontal;
        }
        private int GetRightMargin()
        {
            double baseMargin = (double)(thumbMaxWidth - ThumbWidth) / 2.0;
            return (int)(Math.Floor(baseMargin)) + thumbMarginHorizontal;
        }
        private string TextToHtml(string str)
        {
            str = WebUtility.HtmlEncode(str);
            //str = str.Replace(@"\", @"\\");
            //str = str.Replace(@"'", @"\'");
            return str;
        }

        #endregion
    }
}