using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_QingKong : Form
    {
        public Frm_QingKong()
        {
            InitializeComponent();
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ALL_Table_CheckedChanged(object sender, EventArgs e)//ʵ��ȫѡ����
        {

            foreach (Control c in groupBox1.Controls)
            {
                if (ALL_Table.Checked)
                {
                    ((CheckBox)c).Checked = true;
                }
                else
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }

        private void but_clear_Click(object sender, EventArgs e)
        {
            MyDBControls.GetConn();
            foreach (Control c in groupBox1.Controls)
            {
                if (((CheckBox)c).Checked)
                {
                   //  MessageBox.Show(c.Name.Replace("Table","tb"));
                    MyDBControls.ExecNonQuery("delete from " + c.Name.Replace("Table", "tb"));
                }
            }
            MyDBControls.CloseConn();
            MessageBox.Show("����ɹ�!");
            this.Close();
        }
       

    }
}