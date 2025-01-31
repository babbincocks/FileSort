﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Drawing;
using TagLib;
using Shell32;

namespace File_Sorting
{
    class Video : BaseFile
    {
        
        private int _lengthInSeconds;
        private string _resolution;
        private double _frameRate;
        private string _videoCompression;
        private string _audioCompression;

        public Video() : base()
        {   
            _lengthInSeconds = 0;
            _resolution = "";
            _frameRate = 0;
        }
        public Video(string filePath) : base(filePath)
        {
            
            if (this.Extension.ToLower() == ".wmv")
            {
                TagLib.Asf.File a = new TagLib.Asf.File(filePath);

                _lengthInSeconds = (int)Math.Round(a.Properties.Duration.TotalSeconds);

                _resolution = a.Properties.VideoWidth.ToString() + " x " + a.Properties.VideoHeight.ToString();

                foreach(TagLib.ICodec codec in a.Properties.Codecs)
                {
                    if(codec.MediaTypes == TagLib.MediaTypes.Video)
                    {
                        _videoCompression = codec.Description;
                    }
                    else if (codec.MediaTypes == TagLib.MediaTypes.Audio)
                    {
                        _audioCompression = codec.Description;
                    }
                }


                _frameRate = 0;

            }


            else if (this.Extension.ToLower() == ".mp4")
            {
                TagLib.Mpeg4.File newMpg = new TagLib.Mpeg4.File(filePath);

                _lengthInSeconds = (int)Math.Round(newMpg.Properties.Duration.TotalSeconds);

                _resolution = newMpg.Properties.VideoWidth.ToString() + " x " + newMpg.Properties.VideoHeight.ToString();

                foreach (ICodec codec in newMpg.Properties.Codecs)
                {
                    if (codec.MediaTypes == TagLib.MediaTypes.Video)
                    {
                        _videoCompression = codec.Description;
                    }
                    else if (codec.MediaTypes == TagLib.MediaTypes.Audio)
                    {
                        _audioCompression = codec.Description;
                    }

                    if (codec is TagLib.Mpeg.VideoHeader)
                    {
                        TagLib.Mpeg.VideoHeader G = (TagLib.Mpeg.VideoHeader)codec;
                        _frameRate = G.VideoFrameRate;

                    }
                }
                //TODO: Figure out frame rate.
            }


            else if (this.Extension.ToLower() == ".webm")
            {
                TagLib.Matroska.File a = new TagLib.Matroska.File(filePath);

                _lengthInSeconds = (int)Math.Round(a.Properties.Duration.TotalSeconds);

                _resolution = a.Properties.VideoWidth.ToString() + " x " + a.Properties.VideoHeight.ToString();

                
            }

        }

        public int SecondLength
        {
            get { return _lengthInSeconds; }
        }

        public string VideoCompression
        {
            get { return _videoCompression ?? ""; }
        }

        public string AudioCompression
        {
            get { return _audioCompression ?? ""; }
        }



        public string Resolution
        {
            get { return _resolution ?? ""; }
        }

        public double FrameRate
        {
            get { return _frameRate; }
        }

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }



    }
}
