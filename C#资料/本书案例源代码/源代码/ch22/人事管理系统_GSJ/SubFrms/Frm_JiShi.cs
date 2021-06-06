using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SqlClient;
namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_JiShi : Form
    {
        public Frm_JiShi()
        {
            InitializeComponent();
        }

        private void Frm_JiShi_Load(object sender, EventArgs e)
        {
            #region ��ȡ�������
            string sql = "select WordPad from tb_WordPad"; //sql���
            try
            {
                MyDBControls.GetConn(); //������
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);//��ȡ����
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        cbbox_type.Items.Add(sdr[0].ToString());
                        cbbox_type.SelectedIndex = cbbox_type.Items.Count - 1;
                        WordPad_2.Items.Add(sdr[0].ToString());
                        WordPad_2.SelectedIndex = WordPad_2.Items.Count - 1;
                    }
                }
                else
                {
                    MessageBox.Show("�������ü������");
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch  //�����쳣
            {
                this.Close();
                
            }
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//��ѯʱ��
        {
            if (checkBox1.Checked) { dtp_time.Enabled = true; }
            else { dtp_time.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//��ѯ����
        {
            if (checkBox2.Checked) { cbbox_type.Enabled = true; }
            else { cbbox_type.Enabled = false; }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckPrompt()//��֤�������Ч�� 
        { 
        //�Ƿ� ������
            if (WordPad_3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("���ⲻ��Ϊ��!");
                WordPad_3.Focus();
                return false;
            }
            //�Ƿ��� ����
            if (WordPad_4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("���ݲ���Ϊ��!");
                WordPad_4.Focus();
                return false;
            }
            return true;
        }
        private void btn_Add_Click(object sender, EventArgs e)//��Ӽ�������
        {
            if (CheckPrompt())//����Ϸ�
            {                                                                      //ʱ��  ��� ���� ���� (ʱ��ֻȡ ���ڲ��� �����ѯʱ��ʧЧ)
                string insertSql = string.Format("insert into tb_DayWordPad values('{0}','{1}','{2}','{3}')", WordPad_1.Value.Date, WordPad_2.SelectedItem.ToString(), WordPad_3.Text.Trim(), WordPad_4.Text.Trim());
                try
                {
                    MyDBControls.GetConn();
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(insertSql)) > 0)
                    {
                        MessageBox.Show("��ӳɹ�!");
                        btn_Find_Click(sender, e);//����
                        WordPad_4.Text = WordPad_3.Text = string.Empty;
                    }
                    MyDBControls.CloseConn();
                }
                catch (Exception err) //�����쳣
                {
                    if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                    {
                        MessageBox.Show("�������ⳤ�Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                        WordPad_3.Focus();
                        return;
                    }
                    
                }
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)//���Ҳ���ʾ
        {
            //���� sql ���

            string sql = string.Empty;
            if (checkBox1.Checked && checkBox2.Checked == false)//����ֻ������
            {
                sql = string.Format("select Motif as ���� ,BlotterDate as ʱ�� ,BlotterSort as ��� ,Wordpa as ���� from tb_DayWordPad where BlotterDate='{0}'", dtp_time.Value.Date);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked)//ֻ�����
            {
                sql = string.Format("select Motif as ���� ,BlotterDate as ʱ�� ,BlotterSort as ��� ,Wordpa as ���� from tb_DayWordPad where BlotterSort='{0}'", cbbox_type.SelectedItem.ToString());
            }
            else if (checkBox1.Checked && checkBox2.Checked) //���߶���
            {
                sql = string.Format("select Motif as ���� ,BlotterDate as ʱ�� ,BlotterSort as ��� ,Wordpa as ���� from tb_DayWordPad where BlotterDate='{0}' and BlotterSort='{1}'", dtp_time.Value.Date, cbbox_type.SelectedItem.ToString());
            }
            else//ȫ��ѡ������
            {
                sql = string.Format("select Motif as ���� ,BlotterDate as ʱ�� ,BlotterSort as ��� ,Wordpa as ���� from tb_DayWordPad");
            }
            //��ȡ���
            try
            {
                MyDBControls.GetConn();
                DataSet ds = MyDBControls.GetDataSet(sql);
                MyDBControls.CloseConn();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch 
            {

               
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //��ʾ����
            WordPad_1.Value =(DateTime) dataGridView1.SelectedRows[0].Cells[1].Value;//ʱ��
            WordPad_2.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//���
            WordPad_3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//����
            WordPad_4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//����
            //��ť����
            btn_Delete.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = btn_update.Enabled = false;
            WordPad_3.Text = WordPad_4.Text = string.Empty;//���
            WordPad_3.Focus();
        }

        private void btn_update_Click(object sender, EventArgs e)//�޸ļ���
        {
           
            string updSql = string.Format("update tb_DayWordPad set BlotterDate='{0}' ,BlotterSort='{1}',Motif='{2}',Wordpa='{3}' where BlotterDate='{4}' and BlotterSort='{5}' and Motif='{6}'",
                WordPad_1.Value.Date,//���º��ʱ��
                WordPad_2.SelectedItem.ToString(),//���
                WordPad_3.Text.Trim(),//����
                WordPad_4.Text,//����
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),//ԭ����ʱ��
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),//ԭ�������
                dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//ԭ������
            //MessageBox.Show(updSql);
            //return;
            try
            {
                MyDBControls.GetConn(); //������
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(updSql)) != 0) //�޸�����
                {
                    MessageBox.Show("�޸ĳɹ�!");
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch (Exception err) //�����쳣
            {
                if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                {
                    MessageBox.Show("�������ⳤ�Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                    WordPad_3.Focus();
                    return;
                }
                
            }

            // //���޸ĸ���
            dataGridView1.SelectedRows[0].Cells[1].Value = WordPad_1.Value.Date;
            dataGridView1.SelectedRows[0].Cells[2].Value = WordPad_2.SelectedItem.ToString();
            dataGridView1.SelectedRows[0].Cells[0].Value = WordPad_3.Text;
            dataGridView1.SelectedRows[0].Cells[3].Value = WordPad_4.Text;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string delSql = string.Format("delete from tb_DayWordPad where  BlotterDate='{0}' and BlotterSort='{1}' and Motif='{2}'",
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),//ԭ����ʱ��
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),//ԭ�������
                dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//ԭ������
            try
            {
                MyDBControls.GetConn(); //������
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delSql)) != 0) //ɾ������
                {
                    MessageBox.Show("ɾ���ɹ�!");
                    btn_Find_Click(sender, e);//����
                    WordPad_4.Text = WordPad_3.Text = string.Empty;//���ԭ������
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch  //�����쳣
            {
               
                MessageBox.Show("����ʧ�ܣ������µ�¼��");
            }
        }
       

    }
}