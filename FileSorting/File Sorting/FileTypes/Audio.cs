using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace File_Sorting
{
    class Audio : BaseFile
    {
        private string _artist;
        private string _album;
        private string _genre;
        private int _lengthInSeconds;

        public Audio()
        {
            _artist = "";
            _album = "";
            _genre = "";
            _lengthInSeconds = 0;
        }

        public Audio(string filePath) : base(filePath)
        {
            
            if(this.Extension.ToLower() == ".mp3")
            {
                TagLib.Mpeg.AudioFile audioFile = new TagLib.Mpeg.AudioFile(filePath);
                _artist = audioFile.Tag.FirstAlbumArtist;
                _album = audioFile.Tag.Album;
                _genre = audioFile.Tag.FirstGenre;
                _lengthInSeconds = (int)Math.Round(audioFile.Properties.Duration.TotalSeconds);
            }
            else if (this.Extension.ToLower() == ".wav")
            {
                TagLib.Riff.File audioFile = new TagLib.Riff.File(filePath);
                _artist = audioFile.Tag.FirstAlbumArtist;
                _album = audioFile.Tag.Album;
                _genre = audioFile.Tag.FirstGenre;
                _lengthInSeconds = (int)Math.Round(audioFile.Properties.Duration.TotalSeconds);

            }
            else if (this.Extension.ToLower() == ".aiff")
            {
                TagLib.Aiff.File audioFile = new TagLib.Aiff.File(filePath);
                _artist = audioFile.Tag.FirstAlbumArtist;
                _album = audioFile.Tag.Album;
                _genre = audioFile.Tag.FirstGenre;
                _lengthInSeconds = (int)Math.Round(audioFile.Properties.Duration.TotalSeconds);

            }
            else if (this.Extension.ToLower() == ".flac")
            {
                TagLib.Flac.File audioFile = new TagLib.Flac.File(filePath);
                _artist = audioFile.Tag.FirstAlbumArtist;
                _album = audioFile.Tag.Album;
                _genre = audioFile.Tag.FirstGenre;
                _lengthInSeconds = (int)Math.Round(audioFile.Properties.Duration.TotalSeconds);

            }
            else if (this.Extension.ToLower() == ".aa" || this.Extension.ToLower() == ".aax")
            {
                TagLib.Audible.File audioFile = new TagLib.Audible.File(filePath);
                _artist = audioFile.Tag.FirstAlbumArtist;
                _album = audioFile.Tag.Album;
                _genre = audioFile.Tag.FirstGenre;
                _lengthInSeconds = (int)Math.Round(audioFile.Properties.Duration.TotalSeconds);

            }
        }

        public string Artist
        {
            get { return _artist ?? ""; }
        }

        public string Album
        {
            get { return _album ?? ""; }
        }

        public string Genre
        {
            get { return _genre ?? ""; }
        }

        public int LengthInSeconds
        {
            get { return _lengthInSeconds; }
        }

        public override void ViewFile()
        {
            System.Diagnostics.Process.Start(this.Path);
        }


    }
}
