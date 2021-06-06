using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Text.RegularExpressions;
namespace ���¹���ϵͳ_GSJ
{
    
    public partial class Frm_TongXun : Form
    {
        public Frm_TongXun()
        {
            InitializeComponent();
        }
        #region �޸�ʱʹ�õ�����
        string addStr1="";//����

        public string AddStr1
        {
            get { return addStr1; }
            set { addStr1 = value; }
        }
        string addStr2="��";//�Ա�

        public string AddStr2
        {
            get { return addStr2; }
            set { addStr2 = value; }
        }
        string addStr3;//��ͥ�绰

        public string AddStr3
        {
            get { return addStr3; }
            set { addStr3 = value; }
        }
        string addStr4;//QQ

        public string AddStr4
        {
            get { return addStr4; }
            set { addStr4 = value; }
        }
        string addStr5;//�����绰

        public string AddStr5
        {
            get { return addStr5; }
            set { addStr5 = value; }
        }
        string addStr6;//E-Mail

        public string AddStr6
        {
            get { return addStr6; }
            set { addStr6 = value; }
        }
        string addStr7;//�ֻ�

        public string AddStr7
        {
            get { return addStr7; }
            set { addStr7 = value; }
        }
        #endregion
        private void Frm_TongXun_Load(object sender, EventArgs e)
        {
           
            //�޸�ʱ�Զ���ֵ
            Address_1.Text = AddStr1;
            Address_2.Text = AddStr2;
            Address_3.Text = AddStr3;
            Address_4.Text = AddStr7;
            Address_5.Text = AddStr5;
            Address_6.Text = AddStr4;
            Address_7.Text = AddStr6;
            //
            if (addStr1 != string.Empty)
            {
                btn_save.Text = "�޸�";
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool DoValit()//todo:��֤��������
        { 
            //�û���
            if (Address_1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("�û�������Ϊ��!");
                return false;
            }
            
            //�ֻ���
            if (Address_4.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckCellPhone(Address_4.Text.Trim()))
                {
                    MessageBox.Show("�ֻ��Ų��Ϸ�!");
                    return false;
                }
            }
            //�̶��绰
            if (Address_3.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(Address_3.Text.Trim()))
                {
                    MessageBox.Show("�̶��绰��ʽ���Ϸ�!");
                    return false;
                }
            }
            //�����绰
            if (Address_5.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(Address_5.Text.Trim()))
                {
                    MessageBox.Show("�̶��绰��ʽ���Ϸ�!");
                    return false;
                }
            }
            //QQ
            if (Address_6.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckQQ(Address_6.Text.Trim()))
                {
                    MessageBox.Show("QQ�Ų��Ϸ�!");
                    return false;
                }
            }
            //E-Mail
            if (Address_7.Text.Trim() != string.Empty)//���벻Ϊ��ʱ
            {
                if (!DoValidate.CheckEMail(Address_7.Text.Trim()))
                {

                    MessageBox.Show("�����ʽ���Ϸ�!");
                    return false;
                }
            }
            return true;
        
        }
        private void btn_save_Click(object sender, EventArgs e)
        {  
            //��֤��������
            if (!DoValit())
            { return; }
            string sql="";//sql���
            #region �޸�ʱ
            if (btn_save.Text == "�޸�")
            {
                sql = string.Format("delete from tb_AddressBook where SutName='{0}' and Sex='{1}' and Phone='{2}' and QQ='{3}' and WorkPhone='{4}' and [E-Mail]='{5}' and Handset='{6}'",
                    AddStr1,
                    AddStr2,
                    AddStr3,
                    AddStr4,
                    AddStr5,
                    AddStr6,
                    AddStr7);
                try
                {
                    MyDBControls.GetConn(); //������
                    MyDBControls.ExecNonQuery(sql);
                    MyDBControls.CloseConn(); //�ر�����
                }
                catch (Exception err) //�����쳣
                {
                    MessageBox.Show(err.Message);
                }
            }
            #endregion
            #region ����ʱ
            
           //����sql���
                //����   �Ա� �绰    QQ  �����绰  E-Mail �ֻ�
                       sql = string.Format("insert into tb_AddressBook values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                       Address_1.Text.Trim(),
                       Address_2.SelectedItem.ToString(),
                       Address_3.Text.Trim(),
                       Address_6.Text.Trim(),
                       Address_5.Text.Trim(),
                       Address_7.Text.Trim(),
                       Address_4.Text.Trim());
                
           
            #endregion
            
         
            try
            {
                MyDBControls.GetConn(); //������
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(sql)) > 0)
                {
                    MessageBox.Show(btn_save.Text+"�ɹ�!"); //ִ�����
                    #region ���ԭ������
                    Address_1.Text = Address_3.Text = Address_4.Text = Address_5.Text = Address_6.Text = Address_7.Text = string.Empty;
                    #endregion
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch(Exception err) //�����쳣
            {

                if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                {
                    MessageBox.Show("���볤�Ȳ��Ϸ�!");

                    return;
                }
                MessageBox.Show("��ȷ�����ݿ��������Ӳ����������ݺϷ���");
            }
        }

       
    }
}