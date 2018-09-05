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

        


        private void btnVideo_Click(object sender, EventArgs e)
        {

            string ext = System.IO.Path.GetExtension(txtFileSamp.Text);

            if(VideoTypes.Contains(ext.ToLower()))
            {
                Video videoFile = new Video(txtFileSamp.Text);
               
                videoFile.ViewFile();


            }
            else if(GraphicTypes.Contains(ext.ToLower()))
            {
                Graphic graphicFile = new Graphic(txtFileSamp.Text);
     

                graphicFile.ViewFile();
            }
            else if(AudioTypes.Contains(ext.ToLower()))
            {
                Audio audioFile = new Audio(txtFileSamp.Text);

                audioFile.ViewFile();
            }
            else if(ArchiveTypes.Contains(ext.ToLower()))
            {
                Archive archiveFile = new Archive(txtFileSamp.Text);

            

                archiveFile.ViewFile();
            }
            else if(DocumentTypes.Contains(ext.ToLower()))
            {
                Document docFile = new Document(txtFileSamp.Text);

                

                docFile.ViewFile();
            }
            else
            {
                
                System.IO.FileInfo newFile = new System.IO.FileInfo(txtFileSamp.Text);
                System.IO.FileAttributes b = newFile.Attributes;
                
                
            }
            

            
        }

        public List<string> GraphicTypes = new List<string>();
        public List<string> VideoTypes = new List<string>();
        public List<string> AudioTypes = new List<string>();
        public List<string> DocumentTypes = new List<string>();
        public List<string> ArchiveTypes = new List<string>();

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

            ArchiveTypes.Add(".zip");
            ArchiveTypes.Add(".rar");
            ArchiveTypes.Add(".7z");
        }

        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog a = new OpenFileDialog())
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    txtFileSamp.Text = a.FileName;
                }
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if(fdFolderChoice.ShowDialog() == DialogResult.OK)
            {
                string chosenFolder = fdFolderChoice.SelectedPath;

                if (lbWatchedFolders.Items.Contains(chosenFolder))
                {

                }
            }
            
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {

        }
    }
}
