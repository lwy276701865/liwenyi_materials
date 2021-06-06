using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;   //设置View属性
            listView1.Groups.Add(new ListViewGroup("姓名", HorizontalAlignment.Left));   //建立两个分组
            listView1.Groups.Add(new ListViewGroup("性别", HorizontalAlignment.Left));
            listView1.Items.Add("张三");   //添加项目
            listView1.Items.Add("李四");
            listView1.Items.Add("18");
            listView1.Items.Add("19");
            listView1.Items[0].Group = listView1.Groups[0];   //将索引为0和1的项添加到1分组
            listView1.Items[1].Group = listView1.Groups[0];
            listView1.Items[2].Group = listView1.Groups[1];   //将索引为2和3的项添加到2分组
            listView1.Items[3].Group = listView1.Groups[1];
        }
    }
}
