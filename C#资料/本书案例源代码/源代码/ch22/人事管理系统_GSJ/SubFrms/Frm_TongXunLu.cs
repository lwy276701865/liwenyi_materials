using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SqlClient;
using System.IO;
namespace 人事管理系统_GSJ
{
    public partial class Frm_TongXunLu : Form
    {
        DataSet currentDs = new DataSet();//存储查询结果
        public Frm_TongXunLu()
        {
            InitializeComponent();
        }
        private void btn_Add_Click(object sender, EventArgs e)//添加通讯录
        {
            Frm_TongXun frm_tx = new Frm_TongXun();
            frm_tx.ShowDialog();
            frm_tx.Dispose();
            btn_all_Click(sender, e);//刷新
        }

        private void btn_all_Click(object sender, EventArgs e)//显示所有
        {
            string sql="";//区分操作的表,产生不同的语句
            switch (this.Text)
            {
                case "个人通讯录":
                    sql = "select SutName as 姓名,Sex as 性别, Phone as 家庭电话, QQ as QQ ,WorkPhone as 工作电话 ,[E-Mail] as 邮箱,Handset as 手机号 from tb_AddressBook";
                    break;
                case "员工通讯录":
                    sql = "select Stu_Id as 编号, Stuffname as 姓名,Sex as 性别, Phone as 电话,Handset as 手机 from tb_Stuffbusic";
                    break;
            }
            try
            {
                MyDBControls.GetConn();
                currentDs = MyDBControls.GetDataSet(sql);
                dgv.DataSource = currentDs.Tables[0];
                dgv.Columns[0].Frozen = true;
                MyDBControls.CloseConn();
            }
            catch
            {

                MessageBox.Show("请重试!");
            }
        }

        private void btn_find_Click(object sender, EventArgs e)//开始查询
        {
            string findSql = "";
            if (this.Text == "个人通讯录")
            {
                findSql = "select SutName as 姓名,Sex as 性别, Phone as 家庭电话, QQ as QQ ,WorkPhone as 工作电话 ,[E-Mail] as 邮箱,Handset as 手机号 from tb_AddressBook  ";
                switch (cbox_type.SelectedItem.ToString()) //产生查询语句
                {
                    case "姓名":
                        findSql += " where SutName like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "性别":
                        findSql += " where Sex like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "家庭电话":
                        findSql += " where Phone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "QQ":
                        findSql += " where QQ like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "工作电话":
                        findSql += " where WorkPhone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "手机":
                        findSql += " where Handset like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "邮箱地址":
                        findSql += " where [E-Mail] like '%" + cmbox.Text.Trim() + "%'";
                        break;
                }
            }
            else
            {
                findSql = "select Stu_Id as 编号, Stuffname as 姓名,Sex as 性别 ,Phone as 电话,Handset as 手机 from tb_Stuffbusic ";
                switch (cbox_type.SelectedItem.ToString()) //产生查询语句
                {
                    case "姓名":
                        findSql += " where StuffName like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "性别":
                        findSql += " where Sex like '%" + cmbox.Text.Trim() + "%'";
                        break;
                  case "电话":
                        findSql += " where Phone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "手机":
                        findSql += " where Handset like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "员工编号":
                        findSql += " where Stu_Id like '%" + cmbox.Text.Trim() + "%'";
                        break;
                }
            }
            //MessageBox.Show(findSql);
            try
            {
                MyDBControls.GetConn();  //查询结果并显示
                currentDs= MyDBControls.GetDataSet(findSql);
                dgv.DataSource =currentDs.Tables[0];
                dgv.Columns[0].Frozen = true;
                MyDBControls.CloseConn();
            }
            catch (Exception err)//处理异常
            {

                MessageBox.Show(err.Message);
            }
        }

        private void Frm_TongXunLu_Load(object sender, EventArgs e)
        {
            

            if (this.Text == "员工通讯录")//员工的不能在此修改 删除 添加   更改查询类型
            {
               btn_Add.Enabled = btn_Delete.Enabled = btn_update.Enabled = false;
               cbox_type.Items.Clear();
               cbox_type.Items.AddRange(new object[] { "姓名","性别","电话","手机","员工编号"});
            }
            cbox_type.SelectedIndex = 0;//默认第一项被选中
        }

        private void cbox_type_SelectedIndexChanged(object sender, EventArgs e)//随条件的改变 改变条件内容
        {
            string findSql = "select  ";
            if (this.Text == "个人通讯录")
            {
                switch (cbox_type.SelectedItem.ToString()) //产生查询语句
                {
                    case "姓名":
                        findSql += " SutName ";
                        break;
                    case "性别":
                        findSql += "  Sex ";
                        break;
                    case "家庭电话":
                        findSql += "  Phone ";
                        break;
                    case "QQ":
                        findSql += "  QQ ";
                        break;
                    case "工作电话":
                        findSql += " WorkPhone ";
                        break;
                    case "手机":
                        findSql += "  Handset ";
                        break;
                    case "邮箱地址":
                        findSql += "  [E-Mail] ";
                        break;
                }

                findSql += " from tb_AddressBook";
            }
            else
            {
                switch (cbox_type.SelectedItem.ToString()) //产生查询语句
                {
                    case "姓名":
                        findSql += " StuffName ";
                        break;
                    case "性别":
                        findSql += "  Sex ";
                        break;
                    case "电话":
                        findSql += "  Phone ";
                        break;
                    case "手机":
                        findSql += "  Handset ";
                        break;
                    case "员工编号":
                        findSql += "  Stu_Id ";
                        break;
                }
                findSql += " from tb_stuffbusic";
            }
            try
            {
                MyDBControls.GetConn();
                SqlDataReader sdr = MyDBControls.GetDataReader(findSql);
                if (sdr.HasRows)
                {
                    cmbox.Items.Clear();//清空原有
                    while (sdr.Read())
                    {
                        if (cmbox.Items.IndexOf(sdr[0].ToString()) == -1)
                        {
                            cmbox.Items.Add(sdr[0].ToString());
                            cmbox.SelectedIndex = 0;
                        }
                    }
                }
                MyDBControls.CloseConn();
            }
            catch 
            {
               
               
            }
        }

        private void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count != 0&&this.Text!="员工通讯录")//有选中时修改 删除按钮能用
            {
                btn_Delete.Enabled = btn_update.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)//删除
        {
            string sql = string.Format("delete from tb_AddressBook where SutName ='{0}' and Sex ='{1}' and  Phone ='{2}' and  QQ ='{3}'  and WorkPhone ='{4}'  and [E-Mail] ='{5}' and Handset ='{6}'",
                dgv.SelectedRows[0].Cells[0].Value.ToString(),
                dgv.SelectedRows[0].Cells[1].Value.ToString(),
                dgv.SelectedRows[0].Cells[2].Value.ToString(),
                dgv.SelectedRows[0].Cells[3].Value.ToString(),
                dgv.SelectedRows[0].Cells[4].Value.ToString(),
                dgv.SelectedRows[0].Cells[5].Value.ToString(),
                dgv.SelectedRows[0].Cells[6].Value.ToString());
            //MessageBox.Show(sql);
            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(sql);
                MyDBControls.CloseConn();
                btn_all_Click(sender, e);//更新
                MessageBox.Show("删除成功!");
                btn_Delete.Enabled = btn_update.Enabled = false;//按钮不能用防止错误操作
            }
            catch 
            {

                MessageBox.Show("请重试!");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)//修改
        {
            Frm_TongXun frm_tx = new Frm_TongXun();//把要改的内容传给此窗体
            frm_tx.AddStr1 = dgv.SelectedRows[0].Cells[0].Value.ToString();//姓名
            frm_tx.AddStr2 = dgv.SelectedRows[0].Cells[1].Value.ToString();//性别
            frm_tx.AddStr3 = dgv.SelectedRows[0].Cells[2].Value.ToString();//家庭电话
            frm_tx.AddStr4 = dgv.SelectedRows[0].Cells[3].Value.ToString();//QQ
            frm_tx.AddStr5 = dgv.SelectedRows[0].Cells[4].Value.ToString();//工作电话
            frm_tx.AddStr6 = dgv.SelectedRows[0].Cells[5].Value.ToString();//邮箱
            frm_tx.AddStr7 = dgv.SelectedRows[0].Cells[6].Value.ToString();//手机
            frm_tx.ShowDialog();
            btn_all_Click(sender, e);//更新数据
            btn_Delete.Enabled = btn_update.Enabled = false;
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            sfd_result.FileName = this.Text + ".txt";
            if (DialogResult.OK == sfd_result.ShowDialog())
            {
                StreamWriter sw = new StreamWriter(sfd_result.FileName);
                if (dgv.Rows.Count > 0)
                {
                    string title = "";//列名
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        title += dgv.Columns[i].HeaderText + "\t";
                    }
                    sw.WriteLine(title);
                    for (int x = 0; x < dgv.Rows.Count; x++)
                    {
                        string rowTxt = "";
                        for (int y = 0; y < dgv.Columns.Count; y++)
                        {
                            rowTxt += dgv.Rows[x].Cells[y].Value.ToString() + "\t";
                        }
                        sw.WriteLine(rowTxt);
                    }
                    sw.Close();
                    MessageBox.Show("保存成功!");
                }
            }
        }
       
    }
}