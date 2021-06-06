using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_7
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
            //给定指定的Pen对象，确定矩形的颜色为红色，宽度为2
            Pen MyPen = new Pen(Color.Red, 2f);
            //绘制起点为(35,35)，宽为200，高100的矩形
            Rectangle Rect = new Rectangle(35, 35, 200, 100);
            //使用DrawRectangle进行绘制
            GPS.DrawRectangle(MyPen, Rect);
        }
    }
}
