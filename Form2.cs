using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace AutoAddder
{
    public partial class Form2 : Form
    {
        public WebClient web = new WebClient();
        public Form2()
        {
            InitializeComponent();
            web.DownloadString("https://www.google.com/");
            string ip11 = web.DownloadString("http://icanhazip.com/"); //http://icanhazip.com/
            char[] delimiters11 = new char[] { '\r', '\n' };
            string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
            string result11 = string.Join(Environment.NewLine, lines11);
            MessageBox.Show(result11);

            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
