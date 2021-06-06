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
    public partial class Frm_XiuGaiYongHu : Form
    {
        public Frm_XiuGaiYongHu()
        {
            InitializeComponent();
        }

        private void tool_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tool_UserAdd_Click(object sender, EventArgs e) //显示添加窗体
        {
            Frm_JiaYongHu frm_jyh = new Frm_JiaYongHu();
            frm_jyh.Text = "添加新用户";
            frm_jyh.ShowDialog();
            frm_jyh.Dispose();
            ShowAllUser();//重新加载用户信息
        }

        private void tool_UserPop_Click(object sender, EventArgs e) //显示修改用户权限窗体
        {
            if (!CheckHavaSelected())//检查是否有操作对象
            {
                return; //未选择任何用户所以终止执行
            }
            if (CheckIsCurrent())//检查是否为当前用户 是则不执行操作
            {
                return;
            }

            Frm_QuanXian frm_qx = new Frm_QuanXian();
            frm_qx.Text = "修改用户权限";
            frm_qx.QxUserName = dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString();//传递当前操作的用户名
            frm_qx.ShowDialog();
            frm_qx.Dispose();
            
        }
        private void ShowAllUser() //查询所有用户信息并显示
        {
            string sql = "select Uid  ,Pwd from tb_Login"; //sql 语句
            MyDBControls.GetConn();   //连接数据库
            DataSet ds = MyDBControls.GetDataSet(sql); //得到数据并显示
            dgv_userInfo.DataSource = ds.Tables[0];
            MyDBControls.CloseConn(); //关闭连接
            //解密用户信息
            GSJ_DESC myDesc = new GSJ_DESC("@gsj");
            for (int i = 0; i < dgv_userInfo.Rows.Count; i++)
            {
                for (int y = 0; y < dgv_userInfo.Rows[i].Cells.Count; y++)
                {
                    
                    if (y < dgv_userInfo.Rows[i].Cells.Count)//真证的用户信息要解密
                    {
                       
                        dgv_userInfo.Rows[i].Cells[y].Value = myDesc.Decry(dgv_userInfo.Rows[i].Cells[y].Value.ToString());
                    }
                }
            }
            dgv_userInfo.Columns[1].Visible = false;

        }
        private void Frm_XiuGaiYongHu_Load(object sender, EventArgs e)
        {
            //加载已存在用户信息
            ShowAllUser();
        }
        private bool CheckHavaSelected()//检查是否有选择的用户  没有则返回 false
        {
            if (dgv_userInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要操作的用户!");
                return false;
            }
            return true;
        }
        private bool CheckIsCurrent() //检查是否为选择的是否为当前用户 不是则返回 false
        {
            if (dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString() == FrmMain.P_currentUserName)
            {
                MessageBox.Show("不能删除当前用户或修改当前用户权限!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void tool_UserUpdate_Click(object sender, EventArgs e) //显示修改窗体
        {
            if (!CheckHavaSelected())//检查是否有操作对象
            {
                return; //未选择任何用户所以终止执行
            }
            Frm_JiaYongHu frm_jyh = new Frm_JiaYongHu();
            frm_jyh.Text = "修改密码";
            frm_jyh.UidStr = dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString();//选中的用户名
            frm_jyh.PwdStr = dgv_userInfo.SelectedRows[0].Cells[1].Value.ToString();//选中的密码
            frm_jyh.IsAdd = false;//标致此操作为修改
            frm_jyh.ShowDialog();
            frm_jyh.Dispose();
            ShowAllUser();//重新加载用户信息
        }

        private void tool_UserDelete_Click(object sender, EventArgs e)//删除用户
        {   
            if (!CheckHavaSelected())//检查是否有操作对象
            {
                return; //未选择任何用户所以终止执行
            }
            if (CheckIsCurrent())//检查是否为当前用户 是则不执行操作
            {
                return; 
            }
            //确认是否操作
            if (MessageBox.Show("真的要删除吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                MessageBox.Show("操作已取消!");
                return;
            } 
            try
            {
                //
                GSJ_DESC myDesc = new GSJ_DESC("@gsj");
                MyDBControls.GetConn(); //打开连接
                string delStr="delete from tb_Userpope where Uid='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString()) + "'";//删除对应的权限信息
                MyDBControls.ExecNonQuery(delStr);
                                         //选中的用户名
                string delSql = "delete from tb_Login where Uid='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString()) + "' and Pwd='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[1].Value.ToString()) + "'";
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delSql)) > 0) //执行删除
                {
                    MessageBox.Show("删除成功!");
                }
                MyDBControls.CloseConn();//关闭连接
                ShowAllUser();//重新加载用户信息
            }
            catch 
            {

                
                ShowAllUser();//重新加载用户信息
            }
        }
       
    }
}