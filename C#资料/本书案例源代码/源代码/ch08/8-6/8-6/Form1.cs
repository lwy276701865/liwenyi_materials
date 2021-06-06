using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode f1 = treeView1.Nodes.Add("姓名");   //建立3个父节点
            TreeNode f2 = treeView1.Nodes.Add("学院");
            TreeNode f3 = treeView1.Nodes.Add("班级");
            TreeNode z1 = new TreeNode("张三");   //建立子节点
            TreeNode z2 = new TreeNode("李四");
            f1.Nodes.Add(z1);   //将子节点添加到f1父节点中
            f1.Nodes.Add(z2);
            TreeNode z3 = new TreeNode("信息工程");   //建立子节点
            TreeNode z4 = new TreeNode("语言文化");
            f2.Nodes.Add(z3);   //将子节点添加到f2父节点中
            f2.Nodes.Add(z4);
            TreeNode z5 = new TreeNode("计算机2班");   //建立子节点
            TreeNode z6 = new TreeNode("外语系3班");
            f3.Nodes.Add(z5);   //将子节点添加到f3父节点中
            f3.Nodes.Add(z6);
        }
    }
}
