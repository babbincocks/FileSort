using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ionic.Zip;
using System.IO;

namespace File_Sorting
{
    class Archive : File
    {
        private int _fileCount;
        private string _encryptionType;

        public Archive() : base()
        {
            _fileCount = 0;
        }

        public Archive(string filePath) : base(filePath)
        {

            using (ZipFile zip = ZipFile.Read(filePath))
            {
                _fileCount = zip.Count;
                _encryptionType = zip.Encryption.ToString();
            }

            


        }

        public int FileCount
        {
            get { return _fileCount; }
        }

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }


    }
}
