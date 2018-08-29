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
            if(ext == ".wmv")
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
            else if(GraphicTypes.ContainsKey(ext))
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

        public Dictionary<string, string> GraphicTypes = new Dictionary<string, string>();
        public Dictionary<string, string> VideoTypes = new Dictionary<string, string>();
        public Dictionary<string, string> AudioTypes = new Dictionary<string, string>();

        private void frmMain_Load(object sender, EventArgs e)
        {
            GraphicTypes.Add(".jpg", "Graphic");
            GraphicTypes.Add(".jpeg", "Graphic");
            GraphicTypes.Add(".png", "Graphic");
            GraphicTypes.Add(".bmp", "Graphic");
            GraphicTypes.Add(".tiff", "Graphic");

            VideoTypes.Add(".mp4", "Video");
            VideoTypes.Add(".wmv", "Video");
            VideoTypes.Add(".flv", "Video");
            VideoTypes.Add(".ogg", "Video");
            VideoTypes.Add(".avi", "Video");
            VideoTypes.Add(".webm", "Video");
            AudioTypes.Add(".gif", "Video");

            AudioTypes.Add(".mp3", "Audio");
            AudioTypes.Add(".wav", "Audio");
            AudioTypes.Add(".flac", "Audio");
            AudioTypes.Add(".aiff", "Audio");
            AudioTypes.Add(".aax", "Audio");
            AudioTypes.Add(".aa", "Audio");
        }
    }
}
