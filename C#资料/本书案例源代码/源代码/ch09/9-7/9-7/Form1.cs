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

namespace _9_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("请输入写入内容！");
            }
            else
            {
                saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";   //设置文件保存格式
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    StreamWriter w = new StreamWriter(saveFileDialog1.FileName, true);   //实例化StreamWriter对象，文件名为“另存为”对话框中输入的名称
                    w.WriteLine(textBox1.Text);   //写入内容
                    w.Close();   //关闭写入流
                    textBox1.Clear();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";   //设置文件打开格式
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = string.Empty;
                StreamReader r = new StreamReader(openFileDialog1.FileName);   //实例化StreamReader对象，文件名为“打开”对话框所选文件名
                textBox1.Text = r.ReadToEnd();   //使用ReadToEnd方法读取内容
                r.Close();   //关闭读取流
            }
        }
    }
}
