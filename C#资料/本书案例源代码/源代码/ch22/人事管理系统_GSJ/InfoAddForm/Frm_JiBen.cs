using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_JiBen : Form
    {
        public Frm_JiBen()
        {
            InitializeComponent();
        }
        string operaTable = "";//��ǰ����Ҫ���������ݱ���
        string operaColumn = "";//����
        private void Frm_JiBen_Load(object sender, EventArgs e)
        {
            #region ���ݱ������ж���Ҫ��ȡ����������
                        switch (this.Text)
                        { 
                            case "�����������":
                                operaTable = "tb_Folk";
                                operaColumn = "FolkName";
                                break;
                            case "�Ļ��̶�����":
                                operaTable = "tb_Kultur";
                                operaColumn = "KulturName";
                                break;
                            case "ְ���������":
                                operaTable = "tb_EmployeeGenre";
                                operaColumn = "EmployeeName";
                                break;
                            case "������ò����":
                                operaTable = "tb_Visage";
                                operaColumn = "VisageName";
                                break;
                            case "�����������":
                                operaTable = "tb_Branch";
                                operaColumn = "BranchName";
                                break;
                            case "�����������":
                                operaTable = "tb_Laborage";
                                operaColumn = "LaborageName";
                                break;
                            case "ְ���������":
                                operaTable = "tb_Business";
                                operaColumn = "BusinessName";
                                break;
                            case "ְ���������":
                                operaTable = "tb_Duthcall";
                                operaColumn = "DuthcallName";
                                break;
                            case "�����������":
                                operaTable = "tb_RPKind";
                                operaColumn = "RPKind";
                                break;
                            case "���±��������":
                                operaTable = "tb_WordPad";
                                operaColumn = "WordPad";
                                break;
                            default: MessageBox.Show("���ݱ�δȷ��!");
                                break;
                        }
            #endregion
            //ΪlistView������
               AddItems();
        }
        private void AddItems() //�����ݿ���ȡ���ݲ��ӵ� ListView ��
        {
            #region �������
            try
            {
                string Sql = "select " + operaColumn + " from " + operaTable; //sql���
                MyDBControls.GetConn();     //������
                SqlDataReader sdr = MyDBControls.GetDataReader(Sql);//��ȡ����
                while (sdr.Read())
                {
                    ltb_show.Items.Add(sdr[0]); //��һ�ӵ� listView��
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch 
            {
                this.Close();
            }

            #endregion
        }
        private bool DoValidate()//����֤
        {
            //��֤�Ƿ�Ϊ��
            if (txt_content.Text.Trim() == string.Empty)
            {
                MessageBox.Show("���������/�޸ĵ�����!");
                txt_content.Focus();
                return false;
            }
            else
            {
                //��֤�Ƿ��Ѵ��ڴ�����
                for (int i = 0; i < ltb_show.Items.Count; i++)
                {
                    if (ltb_show.Items[i].ToString() == txt_content.Text.Trim())
                    {
                        MessageBox.Show("�Ѵ��ڴ���Ϣ!");
                        txt_content.Focus();
                        return false;
                    }
                }
            }
            
            return true;

        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            #region ��֤
            //�Ƿ���Ҫ���ĵ���
            if (ltb_show.SelectedItem == null)
            {
                return;
            }
            if (!DoValidate()) //��֤��Ч��
            {
                return;
            }
            #endregion
            string UpdStr = "update " + operaTable + " set " + operaColumn + "='" + txt_content.Text.Trim() + "' where " + operaColumn +"='"+ ltb_show.SelectedItem.ToString()+"'";
            #region �޸�����
            try
            {
                MyDBControls.GetConn(); //�������ݿ�
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(UpdStr)) > 0)
                {
                    ltb_show.Items.Add(txt_content.Text.Trim());//��ӵ� listview ��
                    ltb_show.Items.Clear();//���ԭ������
                    AddItems(); //�������
                    MessageBox.Show("�޸ĳɹ�!");
                    txt_content.Text = string.Empty;//������������
                }
                MyDBControls.CloseConn(); //�ر����ݿ�
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                {
                    MessageBox.Show("�������ݳ��Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                    txt_content.Focus();
                    return;
                }
               
            } 
            #endregion
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            #region ��֤�������Ч��
            if (!DoValidate())
            {
                return;
            }
            #endregion
            #region �������
            string insertSql = "insert into " + operaTable + " values('" + txt_content.Text.Trim() + "')";
            try
            {
                MyDBControls.GetConn(); //�������ݿ�
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(insertSql)) > 0)
                {
                    ltb_show.Items.Add(txt_content.Text.Trim());//��ӵ� listview ��
                    MessageBox.Show("��ӳɹ�!");
                    txt_content.Text = string.Empty;//������������
                }
                MyDBControls.CloseConn(); //�ر����ݿ�
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                {
                    MessageBox.Show("�������ݳ��Ȳ��Ϸ�,��󳤶�Ϊ20λ��ĸ��10������!");
                    
                    
                }
                if (err.Message.IndexOf("�������﷨����") != -1)
                {
                    MessageBox.Show("�������ݲ��Ϸ�!");
                    
                }
                txt_content.Focus();
            }
            #endregion
        }

        private void ltb_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //�޸İ�ť ɾ����ť ����
            if (ltb_show.SelectedItem!=null)
            {
                btn_del.Enabled = true;
                btn_update.Enabled = true; 
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ltb_show.SelectedItem = null;
            btn_del.Enabled = false;
            btn_update.Enabled = false;
            txt_content.Focus();//�����
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (ltb_show.SelectedItem == null)
            {
                MessageBox.Show("��ѡ��Ҫɾ��������!");
                return;
            }
            //sql ���
            string delStr="delete from "+operaTable+" where "+operaColumn+"='"+ltb_show.SelectedItem.ToString()+"'";
            #region ɾ������
            try
            { 
                MyDBControls.GetConn();     //������
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delStr)) > 0)
                {
                    ltb_show.Items.Clear();//���ԭ������
                    AddItems(); //�������
                    MessageBox.Show("ɾ���ɹ�!");
                    
                }
                MyDBControls.CloseConn(); //�ر�����
            }
            catch 
            {
               MessageBox.Show("����ʧ��");
            }

            #endregion

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
       
    }
}