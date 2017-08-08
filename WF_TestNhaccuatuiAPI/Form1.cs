using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_TestNhaccuatuiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtText.Text = "http://www.nhaccuatui.com/bai-hat/ta-la-cua-nhau-dong-nhi-ft-ong-cao-thang.L0G5DzIXoFf3.html";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Song song = new Song(txtText.Text);
        }
    }
}
