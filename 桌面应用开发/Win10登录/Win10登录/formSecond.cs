using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Win10登录
{
    public partial class formSecond : Form
    {
        public formSecond()
        {
            InitializeComponent();
        }
        public class NewPanel : Panel
        {
            public NewPanel()
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.UserPaint, true);             
            }
        }
            private void TbxPassword_MouseEnter(object sender, EventArgs e)
        {
            picbBorderColor.BackColor = System.Drawing.Color.LightGray;
        }
        private void TbxPassword_MouseLeave(object sender, EventArgs e)
        {
            picbBorderColor.BackColor = System.Drawing.Color.White;
        }
        private void TimeTextIsNull_Tick(object sender, EventArgs e)
        {
          if(tbxPassword.TextLength==0)
            {
                lblPIN.Visible = true;
                picbEye.Visible = false;
              
            }
          else
            {
                lblPIN.Visible = false;
                picbEye.Visible = true;
            }
        }
        private void PicbEye_MouseEnter(object sender, EventArgs e)
        {
            picbBorderColor.BackColor = System.Drawing.Color.LightGray;
            picbEye.BackgroundImage = Properties.Resources.eyeIn;
        }
        private void PicbEye_MouseLeave(object sender, EventArgs e)
        {
            picbBorderColor.BackColor = System.Drawing.Color.Transparent;
            picbEye.BackgroundImage = Properties.Resources.eyeOut;
        }

        private void PicbEye_MouseDown(object sender, MouseEventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = false;
            picbEye.BackgroundImage = Properties.Resources.eyeDown;
        }

        private void PicbEye_MouseUp(object sender, MouseEventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = true;
            picbEye.BackgroundImage = Properties.Resources.eyeIn;
        }    
        private void PicbBorderColor_Paint(object sender, PaintEventArgs e)
        {
            picbBorderColor.Width = tbxPassword.Width + 6;
            picbBorderColor.Height = tbxPassword.Height + 6;
            picbBorderColor.Location = new Point(tbxPassword.Location.X-3, tbxPassword.Location.Y -3);
        } 
   

        private void TimeGetTime_Tick(object sender, EventArgs e)
        {
            string week = null;
            string dataTime;
            dataTime = DateTime.Today.DayOfWeek.ToString();
            string monthAndDay = System.DateTime.Now.ToLongDateString().Substring(5);
            switch (dataTime)

            {

                case "Monday":

                    week = "星期一";

                    break;

                case "Tuesday":

                    week = "星期二";

                    break;

                case "Wednesday":

                    week = "星期三";

                    break;

                case "Thursday":

                    week = "星期四";

                    break;

                case "Friday":

                    week = "星期五";

                    break;

                case "Saturday":

                    week = "星期六";

                    break;

                case "Sunday":

                    week = "星期日";

                    break;
            }
            lblTimeTop.Text = System.DateTime.Now.ToLongTimeString();
            lblTimeBot.Text = monthAndDay + "," + week;
        }

        private void FormSecond_MouseClick(object sender, MouseEventArgs e)
        {
            //panel1.Visible = true;
            this.BackgroundImage = Properties.Resources.imageDark;
            tbxPassword.Focus();
        }

        private void FormSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
           // panel1.Visible = true;
            this.BackgroundImage = Properties.Resources.imageDark;
            tbxPassword.Focus();
        }

        private void FormSecond_Load(object sender, EventArgs e)
        {
          
            this.BackgroundImage = Properties.Resources.imageLight;         
        }

        private void TbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode==Keys.Enter&&tbxPassword.Text=="0608")
            {
                this.Close();
            }
            /*else if(e.KeyCode == Keys.Enter && tbxPassword.Text == "")
           {
               lblWrong.Visible = true;
               lblWrong.Text = "提供PIN。";
               tbxPassword.Visible = false;
               picbEye.Visible = false;
               lblPIN.Visible = false;
               btnSure.Visible = true;
              // tbxPassword.Enabled = false;
              // btnSure.Enabled = true ;
           }
           else if(e.KeyCode == Keys.Enter&& tbxPassword.Text != "0608"&& tbxPassword.Text != "")
           {
               /*lblWrong.Visible = true;
               lblWrong.Text = "PIN不正确。请重试。";
               tbxPassword.Visible = false;
               picbEye.Visible = false;
               lblPIN.Visible = false;
               btnSure.Visible = true;
               tbxPassword.Text = null;
              // tbxPassword.Enabled = false;
              // btnSure.Enabled = true ;
           }*/
        }
    }
}
