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
namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_TongXunLu : Form
    {
        DataSet currentDs = new DataSet();//�洢��ѯ���
        public Frm_TongXunLu()
        {
            InitializeComponent();
        }
        private void btn_Add_Click(object sender, EventArgs e)//���ͨѶ¼
        {
            Frm_TongXun frm_tx = new Frm_TongXun();
            frm_tx.ShowDialog();
            frm_tx.Dispose();
            btn_all_Click(sender, e);//ˢ��
        }

        private void btn_all_Click(object sender, EventArgs e)//��ʾ����
        {
            string sql="";//���ֲ����ı�,������ͬ�����
            switch (this.Text)
            {
                case "����ͨѶ¼":
                    sql = "select SutName as ����,Sex as �Ա�, Phone as ��ͥ�绰, QQ as QQ ,WorkPhone as �����绰 ,[E-Mail] as ����,Handset as �ֻ��� from tb_AddressBook";
                    break;
                case "Ա��ͨѶ¼":
                    sql = "select Stu_Id as ���, Stuffname as ����,Sex as �Ա�, Phone as �绰,Handset as �ֻ� from tb_Stuffbusic";
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

                MessageBox.Show("������!");
            }
        }

        private void btn_find_Click(object sender, EventArgs e)//��ʼ��ѯ
        {
            string findSql = "";
            if (this.Text == "����ͨѶ¼")
            {
                findSql = "select SutName as ����,Sex as �Ա�, Phone as ��ͥ�绰, QQ as QQ ,WorkPhone as �����绰 ,[E-Mail] as ����,Handset as �ֻ��� from tb_AddressBook  ";
                switch (cbox_type.SelectedItem.ToString()) //������ѯ���
                {
                    case "����":
                        findSql += " where SutName like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�Ա�":
                        findSql += " where Sex like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "��ͥ�绰":
                        findSql += " where Phone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "QQ":
                        findSql += " where QQ like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�����绰":
                        findSql += " where WorkPhone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�ֻ�":
                        findSql += " where Handset like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�����ַ":
                        findSql += " where [E-Mail] like '%" + cmbox.Text.Trim() + "%'";
                        break;
                }
            }
            else
            {
                findSql = "select Stu_Id as ���, Stuffname as ����,Sex as �Ա� ,Phone as �绰,Handset as �ֻ� from tb_Stuffbusic ";
                switch (cbox_type.SelectedItem.ToString()) //������ѯ���
                {
                    case "����":
                        findSql += " where StuffName like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�Ա�":
                        findSql += " where Sex like '%" + cmbox.Text.Trim() + "%'";
                        break;
                  case "�绰":
                        findSql += " where Phone like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "�ֻ�":
                        findSql += " where Handset like '%" + cmbox.Text.Trim() + "%'";
                        break;
                    case "Ա�����":
                        findSql += " where Stu_Id like '%" + cmbox.Text.Trim() + "%'";
                        break;
                }
            }
            //MessageBox.Show(findSql);
            try
            {
                MyDBControls.GetConn();  //��ѯ�������ʾ
                currentDs= MyDBControls.GetDataSet(findSql);
                dgv.DataSource =currentDs.Tables[0];
                dgv.Columns[0].Frozen = true;
                MyDBControls.CloseConn();
            }
            catch (Exception err)//�����쳣
            {

                MessageBox.Show(err.Message);
            }
        }

        private void Frm_TongXunLu_Load(object sender, EventArgs e)
        {
            

            if (this.Text == "Ա��ͨѶ¼")//Ա���Ĳ����ڴ��޸� ɾ�� ���   ���Ĳ�ѯ����
            {
               btn_Add.Enabled = btn_Delete.Enabled = btn_update.Enabled = false;
               cbox_type.Items.Clear();
               cbox_type.Items.AddRange(new object[] { "����","�Ա�","�绰","�ֻ�","Ա�����"});
            }
            cbox_type.SelectedIndex = 0;//Ĭ�ϵ�һ�ѡ��
        }

        private void cbox_type_SelectedIndexChanged(object sender, EventArgs e)//�������ĸı� �ı���������
        {
            string findSql = "select  ";
            if (this.Text == "����ͨѶ¼")
            {
                switch (cbox_type.SelectedItem.ToString()) //������ѯ���
                {
                    case "����":
                        findSql += " SutName ";
                        break;
                    case "�Ա�":
                        findSql += "  Sex ";
                        break;
                    case "��ͥ�绰":
                        findSql += "  Phone ";
                        break;
                    case "QQ":
                        findSql += "  QQ ";
                        break;
                    case "�����绰":
                        findSql += " WorkPhone ";
                        break;
                    case "�ֻ�":
                        findSql += "  Handset ";
                        break;
                    case "�����ַ":
                        findSql += "  [E-Mail] ";
                        break;
                }

                findSql += " from tb_AddressBook";
            }
            else
            {
                switch (cbox_type.SelectedItem.ToString()) //������ѯ���
                {
                    case "����":
                        findSql += " StuffName ";
                        break;
                    case "�Ա�":
                        findSql += "  Sex ";
                        break;
                    case "�绰":
                        findSql += "  Phone ";
                        break;
                    case "�ֻ�":
                        findSql += "  Handset ";
                        break;
                    case "Ա�����":
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
                    cmbox.Items.Clear();//���ԭ��
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
            if (dgv.SelectedRows.Count != 0&&this.Text!="Ա��ͨѶ¼")//��ѡ��ʱ�޸� ɾ����ť����
            {
                btn_Delete.Enabled = btn_update.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)//ɾ��
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
                btn_all_Click(sender, e);//����
                MessageBox.Show("ɾ���ɹ�!");
                btn_Delete.Enabled = btn_update.Enabled = false;//��ť�����÷�ֹ�������
            }
            catch 
            {

                MessageBox.Show("������!");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)//�޸�
        {
            Frm_TongXun frm_tx = new Frm_TongXun();//��Ҫ�ĵ����ݴ����˴���
            frm_tx.AddStr1 = dgv.SelectedRows[0].Cells[0].Value.ToString();//����
            frm_tx.AddStr2 = dgv.SelectedRows[0].Cells[1].Value.ToString();//�Ա�
            frm_tx.AddStr3 = dgv.SelectedRows[0].Cells[2].Value.ToString();//��ͥ�绰
            frm_tx.AddStr4 = dgv.SelectedRows[0].Cells[3].Value.ToString();//QQ
            frm_tx.AddStr5 = dgv.SelectedRows[0].Cells[4].Value.ToString();//�����绰
            frm_tx.AddStr6 = dgv.SelectedRows[0].Cells[5].Value.ToString();//����
            frm_tx.AddStr7 = dgv.SelectedRows[0].Cells[6].Value.ToString();//�ֻ�
            frm_tx.ShowDialog();
            btn_all_Click(sender, e);//��������
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
                    string title = "";//����
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
                    MessageBox.Show("����ɹ�!");
                }
            }
        }
       
    }
}