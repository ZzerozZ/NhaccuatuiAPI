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
using WF_TestNhaccuatuiAPI.Function;
using WF_TestNhaccuatuiAPI.Manipulation;
using WF_TestNhaccuatuiAPI.Manipulation.Charts;

namespace WF_TestNhaccuatuiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtText.Text = "http://www.nhaccuatui.com";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(txtText.Text);

            //string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);
            HomePage.ItemList();
        }
    }
}
