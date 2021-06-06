using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace myMP3Player
{
    public partial class UserControl3 : UserControl
    {
        public string  img;//图片地址
        private string answer;//答案
        private string tip;//提示
        public UserControl3(string i,string b,string c)
        {
            img = i;
            answer = b;
            tip = c;
            InitializeComponent();
        }
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
        private void UserControl3_Load(object sender, EventArgs e)
        {
            this.IsRight = false;         
             pictureBox1.BackgroundImage =Image.FromFile(img);
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            this.Width = ScreenArea.Width / 5;
            this.Height = ScreenArea.Height / 3;
            toolTip1.SetToolTip(pictureBox3,tip);
        }
        private void UserControl3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            panel1.Visible = true;
            textBox1.Visible = true;
            pictureBox1.Visible = true;
            this.BackColor = Color.FromArgb(244, 164, 96);
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
            if (textBox1.Text != answer && e.KeyChar == (char)13 && textBox1.Text != "")
            {
                pictureBox2.BackgroundImage = Properties.Resources.叉;
                pictureBox2.Visible = true;
                IsRight = false;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                pictureBox2.Visible = false;
            }
        }
    }
}
