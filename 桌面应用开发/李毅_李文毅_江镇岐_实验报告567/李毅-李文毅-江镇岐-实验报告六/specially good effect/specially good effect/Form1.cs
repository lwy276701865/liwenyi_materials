using System;
using System.Drawing;
using System.Windows.Forms;

namespace specially_good_effect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

            lblgo.Top = Height - 300;
            lblgo.Left = 100;
            picbHuman.Top = 0;
            picbHuman.Left = this.Width - 300;
            picbTip.Top = Height / 2-100;
            picbTip.Left = Width / 2-100;
        }

        private void TimeGo_Tick(object sender, EventArgs e)
        {
            lblgo.Left += 5;
            if(lblgo.Left==700)
            {
                timeHuman.Enabled = true;
                picbHuman.Visible = true;
            }
        }     
        private void TimeHuman_Tick(object sender, EventArgs e)
        {
            if(picbHuman.Top<=this.Height-250)
            {
                picbHuman.Top += 20;
                picbHuman.Height += 5;
                picbHuman.Width += 5;
            }
            if(picbHuman.Top+20>=Height-250)
            {
                picbTip.Visible = true;
                Point p = lblgo.Location;
                lblgo.Visible = false;
                lblrun.Visible = true;           
                lblrun.Location = p;
              
            }
            if (picbHuman.Top + 20 >= Height - 230)
            {
                timer1.Enabled = true;
                timeHuman.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            picbHuman.Visible = false;
            lblrun.Visible = false;
            picbTip.Visible = false;
            myControl.WordRain wr = new myControl.WordRain();
            this.Controls.Add(wr);
            timer1.Enabled = false;
        }
    }
}
