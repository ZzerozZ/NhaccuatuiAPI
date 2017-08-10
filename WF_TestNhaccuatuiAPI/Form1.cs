using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_TestNhaccuatuiAPI.Manipulation;

namespace WF_TestNhaccuatuiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtText.Text = "http://www.nhaccuatui.com/video/em-cua-anh-dung-cua-ai-tap-9-fap-tv.RAaecL6wNXZXp.html";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
          //Video song = new Video(txtText.Text);
           Search.Video("em của anh đừng của ai");
        }
    }
}
