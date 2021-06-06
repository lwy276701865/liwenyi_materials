using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
namespace myMP3Player
{
    public partial class UserControl1: UserControl
    {
        private string a;//第一个选项
        private string b;//第二个
        private string c;//第三个
        private string answer;//答案
        private string myfilename;//音频文件地址
        List<RadioButton> rb = new List<RadioButton>();
        private bool isRight;
        [CategoryAttribute("其他"), DescriptionAttribute("答案是否正确")]
        public bool IsRight
        {
            get
            {
                return isRight;
            }
            set
            {
                isRight = value;
            }
        } 
        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.IsRight = false;
            this.radioButton1.Text = a;
            this.radioButton2.Text = b;
            this.radioButton3.Text = c;
            rb.Add(radioButton1);
            rb.Add(radioButton2);
            rb.Add(radioButton3);
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);//获取屏幕大小
            this.Width = ScreenArea.Width / 5;
            this.Height = ScreenArea.Height / 3;
            this.BackgroundImage = Properties.Resources.锁;
        }
        public UserControl1(string a, string b, string c,string d,string e)
        {
            this.a = a; 
            this.b = b;
            this.c = c;
            this.myfilename = d;
            answer = e;
            InitializeComponent();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {               
                SoundPlayer s = new SoundPlayer(myfilename);
                s.Play();            
        }
        private void UserControl1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.panel1.Visible = true;
            this.BackColor = Color.FromArgb(255, 140, 0);
            this.BackgroundImage = null;
            this.button1.Focus();  
        }
        private void RadioButton1_Click(object sender, EventArgs e)
        {
            this.button1.Focus();    
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (RadioButton r in rb)
            {
                if (r.Checked == true && r.Text == answer)
                {
                    pictureBox2.BackgroundImage = Properties.Resources.勾;
                    pictureBox2.Visible = true;
                    IsRight = true;
                }
                if (r.Checked == true && r.Text != answer)
                {
                    pictureBox2.BackgroundImage = Properties.Resources.叉;
                    pictureBox2.Visible = true;
                    IsRight = false ;
                }
            }
        }
    }
}
