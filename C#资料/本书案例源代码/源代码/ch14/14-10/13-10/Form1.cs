using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_10
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
            //创建Pen对象，确定扇形颜色为棕色，宽度为3
            Pen blackPen = new Pen(Color.Brown, 3);
            //创建矩形大小
            Rectangle rect = new Rectangle(0, 0, 150, 100);
            //指定起点角度
            float startAngle = 0.0F;
            //指定终点角度
            float sweepAngle = 45.0F;
            //在屏幕上绘制扇形
            GPS.DrawPie(blackPen, rect, startAngle, sweepAngle);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //创建Graphics对象
            Graphics GPS = this.CreateGraphics();
            //创建Pen对象，确定扇形颜色为黑色，宽度为3
            Pen blackPen = new Pen(Color.Black, 3);
            //创建扇形的大小和位置
            int x = 10;
            int y = 70;
            int width = 200;
            int height = 100;
            //指定起点角度
            int startAngle = 0;
            //指定终点角度
            int sweepAngle = 75;
            //绘制扇形
            GPS.DrawPie(blackPen, x, y, width, height, startAngle, sweepAngle);
        }
    }
}
