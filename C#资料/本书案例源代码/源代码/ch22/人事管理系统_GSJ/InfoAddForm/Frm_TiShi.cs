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
    public partial class Frm_TiShi : Form
    {

        int operaType; //所操作的数据类别 (生日1，合同0)
        public Frm_TiShi()
        {
            InitializeComponent();
        }

        private void Frm_TiShi_Load(object sender, EventArgs e)
        {
            switch (this.Text)//确定本次操作的类型
            { 
                case "员工生日提示":
                    operaType = 1;
                    break;
                case "员工合同提示":
                    operaType = 0;
                    break;
                default:
                    MessageBox.Show("未知");
                    break;
            }
        }

        private void yingYong_CheckedChanged(object sender, EventArgs e)
        {
            if (yingYong.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string sql;
            if (yingYong.Checked)
            {
                sql = "update tb_Clew set Fate =" + nud_days.Value.ToString() + ", Unlock=1 where kind=" + operaType.ToString() ;
            }
            else
            {
                sql = "update tb_Clew set Unlock= 0  where Kind=" + operaType.ToString();
            }
            try
            {
                MyDBControls.GetConn();
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(sql)) > 0)
                {
                    MessageBox.Show("设置成功!");
                }
                MyDBControls.CloseConn();
                this.Close();
            }
            catch 
            {

                MessageBox.Show("操作失败，请重试！");
            }

        }
      

    }
}