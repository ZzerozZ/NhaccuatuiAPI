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
            txtText.Text = "Ta là của nhau";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Song song = new Song(txtText.Text);
            Search.Song(txtText.Text);
        }
    }
}
