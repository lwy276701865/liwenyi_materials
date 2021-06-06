using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _13_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //实例化两个point类，作为渐变图形的起止和结束点
            Point pt1 = new Point(50, 50);
            Point pt2 = new Point(200, 200);
            //实例化Graphics
            Graphics g = this.CreateGraphics();
            //实例化LinearGradientBrush，设置起止点和终止点以及渐变色
            LinearGradientBrush l = new LinearGradientBrush(pt1, pt2, Color.Black, Color.AntiqueWhite);
            //填充矩形
            Rectangle r = new Rectangle(10, 10, 250, 200);
            g.FillRectangle(l, r);
        }
    }
}
