using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Sorting
{
    class Graphic : BaseFile
    {
        private string _resolution;



        public Graphic() : base()
        {
            _resolution = "0 x 0";
        }

        public Graphic(string filePath) : base(filePath)
        {
            string list = TagLib.FileTypes.AvailableTypes.ToString();
            // bmp in Taglib.Image.NoMetadata.File
            // png in TagLib.Png.File
            // tiff in TagLib.Tiff.File
            if (this.Extension.ToLower() == ".jpg" || this.Extension.ToLower() == ".jpeg")
            {       
                TagLib.Jpeg.File pic = new TagLib.Jpeg.File(filePath);
                _resolution = pic.Properties.PhotoWidth.ToString() + " x " + pic.Properties.PhotoHeight.ToString();

            }
            else if (this.Extension.ToLower() == ".png")
            {
                TagLib.Png.File pic = new TagLib.Png.File(filePath);
                _resolution = pic.Properties.PhotoWidth.ToString() + " x " + pic.Properties.PhotoHeight.ToString();
            }
            else if (this.Extension.ToLower() == ".tif" || this.Extension.ToLower() == ".tiff")
            {
                TagLib.Tiff.File pic = new TagLib.Tiff.File(filePath);
                _resolution = pic.Properties.PhotoWidth.ToString() + " x " + pic.Properties.PhotoHeight.ToString();
            }
            else if (this.Extension.ToLower() == ".bmp")
            {
                TagLib.Image.NoMetadata.File pic = new TagLib.Image.NoMetadata.File(filePath);
                _resolution = pic.Properties.PhotoWidth.ToString() + " x " + pic.Properties.PhotoHeight.ToString();
            }

        }

        public string Resolution
        {
            get { return (_resolution != null || _resolution != " x ") ? _resolution : "0 x 0"; }
        }

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }


    }
}
