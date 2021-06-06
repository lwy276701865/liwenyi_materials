using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
//
using System.Data;
using System.Data.SqlClient;
using GSJ_Descryption;
using Microsoft.Win32;
using System.Windows.Forms;
namespace 人事管理系统_GSJ.InstallerClass
{
    [RunInstaller(true)]
    public partial class PWMS_GSJ_Installer : Installer
    {
        public PWMS_GSJ_Installer()
        {
            InitializeComponent();
            
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            
            //
            //try
            //{
            //    string conStr = string.Format("server=.;database=master;uid={0};pwd={1}", Context.Parameters["UID"].ToString(), Context.Parameters["PWD"].ToString());
            //    SqlConnection scon = new SqlConnection(conStr);
            //    scon.Open();
            //    string cmdStr = string.Format(@"exec sp_attach_db 'db_PWMS_GSJ' ,'{0}\db_PWMS_GSJ.mdf' ,'{1}\db_PWMS_GSJ_log.ldf'",Application.StartupPath, Application.StartupPath);
            //    SqlCommand scm = new SqlCommand(cmdStr, scon);
            //    scm.ExecuteNonQuery();
            //    scon.Dispose();
            //    //
            //    GSJ_DESC myDesc = new GSJ_DESC("@gsj"); //实例化一个加密类对象

            //    RegistryKey CU_software = Registry.CurrentUser;
            //    RegistryKey softPWMS = CU_software.OpenSubKey(@"SoftWare", true);
            //    softPWMS.CreateSubKey("PWMS");
            //    RegistryKey serverStr = softPWMS.OpenSubKey("PWMS", true); //创建注册表键
            //    serverStr.SetValue("server", myDesc.Encry(".")); //加密后的服务器
            //    serverStr.SetValue("database", myDesc.Encry("db_PWMS_GSJ"));
            //    serverStr.SetValue("uid", myDesc.Encry(Context.Parameters["UID"].ToString()));//加密后的登录名
            //    serverStr.SetValue("pwd", myDesc.Encry(Context.Parameters["PWD"].ToString()));//加密后的密码
            //    serverStr.Close();
            //    //
            //    MessageBox.Show("附加成功！");

            //}
            //catch(Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //    MessageBox.Show("执行时出错，请重新安装！");
            //    Rollback(stateSaver);

            //}
            //
        }
       
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
           
            base.Uninstall(savedState);
            
        }
        protected override void OnAfterInstall(System.Collections.IDictionary savedState)//安装后调用数据库附加
        {
            base.OnAfterInstall(savedState);
            try
            {
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\企业人事管理系统\\attach_db.exe");

            }
            catch 
            {
                
                
            }
        }
        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)//卸载前分离数据库
        {
            string ConnectionString = "server=";
            GSJ_DESC myDesc = new GSJ_DESC("@gsj");//实例化加/解密对象
            //读取数据库的连接字符
            RegistryKey CU_software = Registry.CurrentUser;
            RegistryKey softPWMS = CU_software.OpenSubKey(@"SoftWare\PWMS");
            ConnectionString += myDesc.Decry(softPWMS.GetValue("server").ToString()) + ";";
            ConnectionString += "database=master;uid=";
            ConnectionString += myDesc.Decry(softPWMS.GetValue("uid").ToString()) + ";";
            ConnectionString += "pwd=";
            ConnectionString += myDesc.Decry(softPWMS.GetValue("pwd").ToString());
            SqlConnection Conn = new SqlConnection(ConnectionString);
            try
            {
                Conn.Open();
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = @"sp_detach_db db_PWMS_GSJ";
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.ExecuteNonQuery();

                MessageBox.Show("分离数据库成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }

            base.OnBeforeUninstall(savedState);
        }
    }


}