using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //创建pen对象，给圆弧指定颜色为黑色，宽度为2
            Pen MyPen = new Pen(Color.Black, 2f);
            //定义Rectangle结构，确定坐标为(30,30)，宽150，高80
            Rectangle Rect = new Rectangle(30, 30, 150, 80);
            //使用DrawArc方法绘制圆弧，起点角度为45度，结束角度为260度
            GPS.DrawArc(MyPen, Rect, 45, 260);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //创建pen对象，给圆弧指定颜色为红色，宽度为3
            Pen MyPen = new Pen(Color.Red, 3f);
            //使用DrawArc方法绘制圆弧
            GPS.DrawArc(MyPen, 150, 50, 100, 80, 45, 270);
        }
    }
}
