using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //存储月份
            string[] Month = new string[12] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            //交点的数值
            float[] d = new float[12] { 20.03F, 60, 10.3F, 15.6F, 30, 70.2F, 50.3F, 30.7F, 70, 50.4F, 30.8F, 20 };
            //初始化图片
            Bitmap BTMap = new Bitmap(800, 600);
            Graphics Gph = Graphics.FromImage(BTMap);
            //背景
            Gph.Clear(Color.Silver);
            //中心点
            PointF CenterPt = new PointF(40, 420);
            //X轴三角形
            PointF[] XPt = new PointF[3] { new PointF(CenterPt.Y + 35, CenterPt.Y), new PointF(CenterPt.Y + 20, CenterPt.Y - 8), new PointF(CenterPt.Y + 20, CenterPt.Y + 8) };
            //Y轴三角形
            PointF[] YPt = new PointF[3] { new PointF(CenterPt.X, CenterPt.X - 15), new PointF(CenterPt.X - 8, CenterPt.X), new PointF(CenterPt.X + 8, CenterPt.X) };
            //图表标题
            Gph.DrawString("某城市年降雨量图", new Font("宋体", 14), Brushes.Black, new PointF(CenterPt.X + 60, CenterPt.X));
            //X轴
            Gph.DrawLine(Pens.Black, CenterPt.X, CenterPt.Y, CenterPt.Y + 20, CenterPt.Y);
            Gph.DrawPolygon(Pens.Black, XPt);
            Gph.FillPolygon(new SolidBrush(Color.Black), XPt);
            //标记月份
            Gph.DrawString("月份", new Font("宋体", 12), Brushes.Black, new PointF(CenterPt.Y + 20, CenterPt.Y - 20));
            //Y轴
            Gph.DrawLine(Pens.Black, CenterPt.X, CenterPt.Y, CenterPt.X, CenterPt.X);
            //填充箭头
            Gph.FillPolygon(new SolidBrush(Color.Black), YPt);
            Gph.DrawString("单位(毫米)", new Font("宋体", 12), Brushes.Black, new PointF(0, 7));
            for (int i = 1; i <= 12; i++)
            {
                //Y轴刻度
                if (i < 11)
                {
                    //显示数字
                    Gph.DrawString((i * 10).ToString(), new Font("宋体", 12), Brushes.Black, new PointF(CenterPt.X, CenterPt.Y - i * 30 - 6));
                    //格子
                    Gph.DrawLine(Pens.Black, CenterPt.X, CenterPt.Y - i * 30, CenterPt.X + 3, CenterPt.Y - i * 30);
                }
                //X轴刻度
                Gph.DrawLine(new Pen(Color.Black, 2f), new PointF(CenterPt.X + i * 30, CenterPt.Y), new PointF(CenterPt.X + i * 30, CenterPt.Y - 5));
                //X轴数字
                Gph.DrawString(Month[i - 1], new Font("宋体", 12), Brushes.Black, new PointF(CenterPt.X + i * 30 - 5, CenterPt.Y + 5));
                //曲线的交叉点
                Gph.FillEllipse(new SolidBrush(Color.Red), CenterPt.X + i * 30 - 1.5F, CenterPt.Y - d[i - 1] * 3 - 1.5F, 3, 3);
                //数值
                Gph.DrawString(d[i - 1].ToString(), new Font("宋体", 12), Brushes.Black, new PointF(CenterPt.X + i * 30, CenterPt.Y - d[i - 1] * 3));
                //画折线
                if (i > 1) Gph.DrawLine(Pens.Black, CenterPt.X + (i - 1) * 30, CenterPt.Y - d[i - 2] * 3, CenterPt.X + i * 30, CenterPt.Y - d[i - 1] * 3);
            }
            pictureBox1.Image = BTMap;
        }
    }
}
