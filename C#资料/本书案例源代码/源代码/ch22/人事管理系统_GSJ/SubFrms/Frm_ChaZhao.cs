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
    public partial class Frm_ChaZhao : Form
    {
        public Frm_ChaZhao()
        {
            InitializeComponent();
        }

        private void Frm_ChaZhao_Load(object sender, EventArgs e)
        {
            
            //����Ĭ��ѡ����
            Find_Sex.SelectedIndex = 0;//�Ա�
            Find_Marriage.SelectedIndex = 0;//��
            Age_Sign.SelectedIndex = 0;//�����ʶ
            WorkLength_Sign.SelectedIndex = 0;//��������
            M_Pay_Sign.SelectedIndex = 0;//�¹���
            Pact_Y_Sign.SelectedIndex = 0;//��ͬ����

            MyDBControls.GetConn();//�����ݿ�����
            DoWork();
            MyDBControls.CloseConn();//�ر����ݿ����� 
            
        }
        /// <summary>
        /// ����ļ����¼�����乩ѡ��� CombBox ���Ļ����� ������ò ��
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="cmb">Ҫ���������б�</param>
        private void InitCombox(string sql, ComboBox cmb)//
        {
            try
            {
               // MyDBControls.GetConn();//�����ݿ�����
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //��ȡ���ݲ��ӵ���Ӧλ��
                    {
                        if (!cmb.Items.Contains(sdr[1]))
                        {
                            cmb.Items.Add(sdr[1].ToString()); //ֻ���ǲ�ѯ���Ϊ���в�������Ϊ�ڶ��е� 
                        }
                       
                    }
                }
                sdr.Close();//�ر� datareader
              //  MyDBControls.CloseConn();//�ر����ݿ�����
            }
            catch
            {

                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            StringBuilder findSql = new StringBuilder("select ");
            //Ҫ��ѯ������
            findSql.Append(" Stu_id as Ա�����,");
            findSql.Append(" StuffName as ְ������, ");
            findSql.Append(" Folk as ���� ,");
            findSql.Append(" Birthday as ��������, ");
            findSql.Append(" Age as ����, ");
            findSql.Append(" Kultur as �Ļ��̶�, ");
            findSql.Append(" Marriage  as ����, ");
            findSql.Append(" Sex as �Ա�, ");
            findSql.Append(" Visage as ������ò, ");
            findSql.Append(" IDCard as ���֤��, ");
            findSql.Append(" WorkDate as ��λ����ʱ��, ");
            findSql.Append(" WorkLength as ����, ");
            findSql.Append(" Employee as ְ������, ");
            findSql.Append(" Business as ְ������, ");
            findSql.Append(" Laborage as �������, ");
            findSql.Append(" Branch as �������, ");
            findSql.Append(" Duthcall as ְ�����, ");
            findSql.Append(" Phone as �绰, ");
            findSql.Append(" Handset as �ֻ�, ");
            findSql.Append(" School as ��ҵѧУ, ");
            findSql.Append(" Speciality as ����רҵ, ");
            findSql.Append(" GraduateDate as ��ҵʱ��, ");
            findSql.Append(" Address as ��ͥסַ, ");
            findSql.Append(" BeAware as ʡ, ");
            findSql.Append(" City as ��, ");
            findSql.Append(" M_Pay as �¹���, ");
            findSql.Append(" Bank as �����˺�, ");
            findSql.Append(" Pact_B as ��ͬ��ʼ����, ");
            findSql.Append(" Pact_E as ��ͬ��������, ");
            findSql.Append(" Pact_Y as ��ͬ���� ");
            
            //����
            findSql.Append(" from tb_Stuffbusic ");

            try
            {
                MyDBControls.GetConn();
                dgv_result.DataSource = MyDBControls.GetDataSet(findSql.ToString()).Tables[0];
                MyDBControls.CloseConn();
                dgv_result.Columns[0].Frozen = true;//�����һ��
            }
            catch 
            { }
        }
        /// <summary>
        /// �������������
        /// </summary>
        private void btn_clear_Click(object sender, EventArgs e)//�������
        {
            foreach (Control c in this.gb_basic.Controls)
            {
                if (c.GetType().Name == "ComboBox")
                {
                    c.Text = string.Empty;
                }
            }
            Find_Age.Text = Find_WorkLength.Text = Find_M_Pay.Text = Find_Pact_Y.Text = Find1_WorkDate.Text = Find2_WorkDate.Text =Find_Marriage.Text=Find_School.Text=Find_Speciality.Text=Find_BeAware.Text=Find_City.Text= string.Empty;

        }

        private void btn_find_Click(object sender, EventArgs e)//��ʼ����
        {
            string conditionType = "";
            if (rbt_and.Checked)//��ѯ����������
            {
                conditionType = " and ";
            }
            if (rbt_or.Checked)
            {
                conditionType = " or ";
            }
            #region ����sql���
            StringBuilder findSql = new StringBuilder("select ");
            //Ҫ��ѯ������
            findSql.Append(" Stu_id as Ա�����,");
            findSql.Append(" StuffName as ְ������, ");
            findSql.Append(" Folk as ���� ,");
            findSql.Append(" Birthday as ��������, ");
            findSql.Append(" Age as ����, ");
            findSql.Append(" Kultur as �Ļ��̶�, ");
            findSql.Append(" Marriage  as ����, ");
            findSql.Append(" Sex as �Ա�, ");
            findSql.Append(" Visage as ������ò, ");
            findSql.Append(" IDCard as ���֤��, ");
            findSql.Append(" WorkDate as ��λ����ʱ��, ");
            findSql.Append(" WorkLength as ����, ");
            findSql.Append(" Employee as ְ������, ");
            findSql.Append(" Business as ְ������, ");
            findSql.Append(" Laborage as �������, ");
            findSql.Append(" Branch as �������, ");
            findSql.Append(" Duthcall as ְ�����, ");
            findSql.Append(" Phone as �绰, ");
            findSql.Append(" Handset as �ֻ�, ");
            findSql.Append(" School as ��ҵѧУ, ");
            findSql.Append(" Speciality as ����רҵ, ");
            findSql.Append(" GraduateDate as ��ҵʱ��, ");
            findSql.Append(" Address as ��ͥסַ, ");
            findSql.Append(" BeAware as ʡ, ");
            findSql.Append(" City as ��, ");
            findSql.Append(" M_Pay as �¹���, ");
            findSql.Append(" Bank as �����˺�, ");
            findSql.Append(" Pact_B as ��ͬ��ʼ����, ");
            findSql.Append(" Pact_E as ��ͬ��������, ");
            findSql.Append(" Pact_Y as ��ͬ���� ");
            //����
            findSql.Append(" from tb_Stuffbusic ");

            //����
            findSql.Append(" where ");
            findSql.Append(" Sex ='" + Find_Sex.SelectedItem.ToString() + "' ");

            if (Find_Folk.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Folk ='" + Find_Folk.Text.Trim() + "' ");
            }

            if (Find_Kultur.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Kultur ='" + Find_Kultur.Text.Trim() + "' ");
            }
            if (Find_Visage.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Visage ='" + Find_Visage.Text.Trim() + "' ");
            }
            if (Find_Employee.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Employee ='" + Find_Employee.Text.Trim() + "' ");
            }
            if (Find_Business.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Business ='" + Find_Business.Text.Trim() + "' ");
            }
            if (Find_Branch.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Branch ='" + Find_Branch.Text.Trim() + "' ");
            }
            if (Find_Duthcall.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Duthcall ='" + Find_Duthcall.Text.Trim() + "' ");
            }
            if (Find_Marriage.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Marriage ='" + Find_Marriage.Text.Trim() + "' ");
            }
            if (Find_BeAware.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" BeAware ='" + Find_BeAware.Text.Trim() + "' ");
            }
            if (Find_City.Text.Trim() != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" City ='" + Find_City.Text.Trim() + "' ");
            }
            if (Find_School.Text.Trim()!=string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" School ='" + Find_School.Text.Trim() + "' "); 
            }
            if (Find_Speciality.Text.Trim()!=string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Speciality ='" + Find_Speciality.Text.Trim() + "' ");
                
            }
            //����������ֻ��Ҫ���ݲ�Ϊ��ʱ�ż�������Ҫ�� or ����ǰ�� ��Ϊ��ȷ�����滹Ҫ��Ҫ��
            if (Find1_WorkDate.Text != string.Empty && Find2_WorkDate.Text != string.Empty)
            {
                try  //�������������Ƿ�Ϊ�Ϸ����� �����
                {
                    DateTime dtTest = new DateTime();
                    dtTest = Convert.ToDateTime(Find1_WorkDate.Text);
                    dtTest = Convert.ToDateTime(Find2_WorkDate.Text);
                    findSql.Append(conditionType);
                    findSql.Append(" WorkDate between '" + Find1_WorkDate.Text + "' and '" + Find2_WorkDate.Text + "' ");
                }
                catch//���ڲ��Ϸ�������
                {
                }

            }

            if (Find_Age.Text != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Age " + Age_Sign.SelectedItem.ToString() + Find_Age.Text);

            }

            if (Find_WorkLength.Text != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" WorkLength " + WorkLength_Sign.SelectedItem.ToString() + Find_WorkLength.Text);

            }

            if (Find_M_Pay.Text != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" M_Pay " + M_Pay_Sign.SelectedItem.ToString()  + Find_M_Pay.Text);

            }

            if (Find_Pact_Y.Text != string.Empty)
            {
                findSql.Append(conditionType);
                findSql.Append(" Pact_Y " + Pact_Y_Sign.SelectedItem.ToString()  + Find_Pact_Y.Text);
            }


            // MessageBox.Show(findSql.ToString());
            #endregion
            try
            {
                //richTextBox1.Text = findSql.ToString();
                MyDBControls.GetConn();
                dgv_result.DataSource = MyDBControls.GetDataSet(findSql.ToString()).Tables[0];
                MyDBControls.CloseConn();

                dgv_result.Columns[0].Frozen = true;//�����һ��
            }
            catch 
            {

                
            }
        }

        private void dgv_result_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)//��ʾ������Ϣ
        {
            if (FrmMain.P_haveDAAccess)//�ж�Ȩ��
            {
                Frm_DangAn frm_da = new Frm_DangAn();
                frm_da.ShowThisUser = dgv_result.SelectedRows[0].Cells[0].Value.ToString();
                frm_da.ShowDialog();
                frm_da.Dispose();
            }
            else
            {
                MessageBox.Show("��ǰ�û���Ȩ����!");
            }
        }

        private void DoWork()//���ؿ�ѡ����
        {
           
            //�������
            string sql = "select * from tb_Folk";//����sql���
            InitCombox(sql, Find_Folk);
            //����Ļ��̶�
            sql = "select * from tb_Kultur";
            InitCombox(sql, Find_Kultur);
            //���������ò
            sql = "select * from tb_Visage";
            InitCombox(sql, Find_Visage);//ְ��������Ϣ�е�������ò
            //ʡ                                        //todo:ʡ���ж�Ӧ
            sql = "select id, BeAware from tb_City";
            InitCombox(sql, Find_BeAware);
            //��
            sql = "select id, City from tb_city";
            InitCombox(sql, Find_City);
            //�������
            sql = "select * from tb_Laborage";
            InitCombox(sql, Find_Laborage);
            //ְ�����
            sql = "select * from tb_Business";
            InitCombox(sql, Find_Business);
            //ְ�����
            sql = "select * from tb_Duthcall";
            InitCombox(sql, Find_Duthcall);
            //�������
            sql = "select * from tb_Branch";
            InitCombox(sql, Find_Branch);
            //ְ�����
            sql = "select * from tb_EmployeeGenre";
            InitCombox(sql, Find_Employee);
            //��ҵѧУ
            sql = "select id,school from tb_Stuffbusic";
            InitCombox(sql, Find_School);
            //����רҵ
            sql = "select id,speciality from tb_Stuffbusic";
            InitCombox(sql, Find_Speciality);
        }

    }
}