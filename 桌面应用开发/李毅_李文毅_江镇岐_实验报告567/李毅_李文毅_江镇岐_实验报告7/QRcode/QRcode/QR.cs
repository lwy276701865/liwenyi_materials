using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QRcode
{
    static class QR
    {
        [STAThread]
        static void Main(String[] args)
        {
            args = PreAnalyseParams(args);//参数预解析

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QR());

            DependentFiles.LoadResourceDll();//载入资源dll文件

            if (args != null && args.Length > 0)//生成参数对应二维码
            {
                foreach (String arg in args)
                {
                    Bitmap pic = frmQR.TxtToQR(arg);//生成二维码
                    frmQR.Save(pic);//保存图像
                }
            }
            else Application.Run(new frmQR());
        }

        private static string[] PreAnalyseParams(string[] args)
        {
            List<string> lst = new List<string>();

            if (args != null && args.Length > 0)//生成参数对应二维码
            {
                foreach (String arg0 in args)
                {
                    String arg = arg0.Trim();
                    if (arg.StartsWith("QRname=")) frmQR.QRname = arg.Substring("QRname=".Length);
                    else lst.Add(arg);
                }
            }
            return lst.ToArray();
        }
    }
}
