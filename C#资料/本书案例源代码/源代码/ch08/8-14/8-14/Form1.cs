using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();

            s.InitialDirectory = @"E:\";   //对话框初始路径   

            s.FileName = "测试.txt";   //默认保存的文件名   

            s.Filter = "C#文件(*.cs)|*.cs|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";

            s.FilterIndex = 2;   //默认就选择在文本文件(*.txt)过滤条件上   

            s.DefaultExt = ".xml";   //默认保存类型，如果过滤条件选"所有文件(*.*)"且保存名没写后缀，则补充上该默认值   

            s.DereferenceLinks = false;   //返回快捷方式的路径而不是快捷方式映射的文件的路径   

            s.Title = "保存对话框";

            s.RestoreDirectory = true;   //每次打开都回到InitialDirectory设置的初始路径   

            s.ShowHelp = true;   //对话框"帮助"按钮   

            s.HelpRequest += new EventHandler(s_HelpRequest);   //注册帮助按钮的事件     

            if (s.ShowDialog() == DialogResult.OK)  
            {
                string filePath = s.FileName;   //文件路径   
            }
        }
        private void s_HelpRequest(object sender, EventArgs e)   //帮助说明内容
        {
            MessageBox.Show("这是帮助说明");
        }
    }
}
