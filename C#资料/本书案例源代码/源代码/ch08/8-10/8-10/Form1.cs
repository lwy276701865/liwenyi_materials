using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ImageList = imageList1;
            tabPage1.ImageIndex = 0;   //设置选项卡的图标
            tabPage2.ImageIndex = 0;
            tabControl1.Appearance = TabAppearance.Buttons;   //将Appearance属性设置为Buttons，使得选项卡具有三维按钮外观
        }
    }
}
