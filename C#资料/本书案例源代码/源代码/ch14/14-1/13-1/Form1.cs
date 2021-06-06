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

namespace _13_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //创建在容器Panel控件的Paint事件中，创建Graphics类的对象g
            Graphics g = e.Graphics;
            //使用SolidBrush类创建一个Brush对象，设置绘图的颜色为绿色
            Brush greenBrush = new SolidBrush(Color.Green);
            //设置直径变量
            int radius = 60;
            //绘制圆，(10, 10)为左上角的坐标，radius为直径
            g.FillEllipse(greenBrush, 10, 10, radius, radius);
            Brush redBush = new SolidBrush(Color.Red);
            //绘制椭圆，其实圆时椭圆的特殊的一种，即两个定点重合, (70, 80)为左上角的坐标，
            //90位椭圆的宽度，60位椭圆的高度
            g.FillEllipse(redBush, 70, 80, 90, 60);
            //绘制正方形
            Brush blueBruch = new SolidBrush(Color.RoyalBlue);
            Rectangle r = new Rectangle(150, 10, 50, 70);
            //填充Rectangle
            g.FillRectangle(blueBruch, r);
        }
    }
}
