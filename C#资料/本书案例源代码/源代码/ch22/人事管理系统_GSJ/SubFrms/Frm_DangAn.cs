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
using Word;
namespace ���¹���ϵͳ_GSJ
{
    public partial class Frm_DangAn : Form
    {
        public Frm_DangAn()
        {
            InitializeComponent();
        }
        string imgPath = "";//ͼƬ·��
        private string operaTable = "";//ָ�������˵����������ݱ�
        private DataGridView currentDGV;//����ҳ�������datagridview
        byte[] imgBytes = new byte[1024];//��ͼ��ʹ�õ�����
        string lastOperaSql = "";//��¼�ϴβ���Ϊ�����޸ĺ�ɾ������и���
        string showThisUser = "";//�Ƿ�������Ҫ��ʾ����Ϣ(�����,���ʾԱ�����)
        public string ShowThisUser
        {
            get { return showThisUser; }
            set { showThisUser = value; }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //��֤����
            if (!DoValitPrimary())
            {
                return;
            }

            #region ����sql���
            //ID	ְ�����	int identit	  
            string insertSql = string.Format("insert into tb_Stuffbusic values('{30}','{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}',{10},"
                                                                             + "'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}',"
                                                                             + "'{21}',{22},'{23}','{24}',{25},'{26}','{27}','{28}',{29})",
                                                                             SSS_0.Text.Trim(),//StuffName	ְ������	Varchar��20��	//0 0��ʾ����Ӧ�Ŀؼ����
                                                                             SSS_1.Text.Trim(), //Folk	����	Varchar��20��	        //1
                                                                             SSS_2.Text, //Birthday	��������	DateTime	    //2
                                                                             SSS_3.Text.Trim(),//Age	����	Int	                    //3
                                                                             SSS_4.SelectedItem.ToString(),//Kultur	�Ļ��̶�	Varchar��14��	4
                                                                             SSS_5.SelectedItem.ToString(),//Marriage	����	Varchar��4��	    5
                                                                             SSS_6.SelectedItem.ToString(),//Sex	�Ա�	Varchar��4��	        6
                                                                             SSS_7.Text,                     //Visage	������ò	Varchar��20��	7 
                                                                             SSS_8.Text,                    //IDCard	���֤��	Varchar��20��	8
                                                                             SSS_9.Text,                    //WorkDate	��λ����ʱ��	DateTime	9
                                                                             SSS_10.Text.Trim(),            //WorkLength	����	Int	            10
                                                                             SSS_11.SelectedItem.ToString(),//Employee	ְ������	Varchar��20��	11
                                                                             SSS_12.SelectedItem.ToString(), //Business	ְ������	Varchar��10��	12
                                                                             SSS_13.SelectedItem.ToString(),//Laborage	�������	Varchar��10��	13
                                                                             SSS_14.SelectedItem.ToString(),//Branch	�������	Varchar��20��	14
                                                                             SSS_15.SelectedItem.ToString(),//Duthcall	ְ�����	Varchar��20��	15
                                                                             SSS_16.Text.Trim(), //Phone	�绰	Varchar��14��	        16
                                                                             SSS_17.Text.Trim(), //Handset	�ֻ�	Varchar��11��	    17
                                                                             SSS_18.Text.Trim(),//School	��ҵѧУ	Varchar��50��	18
                                                                             SSS_19.Text.Trim(), //Speciality	����רҵ	Varchar��20��19	
                                                                             SSS_20.Text, //GraduateDate	��ҵʱ��	DateTime	20
                                                                             SSS_21.Text.Trim(),//Address	��ͥסַ	Varchar��50��	21
                                                                             "@imgBytes",//Photo	������Ƭ	Image	            22
                                                                             SSS_23.SelectedItem.ToString(),//BeAware	ʡ	Varchar��30��	        23
                                                                             SSS_24.SelectedItem.ToString(),//City	��	Varchar��30��	            24
                                                                             SSS_25.Text,//M_Pay	�¹���	Money	                25
                                                                             SSS_26.Text,//Bank	�����˺�	Varchar��20��	    26
                                                                             SSS_27.Text,//Pact_B	��ͬ��ʼ����	DateTime	27
                                                                             SSS_28.Text,//Pact_E	��ͬ��������	DateTime	28
                                                                             SSS_29.Text,//Pact_Y	��ͬ����	Float	        29
                                                                             SSS.Text.Trim()
                                                                             );
            #endregion
            #region ��ͼƬתΪ����

            if (imgPath != "")
            {

                try
                {
                    FileStream imgFs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);//�ļ���
                    imgBytes = new byte[imgFs.Length];
                    BinaryReader imgBr = new BinaryReader(imgFs);//��ȡ������
                    imgBytes = imgBr.ReadBytes((int)imgFs.Length);
                }
                catch
                {


                }
                //


            }
            #endregion
            //ִ�б���
            try
            {
                MyDBControls.GetConn();//������
                if (Convert.ToInt32(MyDBControls.SaveImage(insertSql, imgBytes)) > 0)
                {
                    MessageBox.Show("����ɹ�!");
                }
                MyDBControls.CloseConn();//�ر�����
                ClearControl(tp1.Controls);//��տؼ�
                Img_Clear_Click(sender, e);//���ͼƬ��Ϣ
                MakeIdNo();//�����±��
            }
            catch (Exception err)//�����쳣
            {
                if (err.Message.IndexOf("���ض��ַ��������������") != -1)
                {
                    MessageBox.Show("�������ݳ��Ȳ��Ϸ�!");

                    return;
                }
                if (err.Message.IndexOf("un2") != -1)//un2 �����ݿ��е�Լ����,������֤��Ψһ
                {
                    MessageBox.Show("�Ѵ��ڴ����֤��!");
                    return;
                }
                if (err.Message.IndexOf("UN") != -1)//UN �����ݿ��е�Լ����,���Ա����ź�Ψһ
                {
                    MessageBox.Show("�Ѵ��ڴ�Ա�����!");
                    return;
                }
                MessageBox.Show("�������������Ƿ�Ϸ�!");
            }

            //MessageBox.Show(insertSql);
        }
        private bool DoValitPrimary()//��֤������Ϣ��������
        {
            //���
            if (SSS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("��Ų���Ϊ��!");
                SSS.Focus();
                return false;
            }
            //���� ����Ƿ��,��Ϊ��ʱҪ�����Ϊ���� ����ĸ
            if (SSS_0.Text.Trim() == string.Empty || !DoValidate.CheckName(SSS_0.Text.Trim()))
            {
                MessageBox.Show("����ӦΪ���ֻ�Ӣ��!");
                return false;
            }
            //���֤��
            if (SSS_8.Text.Trim().Length != 20 || SSS_8.Text.Trim().IndexOf(" ") != -1)//���֤��18λ 2λ-
            {
                MessageBox.Show("���֤�Ų��Ϸ�!");
                return false;
            }
            if (SSS_8.Text.Substring(7, 4) != SSS_2.Value.Year.ToString() || Convert.ToInt16(SSS_8.Text.Substring(11, 2)).ToString() != SSS_2.Value.Month.ToString() || Convert.ToInt16(SSS_8.Text.Substring(13, 2)).ToString() != SSS_2.Value.Day.ToString())
            {
                MessageBox.Show("���֤�Ų���ȷ!");
                return false;
            }
            //�����ʺ�
            if (SSS_26.Text.Trim() == string.Empty || SSS_26.Text.Trim().Length < 15 || SSS_26.Text.Trim().IndexOf(" ") != -1)
            {
                MessageBox.Show("�����ʺŲ��Ϸ���");
                return false;
            }
            //�ֻ���
            if (SSS_17.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckCellPhone(SSS_17.Text.Trim()))
                {
                    MessageBox.Show("�ֻ��Ų��Ϸ�!");
                    return false;
                }
            }
            //�̶��绰
            if (SSS_16.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(SSS_16.Text.Trim()))
                {
                    MessageBox.Show("�̶��绰��ʽ��Ϊ:������λ����-8λ����!");
                    return false;
                }
            }
            //��֤��ͬ����

            if (!DoValidate.DoValitTwoDatetime(SSS_27.Value.Date.ToString(), SSS_28.Value.Date.ToString()))
            {
                MessageBox.Show("��ͬ���ڲ��Ϸ�!");
                return false;
            }
            //��������
            if (SSS_3.Text == "0")
            {
                MessageBox.Show("�������ڲ��Ϸ�!");
                return false;
            }
            //����
            try
            {
                if (Convert.ToDecimal(SSS_10.Text) < 0)
                {
                    MessageBox.Show("��������!");
                    return false;
                }
            }
            catch
            {

                MessageBox.Show("��������!");
                return false;
            }
            //����
            try
            {
                if (Convert.ToDecimal(SSS_25.Text) < 0)
                {
                    MessageBox.Show("��������!");
                    return false;
                }

            }
            catch
            {

                MessageBox.Show("��������!");
                return false;
            }
            return true;
        }
        private bool needClose = false;//��֤������Ϣ������ʱҪ�ر�
        private void Frm_DangAn_Load(object sender, EventArgs e)
        {
            #region ��ʼ����ѡ��

            //���ƹ���ʱ�䡢������������ʱ�䡢��ͥ��ϵ�еĳ������ڡ����ֵΪ��ǰ����
            SSS_9.MaxDate = DateTime.Now;
            G_2.MaxDate = DateTime.Now;
            F_3.MaxDate = DateTime.Now;

            //��ѯ����ѡ�е�һ��
            cbox_type.SelectedIndex = 0;
            //�Ա�ѡ�е�һ��
            SSS_6.SelectedIndex = 0;
            //����״̬ѡ�е�һ��
            SSS_5.SelectedIndex = 0;

            //�������
            string sql = "select * from tb_Folk";//����sql���
            InitCombox(sql, SSS_1);
            //����Ļ��̶�
            sql = "select * from tb_Kultur";
            InitCombox(sql, SSS_4);
            //���������ò
            sql = "select * from tb_Visage";
            InitCombox(sql, SSS_7);//ְ��������Ϣ�е�������ò
            InitCombox(sql, F_5);//��ͥ��ϵ�е�������ò
            //ʡ
            sql = "select id, BeAware from tb_City";
            InitCombox(sql, SSS_23);
            //��
            sql = "select id, City from tb_city where BeAware='�㶫ʡ'";
            InitCombox(sql, SSS_24);
            //�������
            sql = "select * from tb_Laborage";
            InitCombox(sql, SSS_13);
            //ְ�����
            sql = "select * from tb_Business";
            InitCombox(sql, SSS_12);
            //ְ�����
            sql = "select * from tb_Duthcall";
            InitCombox(sql, SSS_15);
            //�������
            sql = "select * from tb_Branch";
            InitCombox(sql, SSS_14);
            //ְ�����
            sql = "select * from tb_EmployeeGenre";
            InitCombox(sql, SSS_11);
            //�������
            sql = "select * from tb_RPKind";
            InitCombox(sql, R_1);
            //���
            MakeIdNo();

            ////�ж��Ƿ���������ʾ������(������ѯ,���Ѵ������ʱ������������ʾ������)
            if (showThisUser != "")
            { //��Ҫ��ʾ������
                string showThisUsersql = "select stu_id,stuffname from tb_stuffbusic where stu_id='" + showThisUser + "'";
                try
                {
                    MyDBControls.GetConn();
                    dgv_Info.DataSource = MyDBControls.GetDataSet(showThisUsersql).Tables[0];
                    MyDBControls.CloseConn();
                    //��¼�˴β�������ˢ��
                    lastOperaSql = showThisUsersql;
                    //��ʾ��Ա����Ϣ
                    ShowInfo(showThisUser);

                }
                catch
                { }
            }
            ////
            if (needClose)
            {
                MessageBox.Show("�������ݲ����������Ƚ��л�����Ϣ���ã�");
                this.Close();
            }
            #endregion
        }
        /// <summary>
        /// ��ʼ����ѡ�Ŀؼ�
        /// </summary>
        /// <param name="sql">Ҫ��ѯ������</param>
        /// <param name="cmb">Ҫ���Ŀؼ�</param>
        private void InitCombox(string sql, ComboBox cmb)//����ļ����¼�����乩ѡ��� CombBox ���Ļ����� ������ò ��
        {
            try
            {
                MyDBControls.GetConn();//�����ݿ�����
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //��ȡ���ݲ��ӵ���Ӧλ��
                    {
                        if (cmb.Items.Contains(sdr[1].ToString()) == false)
                        {
                            cmb.Items.Add(sdr[1].ToString());
                        } //ֻ���ǲ�ѯ���Ϊ���в�������Ϊ�ڶ��е�
                        cmb.SelectedIndex = 0;
                    }
                }
                else//û�м�¼��ʾ�������ݱ�û�м�¼  ���ܽ����������
                {
                    needClose = true;//�������ݲ�����


                }
                sdr.Close();//�ر� datareader
                MyDBControls.CloseConn();//�ر����ݿ�����
            }
            catch
            {
                this.Close();
            }
        }

        private void SSS_23_SelectedIndexChanged(object sender, EventArgs e)//ʡ�ݸı�ʱ�ı���Ӧ����
        {//����sql���
            string sql = string.Format("select id,city from tb_city where BeAware='{0}'", SSS_23.SelectedItem.ToString());
            SSS_24.Items.Clear();//���ԭ��
            InitCombox(sql, SSS_24);//������ֵ
        }

        private void SSS_2_ValueChanged(object sender, EventArgs e)//�Զ���������  ��������ʱ��ʾΪ 0
        {
            int years = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(SSS_2.Value.Year);
            //if (years <= 0)
            //{
            //    MessageBox.Show("������������!");
            //}
            SSS_3.Text = years > 0 ? years.ToString() : "0";
        }

        private void SSS_28_ValueChanged(object sender, EventArgs e)//�Զ������ͬ����
        {
            TimeSpan ts = SSS_28.Value - SSS_27.Value;
            if (ts.Days <= 0)//������ڳ�������
            {
                //MessageBox.Show("��ͬ��������,����!");
                SSS_29.Text = "0";
            }
            string years = (ts.Days / 365.0).ToString();
            SSS_29.Text = years.Length >= 3 ? years.Substring(0, 3) : years; //��ֹ����Ϊ����ʱ�޷���ǰ3λ

        }

        private void SSS_27_ValueChanged(object sender, EventArgs e)
        {
            SSS_28_ValueChanged(sender, e);
        }

        private void tbc_showInfo_SelectedIndexChanged(object sender, EventArgs e)//ѡ��ı䵱ǰҳʱ�ƶ���ť
        {
            //ÿ�θı�ʱ����ɾ��״̬��Ϊ������
            Part_Delete.Enabled = false;
            switch (tbc_showInfo.SelectedIndex)
            {
                case 1:
                    gp_SecMenu.Parent = tp2;//�ƶ������˵�
                    gb_MainMenu.Enabled = false;//һ���˵�������
                    operaTable = " tb_WorkResume ";//����������
                    currentDGV = dgv_G;
                    break;
                case 2:
                    gp_SecMenu.Parent = tp3;//�ƶ������˵�
                    gb_MainMenu.Enabled = false;//һ���˵�
                    operaTable = " tb_Family ";//��ͥ��ϵ��
                    currentDGV = dgv_F;
                    break;
                case 3:
                    gp_SecMenu.Parent = tp4;//
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_TrainNote ";//��ѵ��¼��
                    currentDGV = dgv_T;
                    break;
                case 4: gp_SecMenu.Parent = tp5;
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_Randp ";//����
                    currentDGV = dgv_R;
                    break;
                case 5: //���һҳ��Ϊ���ܲ�ͬ����ʹ�õ����Ĳ˵�
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_Individual ";//���˼��
                    break;
                default: gb_MainMenu.Enabled = true;
                    break;
            }
        }
        private void MakeIdNo()//�Զ����
        {
            try
            {
                int id = 0;
                string sql = "select count(*) from tb_Stuffbusic";
                MyDBControls.GetConn();
                object obj = MyDBControls.ExecSca(sql);
                if (obj.ToString() == "")
                {

                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(obj) + 1;
                }
                SSS.Text = "S" + id.ToString();
            }
            catch //�쳣
            {
                this.Close();
                //MessageBox.Show(err.Message);
            }

        }

        private void Img_Save_Click(object sender, EventArgs e)//���ͼ��
        {
            ofd_FindImage.Filter = "ͼ���ļ�(*.jpg *.bmp *.png)|*.jpg; *.bmp; *.png";
            ofd_FindImage.Title = "ѡ��";
            if (DialogResult.OK == ofd_FindImage.ShowDialog())
            {
                imgPath = ofd_FindImage.FileName;
                S_Image.Image = Image.FromFile(ofd_FindImage.FileName);
                Img_Clear.Enabled = true;
            }
        }

        private void Img_Clear_Click(object sender, EventArgs e)//ͼ�������ť
        {
            S_Image.Image = null;//���ͼ��
            imgPath = "";//ͼ��·��
            imgBytes = new byte[0];
        }
        /// <summary>
        /// ������ҳ�������Ϸ���
        /// </summary>
        /// <param name="operatb">���������ݱ�</param>
        /// <returns>����Ϸ�����true ���򷵻� false</returns>
        private bool CheckSecGroup(string operatb)//���ݵ�ǰ�����Ķ������������
        {
            switch (operatb)
            {
                case " tb_WorkResume "://��������
                    if (G_3.Text.Trim() == string.Empty || G_4.Text.Trim() == string.Empty || G_5.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("������������Ϣ��");
                        return false;
                    }
                    if (!DoValidate.DoValitTwoDatetime(G_1.Value.ToString(), G_2.Value.ToString()))
                    {
                        MessageBox.Show("�������ڲ��Ϸ���");
                        return false;
                    }
                    break;
                case " tb_Family "://��ͥ��ϵ
                    if (F_1.Text.Trim() == string.Empty || F_2.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("�������Ա���ƺ��뱾�˹�ϵ��");
                        return false;
                    }

                    break;
                case " tb_TrainNote "://��ѵ��¼
                    if (!DoValidate.DoValitTwoDatetime(T_3.Value.ToString(), T_4.Value.ToString()))
                    {
                        MessageBox.Show("���ڲ��Ϸ���");
                        return false;
                    }
                    try//�����ѵ����Ƿ�Ϸ�
                    {
                        Double dou = Convert.ToDouble(T_5.Text);
                        if (dou < 0)
                        {
                            MessageBox.Show("���ò��Ϸ���");
                            return false;
                        }
                    }
                    catch
                    {

                        MessageBox.Show("���ò��Ϸ���");
                        return false;
                    }
                    if (T_1.Text.Trim() == string.Empty || T_2.Text.Trim() == string.Empty || T_5.Text.Trim() == string.Empty || T_6.Text.Trim() == string.Empty || T_7.Text.Trim() == string.Empty || T_8.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("������������Ϣ��");
                        return false;
                    }
                    break;
                case " tb_Randp "://����
                    if (R_3.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("��׼�˲���Ϊ�գ�");
                        return false;
                    }
                    if (cbbox_re.Checked == true)//����ʱ
                    {
                        if (R_5.Text.Trim() == string.Empty || R_4.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("����ʱ���ԭ����Ϊ��");
                            return false;
                        }
                    }
                    break;
                case " tb_Individual "://���
                    if (Ind_Mome.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("��鲻��Ϊ�գ�");
                        return false;
                    }
                    break;

            }
            //ͨ����֤
            return true;
        }
        private void Part_Add_Click(object sender, EventArgs e)//����ҳ������
        {
            if (!CheckSecGroup(operaTable))
            {
                return;
            }
            //��鵱ǰ�������û��Ƿ��ѱ���
            if (!CheckCurrentUser())
            {
                return; //��ǰ�û�������Ϣδ���� ���ܽ��ж���ҳ��ı���
            }


            //���浱ǰ��Ϣ
            try
            {
                MyDBControls.GetConn();
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(CreateCommandText(operaTable))) > 0)
                {
                    MessageBox.Show("����ɹ�!");
                }
                MyDBControls.CloseConn();
                //ˢ��
                ShowInfo(SSS.Text.Trim());

                ClearControl(gp_SecMenu.Parent.Controls[0].Controls);//��տؼ�����


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }

        }
        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="cons">Ҫ��յĿؼ�����</param>
        private void ClearControl(Control.ControlCollection cons)//���ָ�����϶�������пؼ�
        {
            foreach (Control c in cons)
            {
                if (c.GetType().Name == "TextBox" || c.GetType().Name == "MaskedTextBox")
                {
                    c.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// ���ݵ�ǰҳ��������sql ���
        /// </summary>
        /// <param name="operaTb">��ǰҪ���������ݱ�</param>
        /// <returns>sql���</returns>
        private string CreateCommandText(string operaTb)//���ݲ����ı����sql���
        {
            string sql = "";
            switch (operaTb) //���ݲ����ı�Ĳ�ͬ���� ��ͬ��sql���
            {
                case " tb_WorkResume ":
                    sql = string.Format("insert into  tb_WorkResume values('{0}','{1}','{2}','{3}','{4}','{5}')", SSS.Text, G_1.Text, G_2.Text, G_5.Text.Trim(), G_3.Text.Trim(), G_4.Text.Trim());

                    break;
                case " tb_Family ":
                    sql = string.Format("insert into tb_Family values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", SSS.Text, F_1.Text.Trim(), F_2.Text.Trim(), F_3.Text, F_7.Text.Trim(), F_4.Text.Trim(), F_5.SelectedItem.ToString());
                    break;
                case " tb_TrainNote ":
                    sql = string.Format("insert into tb_TrainNote values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}')", SSS.Text, T_1.Text.Trim(), T_3.Text, T_4.Text, T_2.Text.Trim(), T_6.Text.Trim(), T_8.Text.Trim(), T_5.Text.Trim(), T_7.Text.Trim());
                    break;
                case " tb_Randp ":
                    if (cbbox_re.Checked == true)
                    {
                        sql = string.Format("insert into tb_Randp values('{0}','{1}','{2}','{3}','{4}','{5}')", SSS.Text, R_1.SelectedItem.ToString(), R_2.Text, R_3.Text, R_4.Text, R_5.Text.Trim());
                    }
                    else
                    {
                        sql = string.Format("insert into tb_Randp values('{0}','{1}','{2}','{3}',null,null)", SSS.Text, R_1.SelectedItem.ToString(), R_2.Text, R_3.Text);

                    }
                    break;
                case " tb_Individual ":
                    sql = string.Format("insert into tb_Individual values('{0}','{1}')", SSS.Text, Ind_Mome.Text);
                    break;

            }
            return sql;
        }

        private bool CheckCurrentUser()//��Ӷ���ҳ����Ϣǰ   ��鵱ǰ�����Ķ����Ƿ�Ϊ�Ѵ��ڶ��� ���ڷ��� true
        {
            string sql = "select count(*) from tb_Stuffbusic where stu_id='" + SSS.Text.Trim() + "'";
            try
            {
                MyDBControls.GetConn();
                if (Convert.ToInt32(MyDBControls.ExecSca(sql)) > 0)
                {
                    MyDBControls.CloseConn();
                    return true;//��ʾ�м�¼
                }
                else
                {
                    MyDBControls.CloseConn();
                    MessageBox.Show("���ȱ��浱ǰԱ��������Ϣ!!!");
                    return false;//��ʾ��ǰ�û�δ����
                }

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                return false;
            }
        }

        private void SSS_9_ValueChanged(object sender, EventArgs e)//����ʱ��ı�ʱ�Զ����㹤��
        {

            SSS_10.Text = (DateTime.Now.Date.Year - SSS_9.Value.Date.Year).ToString();
        }

        private void SSS_TextChanged(object sender, EventArgs e)//��ʾ��ǰ�������û�
        {
            txt_current.Text = SSS.Text;
        }

        private void btn_all_Click(object sender, EventArgs e)//��ʾ������Ϣ
        {
            string sql = string.Format("select stu_id,stuffname from tb_stuffbusic");//sql���
            try
            {
                MyDBControls.GetConn();//������
                dgv_Info.DataSource = MyDBControls.GetDataSet(sql).Tables[0];//��ȡ���ݲ���ʾ
                MyDBControls.CloseConn();//�ر�����
                lastOperaSql = sql;//��¼�˴β�������ˢ��
            }
            catch (Exception err)//�����쳣
            {

                MessageBox.Show(err.Message);
            }
        }

        private void btn_find_Click(object sender, EventArgs e)//��ѯ
        {
            string findType = "";//��ѯ����
            switch (cbox_type.SelectedItem.ToString())
            {
                case "��������ѯ":
                    findType = "StuffName";
                    break;
                case "���Ա��ѯ":
                    findType = "Sex";
                    break;
                case "�������ѯ":
                    findType = "Folk";
                    break;
                case "���Ļ��̶Ȳ�ѯ":
                    findType = "Kultur";
                    break;
                case "��������ò��ѯ":
                    findType = "Visage";
                    break;
                case "��ְ������ѯ":
                    findType = "Employee";
                    break;
                case "��ְ��ְ���ѯ":
                    findType = "Business";
                    break;
                case "��ְ�����Ų�ѯ":
                    findType = "Branch";
                    break;
                case "��ְ������ѯ":
                    findType = "Duthcall";
                    break;
                case "����������ѯ":
                    findType = "Laborage";
                    break;
            }
            string sql = string.Format("select stu_id,stuffname from tb_stuffbusic where {0}='{1}'", findType, txt_condition.Text);
            //MessageBox.Show(sql);

            try
            {
                MyDBControls.GetConn();
                dgv_Info.DataSource = MyDBControls.GetDataSet(sql).Tables[0];
                MyDBControls.CloseConn();
                //��¼�˴β�������ˢ��
                lastOperaSql = sql;
            }
            catch
            {


            }
        }

        private void cbox_type_SelectedIndexChanged(object sender, EventArgs e)//�ı��ѯ����ʱ���ѡ����
        {
            string findType = "";//��ѯ����
            switch (cbox_type.SelectedItem.ToString())
            {
                case "��������ѯ":
                    findType = "StuffName";
                    break;
                case "���Ա��ѯ":
                    findType = "Sex";
                    break;
                case "�������ѯ":
                    findType = "Folk";
                    break;
                case "���Ļ��̶Ȳ�ѯ":
                    findType = "Kultur";
                    break;
                case "��������ò��ѯ":
                    findType = "Visage";
                    break;
                case "��ְ������ѯ":
                    findType = "Employee";
                    break;
                case "��ְ��ְ���ѯ":
                    findType = "Business";
                    break;
                case "��ְ�����Ų�ѯ":
                    findType = "Branch";
                    break;
                case "��ְ������ѯ":
                    findType = "Duthcall";
                    break;
                case "����������ѯ":
                    findType = "Laborage";
                    break;
            }
            string sql = string.Format("select {0} from tb_stuffbusic ", findType);
            try
            {
                MyDBControls.GetConn(); //������
                SqlDataReader sdr = MyDBControls.GetDataReader(sql); //��ȡ����
                txt_condition.Items.Clear();//���ԭ������
                txt_condition.Text = string.Empty;
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //��ӵ�������
                    {
                        if (!txt_condition.Items.Contains(sdr[0].ToString()))//������������
                        {
                            txt_condition.Items.Add(sdr[0].ToString());
                        }
                    }
                }
                sdr.Close(); //�ر�
                MyDBControls.CloseConn();
            }
            catch (Exception err)//�����쳣
            {

                MessageBox.Show(err.Message);
            }

        }

        private void dgv_Info_CellClick(object sender, DataGridViewCellEventArgs e)//ѡ��Ҫ�����Ķ���
        {
            if (dgv_Info.SelectedRows.Count > 0 && dgv_Info.SelectedCells[0].Value != null)
            {
                //MessageBox.Show(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());
                ShowInfo(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());//��ʾѡ�е�Ա����Ϣ
                btn_Add.Enabled = false;//�޸�ʱ������ӷ�ֹ�ظ�
            }
        }
        /// <summary>
        /// ��ѯĳ��Ա����������Ϣ
        /// </summary>
        /// <param name="stuId">��ǰ������Ա�����</param>
        private void ShowInfo(string stuId)//����ѡ����ʾ��Ա����Ϣ
        {
            //�޸� ɾ����ť����
            btn_update.Enabled = btn_Delete.Enabled = true;
            #region ������Ϣҳ�����Ϣ��ʾ
            string selSql = string.Format("select * from tb_Stuffbusic where Stu_id ='{0}'", stuId);
            #region ���ݱ��е���Ϣ��ʽ
            //ID	ְ�����	int identit	 
            //SSS_0.Text.Trim(),//StuffName	ְ������	Varchar��20��	//0 0��ʾ����Ӧ�Ŀؼ����
            //SSS_1.Text.Trim(), //Folk	����	Varchar��20��	        //1
            //SSS_2.Text, //Birthday	��������	DateTime	    //2
            //SSS_3.Text.Trim(),//Age	����	Int	                    //3
            //SSS_4.SelectedItem.ToString(),//Kultur	�Ļ��̶�	Varchar��14��	4
            //SSS_5.SelectedItem.ToString(),//Marriage	����	Varchar��4��	    5
            //SSS_6.SelectedItem.ToString(),//Sex	�Ա�	Varchar��4��	        6
            //SSS_7.Text,                     //Visage	������ò	Varchar��20��	7 
            //SSS_8.Text,                    //IDCard	���֤��	Varchar��20��	8
            //SSS_9.Text,                    //WorkDate	��λ����ʱ��	DateTime	9
            //SSS_10.Text.Trim(),            //WorkLength	����	Int	            10
            //SSS_11.SelectedItem.ToString(),//Employee	ְ������	Varchar��20��	11
            //SSS_12.SelectedItem.ToString(), //Business	ְ������	Varchar��10��	12
            //SSS_13.SelectedItem.ToString(),//Laborage	�������	Varchar��10��	13
            //SSS_14.SelectedItem.ToString(),//Branch	�������	Varchar��20��	14
            //SSS_15.SelectedItem.ToString(),//Duthcall	ְ�����	Varchar��20��	15
            //SSS_16.Text.Trim(), //Phone	�绰	Varchar��14��	        16
            //SSS_17.Text.Trim(), //Handset	�ֻ�	Varchar��11��	    17
            //SSS_18.Text.Trim(),//School	��ҵѧУ	Varchar��50��	18
            //SSS_19.Text.Trim(), //Speciality	����רҵ	Varchar��20��19	
            //SSS_20.Text, //GraduateDate	��ҵʱ��	DateTime	20
            //SSS_21.Text.Trim(),//Address	��ͥסַ	Varchar��50��	21
            //"@imgBytes",//Photo	������Ƭ	Image	            22
            //SSS_23.SelectedItem.ToString(),//BeAware	ʡ	Varchar��30��	        23
            //SSS_24.SelectedItem.ToString(),//City	��	Varchar��30��	            24
            //SSS_25.Text,//M_Pay	�¹���	Money	                25
            //SSS_26.Text,//Bank	�����˺�	Varchar��20��	    26
            //SSS_27.Text,//Pact_B	��ͬ��ʼ����	DateTime	27
            //SSS_28.Text,//Pact_E	��ͬ��������	DateTime	28
            //SSS_29.Text,//Pact_Y	��ͬ����	Float	        29
            //SSS.Text.Trim()

            #endregion
            try
            {
                MyDBControls.GetConn();
                SqlDataReader sdr = MyDBControls.GetDataReader(selSql);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        SSS.Text = sdr[1].ToString();
                        SSS_0.Text = sdr[2].ToString();
                        SSS_1.Text = sdr[3].ToString();
                        SSS_2.Text = sdr[4].ToString(); //Birthday	����            }
                        SSS_3.Text = sdr[5].ToString();//Age	����        }
                        SSS_4.Text = sdr[6].ToString();
                        SSS_5.Text = sdr[7].ToString();
                        SSS_6.Text = sdr[8].ToString();
                        SSS_7.Text = sdr[9].ToString();
                        SSS_8.Text = sdr[10].ToString();
                        SSS_9.Text = sdr[11].ToString();
                        SSS_10.Text = sdr[12].ToString();
                        SSS_11.Text = sdr[13].ToString();
                        SSS_12.Text = sdr[14].ToString();
                        SSS_13.Text = sdr[15].ToString();
                        SSS_14.Text = sdr[16].ToString();
                        SSS_15.Text = sdr[17].ToString();
                        SSS_16.Text = sdr[18].ToString();
                        SSS_17.Text = sdr[19].ToString(); //Handset
                        SSS_18.Text = sdr[20].ToString();//School	
                        SSS_19.Text = sdr[21].ToString(); //Special
                        SSS_20.Value = Convert.ToDateTime(sdr[22].ToString()); //GraduateDate	
                        SSS_21.Text = sdr[23].ToString(); ;//Address	
                        imgBytes = (byte[])sdr[24];//Photo	������Ƭ
                        SSS_23.Text = sdr[25].ToString();
                        SSS_24.Text = sdr[26].ToString();
                        SSS_25.Text = sdr[27].ToString();//M_Pay	�¹���	
                        SSS_26.Text = sdr[28].ToString();//Bank	�����˺�
                        SSS_27.Value = Convert.ToDateTime(sdr[29].ToString());//Pact_B	��ͬ��ʼ
                        SSS_28.Value = Convert.ToDateTime(sdr[30].ToString());//Pact_E	��ͬ����
                        SSS_29.Text = sdr[31].ToString();//Pact_Y	��ͬ����
                        //����ͼ��
                        try
                        {
                            byte[] img = (byte[])sdr[24]; //��ͼ��ͼ����ʾ
                            MemoryStream ms = new MemoryStream(img);
                            S_Image.Image = Image.FromStream(ms);
                        }
                        catch //����ʱ��ʾ���ʱ��û�����ͼ��
                        {

                            S_Image.Image = null;
                        }
                    }
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region ��������
            string selSql2 = string.Format("select BeginDat as ��ʼʱ��,EndDate as ����ʱ��,workunit as ������λ,Branch as ����,Business as ְ��,id from tb_WorkResume where sut_Id ='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_G.DataSource = MyDBControls.GetDataSet(selSql2).Tables[0];
                dgv_G.Columns[dgv_G.Columns.Count - 1].Visible = false;//����id��
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region ��ͥ��ϵ
            string selSql3 = string.Format("select leaguerName as ��Ա����,Nexus as �뱾�˹�ϵ,Birthdate as ��������,WorkUnit as ������λ,Business as ְ��,visage as ������ò ,id from tb_Family where Sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_F.DataSource = MyDBControls.GetDataSet(selSql3).Tables[0];
                dgv_F.Columns[dgv_F.Columns.Count - 1].Visible = false;//����id
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region ��ѵ��¼
            string selSql4 = string.Format("select Trainfashion as ��ѵ��ʽ,BeginDate as ��ʼʱ��,EndDate as ����ʱ��,Speciality as ��ѵרҵ,TrainUnit as ��ѵ��λ,KulturMemo as ��ѵ����,Charger as ����,Effects as Ч�� ,id from tb_TrainNote where Sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_T.DataSource = MyDBControls.GetDataSet(selSql4).Tables[0];
                dgv_T.Columns[dgv_T.Columns.Count - 1].Visible = false;//  ����id   
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region ���ͼ�¼
            try
            {
                string selSql5 = string.Format("select RPKind as ���,RPDate as ʱ��,sealMan as ��׼��,QuashDate as ����ʱ��,QuashWhys as ԭ�� ,id from tb_Randp where sut_ID='{0}'", stuId);
                MyDBControls.GetConn();
                dgv_R.DataSource = MyDBControls.GetDataSet(selSql5).Tables[0];
                dgv_R.Columns[dgv_R.Columns.Count - 1].Visible = false;//���� id
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region ���˼���
            string selSql6 = string.Format("select Memo from tb_Individual where sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                SqlDataReader sdr6 = MyDBControls.GetDataReader(selSql6);
                if (sdr6.HasRows)//�м�¼ʱ��ʾ
                {
                    while (sdr6.Read())
                    {
                        Ind_Mome.Text = sdr6[0].ToString();

                    }
                }
                else//û�м�¼ʱ���
                {
                    Ind_Mome.Text = string.Empty;
                }
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
        }

        private void btn_First_Click(object sender, EventArgs e)//�鿴��һ����¼
        {
            try
            {
                dgv_Info.Rows[0].Selected = true;//��һ��ѡ��
                ShowInfo(dgv_Info.Rows[0].Cells[0].Value.ToString());//��ʾ��һ��
            }
            catch
            {


            }
        }

        private void btn_End_Click(object sender, EventArgs e)//�鿴���һ����¼
        {
            try
            {
                dgv_Info.Rows[dgv_Info.Rows.Count - 1].Selected = true;//���һ��ѡ��
                ShowInfo(dgv_Info.Rows[dgv_Info.Rows.Count - 1].Cells[0].Value.ToString());//��ʾ��һ��
            }
            catch
            {


            }
        }

        private void btn_Back_Click(object sender, EventArgs e)//�鿴��һ����¼
        {
            try
            {
                int currentRow = dgv_Info.SelectedRows[0].Index;//��ǰѡ���е�������
                int backRow = 0;
                if ((currentRow - 1) >= 0) //�ж��Ƿ�Ϊ��һ�� �������һֱѡ�е�һ��
                {
                    backRow = currentRow - 1;
                }
                else                     //
                {
                    MessageBox.Show("�ѵ���һ��!");
                    backRow = 0;
                }
                dgv_Info.Rows[backRow].Selected = true;//ǰһ��ѡ��
                ShowInfo(dgv_Info.Rows[backRow].Cells[0].Value.ToString());//��ʾǰһ��
            }
            catch
            {


            }
        }

        private void btn_next_Click(object sender, EventArgs e)//�鿴��һ����¼
        {
            try
            {
                int currentRow = dgv_Info.SelectedRows[0].Index;//��ǰѡ���е�������
                int nextRow = dgv_Info.Rows.Count - 1;//��һ�е����� Ĭ�ϵ�������������
                if ((currentRow + 1) < dgv_Info.Rows.Count)//�ж��Ƿ������һ��
                {
                    nextRow = currentRow + 1;
                }
                else
                {
                    MessageBox.Show("�ѵ����һ��!");
                }
                dgv_Info.Rows[nextRow].Selected = true;//��һ��ѡ��
                ShowInfo(dgv_Info.Rows[nextRow].Cells[0].Value.ToString());//��ʾ��һ��Ա����Ϣ
            }
            catch
            {


            }
        }

        private void btn_update_Click(object sender, EventArgs e)//�޸�
        {
            //��֤����
            if (!DoValitPrimary())
            {
                return;
            }
            #region �޸ĵ�ǰԱ����Ϣ
            string delStr = string.Format("delete from tb_Stuffbusic where Stu_id='{0}'", SSS.Text.Trim());
            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(delStr);
                MyDBControls.CloseConn();
                btn_Add_Click(sender, e);

            }
            catch
            {

                MessageBox.Show("������!");
            }
            #endregion
            #region ˢ��
            try
            {
                MyDBControls.GetConn();
                dgv_Info.DataSource = MyDBControls.GetDataSet(lastOperaSql).Tables[0];
                MyDBControls.CloseConn();
            }
            catch
            {
            }
            #endregion
            btn_Delete.Enabled = btn_update.Enabled = false;//��ť������
        }

        private void btn_Delete_Click(object sender, EventArgs e)//ɾ��
        {
            if (MessageBox.Show("�˲������ɻָ�,ȷ��ɾ����?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                MessageBox.Show("������ȡ��!");
                return;
            }
            string delStr = string.Format("delete from tb_Stuffbusic where stu_id='{0}'", SSS.Text.Trim());
            string delStr2 = string.Format("delete from tb_WorkResume where sut_id='{0}'", SSS.Text.Trim());
            string delStr3 = string.Format("delete from tb_Family where sut_id='{0}'", SSS.Text.Trim());
            string delStr4 = string.Format("delete from tb_TrainNote where sut_id='{0}'", SSS.Text.Trim());
            string delStr5 = string.Format("delete from tb_Randp where sut_id='{0}'", SSS.Text.Trim());
            string delStr6 = string.Format("delete from tb_Individual where sut_id='{0}'", SSS.Text.Trim());
            try
            {
                MyDBControls.GetConn();//������
                MyDBControls.ExecNonQuery(delStr);//ִ��ɾ��
                MyDBControls.ExecNonQuery(delStr2);//ִ��ɾ��
                MyDBControls.ExecNonQuery(delStr3);//ִ��ɾ��
                MyDBControls.ExecNonQuery(delStr4);//ִ��ɾ��
                MyDBControls.ExecNonQuery(delStr5);//ִ��ɾ��
                MyDBControls.ExecNonQuery(delStr6);//ִ��ɾ��
                MyDBControls.CloseConn();//�ر�����
                btn_Back_Click(sender, e);//��ѡ�������һ��
                Img_Clear_Click(sender, e);//���ͼƬ��Ϣ


                MessageBox.Show("ɾ���ɹ�!");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #region ˢ��
            try
            {
                MyDBControls.GetConn();
                dgv_Info.DataSource = MyDBControls.GetDataSet(lastOperaSql).Tables[0];
                MyDBControls.CloseConn();
            }
            catch
            {
            }
            #endregion
            btn_Delete.Enabled = btn_update.Enabled = false;//��ť������
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = btn_update.Enabled = false;//��ť������
            
            ClearControl(tp1.Controls);//��տؼ�����
            SSS_2_ValueChanged(sender, e);//��ʾ�����ֹ���ֿ�ֵ
            SSS_9_ValueChanged(sender, e);//����
            SSS_28_ValueChanged(sender, e);//��ͬ����
            MakeIdNo();//�ָ�Ϊ���״̬
            //�������ҳ�������
            G_3.Text = G_4.Text = G_5.Text = string.Empty;
            dgv_G.DataSource = null;

            F_1.Text = F_2.Text = F_7.Text = F_4.Text = string.Empty;
            dgv_F.DataSource = null;

            T_1.Text = T_2.Text = T_5.Text = T_6.Text = T_7.Text = T_8.Text = string.Empty;
            dgv_T.DataSource = null;

            R_3.Text = R_5.Text = string.Empty;
            dgv_R.DataSource = null;

            Ind_Mome.Text = string.Empty;
            //���ͼƬ
            S_Image.Image = null;
            imgPath = "";
            imgBytes = new byte[0];
            //ȡ���޸� ���������
            btn_Add.Enabled = true;
        }

        private void dgv_G_CellClick(object sender, DataGridViewCellEventArgs e)//��ѡ��������ʱ
        {
            if (dgv_G.SelectedRows.Count > 0 && dgv_G.SelectedCells[0].Value != null)
            {
                //��ʼ ����ʱ�� ��λ ���� ְ��  
                G_1.Text = dgv_G.SelectedRows[0].Cells[0].Value.ToString();
                G_2.Text = dgv_G.SelectedRows[0].Cells[1].Value.ToString();
                G_3.Text = dgv_G.SelectedRows[0].Cells[3].Value.ToString();
                G_4.Text = dgv_G.SelectedRows[0].Cells[4].Value.ToString();
                G_5.Text = dgv_G.SelectedRows[0].Cells[2].Value.ToString();
                Part_Delete.Enabled = true;//ɾ����ť����

            }
        }

        private void Part_Delete_Click(object sender, EventArgs e)//�����˵���ɾ��
        {
            //ȷ�ϲ���
            if (MessageBox.Show("�˲������ɻָ�,ȷ��ɾ����?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                MessageBox.Show("������ȡ��!");
                return;
            }//����sql���
            string delSql = string.Format("delete from {0} where Sut_ID='{1}' and id={2}", operaTable, SSS.Text.Trim(), currentDGV.SelectedRows[0].Cells[currentDGV.Columns.Count - 1].Value.ToString());

            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(delSql);//ִ��ɾ��
                MyDBControls.CloseConn();
                ShowInfo(SSS.Text.Trim());//ˢ��
                //��տؼ�
                ClearControl(gp_SecMenu.Parent.Controls[0].Controls);//��տؼ�����
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void dgv_F_CellClick(object sender, DataGridViewCellEventArgs e)//��ͥ��ϵ
        {
            if (dgv_F.SelectedRows.Count > 0 && dgv_F.SelectedCells[0].Value != null)
            {
                //��Ա���� ���˹�ϵ �������� ��λ ְ�� ������ò
                F_1.Text = dgv_F.SelectedRows[0].Cells[0].Value.ToString();
                F_2.Text = dgv_F.SelectedRows[0].Cells[1].Value.ToString();
                F_3.Text = dgv_F.SelectedRows[0].Cells[2].Value.ToString();
                F_4.Text = dgv_F.SelectedRows[0].Cells[4].Value.ToString();
                F_5.Text = dgv_F.SelectedRows[0].Cells[5].Value.ToString();
                F_7.Text = dgv_F.SelectedRows[0].Cells[3].Value.ToString();
                Part_Delete.Enabled = true;//ɾ����ť����

            }
        }

        private void dgv_T_CellClick(object sender, DataGridViewCellEventArgs e)//��ѵ��¼
        {


            if (dgv_T.SelectedRows.Count > 0 && dgv_T.SelectedCells[0].Value != null)
            {
                //��ʽ ��ʼ ����ʱ�� רҵ ��ѵ��λ ��ѵ���� ���� Ч��
                T_1.Text = dgv_T.SelectedRows[0].Cells[0].Value.ToString();
                T_2.Text = dgv_T.SelectedRows[0].Cells[3].Value.ToString();
                T_3.Text = dgv_T.SelectedRows[0].Cells[1].Value.ToString();
                T_4.Text = dgv_T.SelectedRows[0].Cells[2].Value.ToString();
                T_5.Text = dgv_T.SelectedRows[0].Cells[6].Value.ToString();
                T_6.Text = dgv_T.SelectedRows[0].Cells[4].Value.ToString();
                T_7.Text = dgv_T.SelectedRows[0].Cells[7].Value.ToString();
                T_8.Text = dgv_T.SelectedRows[0].Cells[5].Value.ToString();
                Part_Delete.Enabled = true;//ɾ����ť����

            }
        }

        private void dgv_R_CellClick(object sender, DataGridViewCellEventArgs e)//����
        {
            if (dgv_R.SelectedRows.Count > 0 && dgv_R.SelectedCells[0].Value != null)
            {
                //��� ʱ�� ��׼�� ����ʱ�� ԭ��  
                R_1.Text = dgv_R.SelectedRows[0].Cells[0].Value.ToString();
                R_2.Text = dgv_R.SelectedRows[0].Cells[1].Value.ToString();
                R_3.Text = dgv_R.SelectedRows[0].Cells[2].Value.ToString();
                R_4.Text = dgv_R.SelectedRows[0].Cells[3].Value.ToString();
                R_5.Text = dgv_R.SelectedRows[0].Cells[4].Value.ToString();
                Part_Delete.Enabled = true;//ɾ����ť����

            }
        }

        private void cbbox_re_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbox_re.Checked)//Ҫ����ʱ
            {
                R_4.Enabled = R_5.Enabled = true;//����ʱ���ԭ������
            }
            else
            {
                R_4.Enabled = R_5.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)//�������
        {
            //��鵱ǰ�������û��Ƿ��ѱ���
            if (!CheckCurrentUser())
            {
                return; //��ǰ�û�������Ϣδ���� ���ܽ��ж���ҳ��ı���
            }
            string delSql = string.Format("delete from {0} where sut_Id='{1}'", operaTable, SSS.Text.Trim());

            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(delSql);
                MyDBControls.ExecNonQuery(CreateCommandText(operaTable));
                MyDBControls.CloseConn();
                MessageBox.Show("����ɹ�!");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void btn_CreatDoc_Click(object sender, EventArgs e)//����Word
        {
            //����Ƿ��пɲ�����
            if (dgv_Info.RowCount <= 0)
            {
                MessageBox.Show("��ǰû�пɵ�����Ա����Ϣ!");
                return;
            }
            Frm_CreateWord frm_CW = new Frm_CreateWord();
            frm_CW.StuId =dgv_Info.SelectedRows[0].Cells[0].Value.ToString()??SSS.Text;//Ա�����
            frm_CW.ShowDialog();
            frm_CW.Dispose();

        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Info_Sorted(object sender, EventArgs e)//�������ˢ�·�ֹ��ʾ��һ��
        {
            if (dgv_Info.SelectedRows.Count > 0 && dgv_Info.SelectedCells[0].Value != null)
            {
                //MessageBox.Show(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());
                ShowInfo(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());//��ʾѡ�е�Ա����Ϣ
                btn_Add.Enabled = false;//�޸�ʱ������ӷ�ֹ�ظ�
            }
        }

    }
}
