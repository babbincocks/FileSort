﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Sorting
{
    class File
    {
        private string _name;
        private string _path;
        private long _fileSize;
        private DateTime _createDate;
        private DateTime _modDate;
        private bool _readOnly;
        private string _extension;

        public File()
        {
            _name = "";
            _path = "";
            _fileSize = 0;
            _createDate = DateTime.MinValue;
            _modDate = DateTime.MinValue;
            _readOnly = false;
            _extension = "";
        }

        //public File(string name, string filePath, long fileSizeInBytes, DateTime createdDate, DateTime modifiedDate, bool readOnly)
        //{
        //    _name = name;
        //    _path = filePath;
        //    _fileSize = fileSizeInBytes;
        //    _createDate = createdDate;
        //    _modDate = modifiedDate;
        //    _readOnly = readOnly;
        //}

        public File(string filePath)
        {
            _path = filePath;
            string[] info = FullFileInfo(filePath);
            _name = info[0];
            _fileSize = long.Parse(info[1]);
            _createDate = DateTime.Parse(info[2]);
            _modDate = DateTime.Parse(info[3]);
            _readOnly = bool.Parse(info[4]);
            _extension = info[5];

        }

        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { return _path; }
        }

        public long FileSize
        {
            get { return _fileSize; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
        }

        public DateTime ModifiedDate
        {
            get { return _modDate; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public string Extension
        {
            get { return _extension; }
        }

        private string[] FullFileInfo(string filePath)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);

            string[] aspects = new string[6];
            aspects[0] = file.Name;
            aspects[1] = file.Length.ToString();
            aspects[2] = file.CreationTime.ToLongDateString();
            aspects[3] = file.LastWriteTime.ToLongDateString();
            aspects[4] = file.IsReadOnly.ToString();
            aspects[5] = file.Extension;

            return aspects;
        }

    }
}
