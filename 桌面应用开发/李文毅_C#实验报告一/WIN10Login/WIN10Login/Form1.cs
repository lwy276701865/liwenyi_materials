using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIN10Login
{
  
    public partial class Form1 : Form
    {
        public Form1()
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
        private void TimerGetTime_Tick(object sender, EventArgs e)
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
            lblTopTime.Text = System.DateTime.Now.ToShortTimeString();
            lblBotTime.Text = monthAndDay + "," + week;
        }
    
        private void TbxPassword_MouseEnter(object sender, EventArgs e)
        {
            Graphics g = panPassword.CreateGraphics();
            g.DrawRectangle(new Pen(Color.White, 5.0f), new Rectangle(tbxPassword.Location.X,
                tbxPassword.Location.Y, tbxPassword.Width, tbxPassword.Height));
          
        }
      
 

        private void TbxPassword_MouseLeave(object sender, EventArgs e)
        {
            Graphics g = panPassword.CreateGraphics();
            g.DrawRectangle(new Pen(Color.DarkGray,5.0f), new Rectangle(tbxPassword.Location.X,
                tbxPassword.Location.Y, tbxPassword.Width, tbxPassword.Height));
        
        }

        private void PicbEye_MouseDown(object sender, MouseEventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = false;
            picbEye.BackgroundImage = Properties.Resources.眼睛DOWN;
        }

        private void PicbEye_MouseEnter(object sender, EventArgs e)
        {
            Graphics g = panPassword.CreateGraphics();
            g.DrawRectangle(new Pen(Color.White, 5.0f), new Rectangle(tbxPassword.Location.X,
                tbxPassword.Location.Y, tbxPassword.Width, tbxPassword.Height));
            picbEye.BackgroundImage = Properties.Resources.眼睛IN;
        }

        private void PicbEye_MouseLeave(object sender, EventArgs e)
        {
            Graphics g = panPassword.CreateGraphics();
            g.DrawRectangle(new Pen(Color.DarkGray, 5.0f), new Rectangle(tbxPassword.Location.X,
                tbxPassword.Location.Y, tbxPassword.Width, tbxPassword.Height));
            picbEye.BackgroundImage = Properties.Resources.眼睛;
        }

        private void TimerTextIsNull_Tick(object sender, EventArgs e)
        {
            if (tbxPassword.TextLength == 0)
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

        private void PicbEye_MouseUp(object sender, MouseEventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = true;
            picbEye.BackgroundImage = Properties.Resources.眼睛;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imageDark;
            picbWifi.Enabled = true;
            picbElectry.Enabled = true;
            picbPower.Visible = true;
            panCloseRestart.Visible = false;
            picbHead.Visible = true;
            panPassword.Visible = true;
            tbxPassword.Focus();
            btnSure.Visible = false;
            lblName.Visible = true ;
            lblWrongText.Visible = false;
            lblTopTime.Visible = false ;
            lblBotTime.Visible = false ;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imageDark;
           
            picbWifi.Enabled = true;
            picbElectry.Enabled = true;
            picbPower.Visible = true;
            picbHead.Visible = true;
            panPassword.Visible = true;
            tbxPassword.Focus();
            btnSure.Visible = false;
            lblName.Visible = true;
            lblWrongText.Visible = false;
            lblTopTime.Visible = false;
            lblBotTime.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.imageLight;
            panCloseRestart.Visible = false;
            picbPower.Visible = false ;
            picbHead.Visible = false;
            panPassword.Visible = false;
            btnSure.Visible = false;
            lblName.Visible = false;
            lblWrongText.Visible = false;
            lblTopTime.Visible = true;
            lblBotTime.Visible = true;
            lblTip.Visible = false;
            lblTip.BackColor = Color.FromArgb(20, Color.Transparent);
        }

        private void TbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbxPassword.Text == "0608")
            {
                this.Close();
            }
            else if(e.KeyCode == Keys.Enter && tbxPassword.Text == "")
            {
                panPassword.Visible = false;
                lblWrongText.Visible = true;
                btnSure.Visible = true;
                lblWrongText.Text = "提供PIN。";
                btnSure.Focus();
            }
            else if(e.KeyCode == Keys.Enter && tbxPassword.Text != "" && tbxPassword.Text != "0608")
            {
                panPassword.Visible = false;
                lblWrongText.Visible = true;
                btnSure.Visible = true;
                lblWrongText.Text = "PIN不正确。请重试。";
                btnSure.Focus();
            }
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            panPassword.Visible = true;
            lblWrongText.Visible = false ;
            btnSure.Visible = false ;
            if(tbxPassword.TextLength!=0)
            {
                tbxPassword.Text = null;
            }
        }

        private void BtnSure_KeyDown(object sender, KeyEventArgs e)
        {
            panPassword.Visible = true;
            lblWrongText.Visible = false;
            btnSure.Visible = false;
        }

        private void PicbWifi_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Gainsboro;
        }

        private void PicbWifi_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void PicbPower_Click(object sender, EventArgs e)
        {
            panCloseRestart.Visible = true;
        }
        private void LblClose_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Gainsboro;
        }
        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Transparent;
        }
        private void LblClose_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/cshutdown -s -t 0");
        }
        private void LblSleep_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/cshutdown -h -t 0");
        }
        private void LblRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/cshutdown -r -t 0");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            lblBotTime.Top = Height - 200;
            lblTopTime.Top = Height - 250;
            lblBotTime.Left = 0;
            lblTopTime.Left = 0;
            picbElectry.Top = Height - 50;
            picbElectry.Left = Width - 110;
            picbWifi.Top = Height - 50;
            picbWifi.Left = Width - 180;
            picbPower.Top = Height - 50;
            picbPower.Left = Width - 40;
            panCloseRestart.Top = Height - 160;
            panCloseRestart.Left = Width - 90;
            picbHead.Location = new Point(Width/2-40, Height-610);
            lblName.Location = new Point(Width / 2-40, Height - 490);
             panPassword.Location = new Point(Width/2-80, Height-460);
            btnSure.Location = new Point(Width/2 - 30, Height-380);
            lblWrongText.Location = new Point(Width /2- 15, Height-440);
            lblTip.Top = 50;
            lblTip.Left =50;
            picbSearch.Top =50;
            picbSearch.Left =0;
        }

        private void PicSearch_MouseEnter(object sender, EventArgs e)
        {
            lblTip.Visible = true;
        }

        private void PicSearch_MouseLeave(object sender, EventArgs e)
        {
            lblTip.Visible = false;
        }
    }
  
}
