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

namespace _11_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conStudent;   //连接对象
        SqlCommand cmdStudent;   //执行SQL语句对象
        SqlDataReader dtrStudent;   //读取数据对象
        /// <summary>
        /// 清空所有的文本框的内容
        /// </summary>
        void ContentClear()
        {
            Control.ControlCollection TxtObj = this.Controls;   //获取窗体的控件
            foreach (Control C in TxtObj)
            {
                if (C.GetType().Name == "TextBox")   //判断控件是否为TextBox
                {
                    C.Text = string.Empty;   //将所有文本框内容清空
                }
            }
            textBox1.Focus();
        }
        /// <summary>
        /// 根据班级名称获取班级编号
        /// </summary>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        string GetClassId(string className)
        {
            string cmdStr = "select classId from class where className='" + className + "'";
            cmdStudent = new SqlCommand(cmdStr, conStudent);
            conStudent.Open();
            string Id = Convert.ToString(cmdStudent.ExecuteScalar());
            conStudent.Close();
            return Id;
        }
        /// <summary>
        /// 判断用户编号是否存在
        /// </summary>
        /// <param name="stuId">学生编号</param>
        /// <returns></returns>
        bool IsExists(string stuId)
        {
            string CmdStr = string.Format("select count(*) from student where stuId='{0}'", stuId);
            cmdStudent = new SqlCommand(CmdStr, conStudent);
            conStudent.Open();
            int Count = Convert.ToInt32(cmdStudent.ExecuteScalar());
            conStudent.Close();
            if (Count == 0)
            {
                return true;
            }
            return false;
        }
        //【添加】按钮单击事件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Number = textBox1.Text.Trim();   //学号
                string Name = textBox2.Text.Trim();   //姓名
                string Sex = comboBox1.Text;   //性别
                string ClassName = comboBox2.Text;   //班级名称
                float Score = Convert.ToSingle(textBox3.Text.Trim());   //成绩
                string Telephone = textBox4.Text.Trim();   //电话
                string Address = textBox5.Text.Trim();   //通讯地址
                string cmdStr = string.Format("insert into student values('{0}','{1}','{2}','{3}',{4},'{5}','{6}')", Number, Name, Sex, GetClassId(ClassName), Score, Telephone, Address);
                cmdStudent = new SqlCommand(cmdStr, conStudent);
                conStudent.Open();
                int count = cmdStudent.ExecuteNonQuery();
                conStudent.Close();
                if (count > 0)
                {
                    MessageBox.Show("添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ContentClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();   //获取光标
            //为性别组合框添加选项内容
            comboBox1.Items.Add("男");
            comboBox1.Items.Add("女");
            comboBox1.SelectedIndex = 0;   //默认选择项为第一项
            //为班级组合框添加选项内容
            try
            {
                string conStr = "server=.;database=student;uid=sa;pwd=sa;";
                conStudent = new SqlConnection(conStr);
                string cmdStr = "select className from class";
                cmdStudent = new SqlCommand(cmdStr, conStudent);
                conStudent.Open();
                dtrStudent = cmdStudent.ExecuteReader();
                while (dtrStudent.Read())
                {
                    comboBox2.Items.Add(dtrStudent["className"].ToString());
                }
                comboBox2.SelectedIndex = 0; //默认选择项为第一项
                dtrStudent.Close(); //关闭读取流
                conStudent.Close(); //关闭数据库
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //学号文本框失去焦点事件
        private void textBox1_Leave(object sender, EventArgs e)
        {
            string Number = textBox1.Text.Trim();   //学号    
            if (Number == string.Empty)
            {
                MessageBox.Show("学号不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (!IsExists(Number))
            {
                MessageBox.Show("学号已经存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.SelectAll();
                textBox1.Focus();
                return;
            }
        }
        //【重置】按钮单击事件
        private void button2_Click(object sender, EventArgs e)
        {
            ContentClear();   //调用清空方法
        }
    }
}
