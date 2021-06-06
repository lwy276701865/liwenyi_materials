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
namespace ppm
{
    public partial class FrmPPMViewer : Form
    {
        public FrmPPMViewer()
        {
            InitializeComponent();
        }
        string fn;

        string strTotal;
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fn = ofd.FileName;
            }
            FileStream fs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string strFileType = sr.ReadLine();
            string strResoulution = sr.ReadLine();
            string strMaxColor = sr.ReadLine();
            string[] res = strResoulution.Split(' ');
            int width = int.Parse(res[0]);
            int height = int.Parse(res[1]);
            strTotal = sr.ReadToEnd();
            string[] pixels = strTotal.Split(' ');
            Bitmap bmp = new Bitmap(width, height);
            int count = 0;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int r = int.Parse(pixels[count]);
                    int g = int.Parse(pixels[count + 1]);
                    int b = int.Parse(pixels[count + 2]);
                    count += 3;
                    bmp.SetPixel(y, x, Color.FromArgb(r,g,b));
                }
            }

            this.BackgroundImage = bmp;

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
