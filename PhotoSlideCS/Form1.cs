/*
 * GC.Collect everywhere.
 * Sorry if I spammed GC.Collect(); 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
 
namespace PhotoSlideCS
{
    public partial class Form1 : Form
    {
        PS8 imageList = new PS8();

        string[] file_filter = {"*.jpg", "*.png", "*.gif" };
        bool pause;

        //The SlideShow
        int fileIndex = 0;
        int defaultDelay = 0, newInterval = 0;

        public Form1(){
            InitializeComponent();
           
            this.playlistControl1.listView1.DragDrop += new DragEventHandler(listView1_DragDrop);
            this.playlistControl1.listView1.DragEnter += new DragEventHandler(listView1_DragEnter);
            this.playlistControl1.listView1.MouseClick += new MouseEventHandler(listView1_MouseClick);
            this.playlistControl1.listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);

            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
           
            this.splitContainer1.SplitterMoved += new SplitterEventHandler(splitContainer1_SplitterMoved);


            this.customPictureBox1.DragDrop += new DragEventHandler(customPictureBox1_DragDrop);
            this.customPictureBox1.DragEnter += new DragEventHandler(customPictureBox1_DragEnter);

        }

        #region "Form Events"
        private void Form1_Load(object sender, EventArgs e)
        {
            ((Control)customPictureBox1).AllowDrop = true;

            this.toolStriptxtSpeed.Text = timer1.Interval.ToString();

            if (!pause)
                this.label1.Text = "Stopped Can Play";
            else
                this.label1.Text = "Playing: Can Pause";


            string customBg = "";

            bool exist = false;
            foreach (string ext in file_filter)
            {
                string newExt = ext.Replace("*.", "");
                string varx = Application.StartupPath + @"/defaultBg.{0}";
                if (File.Exists(string.Format(varx, newExt)))
                {
                    exist = true;
                    customBg = string.Format(varx, newExt);
                    break;
                }
                else
                    exist = false;
            }

            if (exist)
                customPictureBox1.Image = Image.FromFile(customBg);
            else
                customPictureBox1.Image = PhotoSlideCS.Properties.Resources.defaultBg;

            customBg = string.Empty;
            defaultDelay = 1200;
            GC.Collect();
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Pause();
            }
        }

        #endregion

        #region "ListView 1 Events"
        void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select skip, Show the selected image and start on it
            if (this.playlistControl1.listView1.SelectedItems.Count > 0)
            {
                Console.WriteLine("Selected:" + this.playlistControl1.listView1.SelectedItems[0].Index);
                this.fileIndex = this.playlistControl1.listView1.SelectedItems[0].Index;
            }
        }


        void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (!pause)
            {
                Console.WriteLine(this.playlistControl1.listView1.SelectedItems[0]);
                customPictureBox1.Image = Image.FromFile(
                    imageList.Files[this.playlistControl1.listView1.SelectedIndices[playlistControl1.listView1.SelectedIndices.Count - 1]].path
                    );
                ShowImageInfo(playlistControl1.listView1.SelectedIndices.Count - 1);
            }
        }

        //Drag and Drop Images on ListView
        void listView1_DragEnter(object sender, DragEventArgs e)
        {
            DragCopy(e);
        }

        void listView1_DragDrop(object sender, DragEventArgs e)
        {
            DragAndDrop(e);
            ShowDroppedImage();
        }
        #endregion

        void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.playlistControl1.Focus();
        }

        //Drag and Drop Images on Picture box
        void customPictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            DragCopy(e);
            //throw new NotImplementedException();
        }

        void customPictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            DragAndDrop(e);
            ShowDroppedImage();
            //throw new NotImplementedException();
        }
       

        #region "MyFunctions"

        void TestSave() {
            PS8 ps8 = new PS8();
            ps8.Speed = 500;
            for (int i = 1; i <= 3; i++)
            {
                ps8.AddPhoto("this is a test"+i, "path"+i);
            }
            PS8Writer.Save(ps8, Application.StartupPath + @"/playlist2.txt");
        }

        void TestLoad() {
            PS8 ps8 = PS8Reader.Read(Application.StartupPath + @"/playlist2.txt");
            Console.WriteLine(ps8.Files[0].filename + ":" + ps8.Files[0].path);
            Console.WriteLine(ps8.Speed);
        }

        //ShowImage
        void ShowDroppedImage() {
            customPictureBox1.Image = Image.FromFile(imageList.Files[imageList.Files.Count-1].path);
        }
        //Command for Drag and Drop
        void DragCopy(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Command for Drag and Drop
        void DragAndDrop(DragEventArgs e)
        {
            string[] handles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in handles)
            {
                FileInfo fileInfo = new FileInfo(item);

                imageList.AddPhoto(fileInfo.Name, fileInfo.FullName, fileInfo.Extension);
                ListFiles();
            }

        }
        public void OpenFile(string path) {
            System.Threading.Thread.Sleep(1000);
            FileInfo fileInfo = new FileInfo(path);
            imageList.AddPhoto(fileInfo.Name, fileInfo.FullName, fileInfo.Extension);
            ListFiles();
            customPictureBox1.Image = Image.FromFile(path);
            GC.Collect();
        }

        void LoadPlaylist(string _playlistfile, bool append) {
            try
            {
 
                imageList.Files.Clear();

                imageList = PS8Reader.Read(_playlistfile);
 
                this.timer1.Interval = imageList.Speed;
                this.toolStriptxtSpeed.Text = this.timer1.Interval.ToString();
                ListFiles();

                //set the default delay
                defaultDelay = imageList.Speed;
                fileIndex = 0;
            }
            catch(PS8Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GC.Collect();
        }
        
        /// <summary>
        /// Saves the playlist to a File
        /// </summary>
        /// <param name="_playlistName"></param>
        void SavePlaylist(string _playlistName) {
            try
            {
                if (this.toolStriptxtSpeed.Text == string.Empty)
                {
                    throw new PS8Exception("Save Error: Please specify a time.");
                }
                imageList.Speed = Convert.ToInt32(this.toolStriptxtSpeed.Text);
                PS8Writer.Save(imageList, _playlistName);
            }
            catch (PS8Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GC.Collect();
        }

        //Get the files in the directory and populate the List<>
        void GetFiles(string input_dir)
        {
            DirectoryInfo dir = new DirectoryInfo(input_dir);
            List<FileInfo>  fnfo = new List<FileInfo>();
            //foreach (var ext in file_filter)
            //{
            //    fnfo = dir.GetFiles(ext, SearchOption.TopDirectoryOnly);
            //    //fnfo = fnfo.OrderByDescending(x => x.CreationTime);
            //    //foreach (var file in fnfo)//dir.GetFiles(ext, SearchOption.TopDirectoryOnly))
            //    //{
                    
            //    //    imageList.AddPhoto(file.Name+file.CreationTime,file.FullName, file.Extension);
            //    //}
            //}
            foreach (string ext in file_filter)
            {
                foreach (FileInfo item in dir.GetFiles(ext, SearchOption.TopDirectoryOnly))
                {
                    fnfo.Add(item);
                }
            } 
            foreach (var file in fnfo.OrderByDescending(x => x.CreationTime))
            {
                imageList.AddPhoto(file.Name, file.FullName, file.Extension);  
            }
            fnfo.Clear();
            GC.Collect();
        }

        void ListFiles()
        {
            playlistControl1.listView1.Items.Clear();
            foreach (var item in imageList.Files)
            {
                playlistControl1.listView1.Items.Add(item.filename);
            }
            GC.Collect();
        }

        void ShowImageInfo(int _listIndex) {
            string fname = imageList.Files[_listIndex].filename;
            string path = imageList.Files[_listIndex].path;
            customPictureBox1.ShowImageInfo(fname,path,0f);
        }

        void Pause() {
            pause = !pause;
            Console.WriteLine(pause);
            timer1.Enabled = pause;
            playlistControl1.listView1.MultiSelect = !pause;
            if (!pause)
            {
                this.label1.Text = "Stopped Can Play";
            }
            else
                this.label1.Text = "Playing: Can Pause";

            GC.Collect();
        }
        #endregion "MyFunctions"

        #region "Contex Menu and ToolStrips / Auto-Generated"

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.playlistControl1.listView1.Items.Count == 0)
            {
                this.toolStripSavePlaylist.Enabled = false;
            }
            else {
                this.toolStripSavePlaylist.Enabled = true;
            }
            GC.Collect();
        }

        //Ctrl+F
        //Show the folder browser dialog
        private void toolStripOpenFolder_Click(object sender, EventArgs e)
        {
            if(vistaFolderBrowserDialog1.ShowDialog()== DialogResult.OK){
                GetFiles(vistaFolderBrowserDialog1.SelectedPath);
                ListFiles();
            }
            vistaFolderBrowserDialog1.Dispose();
            GC.Collect();
        }

        //Alt+T
        //Toggle ListView
        private void toolStripTogglePlaylist_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            GC.Collect();
        }

        //Ctrl+S
        //Save list to file
        private void toolStripSavePlaylist_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                //Console.WriteLine(saveFileDialog1.InitialDirectory + saveFileDialog1.FileName);
                SavePlaylist(saveFileDialog1.InitialDirectory + saveFileDialog1.FileName);
            }
            GC.Collect();
        }
        //Ctrl+O
        //Open playlist file
        private void toolStripOpenPlaylist_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                LoadPlaylist(openFileDialog1.InitialDirectory + openFileDialog1.FileName,false);
            }
            openFileDialog1.Dispose();
            GC.Collect();
        }

        //Append Playlist File
        private void toolStripAppendPlaylist_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylist(openFileDialog1.InitialDirectory + openFileDialog1.FileName, true);
            }
            openFileDialog1.Dispose();
            GC.Collect();
        }
        //Clear List
        private void toolStripClearList_Click(object sender, EventArgs e)
        {
            this.playlistControl1.listView1.Items.Clear();
            this.imageList.Files.Clear();
            timer1.Stop();
            customPictureBox1.Image = PhotoSlideCS.Properties.Resources.defaultBg;

            GC.Collect();
        }

        //SpeedSettings
        private void toolStriptxtSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            try{
                int x;
                if (int.TryParse(toolStriptxtSpeed.Text, out x)){
                    timer1.Interval = x;//Convert.ToInt32(toolStriptxtSpeed.Text);
                    newInterval = x;
                }
            }
            catch{}
        }

        //Multi Remove Item
        private void toolStripRemoveItem_Click(object sender, EventArgs e)
        {
            for (int i = playlistControl1.listView1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                imageList.Files.RemoveAt(playlistControl1.listView1.SelectedIndices[i]);
                playlistControl1.listView1.Items.RemoveAt(playlistControl1.listView1.SelectedIndices[i]);
            }

        }
        //Press Spacebar to pause
        private void toolStripPlay_Click(object sender, EventArgs e)
        {
            Pause();
        }

        //Window Layer Position : TOP MOST
        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.normalToolStripMenuItem.Checked = false;
        }
        //Window Layer Position : NORMAL
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.topMostToolStripMenuItem.Checked = false;
        }
        #endregion "Auto-Generated"

        
        bool allocated = false;
        void GifTest()
        {
            try
            {
                GC.Collect();
                if (fileIndex < imageList.Files.Count)
                {
                    Text = imageList.Files[fileIndex].filename;

                    GC.Collect();

                    playlistControl1.listView1.Items[fileIndex].Focused = true;
                    playlistControl1.listView1.Items[fileIndex].Selected = true;

                    customPictureBox1.Image = Image.FromFile(imageList.Files[fileIndex].path);
                    if (imageList.Files[fileIndex].extension.ToLower() == ".gif"){
                        if (!allocated){
                          
                            defaultDelay = timer1.Interval;
                            allocated = true;
                            System.Diagnostics.Debug.WriteLine("Default delay" + defaultDelay);
                        }

                        //Get the GIF length and change the timer1 Interval
                        //Do not save the GIF length on the global picture interval
                        newInterval = ImageUtil.GetDuration((Image)customPictureBox1.Image.Clone());
                        newInterval = newInterval * 100;

                        if (newInterval <= 5000)
                            newInterval = (int)((double)newInterval*1.5);
                        System.Diagnostics.Debug.WriteLine("GIF Duration: " + newInterval);
                        timer1.Interval = newInterval;

                    }
                    else{
                        // png jpeg
                        int x = 0;
                        //parse the input speed and set it as the timer's interval
                        if (int.TryParse(toolStriptxtSpeed.Text, out x))
                        {
                            if (x <= 0)
                            {
                                newInterval = defaultDelay;
                            }
                            else
                            {
                                timer1.Interval = x;
                                newInterval = x;
                            }
                        }
                        
                        else
                        {
                            newInterval = defaultDelay;
                        }
                        System.Diagnostics.Debug.WriteLine("jpeg delay" + newInterval);
                        
                        timer1.Interval = newInterval;
                    }

                    fileIndex++;
                    
                    GC.Collect();
                }
                else
                    fileIndex = 0;
            }
            catch (OutOfMemoryException){
                Application.ExitThread();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            GifTest();
            //OK();
        }

        void OK() {

            try
            {
                GC.Collect();
                if (fileIndex < imageList.Files.Count)
                {
                    Text = imageList.Files[fileIndex].filename;

                    GC.Collect();

                    playlistControl1.listView1.Items[fileIndex].Focused = true;
                    playlistControl1.listView1.Items[fileIndex].Selected = true;

                    customPictureBox1.Image = Image.FromFile(imageList.Files[fileIndex].path);
                    if (imageList.Files[fileIndex].extension.ToLower() == ".gif")
                    {
                        defaultDelay = timer1.Interval;

                        PropertyItem item = customPictureBox1.Image.GetPropertyItem(0x5100); // FrameDelay in libgdiplus
                        // Time is in 1/100th of a second
                        newInterval = (item.Value[0] + item.Value[1] * 256) * 1000;
                        
                        //the gif length is less than 1 sec.
                        if (newInterval < 1000)
                        {
                            newInterval = 3000;
                        }

                        System.Diagnostics.Debug.WriteLine("GIF Duration: " + newInterval);
                        timer1.Interval = newInterval;
                    }
                    else
                    {
                        // png jpeg
                        newInterval = defaultDelay;
                    }

                    fileIndex++;

                    GC.Collect();
                }
                else{
                    fileIndex = 0;
                }
            }
            catch (OutOfMemoryException){
                Application.ExitThread();
            }
        }

    }
}
