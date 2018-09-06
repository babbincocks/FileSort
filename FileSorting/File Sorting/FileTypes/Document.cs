using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Text.RegularExpressions;

namespace File_Sorting
{
    class Document : BaseFile
    {
        
        public Document() : base()
        {

        }

        public Document(string filePath) : base(filePath)
        {
            
        }
        

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }

    }
}
