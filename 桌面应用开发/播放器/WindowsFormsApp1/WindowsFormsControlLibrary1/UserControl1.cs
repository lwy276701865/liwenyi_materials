using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        Graphics g;

        int margin = 10;
        int borderWidth = 8;
        int curPosRadius = 10;

        int angle;
        private Image singerImg;
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//曲线光滑
            Pen pen = new Pen(Color.FromArgb(65, 71, 87), borderWidth);//画圆的笔

            Rectangle rect = new Rectangle(margin, margin, this.Width - 20, this.Height - 20);//定义矩形

            //g.DrawEllipse(pen, new RectangleF(margin, margin, this.Width - 20, this.Height - 20));
            g.DrawEllipse(pen, rect);//画内切圆

            Pen pen2 = new Pen(Color.FromArgb(168, 186, 217), borderWidth);//画进度条圆的笔

            g.TranslateTransform(this.Width / 2, this.Height / 2);
            g.RotateTransform((float)avaterRotAngle);
            g.TranslateTransform(-this.Width / 2, -this.Height / 2);//旋转坐标系

            Image img = Image.FromFile(@"d:\\yqst.png");
            img = img.GetThumbnailImage(this.Width, this.Height, null, IntPtr.Zero);//完全展现图片
            TextureBrush tb = new TextureBrush(img);//以图像img作为画笔填充
            g.FillEllipse(tb, new RectangleF(margin + borderWidth / 2,margin + borderWidth / 2,
                this.Width - 2 * (margin + borderWidth / 2), this.Width - 2 * (margin + borderWidth / 2)));

            g.ResetTransform();
            g.Save();

            g.DrawArc(pen2, rect, 270, angle);//画弧

            double r = this.Width / 2 - margin;//半径
            double x = r * Math.Sin(angle / 180.0 * Math.PI);//180.0
            double y = r * Math.Cos(angle / 180.0 * Math.PI);//180.0
            int x1 = (int)(this.Width / 2 + x);
            int y1 = (int)(this.Height / 2 - y);//进度条圆位置（x1,y1)

            g.FillEllipse(new SolidBrush(Color.FromArgb(168, 186, 217)),
                new Rectangle(x1 - curPosRadius, y1 - curPosRadius, 2 * curPosRadius, 2 * curPosRadius));//进度条圆          
        }

        double avaterRotAngle = 0.0;

        public Image Singerimg { get => singerImg; set => singerImg = value; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (angle == 360)
                timer1.Enabled = false;
            angle++;
            avaterRotAngle+=2;
            this.Invalidate();
        }
    }
}
