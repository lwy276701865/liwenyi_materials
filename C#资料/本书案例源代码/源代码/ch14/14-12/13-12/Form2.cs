using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _13_12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //总票数变量
            int Sum;
            //建立数据库连接
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True");
            Conn.Open();
            //定义SqlCommand类，用于对数据库相关操作
            SqlCommand Cmd = new SqlCommand("select sum(num) from GDI", Conn);
            //返回查询结果
            Sum = (int)Cmd.ExecuteScalar();
            SqlDataAdapter Sda = new SqlDataAdapter("select * from GDI", Conn);
            //定义DataSet，用于填充数据
            DataSet Ds = new DataSet();
            Sda.Fill(Ds);
            Conn.Close();
            //梅西的票数
            int NumMX = Convert.ToInt32(Ds.Tables[0].Rows[2][1].ToString());
            //C罗的票数
            int NumCL = Convert.ToInt32(Ds.Tables[0].Rows[0][1].ToString());
            //内马尔的票数
            int NumNME = Convert.ToInt32(Ds.Tables[0].Rows[3][1].ToString());
            //里贝里的票数
            int NumLBL = Convert.ToInt32(Ds.Tables[0].Rows[1][1].ToString());
            //票数比例 小数点
            float LenMX = Convert.ToSingle(Convert.ToSingle(NumMX) * 100 / Convert.ToSingle(Sum));
            float LenCL = Convert.ToSingle(Convert.ToSingle(NumCL) * 100 / Convert.ToSingle(Sum));
            float LenNME = Convert.ToSingle(Convert.ToSingle(NumNME) * 100 / Convert.ToSingle(Sum));
            float LenLBL = Convert.ToSingle(Convert.ToSingle(NumLBL) * 100 / Convert.ToSingle(Sum));
            //定义图像
            Bitmap BitMap = new Bitmap(300, 300);
            Graphics G = Graphics.FromImage(BitMap);
            //填充背景色，白色
            G.Clear(Color.White);
            //设置笔刷参数
            Brush Brush_Bg = new SolidBrush(Color.White);
            Brush Brush_Word = new SolidBrush(Color.Black);
            Brush Brush_MX = new SolidBrush(Color.Red);
            Brush Brush_CL = new SolidBrush(Color.Green);
            Brush Brush_NME = new SolidBrush(Color.Orange);
            Brush Brush_LBL = new SolidBrush(Color.DarkBlue);
            //设置字体
            Font FontTitle = new Font("Courier New", 16, FontStyle.Bold);
            Font font2 = new Font("Courier New", 8);
            //绘制背景图
            G.FillRectangle(Brush_Bg, 0, 0, 300, 300);
            G.DrawString("投票结果", FontTitle, Brush_Word, new Point(90, 20));
            Point p1 = new Point(70, 50);
            Point p2 = new Point(230, 50);
            G.DrawLine(new Pen(Color.Black), p1, p2);
            //绘制文字，以及文字位置坐标
            G.DrawString("梅西：", font2, Brush_Word, new Point(52, 80));
            G.DrawString("C 罗：", font2, Brush_Word, new Point(51, 110));
            G.DrawString("内马尔：", font2, Brush_Word, new Point(40, 140));
            G.DrawString("里贝里：", font2, Brush_Word, new Point(40, 170));
            //使用FillRectangle方法绘制柱形图
            G.FillRectangle(Brush_MX, 95, 80, LenMX, 17);
            G.FillRectangle(Brush_CL, 95, 110, LenCL, 17);
            G.FillRectangle(Brush_NME, 95, 140, LenNME, 17);
            G.FillRectangle(Brush_LBL, 95, 170, LenLBL, 17);
            //绘制范围框
            G.DrawRectangle(new Pen(Color.Green), 10, 210, 280, 80);
            //绘制所有选项的票数显示
            G.DrawString("梅西：" + NumMX.ToString() + "票", font2, Brush_Word, new Point(15, 220));
            G.DrawString("C罗：" + NumCL.ToString() + "票", font2, Brush_Word, new Point(150, 220));
            G.DrawString("内马尔：" + NumNME.ToString() + "票", font2, Brush_Word, new Point(15, 260));
            G.DrawString("里贝里：" + NumLBL.ToString() + "票", font2, Brush_Word, new Point(150, 260));
            pictureBox1.Image = BitMap;
        }
    }
}
