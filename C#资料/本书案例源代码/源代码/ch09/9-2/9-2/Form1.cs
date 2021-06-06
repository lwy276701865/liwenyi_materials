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

namespace _9_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")   //检查是否输入名称
            {
                MessageBox.Show("请输入文件夹名称");
            }
            else
            {
                if(Directory.Exists(textBox1.Text))
                {
                    MessageBox.Show("该文件夹已存在，请重新输入");   //检查是否重名
                }
                else
                {
                    Directory.CreateDirectory(textBox1.Text);   //使用CreateDirectory方法创建文件夹
                }
            }
        }
    }
}
