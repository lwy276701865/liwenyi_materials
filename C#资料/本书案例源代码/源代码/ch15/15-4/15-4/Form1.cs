using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace _15_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置richTextBox1不可编辑
            richTextBox1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //判断IP地址是否为空
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入有效网址！");
            }
            else
            {
                //声明一个string变量，保存从WebClint下载数据
                string s = "";
                //实例化WebClient对象
                WebClient w = new WebClient();
                //设置WebClient基URI
                w.BaseAddress = textBox1.Text;
                //指定下载的字符串为UTF8编码
                w.Encoding = Encoding.UTF8;
                //添加报头
                w.Headers.Add("Content-Type", "application/x-www-from-urlencoded");
                //打开一个可读流
                Stream st = w.OpenRead(textBox1.Text);
                //实例化StreamReader
                StreamReader sr = new StreamReader(st);
                //从网页获取数据
                while((s=sr.ReadLine())!=null)
                {
                    richTextBox1.Text += s + "\n";
                }
                //使用DownloadFile将网页内容保存
                w.DownloadFile(textBox1.Text, DateTime.Now.ToFileTime() + ".txt");
                MessageBox.Show("文件保存成功！");
            }
        }
    }
}
