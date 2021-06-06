using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Text.RegularExpressions;
namespace 人事管理系统_GSJ
{
    
    public partial class Frm_TongXun : Form
    {
        public Frm_TongXun()
        {
            InitializeComponent();
        }
        #region 修改时使用的属性
        string addStr1="";//姓名

        public string AddStr1
        {
            get { return addStr1; }
            set { addStr1 = value; }
        }
        string addStr2="男";//性别

        public string AddStr2
        {
            get { return addStr2; }
            set { addStr2 = value; }
        }
        string addStr3;//家庭电话

        public string AddStr3
        {
            get { return addStr3; }
            set { addStr3 = value; }
        }
        string addStr4;//QQ

        public string AddStr4
        {
            get { return addStr4; }
            set { addStr4 = value; }
        }
        string addStr5;//工作电话

        public string AddStr5
        {
            get { return addStr5; }
            set { addStr5 = value; }
        }
        string addStr6;//E-Mail

        public string AddStr6
        {
            get { return addStr6; }
            set { addStr6 = value; }
        }
        string addStr7;//手机

        public string AddStr7
        {
            get { return addStr7; }
            set { addStr7 = value; }
        }
        #endregion
        private void Frm_TongXun_Load(object sender, EventArgs e)
        {
           
            //修改时自动赋值
            Address_1.Text = AddStr1;
            Address_2.Text = AddStr2;
            Address_3.Text = AddStr3;
            Address_4.Text = AddStr7;
            Address_5.Text = AddStr5;
            Address_6.Text = AddStr4;
            Address_7.Text = AddStr6;
            //
            if (addStr1 != string.Empty)
            {
                btn_save.Text = "修改";
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool DoValit()//todo:验证输入内容
        { 
            //用户名
            if (Address_1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户名不能为空!");
                return false;
            }
            
            //手机号
            if (Address_4.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckCellPhone(Address_4.Text.Trim()))
                {
                    MessageBox.Show("手机号不合法!");
                    return false;
                }
            }
            //固定电话
            if (Address_3.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(Address_3.Text.Trim()))
                {
                    MessageBox.Show("固定电话格式不合法!");
                    return false;
                }
            }
            //工作电话
            if (Address_5.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(Address_5.Text.Trim()))
                {
                    MessageBox.Show("固定电话格式不合法!");
                    return false;
                }
            }
            //QQ
            if (Address_6.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckQQ(Address_6.Text.Trim()))
                {
                    MessageBox.Show("QQ号不合法!");
                    return false;
                }
            }
            //E-Mail
            if (Address_7.Text.Trim() != string.Empty)//输入不为空时
            {
                if (!DoValidate.CheckEMail(Address_7.Text.Trim()))
                {

                    MessageBox.Show("邮箱格式不合法!");
                    return false;
                }
            }
            return true;
        
        }
        private void btn_save_Click(object sender, EventArgs e)
        {  
            //验证输入内容
            if (!DoValit())
            { return; }
            string sql="";//sql语句
            #region 修改时
            if (btn_save.Text == "修改")
            {
                sql = string.Format("delete from tb_AddressBook where SutName='{0}' and Sex='{1}' and Phone='{2}' and QQ='{3}' and WorkPhone='{4}' and [E-Mail]='{5}' and Handset='{6}'",
                    AddStr1,
                    AddStr2,
                    AddStr3,
                    AddStr4,
                    AddStr5,
                    AddStr6,
                    AddStr7);
                try
                {
                    MyDBControls.GetConn(); //打开连接
                    MyDBControls.ExecNonQuery(sql);
                    MyDBControls.CloseConn(); //关闭连接
                }
                catch (Exception err) //处理异常
                {
                    MessageBox.Show(err.Message);
                }
            }
            #endregion
            #region 保存时
            
           //产生sql语句
                //姓名   性别 电话    QQ  工作电话  E-Mail 手机
                       sql = string.Format("insert into tb_AddressBook values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                       Address_1.Text.Trim(),
                       Address_2.SelectedItem.ToString(),
                       Address_3.Text.Trim(),
                       Address_6.Text.Trim(),
                       Address_5.Text.Trim(),
                       Address_7.Text.Trim(),
                       Address_4.Text.Trim());
                
           
            #endregion
            
         
            try
            {
                MyDBControls.GetConn(); //打开连接
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(sql)) > 0)
                {
                    MessageBox.Show(btn_save.Text+"成功!"); //执行添加
                    #region 清空原有内容
                    Address_1.Text = Address_3.Text = Address_4.Text = Address_5.Text = Address_6.Text = Address_7.Text = string.Empty;
                    #endregion
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch(Exception err) //处理异常
            {

                if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                {
                    MessageBox.Show("输入长度不合法!");

                    return;
                }
                MessageBox.Show("请确保数据库正常连接并且输入内容合法！");
            }
        }

       
    }
}