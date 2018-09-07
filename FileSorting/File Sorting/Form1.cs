using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace File_Sorting
{
    public partial class frmMain : Form
    {

        bool activeCheck;
        Queue<string> qDirectories = new Queue<string>();
        DateTime lastSearch;


        public frmMain()
        {
            InitializeComponent();
        }

        


        private void btnVideo_Click(object sender, EventArgs e)
        {

            errProv.Dispose();

            try
            {
                if(txtFileSamp.Text == "")
                {
                    throw new Exception("No file chosen.");
                }
                else if(!File.Exists(txtFileSamp.Text))
                {
                    throw new Exception("That file does not exist, and thus can't be ran.");
                }

                string ext = Path.GetExtension(txtFileSamp.Text);


                if (VideoTypes.Contains(ext.ToLower()))
                {
                    Video videoFile = new Video(txtFileSamp.Text);

                    videoFile.ViewFile();


                }
                else if (GraphicTypes.Contains(ext.ToLower()))
                {
                    Graphic graphicFile = new Graphic(txtFileSamp.Text);


                    graphicFile.ViewFile();
                }
                else if (AudioTypes.Contains(ext.ToLower()))
                {
                    Audio audioFile = new Audio(txtFileSamp.Text);

                    audioFile.ViewFile();
                }
                else if (ArchiveTypes.Contains(ext.ToLower()))
                {
                    Archive archiveFile = new Archive(txtFileSamp.Text);



                    archiveFile.ViewFile();
                }
                else if (DocumentTypes.Contains(ext.ToLower()))
                {
                    Document docFile = new Document(txtFileSamp.Text);



                    docFile.ViewFile();
                }
                else
                {
                    throw new Exception("File type not found: the chosen file type is not supported.");
                    //System.IO.FileInfo newFile = new System.IO.FileInfo(txtFileSamp.Text);
                    //System.IO.FileAttributes b = newFile.Attributes;


                }

            }
            catch(Exception ex)
            {
                errProv.SetError(btnDisplay, ex.Message);
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

            activeCheck = false;
        }




        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
            errProv.Dispose();

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
            errProv.Dispose();

            fdFolderChoice.ShowNewFolderButton = true;

            if (fdFolderChoice.ShowDialog() == DialogResult.OK)
            {
                txtDestPath.Text = fdFolderChoice.SelectedPath;
            }

            CheckButtonState();
        }




        private void btnAddFile_Click(object sender, EventArgs e)
        {
            errProv.Dispose();
            fdFolderChoice.ShowNewFolderButton = false;

            try
            {
                if (fdFolderChoice.ShowDialog() == DialogResult.OK)
                {
                    string chosenFolder = fdFolderChoice.SelectedPath;

                    if (!lbWatchedFolders.Items.Contains(chosenFolder))
                    {
                        lbWatchedFolders.Items.Add(chosenFolder);
                        lbWatchedFolders.TopIndex = lbWatchedFolders.Items.Count - 1;
                    }
                    else
                    {
                        lbWatchedFolders.SelectedItem = chosenFolder;
                    }
                }
            }
            catch(Exception ex)
            {
                errProv.SetError(btnAddFile, ex.Message);
            }

            fdFolderChoice.ShowNewFolderButton = true;


            CheckButtonState();
        }




        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            errProv.Dispose();
            fdFolderChoice.ShowNewFolderButton = false;

            try
            {

                if (lbWatchedFolders.Items.Count > 0)
                {
                    if (fdFolderChoice.ShowDialog() == DialogResult.OK)
                    {
                        string chosenFolder = fdFolderChoice.SelectedPath;

                        if (lbWatchedFolders.Items.Contains(chosenFolder))
                        {
                            lbWatchedFolders.Items.Remove(chosenFolder);
                        }
                        else
                        {
                            throw new Exception("The chosen directory does not exist in the previously chosen directories");
                        }
                    }
                }
                else
                {
                    throw new Exception("No directories have been previously chosen, so there's nothing to remove.");
                }
            }
            catch(Exception ex)
            {
                errProv.SetError(btnRemoveFile, ex.Message);
            }

            fdFolderChoice.ShowNewFolderButton = true;

            CheckButtonState();
        }




        private void btnTrack_Click(object sender, EventArgs e)
        {
            errProv.Dispose();

            try
            {
                
                //TODO: If multiple directories are added to lbWatchedFolders, the archive doesn't properly split up each directory into their own folder, and instead puts it all into one.
                
                if (activeCheck)
                {
                    checkTimer.Enabled = false;
                    activeCheck = false;
                    loops = 0;

                }
                else
                {
                    

                    if (txtDestPath.Text != "" && lbWatchedFolders.Items.Count > 0)
                    {
                        if (Directory.Exists(txtDestPath.Text))
                        {
                            activeCheck = true;
                            MoveToArchive();
                            checkTimer.Enabled = true;
                            lastSearch = DateTime.Now;
                        }
                        else
                        {
                            throw new Exception("The destination folder chosen does not exist.");
                        }
                    }
                    else if (txtDestPath.Text == "")
                    {
                        throw new Exception("No destination folder chosen.");
                    }
                    else if (lbWatchedFolders.Items.Count == 0)
                    {
                        throw new Exception("No items to track have been chosen.");
                    }
                }
            }
            catch(Exception ex)
            {
                errProv.SetError(btnTrack, ex.Message);
            }

            CheckButtonState();
        }




        private void checkTimer_Tick(object sender, EventArgs e)
        {
            checkTimer.Enabled = false;
            MoveToArchive();
            MoveQueuedFiles();

            lastSearch = DateTime.Now;
            checkTimer.Enabled = activeCheck;
            Application.DoEvents();
        }


        private void MoveToArchive()
        {
            string caller = new StackFrame(1).GetMethod().Name;
            if (caller == "checkTimer_Tick")
            {
                foreach (string path in lbWatchedFolders.Items)
                {
                    ScanFolder(path);
                    loops = 0;
                }
            }
            else
            {
                foreach (string path in lbWatchedFolders.Items)
                {
                    ScanFolder(path, txtDestPath.Text);
                }
            }
        }

        private void ScanFolder(string startingFolder)
        {
            DateTime write;
            try
            {
                foreach (string file in Directory.GetFiles(startingFolder))
                {
                    write = File.GetLastWriteTime(file);

                    if(write > lastSearch && !qDirectories.Contains(file))
                    {
                        qDirectories.Enqueue(file);
                    }

                }

                foreach (string directory in Directory.GetDirectories(startingFolder))
                {
                    ScanFolder(directory);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int loops;
        private string baseDirectory;

        private void ScanFolder(string startingFolder, string destFolder)
        {
            DateTime write;
            string fileName;
            string newDest;
            string fullPath;
            string directoryName;
            string combPath = baseDirectory;
            try
            {
                

                if (loops == 0)
                {
                    fullPath = Path.GetFullPath(startingFolder).TrimEnd(Path.DirectorySeparatorChar);
                    directoryName = fullPath.Split(Path.DirectorySeparatorChar).Last();
                    combPath = Path.Combine(destFolder, directoryName);

                    if (!Directory.Exists(combPath))
                    {
                        Directory.CreateDirectory(combPath);
                        baseDirectory = combPath;
                    }
                    loops++;
                }

                

                foreach (string file in Directory.GetFiles(startingFolder))
                {
                    
                    fileName = Path.GetFileName(file);
                    newDest = Path.Combine(combPath, fileName);
                    write = File.GetLastWriteTime(newDest);

                    
                    if (write > lastSearch)
                    {
                        File.Copy(file, newDest, true);
                    }

                }

                foreach (string directory in Directory.GetDirectories(startingFolder))
                {
                    
                    ScanFolder(directory, destFolder);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitialMove()
        {
            
        }


        private void CheckButtonState()
        {
            if (txtDestPath.Text.Length > 0 && lbWatchedFolders.Items.Count > 0)
            {
                if(!activeCheck)
                {
                    btnTrack.BackColor = Color.Green;
                    btnTrack.Text = "Start Tracking";
                }
                else
                {
                    btnTrack.BackColor = Color.Red;
                    btnTrack.Text = "Stop Tracking";
                }
            }
            else
            {
                btnTrack.BackColor = Color.Red;
                btnTrack.Text = "Start Tracking";
            }
        }

        private void MoveQueuedFiles()
        {
            while(qDirectories.Count != 0)
            {

                string file = qDirectories.Dequeue();
                string fileName = Path.GetFileName(file);
                string newDest = Path.Combine(txtDestPath.Text, fileName);
                File.Copy(file, newDest, true);
                
            }
        }
    }
}
