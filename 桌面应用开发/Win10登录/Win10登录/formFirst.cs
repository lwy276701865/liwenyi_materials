using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win10登录
{
    public partial class formFirst : Form
    {
        public formFirst()
        {
            InitializeComponent();
        }

        private void TimeGetTime_Tick(object sender, EventArgs e)
        {
           
        }

        private void FormFirst_Load(object sender, EventArgs e)
        {
            
        }


        private void FormFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            formSecond fs = new formSecond();
            this.Hide();
            fs.Show();
        }

        private void FormFirst_MouseClick(object sender, MouseEventArgs e)
        {
            formSecond fs = new formSecond();
            this.Hide();
            fs.Show();
        }
    }
}
