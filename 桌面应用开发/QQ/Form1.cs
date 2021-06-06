using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PicbSetup_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.LightGray;
        }

        private void PicbSetup_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }
        private void PicbClose_MouseEnter(object sender, EventArgs e)
        {
           picbClose. BackColor = Color.Red;
        }
      
        private void PicbArrow_MouseEnter(object sender, EventArgs e)
        {
            
            picbArrow.BackgroundImage = Properties.Resources.下箭头_en;
        }

        private void PicbArrow_MouseLeave(object sender, EventArgs e)
        {
            picbArrow.BackgroundImage = Properties.Resources.下箭头_dis; 
        }

        private void PicbKeyboard_MouseEnter(object sender, EventArgs e)
        {
            picbKeyboard.BackgroundImage = Properties.Resources.键盘_en;
        }

        private void PicbKeyboard_MouseLeave(object sender, EventArgs e)
        {
            picbKeyboard.BackgroundImage = Properties.Resources.键盘_dis;
        }

        private void LblFindpw_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;
        }

        private void LblFindpw_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Silver;
        }

        private void PicbQr_code_MouseEnter(object sender, EventArgs e)
        {
            picbQr_code.BackgroundImage = Properties.Resources.二维码_en;
        }

        private void PicbQr_code_MouseLeave(object sender, EventArgs e)
        {
            picbQr_code.BackgroundImage = Properties.Resources.二维码_dis;
        }
        bool upisPress,downisPress;
        private void TextBoxUp_MouseEnter(object sender, EventArgs e)
        {
            if(!upisPress)
            panelUp.BackColor = Color.Gray;
        }

        private void TextBoxUp_MouseLeave(object sender, EventArgs e)
        {
            if (!upisPress)
                panelUp.BackColor = Color.LightGray;
        }

        private void TextBoxDown_MouseEnter(object sender, EventArgs e)
        {
            if (!downisPress)
                panelDown.BackColor = Color.Gray;
        }

        private void TextBoxDown_MouseLeave(object sender, EventArgs e)
        {
            if (!downisPress)
                panelDown.BackColor = Color.LightGray;
        }
        private void TextBoxDown_MouseDown(object sender, MouseEventArgs e)
        {
            panelDown.BackColor= Color.LightBlue;
            picbLock.BackgroundImage = Properties.Resources._189解锁__1_;
            downisPress = true;
            upisPress = false;       
            textBoxDown.Text = null;
            textBoxDown.UseSystemPasswordChar = true;
            textBoxDown.ForeColor = Color.Black;       
        }

   

        private void PicbKeyboard_Click(object sender, EventArgs e)
        {
           
        }
        Point pMousedown;
        bool isMoving;

        //让界面可以移动
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pMousedown = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                isMoving = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                this.Location = new Point(this.Location.X + e.X - pMousedown.X,
                    this.Location.Y + e.Y - pMousedown.Y);
            }
        }
        private void TextBoxUp_Leave(object sender, EventArgs e)
        {
            upisPress = false;
            picbPenguin.BackgroundImage = Properties.Resources.QQ_user_dis;
            panelUp.BackColor = Color.LightGray;
            if (textBoxUp.Text==null)
            textBoxUp.Text = "QQ号码/手机/邮箱";
            textBoxUp.ForeColor = Color.Gray;
        }

        private void PicbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxDown_Leave(object sender, EventArgs e)
        {
            textBoxDown.ForeColor = Color.Gray;
            textBoxDown.UseSystemPasswordChar = false;
            if (textBoxDown.Text == null)
                textBoxDown.Text = "密码";
            picbLock.BackgroundImage = Properties.Resources._189解锁;
            panelDown.BackColor = Color.LightGray;
            downisPress = false;
        }

        private void PicbMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // if(WindowState==FormWindowState.Minimized)
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.ShowDialog();
           
        }
        enum Move_Dic { Left,Right}
        Move_Dic movedic;
        int movestep;
        private void PicbHead_MouseEnter(object sender, EventArgs e)
        {
            movedic = Move_Dic.Right;
            timer1.Enabled = true;
             movestep  = 17;
        }

        private void PicbHead_MouseLeave(object sender, EventArgs e)
        {
            movedic = Move_Dic.Left;
           movestep = 17;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (movedic == Move_Dic.Left)
            {
                if (picbAdd.Location.X >= picbHead.Location.X)
                {
                    if ((picbAdd.Location.X - picbHead.Location.X) <= movestep)
                        movestep = picbAdd.Location.X - picbHead.Location.X;
                        picbAdd.Location = new Point(picbAdd.Location.X - movestep, picbAdd.Location.Y);
                }
            }
           else if (movedic == Move_Dic.Right)
            {
                if (picbAdd.Location.X <= picbHead.Location.X+100)
                    picbAdd.Location = new Point(picbAdd.Location.X + movestep, picbAdd.Location.Y);
            }
        }

        private void TextBoxUp_MouseDown(object sender, MouseEventArgs e)
        {
            panelUp.BackColor = Color.LightBlue;
            picbPenguin.BackgroundImage = Properties.Resources.QQ_user_en;
            upisPress = true;
            textBoxUp.Text = null;
            textBoxUp.ForeColor = Color.Black;
           
        }
    }
}
