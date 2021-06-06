using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Microsoft.Win32;
using GSJ_Descryption;

namespace 人事管理系统_GSJ
{
    public partial class FrmLoad : Form
    {
        public FrmLoad()
        {
            InitializeComponent();
        }
        private void DoValidated() //验证登陆
        {
            #region 验证输入有效性
            if (txt_Name.Text == string.Empty)
            {
                MessageBox.Show("用户名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_Pwd.Text == string.Empty)
            {
                MessageBox.Show("密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 连接数据库验证用户是否合法并处理异常

            GSJ_DESC myDesc = new GSJ_DESC("@gsj");//实例化加/解密对象
            

            //Sql语句                                                                                     //加密后的用户名                   //加密后的密码
            string P_sqlStr = string.Format("select count(*) from tb_Login where Uid='{0}' and Pwd='{1}'",myDesc.Encry(txt_Name.Text.Trim()),myDesc.Encry(txt_Pwd.Text.Trim()));
            try
            {


                
                //读取数据库的连接字符
                RegistryKey CU_software = Registry.CurrentUser;
                RegistryKey softPWMS = CU_software.OpenSubKey(@"SoftWare\PWMS");
                MyDBControls.Server = myDesc.Decry(softPWMS.GetValue("server").ToString());
                MyDBControls.Uid = myDesc.Decry(softPWMS.GetValue("uid").ToString());
                MyDBControls.Pwd = myDesc.Decry(softPWMS.GetValue("pwd").ToString());
                //MessageBox.Show(MyDBControls.Server + MyDBControls.Uid + MyDBControls.Pwd);


                MyDBControls.GetConn();//打开连接
                if (Convert.ToInt32(MyDBControls.ExecSca(P_sqlStr)) != 0)//判断是否为合法用户
                {
                    FrmMain.P_currentUserName = txt_Name.Text;
                    FrmMain.P_isSucessLoad = true;
                    P_needValite = false;//不需确认直接关闭
                    //记录此次登录
                    
                    //
                    this.Close(); //登陆成功关闭本窗体
                }
                else
                {
                    MessageBox.Show("用户名或密码错误,请重新输入!");
                    //清空原有内容
                    txt_Name.Text = string.Empty;
                    txt_Pwd.Text = string.Empty;
                    //用户名获得焦点
                    txt_Name.Focus();
                }
                MyDBControls.CloseConn();//关闭连接
            }
            catch //数据库连接失败时
            {

                if (DialogResult.Yes == MessageBox.Show("数据库连接失败,程序不能启动!\n是否重新注册?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    Frm_reg frmReg = new Frm_reg();//显示注册窗体
                    frmReg.ShowDialog();
                    frmReg.Dispose();
                }
                else
                {
                    Application.ExitThread();
                }
               
               
            }
            #endregion
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {

            DoValidated();//验证登陆
        }

        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//光标换到下一行
            {
                txt_Pwd.Focus();
            }
        }

        private void txt_Pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') 
            {
                DoValidated();//验证登陆
            }
        }
        bool P_needValite = true;//关闭窗体时是否需确认
        private void FrmLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (P_needValite)//没成功登陆而关闭
            {
                //确认取消登陆
                DialogResult dr = MessageBox.Show("确认取消登陆吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Cancel) //当选择取消时不执行操作
                {
                    e.Cancel = true;
                }
                else //退出程序
                {

                    Application.ExitThread();
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}