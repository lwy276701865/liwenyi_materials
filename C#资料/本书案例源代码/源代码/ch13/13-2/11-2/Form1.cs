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

namespace _11_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //使用try...catch语句用于返回代码区异常
            try
            {
                //创建数据库连接并打开
                string ConString = "server=.;database=test;uid=sa;pwd=sa;";
                SqlConnection ConStudent = new SqlConnection(ConString);
                string CmdString = string.Format("select * from Student where StudentName like '%{0}%'", textBox1.Text.Trim());
                SqlCommand cmdStudent = new SqlCommand(CmdString, ConStudent);
                ConStudent.Open();
                //创建读取对象SqlDataReader
                SqlDataReader dtrStudent = cmdStudent.ExecuteReader();
                textBox2.Text = "  学号\t\t姓名\t性别\t专业\r\n";
                //使用HasRows属性判断数读取的dtrStudent对象中是否有数据
                if (dtrStudent.HasRows)
                {
                    //从dtrStudent中一条一条读取数据
                    while (dtrStudent.Read())
                    {
                        textBox2.Text += string.Format("  {0}\t{1}\t{2}\t{3}\t\r\n", dtrStudent[0].ToString(), dtrStudent[1].ToString(), dtrStudent[2].ToString(), dtrStudent[3].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("查无此人！");
                }
                dtrStudent.Close();
                ConStudent.Close();
            }
            //返回异常
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
