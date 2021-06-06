using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();

            fb.RootFolder = Environment.SpecialFolder.Desktop;   //设置默认根目录是桌面   

            fb.Description = "请选择文件的目录:";    //设置对话框说明   

            if (fb.ShowDialog() == DialogResult.OK)
            {
                string filePath = fb.SelectedPath;
            }
        }
    }
}
