using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;   
namespace 图像处理
{
    public partial class btnOpen : Form
    {
        public btnOpen()
        {
            InitializeComponent();
        }
        Image imgOriginal;
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
          
            ofd.InitialDirectory = @"D:\Desktop\图像处理";//定义打开的初始位置
            ofd.Filter = "图片文件(*.jpg)|*.jpg";//筛选选择的文件格式
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                 imgOriginal = Image.FromFile(ofd.FileName);
                picOriginal.BackgroundImage = imgOriginal;
            }
        }

        private void BtnGray_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(imgOriginal);
            for(int i=0;i<bmp.Width;i++)
            {
                for(int j=0;j<bmp.Height;j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;
                    int x = (r + g + b) / 3;
                    Color cNew = Color.FromArgb(x, x, x);
                    bmp.SetPixel(i, j, cNew);
                }
            }
            picAfter.BackgroundImage = bmp;
        }

        private void BtnReverse_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(imgOriginal);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int r = 255-color.R;
                    int g = 255-color.G;
                    int b = 255-color.B;
                  
                    Color cNew = Color.FromArgb(r,g,b);
                    bmp.SetPixel(i, j, cNew);
                }
            }
            picAfter.BackgroundImage = bmp;
        }

        private void BtnFog_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            Bitmap bmp = new Bitmap(imgOriginal);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                   
                    int dx = i + rd.Next()%10;
                    int dy = j + rd.Next() % 10;
                    if(dx>=bmp.Width-1)
                    {
                        dx = bmp.Width-1;
                    }
                    if (dy >= bmp.Height-1)
                    {
                        dy = bmp.Height-1;
                    }
                    Color cNew = bmp.GetPixel(dx, dy);
                    bmp.SetPixel(i, j, cNew);
                }
            }
            picAfter.BackgroundImage = bmp;
        }

        private void BtnRelief_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(imgOriginal);
            Color piexl1;
            Color piexl2;
            for (int i = 0; i < bmp.Width-1; i++)
            {
                for (int j = 0; j < bmp.Height-1; j++)
                {

                    piexl1 = bmp.GetPixel(i, j);
                    piexl2 = bmp.GetPixel(i+1, j+1);
                    int r = Math.Abs(piexl1.R - piexl2.R + 128);
                    int g = Math.Abs(piexl1.R - piexl2.R + 128);
                    int b = Math.Abs(piexl1.R - piexl2.R + 128);
                }
            }
            picAfter.BackgroundImage = bmp;
        }
    }
}
