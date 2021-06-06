using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using GSJ_Descryption;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace 人事管理系统_GSJ
{
    public partial class Frm_reg : Form
    {
        public Frm_reg()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //检查输入内容
            if (txt_uid.Text.Trim() == string.Empty || txt_server.Text.Trim() == string.Empty )
            {
                MessageBox.Show("服务器或登录名不能为空!");
                return;
            }
            //实例化一个加密类对象
            try
            {
                GSJ_DESC myDesc = new GSJ_DESC("@gsj");

                RegistryKey CU_software = Registry.CurrentUser;
                RegistryKey softPWMS = CU_software.OpenSubKey(@"SoftWare", true);
                softPWMS.CreateSubKey("PWMS");
                RegistryKey serverStr = softPWMS.OpenSubKey("PWMS", true); //创建注册表键
                serverStr.SetValue("server", myDesc.Encry(txt_server.Text.Trim())); //加密后的服务器
                serverStr.SetValue("database", myDesc.Encry("db_PWMS_GSJ"));
                serverStr.SetValue("uid", myDesc.Encry(txt_uid.Text.Trim()));//加密后的登录名
                serverStr.SetValue("pwd", myDesc.Encry(txt_pwd.Text.Trim()));//加密后的密码
                serverStr.Close();
                MessageBox.Show("已修改成功,请重新登录!");
                this.Close();
            }
            catch 
            {

                this.Close();
            }
        }

        private void btn_test_Click(object sender, EventArgs e)//测试连接
        {
            try
            {
                SqlConnection scon = new SqlConnection(string.Format("server={0};database=db_PWMS_GSJ;uid={1};pwd={2}", txt_server.Text.Trim(), txt_uid.Text.Trim(), txt_pwd.Text.Trim()));
                scon.Open();
                scon.Dispose();
                btn_test.Text = "测试成功!";
            }
            catch 
            {

                MessageBox.Show("连接失败!");
            }
        }
    }
}