using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace File_Sorting
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog a = new OpenFileDialog())
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = a.FileName;
                }
            }
        }

        


        private void btnVideo_Click(object sender, EventArgs e)
        {

            string ext = System.IO.Path.GetExtension(txtPath.Text);

            if(VideoTypes.Contains(ext.ToLower()))
            {
                Video videoFile = new Video(txtPath.Text);
                txtOutput.Text = "Video" + Environment.NewLine +
                           "File Name: " + videoFile.Name + Environment.NewLine + 
                           "Path: " + videoFile.Path + Environment.NewLine + 
                           "Size (bytes): " + videoFile.FileSize.ToString() + Environment.NewLine + 
                           "Date Created: " + videoFile.CreateDate.ToLongDateString() +
                           Environment.NewLine + "Last Modified: " + 
                           videoFile.ModifiedDate.ToLongDateString() +
                           Environment.NewLine + "Read-only?: " + videoFile.ReadOnly.ToString() +
                           Environment.NewLine + "Length (seconds): " + videoFile.SecondLength +
                           Environment.NewLine + "Resolution: " +videoFile.Resolution +
                           Environment.NewLine + "Frame Rate: " +videoFile.FrameRate +
                           Environment.NewLine + "Video Compression: " + videoFile.VideoCompression +
                           Environment.NewLine + "Audio Compression: " + videoFile.AudioCompression;


            }
            else if(GraphicTypes.Contains(ext.ToLower()))
            {
                Graphic graphicFile = new Graphic(txtPath.Text);
                txtOutput.Text = "Graphic" + Environment.NewLine +
                           "File Name: " + graphicFile.Name + Environment.NewLine +
                           "Path: " + graphicFile.Path + Environment.NewLine +
                           "Size (bytes): " + graphicFile.FileSize.ToString() + Environment.NewLine +
                           "Date Created: " + graphicFile.CreateDate.ToLongDateString() +
                           Environment.NewLine + "Last Modified: " +
                           graphicFile.ModifiedDate.ToLongDateString() +
                           Environment.NewLine + "Read-only?: " + graphicFile.ReadOnly.ToString() +
                           Environment.NewLine + "Resolution: " + graphicFile.Resolution;
            }
            else if(AudioTypes.Contains(ext.ToLower()))
            {
                Audio audioFile = new Audio(txtPath.Text);

                txtOutput.Text = "Audio" + Environment.NewLine + "File Name: " + audioFile.Name + Environment.NewLine +
                           "Path: " + audioFile.Path + Environment.NewLine +
                           "Size (bytes): " + audioFile.FileSize.ToString() + Environment.NewLine +
                           "Date Created: " + audioFile.CreateDate.ToLongDateString() +
                           Environment.NewLine + "Last Modified: " +
                           audioFile.ModifiedDate.ToLongDateString() +
                           Environment.NewLine + "Read-only?: " + audioFile.ReadOnly.ToString() + Environment.NewLine +
                           "Artist: " +audioFile.Artist + Environment.NewLine + "Album: " + audioFile.Album + Environment.NewLine + 
                           "Genre: " + audioFile.Genre + Environment.NewLine +  "Length (in seconds): " + audioFile.LengthInSeconds;
            }
            else
            {
                File newFile = new File(txtPath.Text);
                System.IO.FileInfo a = new System.IO.FileInfo(newFile.Name);
                System.IO.FileAttributes b = a.Attributes;
                
                txtOutput.Text = newFile.Name + Environment.NewLine + newFile.Path +
                            Environment.NewLine + newFile.FileSize.ToString() +
                            Environment.NewLine + newFile.CreateDate.ToLongDateString() +
                            Environment.NewLine + newFile.ModifiedDate.ToLongDateString() +
                            Environment.NewLine + newFile.ReadOnly.ToString();
            }
            

            
        }

        public List<string> GraphicTypes = new List<string>();
        public List<string> VideoTypes = new List<string>();
        public List<string> AudioTypes = new List<string>();
        public List<string> DocumentTypes = new List<string>();

        private void frmMain_Load(object sender, EventArgs e)
        {
            GraphicTypes.Add(".jpg");
            GraphicTypes.Add(".jpeg");
            GraphicTypes.Add(".png");
            GraphicTypes.Add(".bmp");
            GraphicTypes.Add(".tiff");

            VideoTypes.Add(".mp4");
            VideoTypes.Add(".wmv");
            VideoTypes.Add(".flv");
            VideoTypes.Add(".ogg");
            VideoTypes.Add(".avi");
            VideoTypes.Add(".webm");
            VideoTypes.Add(".gif");

            AudioTypes.Add(".mp3");
            AudioTypes.Add(".wav");
            AudioTypes.Add(".flac");
            AudioTypes.Add(".aiff");
            AudioTypes.Add(".aax");
            AudioTypes.Add(".aa");

            DocumentTypes.Add(".pdf");
            DocumentTypes.Add(".docx");
            DocumentTypes.Add(".txt");
        }
    }
}
