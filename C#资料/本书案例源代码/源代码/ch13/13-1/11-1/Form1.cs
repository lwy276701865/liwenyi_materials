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

namespace _11_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection contest;   //连接数据库对象
        SqlCommand cmdLoginOP;  //执行SQL命令对象
        string cmdString;   //Sql语句字符串
        //判断指定的用户名是否存在，如果存在返回true，否则返回false
        bool IsExist(string Name)
        {
            string str = string.Format("select count(*) from Table_2 where Name='{0}'", Name);
            cmdLoginOP = new SqlCommand(str, contest);
            contest.Open();
            int count = Convert.ToInt32(cmdLoginOP.ExecuteScalar());    //查询该用户名的个数
            contest.Close();
            if (count != 0)
            {
                return true;
            }
            return false;
        }
        //执行Sql命令，执行成功返回true，否则返回false
        bool GetSqlCmd(string CmdStr)
        {
            cmdLoginOP = new SqlCommand(CmdStr, contest);
            contest.Open();
            int count = cmdLoginOP.ExecuteNonQuery();   //执行SQL命令并返回受影响行数
            contest.Close();
            if (count != 0)
            {
                return true;
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string ConString = "server=.;database=test;uid=sa;pwd=sa;";
            contest = new SqlConnection(ConString);
        }
        //选项卡选择页面更改事件执行代码
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                gropbox1.Parent = tabControl1.TabPages[0];  //将组中对象放入第1个页面
            }
            if (tabControl1.SelectedIndex == 1)
            {
                gropbox1.Parent = tabControl1.TabPages[1];  //将组中对象放入第2个页面
            }
        }
        //保存按钮单击事件执行代码
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("用户名和密码不能为空！");
                return; //中止该方法
            }
            string StuName = textBox1.Text.Trim();
            string StuPass = textBox2.Text.Trim();
            if (tabControl1.SelectedIndex == 0)    //组合框内的控件在添加页面
            {
                cmdString = string.Format("insert into Table_2 values('{0}','{1}')", StuName, StuPass);
                if (IsExist(StuName))
                {
                    MessageBox.Show("对不起，该用户名已经存在");
                }
                else
                {
                    if (GetSqlCmd(cmdString))
                    {
                        MessageBox.Show("添加用户成功！");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();    //获取光标
                    }
                }
            }
            if (tabControl1.SelectedIndex == 1)    //组合框内的控件在修改页面
            {
                cmdString = string.Format("update Table_2 set Name='{0}',Pass='{1}' where Name='{0}'", StuName, StuPass);
                if (!IsExist(StuName))
                {
                    MessageBox.Show("对不起，修改的用户名不存在");
                }
                else
                {
                    if (GetSqlCmd(cmdString))
                    {
                        MessageBox.Show("修改用户成功！");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();    //获取光标
                    }
                }
            }
        }
        //退出按钮单击事件执行代码
        private void button2_Click(object sender, EventArgs e)
        {
            contest.Dispose();
            this.Close();
        }
        //删除按钮单击事件执行代码
        private void button3_Click(object sender, EventArgs e)
        {
            string StuName = textBox3.Text.Trim();
            cmdString = string.Format("delete Table_2 where Name='{0}'", StuName);
            if (!IsExist(StuName))
            {
                MessageBox.Show("对不起，该用户不存在");
            }
            else
            {
                if (GetSqlCmd(cmdString))
                {
                    MessageBox.Show("删除用户成功！");
                    textBox3.Text = "";
                    textBox3.Focus(); //获取光标
                }
            }
        }
    }
}
