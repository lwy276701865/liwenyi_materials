using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _11_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接到数据库
            string conString = "server=DESKTOP-D5KF15E;database=test;uid=sa;pwd=sa;";
            SqlConnection conn = new SqlConnection(conString);
            //创建SqlDataAdapter对象s
            SqlDataAdapter s = new SqlDataAdapter("Select * from Table_1", conn);
            //创建DataSet对象d
            DataSet d = new DataSet();
            //使用Fill方法填充DataSet
            s.Fill(d, "t");
            //在dataGridView1控件中显示表t
            dataGridView1.DataSource = d.Tables["t"];
            //设置SelectionMode属性，使得控件可以整行选择
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //设置控件只读
            dataGridView1.ReadOnly = true;
            //设置选中行背景色为红
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
        }
    }
}
