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
    public partial class Frm_XiuGaiYongHu : Form
    {
        public Frm_XiuGaiYongHu()
        {
            InitializeComponent();
        }

        private void tool_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tool_UserAdd_Click(object sender, EventArgs e) //��ʾ��Ӵ���
        {
            Frm_JiaYongHu frm_jyh = new Frm_JiaYongHu();
            frm_jyh.Text = "������û�";
            frm_jyh.ShowDialog();
            frm_jyh.Dispose();
            ShowAllUser();//���¼����û���Ϣ
        }

        private void tool_UserPop_Click(object sender, EventArgs e) //��ʾ�޸��û�Ȩ�޴���
        {
            if (!CheckHavaSelected())//����Ƿ��в�������
            {
                return; //δѡ���κ��û�������ִֹ��
            }
            if (CheckIsCurrent())//����Ƿ�Ϊ��ǰ�û� ����ִ�в���
            {
                return;
            }

            Frm_QuanXian frm_qx = new Frm_QuanXian();
            frm_qx.Text = "�޸��û�Ȩ��";
            frm_qx.QxUserName = dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString();//���ݵ�ǰ�������û���
            frm_qx.ShowDialog();
            frm_qx.Dispose();
            
        }
        private void ShowAllUser() //��ѯ�����û���Ϣ����ʾ
        {
            string sql = "select Uid  ,Pwd from tb_Login"; //sql ���
            MyDBControls.GetConn();   //�������ݿ�
            DataSet ds = MyDBControls.GetDataSet(sql); //�õ����ݲ���ʾ
            dgv_userInfo.DataSource = ds.Tables[0];
            MyDBControls.CloseConn(); //�ر�����
            //�����û���Ϣ
            GSJ_DESC myDesc = new GSJ_DESC("@gsj");
            for (int i = 0; i < dgv_userInfo.Rows.Count; i++)
            {
                for (int y = 0; y < dgv_userInfo.Rows[i].Cells.Count; y++)
                {
                    
                    if (y < dgv_userInfo.Rows[i].Cells.Count)//��֤���û���ϢҪ����
                    {
                       
                        dgv_userInfo.Rows[i].Cells[y].Value = myDesc.Decry(dgv_userInfo.Rows[i].Cells[y].Value.ToString());
                    }
                }
            }
            dgv_userInfo.Columns[1].Visible = false;

        }
        private void Frm_XiuGaiYongHu_Load(object sender, EventArgs e)
        {
            //�����Ѵ����û���Ϣ
            ShowAllUser();
        }
        private bool CheckHavaSelected()//����Ƿ���ѡ����û�  û���򷵻� false
        {
            if (dgv_userInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("��ѡ��Ҫ�������û�!");
                return false;
            }
            return true;
        }
        private bool CheckIsCurrent() //����Ƿ�Ϊѡ����Ƿ�Ϊ��ǰ�û� �����򷵻� false
        {
            if (dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString() == FrmMain.P_currentUserName)
            {
                MessageBox.Show("����ɾ����ǰ�û����޸ĵ�ǰ�û�Ȩ��!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void tool_UserUpdate_Click(object sender, EventArgs e) //��ʾ�޸Ĵ���
        {
            if (!CheckHavaSelected())//����Ƿ��в�������
            {
                return; //δѡ���κ��û�������ִֹ��
            }
            Frm_JiaYongHu frm_jyh = new Frm_JiaYongHu();
            frm_jyh.Text = "�޸�����";
            frm_jyh.UidStr = dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString();//ѡ�е��û���
            frm_jyh.PwdStr = dgv_userInfo.SelectedRows[0].Cells[1].Value.ToString();//ѡ�е�����
            frm_jyh.IsAdd = false;//���´˲���Ϊ�޸�
            frm_jyh.ShowDialog();
            frm_jyh.Dispose();
            ShowAllUser();//���¼����û���Ϣ
        }

        private void tool_UserDelete_Click(object sender, EventArgs e)//ɾ���û�
        {   
            if (!CheckHavaSelected())//����Ƿ��в�������
            {
                return; //δѡ���κ��û�������ִֹ��
            }
            if (CheckIsCurrent())//����Ƿ�Ϊ��ǰ�û� ����ִ�в���
            {
                return; 
            }
            //ȷ���Ƿ����
            if (MessageBox.Show("���Ҫɾ����", "����", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                MessageBox.Show("������ȡ��!");
                return;
            } 
            try
            {
                //
                GSJ_DESC myDesc = new GSJ_DESC("@gsj");
                MyDBControls.GetConn(); //������
                string delStr="delete from tb_Userpope where Uid='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString()) + "'";//ɾ����Ӧ��Ȩ����Ϣ
                MyDBControls.ExecNonQuery(delStr);
                                         //ѡ�е��û���
                string delSql = "delete from tb_Login where Uid='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[0].Value.ToString()) + "' and Pwd='" +myDesc.Encry(dgv_userInfo.SelectedRows[0].Cells[1].Value.ToString()) + "'";
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delSql)) > 0) //ִ��ɾ��
                {
                    MessageBox.Show("ɾ���ɹ�!");
                }
                MyDBControls.CloseConn();//�ر�����
                ShowAllUser();//���¼����û���Ϣ
            }
            catch 
            {

                
                ShowAllUser();//���¼����û���Ϣ
            }
        }
       
    }
}