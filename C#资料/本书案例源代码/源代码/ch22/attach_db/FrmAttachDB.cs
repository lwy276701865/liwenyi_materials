using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SqlClient;
using GSJ_Descryption;
using Microsoft.Win32;
namespace attach_db
{
    public partial class FrmAttachDB : Form
    {
        public FrmAttachDB()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            
            ////
             //检查输入内容
            if (txt0.Text.Trim() == string.Empty || txt1.Text.Trim() == string.Empty )
            {
                MessageBox.Show("服务器或登录名不能为空!");
                return;
            }
           
            ///
            groupBox1.Enabled = false;
            btn_start.Text = "正在附加......";
            try
            {
                string conStr = string.Format("server=.;database=master;uid={0};pwd={1}", txt1.Text.Trim(), txt2.Text.Trim());
                SqlConnection scon = new SqlConnection(conStr);
                scon.Open();
                string cmdStr = string.Format(@"exec sp_attach_db 'db_PWMS_GSJ' ,'{0}\db_PWMS_GSJ.mdf' ,'{1}\db_PWMS_GSJ_log.ldf'", Application.StartupPath, Application.StartupPath);
                SqlCommand scm = new SqlCommand(cmdStr, scon);
                scm.ExecuteNonQuery();
                scon.Dispose();
                //
                GSJ_DESC myDesc = new GSJ_DESC("@gsj"); //实例化一个加密类对象

                RegistryKey CU_software = Registry.CurrentUser;
                RegistryKey softPWMS = CU_software.OpenSubKey(@"SoftWare", true);
                softPWMS.CreateSubKey("PWMS");
                RegistryKey serverStr = softPWMS.OpenSubKey("PWMS", true); //创建注册表键
                serverStr.SetValue("server", myDesc.Encry(txt0.Text.Trim())); //加密后的服务器
                serverStr.SetValue("database", myDesc.Encry("db_PWMS_GSJ"));
                serverStr.SetValue("uid", myDesc.Encry(txt1.Text.Trim()));//加密后的登录名
                serverStr.SetValue("pwd", myDesc.Encry(txt2.Text.Trim()));//加密后的密码
                serverStr.Close();
                //
                MessageBox.Show("附加成功！");
                this.Close();
            }
            catch 
            {

                MessageBox.Show("执行时出错，请手动附加！");
                this.Close();
            }
            
        }

        
    }
}