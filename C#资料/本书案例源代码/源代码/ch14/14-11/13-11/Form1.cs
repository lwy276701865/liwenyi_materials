using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //创建笔，确定多边形颜色为黑色，宽度为3
            Pen blackPen = new Pen(Color.Black, 3);
            //定义多边形顶点
            Point point1 = new Point(90, 30);
            Point point2 = new Point(50, 60);
            Point point3 = new Point(90, 90);
            Point point4 = new Point(170, 90);
            Point point5 = new Point(210, 60);
            Point point6 = new Point(170, 30);
            //定义Point结构数组，用来表多边形的点
            Point[] curvePoints = { point1, point2, point3, point4, point5, point6 };
            //绘制多边形
            GPS.DrawPolygon(blackPen, curvePoints);
        }
    }
}
