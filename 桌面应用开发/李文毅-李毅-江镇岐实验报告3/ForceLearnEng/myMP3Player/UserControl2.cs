using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace myMP3Player
{
    public partial class UserControl2 : UserControl
    {
        private string eng;//显示的单词
        private string answer;//答案
        public UserControl2(string a,string b)
        {
            eng = a;
            answer = b;         
            InitializeComponent();
        }
        private bool isRight;//用户是否答对
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
        private void UserControl2_Load(object sender, EventArgs e)
        {
            this.IsRight = false;
            this.label1.Text = eng;
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            this.Width = ScreenArea.Width / 5;
            this.Height = ScreenArea.Height / 3;          
        }
        private void UserControl2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            panel1.Visible = true;
            textBox1.Visible = true;       
            this.BackColor = Color.FromArgb(255, 192, 0);
            this.BackgroundImage = null;
            this.textBox1.Focus();          
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {       
            if (textBox1.Text == answer && e.KeyChar == (char)13)
            {
                pictureBox2.BackgroundImage = Properties.Resources.勾;
                pictureBox2.Visible = true;
                IsRight = true;
            }     
            if (textBox1.Text != answer && e.KeyChar == (char)13&&textBox1.Text != "")
            {
                pictureBox2.BackgroundImage = Properties.Resources.叉;
                pictureBox2.Visible = true;
                IsRight = false;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                pictureBox2.Visible = false;
            }
        }
    }
}
