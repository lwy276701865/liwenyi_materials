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

namespace _13_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //连数据库
            SqlConnection Connection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True");
            Connection.Open();
            //学生人数总和
            string StuNum = "SELECT SUM(num)  FROM SIF";
            SqlCommand CmdCount = new SqlCommand(StuNum, Connection);
            int Sum = Convert.ToInt32(CmdCount.ExecuteScalar());
            string StuSql = "select * from SIF";
            SqlCommand CmdTatalInfo = new SqlCommand(StuSql, Connection);
            //创建SqlDataAdapter对象读取数据
            SqlDataAdapter Sda = new SqlDataAdapter(CmdTatalInfo);
            DataSet Ds = new DataSet();
            Sda.Fill(Ds);
            Connection.Close();
            //优秀人数
            int NumBest = Convert.ToInt32(Ds.Tables[0].Rows[0][1].ToString());
            //良好人数
            int NumGood = Convert.ToInt32(Ds.Tables[0].Rows[1][1].ToString());
            //一般人数
            int NumNormal = Convert.ToInt32(Ds.Tables[0].Rows[2][1].ToString());
            //不及格人数
            int NumBad = Convert.ToInt32(Ds.Tables[0].Rows[3][1].ToString());
            //创建画图对象
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics G = Graphics.FromImage(bitmap);
            //清空背景色
            G.Clear(Color.White);
            Pen pen1 = new Pen(Color.Red);
            Brush Brush_Bg = new SolidBrush(Color.Silver);
            Brush Brush_Best = new SolidBrush(Color.Blue);
            Brush Brush_Good = new SolidBrush(Color.Wheat);
            Brush Brush_Normal = new SolidBrush(Color.Yellow);
            Brush Brush_Bad = new SolidBrush(Color.Red);
            Font FontTitle = new Font("Courier New", 16, FontStyle.Bold);
            Font FontInfo = new Font("Courier New", 8);
            //绘制背景图
            G.FillRectangle(Brush_Bg, 0, 0, 800, 600);
            //书写标题
            G.DrawString("某高校期中考试成绩等级分配图", FontTitle, Brush_Best, new Point(40, 20));
            //定义范围
            int StartX = 100, StartY = 60, StartWidth = 200, StartHeight = 200;
            //优秀分配的角度
            float CircleBest = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(NumBest));
            //良好分配的角度
            float CircleGood = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(NumGood));
            //一般分配的角度
            float CircleNormal = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(NumNormal));
            //不及格分配的角度
            float CircleBad = Convert.ToSingle((360 / Convert.ToSingle(Sum)) * Convert.ToSingle(NumBad));
            //绘制优秀所占比例
            G.FillPie(Brush_Best, StartX, StartY, StartWidth, StartHeight, 0, CircleBest);
            //绘制良好所占比例
            G.FillPie(Brush_Good, StartX, StartY, StartWidth, StartHeight, CircleBest, CircleGood);
            //绘制一般所占比例
            G.FillPie(Brush_Normal, StartX, StartY, StartWidth, StartHeight, CircleBest + CircleGood, CircleNormal);
            //绘制不及格所占比例
            G.FillPie(Brush_Bad, StartX, StartY, StartWidth, StartHeight, CircleBest + CircleGood + CircleNormal, CircleBad);
            //绘制标识，绘制范围框
            G.DrawRectangle(pen1, 50, 300, 310, 180);
            //绘制等级人数占比说明框
            G.FillRectangle(Brush_Best, 90, 320, 20, 10);
            G.DrawString("优秀人数比例:" + Convert.ToSingle(NumBest) * 100 / Convert.ToSingle(Sum) + "%", FontInfo, Brush_Best, 120, 320);
            G.FillRectangle(Brush_Good, 90, 360, 20, 10);
            G.DrawString("良好人数比例:" + Convert.ToSingle(NumGood) * 100 / Convert.ToSingle(Sum) + "%", FontInfo, Brush_Good, 120, 360);
            G.FillRectangle(Brush_Normal, 90, 400, 20, 10);
            G.DrawString("一般人数比例:" + Convert.ToSingle(NumNormal) * 100 / Convert.ToSingle(Sum) + "%", FontInfo, Brush_Normal, 120, 400);
            G.FillRectangle(Brush_Bad, 90, 440, 20, 10);
            G.DrawString("不及格人数比例:" + Convert.ToSingle(NumBad) * 100 / Convert.ToSingle(Sum) + "%", FontInfo, Brush_Bad, 120, 440);
            pictureBox1.Image = bitmap;
        }
    }
}
