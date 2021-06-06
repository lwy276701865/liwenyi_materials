using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace 人事管理系统_GSJ
{
    public partial class Frm_BeiFenHuanYuan : Form
    {
        public Frm_BeiFenHuanYuan()
        {
            InitializeComponent();
        }

        private void btn_calcel_Click(object sender, EventArgs e)//关闭窗体
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search2_Click(object sender, EventArgs e)//查找备份文件
        {
            ofd_restore.Filter = "备份文件(*.bak)|*.bak";//过滤文件类型
            ofd_restore.FileName = "*.bak";
            if (ofd_restore.ShowDialog() == DialogResult.OK)
            {
                txt_R_Path.Text = ofd_restore.FileName;//显示选中的文件名

            }
        }

        private void Frm_BeiFenHuanYuan_Load(object sender, EventArgs e)
        {
            txt_B_Path1.Text = Application.StartupPath.ToString() + "\\PWMS_GSJ"+ DateTime.Now.Millisecond.ToString() + ".bak";//显示默认路径
        }

        private void rbtn_2_CheckedChanged(object sender, EventArgs e)//确定路径是否为默认
        {
            if (rbtn_2.Checked)
            {
                txt_B_Path2.Enabled = true;//供用户选择路径
                btn_search.Enabled = true;
            }
            else
            {
                txt_B_Path2.Enabled = btn_search.Enabled =false;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)//备份文件存放位置
        {
            if (DialogResult.OK == fbd_save.ShowDialog())
            {
                txt_B_Path2.Text = fbd_save.SelectedPath+ "\\PWMS_GSJ"+ DateTime.Now.Millisecond.ToString() + ".bak";
            }
        }

        private void btn_backup_Click(object sender, EventArgs e)//执行备份
        {
            string savePath="";//最终存放路径
            if (rbtn_1.Checked)
            {
                savePath = txt_B_Path1.Text;
            }
            else
            {
                if (txt_B_Path2.Text == string.Empty)//判断路径是否为空
                {
                    MessageBox.Show("请选择路径!");
                    return;
                }
                savePath = txt_B_Path2.Text;
            }
            
            //备份语句
            string backSql = "backup database db_PWMS_GSJ to disk ='" + savePath +"'";
            //MessageBox.Show(backSql);
            //return;
            try
            {
                MyDBControls.GetConn(); //打开连接
                MyDBControls.ExecNonQuery(backSql);//执行命令
                MyDBControls.CloseConn();//关闭连接
                MessageBox.Show("已成功备份到:\n"+savePath);
                this.Close();
            }
            catch //处理异常
            {

                MessageBox.Show("文件路径不正确!");
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            btn_restore.Enabled = false;//防止还原过程中错误操作
            MyDBControls.RestoreDB(txt_R_Path.Text);
            MessageBox.Show("成功还原!为了防止数据丢失请重新登录！");
            Application.Restart();
        }
       
    }
}