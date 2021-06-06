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

namespace _9_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")   //检查是否输入名称
            {
                MessageBox.Show("请输入文件夹名称");
            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(textBox1.Text);   //实例化DirectoryInfo类对象
                if (d.Exists)
                {
                    MessageBox.Show("该文件夹已存在，请重新输入");   //检查是否重名
                }
                else
                {
                    d.Create();   //使用Create方法创建文件夹
                }
            }
        }
    }
}
