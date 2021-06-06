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

namespace _9_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入写入内容！");
            }
            else
            {
                saveFileDialog1.Filter = "二进制文件(*.bmp)|*.bmp";   //设置文件保存格式
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //实例化FileStream对象，文件名为“另存为”对话框中输入的名称
                    FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate,FileAccess.ReadWrite);
                    BinaryWriter w = new BinaryWriter(f);   //实例化BinaryWriter二进制写入流对象
                    w.Write(textBox1.Text);   //写入内容
                    w.Close();   //关闭二进制写入流
                    f.Close();   //关闭文件流
                    textBox1.Clear();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二进制文件(*.bmp)|*.bmp";   //设置文件打开格式
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //实例化StreamReader对象，文件名为“打开”对话框所选文件名
                FileStream f = new FileStream(openFileDialog1.FileName,FileMode.Open,FileAccess.Read);
                BinaryReader r = new BinaryReader(f);   //实例化BinaryReader二进制写入流对象
                if(r.BaseStream.Position < r.BaseStream.Length)
                {
                    textBox1.Text = Convert.ToString(r.ReadUInt32());   //用二进制方式读取文件内容
                }
                r.Close();   //关闭读取流
                f.Close();   //关闭文件流
            }
        }
    }
}
