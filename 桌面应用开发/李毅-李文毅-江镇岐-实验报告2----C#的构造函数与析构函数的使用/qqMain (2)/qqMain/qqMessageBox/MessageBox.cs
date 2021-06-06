using System;
using System.Drawing;
using System.Windows.Forms;

namespace qqMessageBox
{
    public partial class MessageBox: UserControl
    {
        public MessageBox()
        {
            InitializeComponent();
        }
        private string nickname;//昵称
     
        public bool isDown = false;

        public string Nickname
        {
            get
            {
                return lblName.Text;
            }

            set
            {
                lblName.Text= value ;
            }
        }
        private string news; //消息

        public string News
        {
            get
            {
                return lblMessage.Text;
            }

            set
            {
                lblMessage.Text = value;
            }
        }
        private Image head; //头像

        public Bitmap Head
        {
            get
            {
                 return (Bitmap)this.picHead.BackgroundImage;
            }
            set
            {
                picHead.BackgroundImage = value;
            }
        }
        private string time; //时间

        public string Time
        {
            get
            {
                return lblTime.Text;
            }

            set
            {
                lblTime.Text = value;
            }
        }
        private void MessageBox_Click(object sender, EventArgs e)
        {
            this.isDown = true;
            this.BackColor = Color.FromArgb(235, 235, 235);//深灰
        }

        private void MessageBox_MouseLeave(object sender, EventArgs e)
        {
            if (!isDown)
                this.BackColor = Color.White;
        }

        private void MessageBox_MouseEnter(object sender, EventArgs e)
        {
            if (!isDown)
                this.BackColor = Color.FromArgb(242, 242, 242);//浅灰
        }

        private void MessageBox_Leave(object sender, EventArgs e)
        {
            isDown = false;
            this.BackColor = Color.White;
        }
    }
}
