using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.InitialDirectory = @"E:\";   //对话框初始路径   

            op.Filter = "C#文件(*.cs)|*.cs|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";

            op.FilterIndex = 2;   //默认就选择在文本文件(*.txt)过滤条件上   

            op.DereferenceLinks = false;   //返回快捷方式的路径而不是快捷方式映射的文件的路径   

            op.Title = "打开对话框实例";

            op.RestoreDirectory = true;   //每次打开都回到InitialDirectory设置的初始路径   

            op.ShowHelp = true;   //对话框多了个"帮助"按钮   

            op.ShowReadOnly = true;   //对话框多了"只读打开"的复选框   

            op.ReadOnlyChecked = true;   //默认"只读打开"复选框勾选   

            op.HelpRequest += new EventHandler(op_HelpRequest);   //注册帮助按钮的事件   
 
            if (op.ShowDialog() == DialogResult.OK)
            {
                string filePath = op.FileName;   //文件路径   

                string fileName = op.SafeFileName;  //文件名   
            }
        } 
        private void op_HelpRequest(object sender, EventArgs e)   //帮助说明内容
        {
            MessageBox.Show("这是帮助说明");
        }
    }
}
