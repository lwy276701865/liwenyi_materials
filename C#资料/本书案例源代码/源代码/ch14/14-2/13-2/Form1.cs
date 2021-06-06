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

namespace _13_2
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
            //创建HatchBrush类，设置HatchStyle值，前景色以及背景色
            HatchBrush h = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.White);
            //绘制矩形
            Rectangle r = new Rectangle(10, 10, 300, 200);
            //填充矩形
            g.FillRectangle(h, r);
        }
    }
}
