namespace PhotoSlideCS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripOpenPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAppendPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSavePlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTogglePlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStriptxtSpeed = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripClearList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.playlistControl1 = new PhotoSlideCS.PlaylistControl();
            this.customPictureBox1 = new PhotoSlideCS.CustomPictureBox();
            this.vistaFolderBrowserDialog1 = new Ookii.Dialogs.VistaFolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(25, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenPlaylist,
            this.toolStripAppendPlaylist,
            this.toolStripOpenFolder,
            this.toolStripSavePlaylist,
            this.toolStripTogglePlaylist,
            this.toolStripPlay,
            this.toolStriptxtSpeed,
            this.toolStripSeparator1,
            this.toolStripClearList,
            this.toolStripRemoveItem,
            this.toolStripSeparator2,
            this.toolStripPosition});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 239);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripOpenPlaylist
            // 
            this.toolStripOpenPlaylist.Name = "toolStripOpenPlaylist";
            this.toolStripOpenPlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripOpenPlaylist.Size = new System.Drawing.Size(188, 22);
            this.toolStripOpenPlaylist.Text = "Open Playlist";
            this.toolStripOpenPlaylist.Click += new System.EventHandler(this.toolStripOpenPlaylist_Click);
            // 
            // toolStripAppendPlaylist
            // 
            this.toolStripAppendPlaylist.Name = "toolStripAppendPlaylist";
            this.toolStripAppendPlaylist.Size = new System.Drawing.Size(188, 22);
            this.toolStripAppendPlaylist.Text = "Append Playlist";
            this.toolStripAppendPlaylist.Click += new System.EventHandler(this.toolStripAppendPlaylist_Click);
            // 
            // toolStripOpenFolder
            // 
            this.toolStripOpenFolder.Name = "toolStripOpenFolder";
            this.toolStripOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.toolStripOpenFolder.Size = new System.Drawing.Size(188, 22);
            this.toolStripOpenFolder.Text = "Open Folder";
            this.toolStripOpenFolder.Click += new System.EventHandler(this.toolStripOpenFolder_Click);
            // 
            // toolStripSavePlaylist
            // 
            this.toolStripSavePlaylist.Name = "toolStripSavePlaylist";
            this.toolStripSavePlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripSavePlaylist.Size = new System.Drawing.Size(188, 22);
            this.toolStripSavePlaylist.Text = "Save Playlist to File";
            this.toolStripSavePlaylist.Click += new System.EventHandler(this.toolStripSavePlaylist_Click);
            // 
            // toolStripTogglePlaylist
            // 
            this.toolStripTogglePlaylist.Name = "toolStripTogglePlaylist";
            this.toolStripTogglePlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toolStripTogglePlaylist.Size = new System.Drawing.Size(188, 22);
            this.toolStripTogglePlaylist.Text = "Toggle Playlist";
            this.toolStripTogglePlaylist.Click += new System.EventHandler(this.toolStripTogglePlaylist_Click);
            // 
            // toolStripPlay
            // 
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.Size = new System.Drawing.Size(188, 22);
            this.toolStripPlay.Text = "Play/Pause";
            this.toolStripPlay.Click += new System.EventHandler(this.toolStripPlay_Click);
            // 
            // toolStriptxtSpeed
            // 
            this.toolStriptxtSpeed.Name = "toolStriptxtSpeed";
            this.toolStriptxtSpeed.Size = new System.Drawing.Size(100, 23);
            this.toolStriptxtSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStriptxtSpeed_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripClearList
            // 
            this.toolStripClearList.Name = "toolStripClearList";
            this.toolStripClearList.Size = new System.Drawing.Size(188, 22);
            this.toolStripClearList.Text = "Clear List";
            this.toolStripClearList.Click += new System.EventHandler(this.toolStripClearList_Click);
            // 
            // toolStripRemoveItem
            // 
            this.toolStripRemoveItem.Name = "toolStripRemoveItem";
            this.toolStripRemoveItem.Size = new System.Drawing.Size(188, 22);
            this.toolStripRemoveItem.Text = "Remove Item";
            this.toolStripRemoveItem.Click += new System.EventHandler(this.toolStripRemoveItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripPosition
            // 
            this.toolStripPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem,
            this.normalToolStripMenuItem});
            this.toolStripPosition.Name = "toolStripPosition";
            this.toolStripPosition.Size = new System.Drawing.Size(188, 22);
            this.toolStripPosition.Text = "Position";
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.CheckOnClick = true;
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.topMostToolStripMenuItem.Text = "Top Most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.CheckOnClick = true;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text file|*.txt";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.playlistControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.customPictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(811, 409);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Text File|*.txt";
            // 
            // playlistControl1
            // 
            this.playlistControl1.AllowDrop = true;
            this.playlistControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistControl1.Location = new System.Drawing.Point(0, 0);
            this.playlistControl1.Name = "playlistControl1";
            this.playlistControl1.Size = new System.Drawing.Size(270, 409);
            this.playlistControl1.TabIndex = 0;
            // 
            // customPictureBox1
            // 
            this.customPictureBox1.BackColor = System.Drawing.Color.Black;
            this.customPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPictureBox1.Image = global::PhotoSlideCS.Properties.Resources.defaultBg;
            this.customPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.customPictureBox1.Name = "customPictureBox1";
            this.customPictureBox1.Size = new System.Drawing.Size(537, 409);
            this.customPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customPictureBox1.TabIndex = 2;
            this.customPictureBox1.TabStop = false;
            // 
            // vistaFolderBrowserDialog1
            // 
            this.vistaFolderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 409);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Photo Slide CS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PlaylistControl playlistControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpenPlaylist;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtSpeed;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripSavePlaylist;
        private System.Windows.Forms.ToolStripMenuItem toolStripTogglePlaylist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Ookii.Dialogs.VistaFolderBrowserDialog vistaFolderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomPictureBox customPictureBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripPlay;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripClearList;
        private System.Windows.Forms.ToolStripMenuItem toolStripRemoveItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripAppendPlaylist;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripPosition;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
    }
}

