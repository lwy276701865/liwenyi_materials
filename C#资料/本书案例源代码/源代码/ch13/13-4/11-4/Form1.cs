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

namespace _11_4
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
        }
    }
}
