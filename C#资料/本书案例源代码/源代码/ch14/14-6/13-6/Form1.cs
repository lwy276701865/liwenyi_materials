using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_6
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
            //创建黑色Pen对象
            Pen MyPen = new Pen(Color.Black, 2f);
            //确定起点终点
            Point pt1 = new Point(70, 20);
            Point pt2 = new Point(200, 320);
            //使用DrawLine方法绘制直线
            GPS.DrawLine(MyPen, pt1, pt2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //创建红色Pen对象
            Pen MyPen = new Pen(Color.Red, 2f);
            //使用DrawLine方法绘制直线
            GPS.DrawLine(MyPen, 50, 20, 300, 220);
        }
    }
}
