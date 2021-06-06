using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 色彩处理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Bitmap bmpzoom = new Bitmap(20, 20);
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           Color color= bmp.GetPixel(e.X, e.Y);
            label1.Text = "颜色:"+color.ToString();
          if(color==Color.FromArgb(254,0,0))
            {
                pictureBox1.Cursor = Cursors.Hand;
               
                label2.Text = "pipe1";
                label2.Location = new Point(e.X+15,e.Y);
            }
          else
            {
                 pictureBox1.Cursor = Cursors.Cross;
                label2.Text = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1 .BackgroundImage.GetThumbnailImage
                (pictureBox1.Width,
                pictureBox1.Height,null,IntPtr.Zero));
            pictureBox1.Cursor = Cursors.Cross;
        }
    }
}
