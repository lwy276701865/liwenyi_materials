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
    public partial class Frm_QuanXian : Form
    {
        private string qxUserName = "";//当前操作的用户名
        GSJ_DESC myDesc;//加密解密对象
        public string QxUserName
        {
            get { return qxUserName; }
            set { qxUserName = value; }
        }
        public Frm_QuanXian()
        {
            InitializeComponent();
        }
        //定义所有表示权限的控件的集合
        Control.ControlCollection popeControls;
        private void Frm_QuanXian_Load(object sender, EventArgs e)
        {
            //
            myDesc = new GSJ_DESC("@gsj");
            //
            txt_userName.Text =QxUserName;//确定当前用户
            popeControls = this.groupBox2.Controls;
            DataSet popeDS=new DataSet();//存当前用户所有权限信息
            // 根据已有权限设置相关按钮
            string popeSql="select PopeName,Pope from tb_UserPope where Uid ='"+myDesc.Encry(txt_userName.Text)+"'";
            try
            {
                MyDBControls.GetConn();
                popeDS = MyDBControls.GetDataSet(popeSql); //提取当前用户的所有权限信息
                MyDBControls.CloseConn();
            }
            catch 
            {

                MessageBox.Show("数据提取失败!");
                this.Close();
            }
            //逐一检查确定相应按钮是否为选中
            for (int i = 0; i < popeDS.Tables[0].Rows.Count; i++)
            {
                foreach (Control c in popeControls)
                {
                    if (c.Text == popeDS.Tables[0].Rows[i][0].ToString())
                    {
                        if (popeDS.Tables[0].Rows[i][1].ToString() == "True")
                        {
                            ((CheckBox)c).Checked = true;
                        }
                    }
                }
            }
           
        }

        private void User_All_CheckedChanged(object sender, EventArgs e)//实现全选功能
        {
            if (User_All.Checked)
            {
                foreach (Control c in popeControls) //全选
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in popeControls)//全部取消选择
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }

        private void User_Save_Click(object sender, EventArgs e)//保存仅限
        {
            try
            {
                MyDBControls.GetConn();//打开连接
                foreach (Control c in popeControls)//逐一检测是否修改所对应的权限
                {
                    int flg = 0;  //没选中则为 0 表示权限不能用  否则为 1 表示能用
                    if (((CheckBox)c).Checked)
                    {
                        flg = 1;
                    }

                    string sql = "update tb_UserPope set pope=" + flg + " where Uid='" +myDesc.Encry(txt_userName.Text) + "' and PopeName='" + c.Text + "'";
                    MyDBControls.ExecNonQuery(sql);
                }
                MyDBControls.CloseConn();//关闭连接
                MessageBox.Show("保存成功!");
                this.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void User_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}