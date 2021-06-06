using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_BeiFenHuanYuan : Form
    {
        public Frm_BeiFenHuanYuan()
        {
            InitializeComponent();
        }

        private void btn_calcel_Click(object sender, EventArgs e)//�رմ���
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search2_Click(object sender, EventArgs e)//���ұ����ļ�
        {
            ofd_restore.Filter = "�����ļ�(*.bak)|*.bak";//�����ļ�����
            ofd_restore.FileName = "*.bak";
            if (ofd_restore.ShowDialog() == DialogResult.OK)
            {
                txt_R_Path.Text = ofd_restore.FileName;//��ʾѡ�е��ļ���

            }
        }

        private void Frm_BeiFenHuanYuan_Load(object sender, EventArgs e)
        {
            txt_B_Path1.Text = Application.StartupPath.ToString() + "\\PWMS_GSJ"+ DateTime.Now.Millisecond.ToString() + ".bak";//��ʾĬ��·��
        }

        private void rbtn_2_CheckedChanged(object sender, EventArgs e)//ȷ��·���Ƿ�ΪĬ��
        {
            if (rbtn_2.Checked)
            {
                txt_B_Path2.Enabled = true;//���û�ѡ��·��
                btn_search.Enabled = true;
            }
            else
            {
                txt_B_Path2.Enabled = btn_search.Enabled =false;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)//�����ļ����λ��
        {
            if (DialogResult.OK == fbd_save.ShowDialog())
            {
                txt_B_Path2.Text = fbd_save.SelectedPath+ "\\PWMS_GSJ"+ DateTime.Now.Millisecond.ToString() + ".bak";
            }
        }

        private void btn_backup_Click(object sender, EventArgs e)//ִ�б���
        {
            string savePath="";//���մ��·��
            if (rbtn_1.Checked)
            {
                savePath = txt_B_Path1.Text;
            }
            else
            {
                if (txt_B_Path2.Text == string.Empty)//�ж�·���Ƿ�Ϊ��
                {
                    MessageBox.Show("��ѡ��·��!");
                    return;
                }
                savePath = txt_B_Path2.Text;
            }
            
            //�������
            string backSql = "backup database db_PWMS_GSJ to disk ='" + savePath +"'";
            //MessageBox.Show(backSql);
            //return;
            try
            {
                MyDBControls.GetConn(); //������
                MyDBControls.ExecNonQuery(backSql);//ִ������
                MyDBControls.CloseConn();//�ر�����
                MessageBox.Show("�ѳɹ����ݵ�:\n"+savePath);
                this.Close();
            }
            catch //�����쳣
            {

                MessageBox.Show("�ļ�·������ȷ!");
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            btn_restore.Enabled = false;//��ֹ��ԭ�����д������
            MyDBControls.RestoreDB(txt_R_Path.Text);
            MessageBox.Show("�ɹ���ԭ!Ϊ�˷�ֹ���ݶ�ʧ�����µ�¼��");
            Application.Restart();
        }
       
    }
}