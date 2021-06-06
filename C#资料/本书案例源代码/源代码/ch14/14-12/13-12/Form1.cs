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

namespace _13_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //定义SqlConnection用于数据库连接
        SqlConnection Conn;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //建立数据库连接
                Conn = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True");
                string StrSelectPerson = "";
                //获取选项
                if (radioButton1.Checked)
                {
                    StrSelectPerson = radioButton1.Text;
                }
                if (radioButton2.Checked)
                {
                    StrSelectPerson = radioButton2.Text;
                }
                if (radioButton3.Checked)
                {
                    StrSelectPerson = radioButton3.Text;
                }
                if (radioButton4.Checked)
                {
                    StrSelectPerson = radioButton4.Text;
                }
                //修改数据库
                string SqlStr = "update GDI set num=num+1 where person='" + StrSelectPerson + "'";
                Conn.Open();
                //执行更新数据库操作
                SqlCommand Cmd = new SqlCommand(SqlStr, Conn);
                //返回投票操作
                int i = (int)Cmd.ExecuteNonQuery();
                Conn.Close();
                if (i > 0)
                {
                    MessageBox.Show("感谢 你对【" + StrSelectPerson + "】投票成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //打开Form2窗体
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
