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

namespace _13_4
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
            Graphics g = this.CreateGraphics();
            //实例化Bitmap对象，用于获取图像的路径
            Bitmap b = new Bitmap(@"E:\test\ch14\14-4\14-4\bin\Debug\1.jpg");
            //实例化TextureBrush对象
            TextureBrush t = new TextureBrush(b);
            //使用TranslateTransform方法，令图像从坐标50，50开始填充
            g.TranslateTransform(50, 50);
            g.FillRectangle(t, 0, 0, 150, 150);
        }
    }
}
