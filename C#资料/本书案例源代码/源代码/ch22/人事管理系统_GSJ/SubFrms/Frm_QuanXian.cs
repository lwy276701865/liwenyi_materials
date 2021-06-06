using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using GSJ_Descryption;
namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_QuanXian : Form
    {
        private string qxUserName = "";//��ǰ�������û���
        GSJ_DESC myDesc;//���ܽ��ܶ���
        public string QxUserName
        {
            get { return qxUserName; }
            set { qxUserName = value; }
        }
        public Frm_QuanXian()
        {
            InitializeComponent();
        }
        //�������б�ʾȨ�޵Ŀؼ��ļ���
        Control.ControlCollection popeControls;
        private void Frm_QuanXian_Load(object sender, EventArgs e)
        {
            //
            myDesc = new GSJ_DESC("@gsj");
            //
            txt_userName.Text =QxUserName;//ȷ����ǰ�û�
            popeControls = this.groupBox2.Controls;
            DataSet popeDS=new DataSet();//�浱ǰ�û�����Ȩ����Ϣ
            // ��������Ȩ��������ذ�ť
            string popeSql="select PopeName,Pope from tb_UserPope where Uid ='"+myDesc.Encry(txt_userName.Text)+"'";
            try
            {
                MyDBControls.GetConn();
                popeDS = MyDBControls.GetDataSet(popeSql); //��ȡ��ǰ�û�������Ȩ����Ϣ
                MyDBControls.CloseConn();
            }
            catch 
            {

                MessageBox.Show("������ȡʧ��!");
                this.Close();
            }
            //��һ���ȷ����Ӧ��ť�Ƿ�Ϊѡ��
            for (int i = 0; i < popeDS.Tables[0].Rows.Count; i++)
            {
                foreach (Control c in popeControls)
                {
                    if (c.Text == popeDS.Tables[0].Rows[i][0].ToString())
                    {
                        if (popeDS.Tables[0].Rows[i][1].ToString() == "True")
                        {
                            ((CheckBox)c).Checked = true;
                        }
                    }
                }
            }
           
        }

        private void User_All_CheckedChanged(object sender, EventArgs e)//ʵ��ȫѡ����
        {
            if (User_All.Checked)
            {
                foreach (Control c in popeControls) //ȫѡ
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in popeControls)//ȫ��ȡ��ѡ��
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }

        private void User_Save_Click(object sender, EventArgs e)//�������
        {
            try
            {
                MyDBControls.GetConn();//������
                foreach (Control c in popeControls)//��һ����Ƿ��޸�����Ӧ��Ȩ��
                {
                    int flg = 0;  //ûѡ����Ϊ 0 ��ʾȨ�޲�����  ����Ϊ 1 ��ʾ����
                    if (((CheckBox)c).Checked)
                    {
                        flg = 1;
                    }

                    string sql = "update tb_UserPope set pope=" + flg + " where Uid='" +myDesc.Encry(txt_userName.Text) + "' and PopeName='" + c.Text + "'";
                    MyDBControls.ExecNonQuery(sql);
                }
                MyDBControls.CloseConn();//�ر�����
                MessageBox.Show("����ɹ�!");
                this.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void User_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}