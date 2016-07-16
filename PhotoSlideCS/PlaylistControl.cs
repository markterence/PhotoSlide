using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotoSlideCS
{
    public partial class PlaylistControl : UserControl
    {
        public PlaylistControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(PlaylistControl_Load);
            this.ClientSizeChanged += new EventHandler(PlaylistControl_ClientSizeChanged);
        }

        void PlaylistControl_ClientSizeChanged(object sender, EventArgs e)
        {
            ResizeListView();
        }

        void PlaylistControl_Load(object sender, EventArgs e)
        {
            ResizeListView();
        }

        void ResizeListView() {
            listView1.Columns[0].Width = this.Width - 5; //(int)((float)this.Width * 0.2f);
            //listView1.Columns[1].Width = Math.Abs(this.ClientRectangle.Width - listView1.Columns[0].Width)-10;
        }
    }
}
