using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_TiShi : Form
    {

        int operaType; //��������������� (����1����ͬ0)
        public Frm_TiShi()
        {
            InitializeComponent();
        }

        private void Frm_TiShi_Load(object sender, EventArgs e)
        {
            switch (this.Text)//ȷ�����β���������
            { 
                case "Ա��������ʾ":
                    operaType = 1;
                    break;
                case "Ա����ͬ��ʾ":
                    operaType = 0;
                    break;
                default:
                    MessageBox.Show("δ֪");
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
                    MessageBox.Show("���óɹ�!");
                }
                MyDBControls.CloseConn();
                this.Close();
            }
            catch 
            {

                MessageBox.Show("����ʧ�ܣ������ԣ�");
            }

        }
      

    }
}