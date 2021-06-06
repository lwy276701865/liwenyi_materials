using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_TongJi : Form
    {
        public Frm_TongJi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbx_T_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lbx_T.SelectedItem.ToString());
            if (lbx_T.SelectedItem == null)//û��ѡ���ִ�в���
                return;

            
            string sql = "";
            switch (lbx_T.SelectedItem.ToString())
            { 
                case "ְ�����":
                    sql = "select Duthcall as ְ�����,count(Duthcall) as ���� from tb_stuffbusic group by Duthcall";
                    break;
                case "ְ�����":
                    sql = "select Business as ְ����� ,count(Business) as ���� from tb_stuffbusic group by Business";
                    break;
                case "�������":
                    sql = "select Laborage as ������� ,count(Laborage) as ���� from tb_stuffbusic  group by Laborage";
                    break;
                case "�������":
                    sql = "select Branch as ������� ,count(Branch) as ���� from tb_stuffbusic  group by Branch";
                    break;
                case "������ò":
                    sql = "select Visage as ������ò ,count(Visage) as ����  from tb_stuffbusic group by Visage";
                    break;
                case "�Ļ��̶�":
                    sql = "select Kultur as �Ļ��̶� ,count(Kultur) as ���� from tb_stuffbusic  group by Kultur";
                    break;
                case "ְ�����":
                    sql = "select Employee as ְ����� ,count(Employee) as ���� from tb_stuffbusic  group by Employee";
                    break;
                case "�������":
                    sql = "select Folk as ������� ,count(Folk) as ����  from tb_stuffbusic group by Folk";
                    break;
                case "����":
                    sql = "select Age as ���� ,count(Age) as ���� from tb_stuffbusic  group by Age";
                    break;
                case "�Ա�":
                    sql = "select Sex as �Ա� ,count(Sex) as ����  from tb_stuffbusic group by Sex";
                    break;
            }
            try
            {
                MyDBControls.GetConn();
                dgv_TJ.DataSource = MyDBControls.GetDataSet(sql).Tables[0];
                MyDBControls.CloseConn();
            }
            catch 
            {
                this.Close();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_TJ.Rows.Count>0)//������ʱ
            {
                try
                {
                    sfd_TJ.FileName = dgv_TJ.Columns[0].HeaderText;
                    if (DialogResult.OK == sfd_TJ.ShowDialog())
                    {

                        StreamWriter sw = new StreamWriter(sfd_TJ.FileName);
                        sw.WriteLine(dgv_TJ.Columns[0].HeaderText + "\t" + dgv_TJ.Columns[1].HeaderText);
                        for (int i = 0; i < dgv_TJ.Rows.Count; i++)
                        {
                            sw.WriteLine(dgv_TJ.Rows[i].Cells[0].Value.ToString() + "\t" + dgv_TJ.Rows[i].Cells[1].Value.ToString());
                        }
                        sw.Close();
                    }
                }
                catch 
                {

                    MessageBox.Show("������!");
                }
            }
        }
       
    }
}