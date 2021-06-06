using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 人事管理系统_GSJ
{
    public partial class Frm_JiBen : Form
    {
        public Frm_JiBen()
        {
            InitializeComponent();
        }
        string operaTable = "";//当前窗体要操作的数据表名
        string operaColumn = "";//列名
        private void Frm_JiBen_Load(object sender, EventArgs e)
        {
            #region 根据标题来判断需要提取的数据内容
                        switch (this.Text)
                        { 
                            case "民族类别设置":
                                operaTable = "tb_Folk";
                                operaColumn = "FolkName";
                                break;
                            case "文化程度设置":
                                operaTable = "tb_Kultur";
                                operaColumn = "KulturName";
                                break;
                            case "职工类别设置":
                                operaTable = "tb_EmployeeGenre";
                                operaColumn = "EmployeeName";
                                break;
                            case "政治面貌设置":
                                operaTable = "tb_Visage";
                                operaColumn = "VisageName";
                                break;
                            case "部门类别设置":
                                operaTable = "tb_Branch";
                                operaColumn = "BranchName";
                                break;
                            case "工资类别设置":
                                operaTable = "tb_Laborage";
                                operaColumn = "LaborageName";
                                break;
                            case "职务类别设置":
                                operaTable = "tb_Business";
                                operaColumn = "BusinessName";
                                break;
                            case "职称类别设置":
                                operaTable = "tb_Duthcall";
                                operaColumn = "DuthcallName";
                                break;
                            case "奖惩类别设置":
                                operaTable = "tb_RPKind";
                                operaColumn = "RPKind";
                                break;
                            case "记事本类别设置":
                                operaTable = "tb_WordPad";
                                operaColumn = "WordPad";
                                break;
                            default: MessageBox.Show("数据表未确定!");
                                break;
                        }
            #endregion
            //为listView加内容
               AddItems();
        }
        private void AddItems() //从数据库提取数据并加到 ListView 中
        {
            #region 填充数据
            try
            {
                string Sql = "select " + operaColumn + " from " + operaTable; //sql语句
                MyDBControls.GetConn();     //打开连接
                SqlDataReader sdr = MyDBControls.GetDataReader(Sql);//读取数据
                while (sdr.Read())
                {
                    ltb_show.Items.Add(sdr[0]); //逐一加到 listView中
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch 
            {
                this.Close();
            }

            #endregion
        }
        private bool DoValidate()//做验证
        {
            //验证是否为空
            if (txt_content.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入添加/修改的内容!");
                txt_content.Focus();
                return false;
            }
            else
            {
                //验证是否已存在此内容
                for (int i = 0; i < ltb_show.Items.Count; i++)
                {
                    if (ltb_show.Items[i].ToString() == txt_content.Text.Trim())
                    {
                        MessageBox.Show("已存在此信息!");
                        txt_content.Focus();
                        return false;
                    }
                }
            }
            
            return true;

        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            #region 验证
            //是否有要更改的项
            if (ltb_show.SelectedItem == null)
            {
                return;
            }
            if (!DoValidate()) //验证有效性
            {
                return;
            }
            #endregion
            string UpdStr = "update " + operaTable + " set " + operaColumn + "='" + txt_content.Text.Trim() + "' where " + operaColumn +"='"+ ltb_show.SelectedItem.ToString()+"'";
            #region 修改内容
            try
            {
                MyDBControls.GetConn(); //连接数据库
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(UpdStr)) > 0)
                {
                    ltb_show.Items.Add(txt_content.Text.Trim());//添加到 listview 中
                    ltb_show.Items.Clear();//清空原有内容
                    AddItems(); //重新添加
                    MessageBox.Show("修改成功!");
                    txt_content.Text = string.Empty;//清空输入的内容
                }
                MyDBControls.CloseConn(); //关闭数据库
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                {
                    MessageBox.Show("输入内容长度不合法,最大长度为20位字母或10个汉字!");
                    txt_content.Focus();
                    return;
                }
               
            } 
            #endregion
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            #region 验证输入的有效性
            if (!DoValidate())
            {
                return;
            }
            #endregion
            #region 添加内容
            string insertSql = "insert into " + operaTable + " values('" + txt_content.Text.Trim() + "')";
            try
            {
                MyDBControls.GetConn(); //连接数据库
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(insertSql)) > 0)
                {
                    ltb_show.Items.Add(txt_content.Text.Trim());//添加到 listview 中
                    MessageBox.Show("添加成功!");
                    txt_content.Text = string.Empty;//清空输入的内容
                }
                MyDBControls.CloseConn(); //关闭数据库
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                {
                    MessageBox.Show("输入内容长度不合法,最大长度为20位字母或10个汉字!");
                    
                    
                }
                if (err.Message.IndexOf("附近有语法错误") != -1)
                {
                    MessageBox.Show("输入内容不合法!");
                    
                }
                txt_content.Focus();
            }
            #endregion
        }

        private void ltb_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //修改按钮 删除按钮 能用
            if (ltb_show.SelectedItem!=null)
            {
                btn_del.Enabled = true;
                btn_update.Enabled = true; 
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ltb_show.SelectedItem = null;
            btn_del.Enabled = false;
            btn_update.Enabled = false;
            txt_content.Focus();//输入框
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (ltb_show.SelectedItem == null)
            {
                MessageBox.Show("请选择要删除的内容!");
                return;
            }
            //sql 语句
            string delStr="delete from "+operaTable+" where "+operaColumn+"='"+ltb_show.SelectedItem.ToString()+"'";
            #region 删除内容
            try
            { 
                MyDBControls.GetConn();     //打开连接
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delStr)) > 0)
                {
                    ltb_show.Items.Clear();//清空原有内容
                    AddItems(); //重新添加
                    MessageBox.Show("删除成功!");
                    
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch 
            {
               MessageBox.Show("操作失败");
            }

            #endregion

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
       
    }
}