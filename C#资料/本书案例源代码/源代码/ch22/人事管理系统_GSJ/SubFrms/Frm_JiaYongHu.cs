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
    public partial class Frm_JiaYongHu : Form
    {
        public Frm_JiaYongHu()
        {
            InitializeComponent();
        }
        private string uidStr = "";//��ǰҪ�������û���,������û�ʱ����Ϊ��

        public string UidStr
        {
            get { return uidStr; }
            set { uidStr = value; }
        }
        private string pwdStr = "";//��ǰҪ����������,������û�ʱ����Ϊ��

        public string PwdStr
        {
            get { return pwdStr; }
            set { pwdStr = value; }
        }
        private bool isAdd = true;//�ж�����ӻ����޸�  

        public bool IsAdd
        {
            get { return isAdd; }
            set { isAdd = value; }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            #region ��֤��������
            if (text_Name.Text.Trim() == string.Empty || text_Pass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("�û��������벻����Ϊ��!");
                text_Name.Focus();
                return;

            }
            if (txt_Pwd2.Text != text_Pass.Text)
            {
                MessageBox.Show("���벻һ��,��������д!");
                txt_Pwd2.Text = text_Pass.Text = string.Empty;
                text_Pass.Focus();
                return;
            }
            #endregion
            #region �û���¼������
            GSJ_DESC myDesc = new GSJ_DESC("@gsj");
            string descryUser = myDesc.Encry(text_Name.Text.Trim());//���ܺ���û���
            string descryPwd = myDesc.Encry(text_Pass.Text.Trim());//���ܺ������
            #endregion
            if (IsAdd) //����û�ʱ����Ƿ��Ѵ��� 
            {
                #region ��֤�Ƿ��Ѵ��ڴ��û�

                string sql = "select count(*) from tb_Login where Uid='" + descryUser + "'";
                try
                {
                    MyDBControls.GetConn();//������
                    if (Convert.ToInt32(MyDBControls.ExecSca(sql)) > 0) //����Ƿ����
                    {
                        MessageBox.Show("�Ѵ��ڴ��û�!");
                        text_Name.Text = string.Empty; //���
                        text_Name.Focus(); //��ý���
                        return;
                    }
                    MyDBControls.CloseConn();//�ر�����
                }
                catch 
                {

                   
                    return; //����ʱ��������ִ��
                }

                #endregion
                #region ����û�
                //����û���\����
                string addUser = "insert into tb_Login values('" + descryUser + "','" + descryPwd + "')";
                string popeModel = "select popeName from tb_popeModel";//���Ȩ��ģ��
                DataSet popeDS;
                try
                {
                    MyDBControls.GetConn(); //������
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(addUser)) > 0) //ִ�����
                    {
                        
                        popeDS = MyDBControls.GetDataSet(popeModel);
                        for (int i = 0; i < popeDS.Tables[0].Rows.Count; i++)
                        { //��һ���Ȩ��
                            string popeSql = "insert into tb_UserPope values('"+descryUser+"','" + popeDS.Tables[0].Rows[i][0].ToString() + "',"+0+")";
                            //MessageBox.Show(popeSql);
                            MyDBControls.ExecNonQuery(popeSql);
                        }
                    }
                    
                    MyDBControls.CloseConn();//�ر�����
                    text_Name.Text = text_Pass.Text = txt_Pwd2.Text = string.Empty; //���
                    MessageBox.Show("��ӳɹ�!");
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                    {
                        MessageBox.Show("�������ݳ��Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                        
                        return;
                    }
                    
                }
                #endregion
            }
            else //�޸��û�ʱ
            {
                #region �޸��û���Ϣ
                //�޸����
                string updSql = "update tb_Login set Uid='" + descryUser + "',Pwd='" + descryUser + "'  where Uid='" + UidStr + "'";
                try
                {
                    MyDBControls.GetConn(); //������
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(updSql)) > 0) //ִ���޸�
                    {
                        text_Name.Text = text_Pass.Text = txt_Pwd2.Text = string.Empty; //���
                        MessageBox.Show("�޸ĳɹ�!");
                    }
                    MyDBControls.CloseConn();//�ر�����
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                    {
                        MessageBox.Show("�������ݳ��Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                       
                        return;
                    }
                    
                }
                #endregion
            }
            this.Close();
        }

        private void Frm_JiaYongHu_Load(object sender, EventArgs e)
        {
            text_Name.Text = UidStr; //����û���������  
            txt_Pwd2.Text = text_Pass.Text = PwdStr;

            //�޸�ʱ�û���Ϊֻ��
            if (!IsAdd) text_Name.ReadOnly = true;
            
        }
       
    }
}