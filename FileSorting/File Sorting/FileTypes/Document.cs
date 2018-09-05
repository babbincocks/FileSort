using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Text.RegularExpressions;

namespace File_Sorting
{
    class Document : File
    {
        
        public Document() : base()
        {

        }

        public Document(string filePath) : base(filePath)
        {
            string a = "this is a sentence. blah blah";
            int b = Regex.Matches(a, @"\b\w+\b").Count;
        }
        

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }

    }
}
