using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_12
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tp = "tabPage"+(tabControl1.TabCount+1).ToString();   //新的选项卡名称
            TabPage t = new TabPage(tp);   //实例化tabPage
            tabControl1.TabPages.Add(t);   //使用TabPages属性的Add方法添加新的选项卡
            tabControl1.SizeMode = TabSizeMode.Fixed;   //设置选项卡的尺寸为Fixed
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)   //判断是否选择选项卡
            {
                MessageBox.Show("请选择需要删除的选项卡");
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);   //将选择的选项卡删除
            }
        }
    }
}
