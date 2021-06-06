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

namespace _9_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //实例化一个打开文件对话框 
            OpenFileDialog op = new OpenFileDialog();
            //设置文件的类型 
            op.Filter = "JPG图片|*.jpg|GIF图片|*.gif";
            //如果用户点击了打开按钮，选择了正确的图片路径则进行如下操作： 
            if (op.ShowDialog() == DialogResult.OK)
            {
                //实例化一个文件流 
                FileStream f = new FileStream(op.FileName, FileMode.Open);
                //把文件读取到字节数组 
                byte[] data = new byte[f.Length];
                f.Read(data, 0, data.Length);
                f.Close();
                //实例化一个内存流并把从文件流中读取的字节数组放到内存流中去 
                MemoryStream ms = new MemoryStream(data);
                //设置图片框 pictureBox1中的图片 
                this.pictureBox1.Image = Image.FromStream(ms);
            }
        }
    }
}
