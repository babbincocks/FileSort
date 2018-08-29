using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Sorting
{
    class Graphic : File
    {
        private string _resolution;



        public Graphic() : base()
        {
            _resolution = "";
        }

        public Graphic(string filePath) : base(filePath)
        {
            TagLib.Jpeg.File pic = new TagLib.Jpeg.File(filePath);
            _resolution = pic.Properties.PhotoWidth.ToString() + " x " + pic.Properties.PhotoHeight.ToString();
        }

        public string Resolution
        {
            get { return _resolution; }
        }

    }
}
