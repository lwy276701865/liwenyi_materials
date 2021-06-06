using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")   //判断文本框是否有内容，没有就弹出警告
            {
                MessageBox.Show("内容不得为空");
            }
            else
            {
                listView1.Items.Add(textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count==0)   //判断是否选择内容
            {
                MessageBox.Show("请选择想要删除的内容");
            }
            else
            {
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);   //删除所选内容
                listView1.SelectedItems.Clear();   //取消控件选择
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)   //判断ListView中是否存在内容，没有就会警告
            {
                MessageBox.Show("内容为空");
            }
            else
            {
                listView1.Items.Clear();   //清空内容
            }
        }
    }
}
