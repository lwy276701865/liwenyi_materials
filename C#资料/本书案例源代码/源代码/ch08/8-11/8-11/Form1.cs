using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_11
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
            tabControl1.Appearance = TabAppearance.Buttons;   //将Appearance属性设置为Buttons，使得
                                                              //选项卡具有三维按钮外观
            Button b = new Button();   //实例化一个button按钮
            b.Text = "测试";
            tabPage1.Controls.Add(b);   //使用Controls属性Add方法将按钮添加到tabPage1中
            string tp3 = "tabPage3";   //新的选项卡名称
            TabPage t = new TabPage(tp3);   //实例化tabPage
            tabControl1.TabPages.Add(t);   //使用TabPages属性的Add方法添加新的选项卡
            tabControl1.SizeMode=TabSizeMode.Fixed;   //设置选项卡的尺寸为Fixed
        }
    }
}
