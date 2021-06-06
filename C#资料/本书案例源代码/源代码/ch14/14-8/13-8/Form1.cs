using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个Graphics对象
            Graphics GPS = this.CreateGraphics();
            //给线条指定Pen对象确定椭圆颜色为绿色，宽度为2
            Pen MyPen = new Pen(Color.Green, 2f);
            //使用Rectangle结构定义椭圆的边界，位置在(30,30)，宽150，高70
            Rectangle Rect = new Rectangle(30, 30, 150, 70);
            //使用DrawEllipse方法绘制椭圆
            GPS.DrawEllipse(MyPen, Rect);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //给线条指定Pen对象确定椭圆颜色为黑色，宽度为2.5
            Pen MyPen = new Pen(Color.Black, 2.5f);
            //使用DrawEllipse方法绘制椭圆，坐标为(150,90)，宽100，高60
            GPS.DrawEllipse(MyPen, 150, 90, 100, 60);
        }
    }
}
