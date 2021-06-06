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

namespace _9_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();   //清空listView1
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(label1.Text);   //实例化DirectoryInfo
                FileSystemInfo[] f = d.GetFileSystemInfos();   //获取指定文件夹中子文件夹和文件
                foreach(FileSystemInfo fs in f)
                {
                    if (fs is DirectoryInfo)   //判断遍历出的是否为文件夹
                    {
                        DirectoryInfo di = new DirectoryInfo(fs.FullName);   //实例化DirectoryInfo并获取文件夹名
                        listView1.Items.Add(di.Name);   //获取名称并添加到listView1中
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.FullName);   //获取路径
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.CreationTime.ToShortDateString());   //获取创建时间
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(fs.FullName);   //实例化FileInfo并获取文件名
                        listView1.Items.Add(fi.Name);   //获取名称
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fi.FullName);   //获取路径
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fi.CreationTime.ToShortDateString());   //获取创建时间
                    }
                }
            }
        }
    }
}
