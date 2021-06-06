using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using GSJ_Descryption;
namespace 人事管理系统_GSJ
{
    public partial class Frm_JiaYongHu : Form
    {
        public Frm_JiaYongHu()
        {
            InitializeComponent();
        }
        private string uidStr = "";//当前要操作的用户名,添加新用户时此项为空

        public string UidStr
        {
            get { return uidStr; }
            set { uidStr = value; }
        }
        private string pwdStr = "";//当前要操作的密码,添加新用户时此项为空

        public string PwdStr
        {
            get { return pwdStr; }
            set { pwdStr = value; }
        }
        private bool isAdd = true;//判断是添加还是修改  

        public bool IsAdd
        {
            get { return isAdd; }
            set { isAdd = value; }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            #region 验证输入内容
            if (text_Name.Text.Trim() == string.Empty || text_Pass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户名和密码不允许为空!");
                text_Name.Focus();
                return;

            }
            if (txt_Pwd2.Text != text_Pass.Text)
            {
                MessageBox.Show("密码不一致,请重新填写!");
                txt_Pwd2.Text = text_Pass.Text = string.Empty;
                text_Pass.Focus();
                return;
            }
            #endregion
            #region 用户登录名加密
            GSJ_DESC myDesc = new GSJ_DESC("@gsj");
            string descryUser = myDesc.Encry(text_Name.Text.Trim());//加密后的用户名
            string descryPwd = myDesc.Encry(text_Pass.Text.Trim());//加密后的密码
            #endregion
            if (IsAdd) //添加用户时检查是否已存在 
            {
                #region 验证是否已存在此用户

                string sql = "select count(*) from tb_Login where Uid='" + descryUser + "'";
                try
                {
                    MyDBControls.GetConn();//打开连接
                    if (Convert.ToInt32(MyDBControls.ExecSca(sql)) > 0) //检查是否存在
                    {
                        MessageBox.Show("已存在此用户!");
                        text_Name.Text = string.Empty; //清空
                        text_Name.Focus(); //获得焦点
                        return;
                    }
                    MyDBControls.CloseConn();//关闭连接
                }
                catch 
                {

                   
                    return; //出错时不再往下执行
                }

                #endregion
                #region 添加用户
                //添加用户名\密码
                string addUser = "insert into tb_Login values('" + descryUser + "','" + descryPwd + "')";
                string popeModel = "select popeName from tb_popeModel";//检查权限模块
                DataSet popeDS;
                try
                {
                    MyDBControls.GetConn(); //打开连接
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(addUser)) > 0) //执行添加
                    {
                        
                        popeDS = MyDBControls.GetDataSet(popeModel);
                        for (int i = 0; i < popeDS.Tables[0].Rows.Count; i++)
                        { //逐一添加权限
                            string popeSql = "insert into tb_UserPope values('"+descryUser+"','" + popeDS.Tables[0].Rows[i][0].ToString() + "',"+0+")";
                            //MessageBox.Show(popeSql);
                            MyDBControls.ExecNonQuery(popeSql);
                        }
                    }
                    
                    MyDBControls.CloseConn();//关闭连接
                    text_Name.Text = text_Pass.Text = txt_Pwd2.Text = string.Empty; //清空
                    MessageBox.Show("添加成功!");
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                    {
                        MessageBox.Show("输入内容长度不合法,最大长度为20位字母或10个汉字!");
                        
                        return;
                    }
                    
                }
                #endregion
            }
            else //修改用户时
            {
                #region 修改用户信息
                //修改语句
                string updSql = "update tb_Login set Uid='" + descryUser + "',Pwd='" + descryUser + "'  where Uid='" + UidStr + "'";
                try
                {
                    MyDBControls.GetConn(); //打开连接
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(updSql)) > 0) //执行修改
                    {
                        text_Name.Text = text_Pass.Text = txt_Pwd2.Text = string.Empty; //清空
                        MessageBox.Show("修改成功!");
                    }
                    MyDBControls.CloseConn();//关闭连接
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                    {
                        MessageBox.Show("输入内容长度不合法,最大长度为20位字母或10个汉字!");
                       
                        return;
                    }
                    
                }
                #endregion
            }
            this.Close();
        }

        private void Frm_JiaYongHu_Load(object sender, EventArgs e)
        {
            text_Name.Text = UidStr; //填充用户名和密码  
            txt_Pwd2.Text = text_Pass.Text = PwdStr;

            //修改时用户名为只读
            if (!IsAdd) text_Name.ReadOnly = true;
            
        }
       
    }
}