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

namespace _9_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string  ct, la, lw, n, fn, dn, ir;
                long l;
                label1.Text = openFileDialog1.FileName;
                FileInfo f = new FileInfo(label1.Text);   //实例化
                n = f.Name;   //获取文件名
                ct = f.CreationTime.ToShortDateString();   //获取创建时间
                la = f.LastAccessTime.ToShortDateString();   //获取上次文件访问时间
                lw = f.LastWriteTime.ToShortDateString();   //获取上次写入文件时间
                fn = f.FullName;   //获取文件完整目录
                dn = f.DirectoryName;   //获取文件完整路径
                ir = f.IsReadOnly.ToString();   //获取文件是否为只读
                l = f.Length;   //获取文件的长度
                MessageBox.Show("此文件基本信息为：\n文件名：" + n + "\n创建时间：" + ct + "\n上次访问文件时间：" + la + "\n上次写入文件时间：" + lw + "\n文件完整目录：" + fn + "\n是否只读：" + ir + "\n文件长度：" + l);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
