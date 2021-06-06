using System;
using System.Drawing;
using System.Windows.Forms;

namespace qqMain
{
    public partial class frmWeather : Form
    {
       public Point pt;
        public frmWeather(Point p)//定义新的构造函数，确定窗体出现的位置
        {
            pt = p;
            InitializeComponent();
        }
        public event setBackImgValue setFormImgValue;

        private void FrmWeather_Paint(object sender, PaintEventArgs e)
        {
            setFormImgValue(this.picbWeather1.BackgroundImage);
        }

        private void PicbSet_MouseEnter(object sender, EventArgs e)
        {
            picbSet.BackColor = Color.FromArgb(50, Color.Transparent);
        }
        public delegate void setBackImgValue(Image imgValue);//定义一个委托
        private void PicbSet_MouseLeave(object sender, EventArgs e)
        {
            picbSet.BackColor = Color.Transparent;
        }
        string s1, s2, s3;//今明后三天的图片文件名
        private void FrmWeather_Load(object sender, EventArgs e)//从Web Service获得天气信息
        {
            this.Location = pt;
            picbSet.BackColor = Color.Transparent;
            qqMain.Weather.WeatherWebService w = new Weather.WeatherWebService();
            string[] r = w.getWeatherbyCityName("成都");
            lblTemperature.Text = r[10].Substring(10, 3).Replace("；", "");//1
            int j = r[6].IndexOf(" ") + 1;//
            lblWeather.Text = r[6].Substring(j);//
            int k = r[10].IndexOf("风向/风力：") + 6;//
            lblWind.Text = r[10].Substring(k, 3).Replace("。", "");//
            lblAir.Text = "空气" + r[10].Substring(r[10].Length - 2, 1);//
            int i = r[10].IndexOf("湿度：") + 3;//
            lblHumidity.Text = "湿度" + r[10].Substring(i, 3).Replace("；", "");//
            lblSurvey1.Text = r[5];
            lblSurvey2.Text = r[12];
            lblSurvey3.Text = r[17];
            s1 = r[8];
            s2 = r[15];
            s3 = r[20];
            //相对路径
            picbWeather1.BackgroundImage = Bitmap.FromFile(@"..\..\..\\Resources\weather\weather\" + s1);
            picbWeather2.BackgroundImage = Bitmap.FromFile(@"..\..\..\\Resources\weather\weather\" + s2);
            picbWeather3.BackgroundImage = Bitmap.FromFile(@"..\..\..\\Resources\weather\weather\" + s3);
        }
    }
}