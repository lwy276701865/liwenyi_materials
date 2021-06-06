using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeChatLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PicbSet_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void PicbClose_MouseEnter(object sender, EventArgs e)
        {
            picbClose.BackColor = Color.Red;
        }

        private void PicbSet_MouseEnter(object sender, EventArgs e)
        {
            picbSet.BackColor = Color.LightGray;
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(18, 150, 17);
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(26, 173, 25);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Visible = false;
            lblTip.Visible = true;
        }

        private void PicbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
