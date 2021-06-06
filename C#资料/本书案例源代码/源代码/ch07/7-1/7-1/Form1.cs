using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_1
{
    public partial class Regrad : Form
    {
        public Regrad()
        {
            InitializeComponent();
        }
        private void btnChinese_Click(object sender, EventArgs e)
        {
            lblShow.Text = "早上好";
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            lblShow.Text = "Good Morning";
        }
    }
}
