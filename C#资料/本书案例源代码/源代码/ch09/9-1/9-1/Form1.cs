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

namespace _9_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")   //文件名称不能为空
            {
                MessageBox.Show("文件名称不得为空");
            }
            else
            {
                if(File.Exists(textBox1.Text))   //使用Exists方法判断文件是否已存在
                {
                    MessageBox.Show("该文件已存在，请重新命名");
                }
                else
                {
                    File.Create(textBox1.Text);   //使用Create方法创建文件
                }
            }
        }
    }
}
