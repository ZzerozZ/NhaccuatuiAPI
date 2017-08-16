using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhaccuatui.Function;
using Nhaccuatui.Manipulation;
using Nhaccuatui.Manipulation.Charts;

namespace Nhaccuatui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtText.Text = "http://www.nhaccuatui.com/playlist/dang-nghe-dang-cap-nhat.P0Pe1HCB34cc.html";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Song";
            Playlist playlist = new Playlist(txtText.Text);
            txtText.Text = "DOWNLOADING...";
            if(playlist.Download(path))
                txtText.Text = "Done!";
        }
    }
}
