using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yc.QrCodeLib;
using Yc.QrCodeLib.Data;

namespace QRcode
{
    public partial class frmQR : Form
    {
        public static string QRname = "";//二维码名称

        public frmQR()
        {
            InitializeComponent();
        }

         private void frmQR_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "Skins/mp10.ssk";
        }

        bool isUpdated = true;//url地址变是否动，变动则更新二维码显示

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (isUpdated)
            {
                string url = txtURL.Text;
                if (!url.Equals(""))
                {
                    Bitmap bmp = TxtToQR(url);
                    picQR.Image = bmp;
                }
                if(url.Equals(""))
                {
                    picQR.Image = null;
                }
            }
        }

        private void pnlDragQR_DragEnter(object sender, DragEventArgs e)//拖入文件
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))//判断拖来的是否是文件  
            {
                e.Effect = DragDropEffects.Link;//是则将拖动源中的数据连接到控件  
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlDragQR_DragDrop(object sender, DragEventArgs e)//成功拖入文件
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);//将拖来的数据转化为数组存储
            foreach (object file in files)
            {
                try
                {
                    string str = file.ToString();
                    Image bmp = Bitmap.FromFile(str);
                    picQR.Image = bmp;

                    // 解析二维码图像
                    isUpdated = false;
                    String code = QRToTxt(new Bitmap(bmp));
                    txtURL.Text = code;
                    isUpdated = true;

                    break;
                }
                catch (Exception ex) { }
            }
        }

        public static Bitmap TxtToQR(string url)//将链接地址转化为二维码图像
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(url);

            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            DrawingSize size = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            Bitmap bmp = new Bitmap(size.CodeWidth, size.CodeWidth);
            Graphics g = Graphics.FromImage(bmp);

            render.Draw(g, qrCode.Matrix);

            return bmp;
        }

        public static string QRToTxt(Bitmap bmp)//将二维码图像转化为编码串
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            String decodedString = decoder.decode(new QRCodeBitmapImage(bmp));

            return decodedString;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//在文件浏览器中显示已保存的二维码图像文件
        {
            String dir = curDir() + "QR\\";
            String name = linkLabel1.Text.Substring("二维码已保存：".Length);
            ShowFileInExplorer(dir + name);

            linkLabel1.Visible = false;
        }


        private void ShowFileInExplorer(string file)//在文件浏览器中显示指定的文件
        {
            if (File.Exists(file))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/e,/select, " + file);
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", "/e, " + file);
            }
        }

        public static String Save(Bitmap bmp)//图像返回文件名
        {
            String path = curDir() + "QR\\";
            checkDir(path);

            String name = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            if (!QRname.Equals(""))
            {
                name = QRname;
            }
            SaveImage(bmp, path + name);

            return name;
        }

        public static void SaveImage(Bitmap bmp, String filePath)//保存图片
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            bmp.Save(filePath, ImageFormat.Png);
        }

        private static string curDir()//获取当前运行路径
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void checkDir(string path)//检测目录是否存在，若不存在则创建
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkLabel1.Visible = true;
            if (picQR.Image != null)
            {
                Bitmap bmp = new Bitmap(picQR.Image);

                String filepath = Save(bmp);
                linkLabel1.Text = "二维码已保存：" + filepath;
            }
            else linkLabel1.Text = "";
        }

        private void 跳转二维码地址ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!txtURL.Text.Equals(""))
            {
                try
                {
                    System.Diagnostics.Process.Start(txtURL.Text);
                }
                catch(System.ComponentModel.Win32Exception)
                {
                    label2.Visible = true;
                    label2.Text= "链接地址错误，请输入正确的网址！";
                }
            }
        }
    }
}
