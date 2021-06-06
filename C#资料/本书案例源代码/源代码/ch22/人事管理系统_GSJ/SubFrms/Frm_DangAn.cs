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
namespace 人事管理系统_GSJ
{
    public partial class Frm_DangAn : Form
    {
        public Frm_DangAn()
        {
            InitializeComponent();
        }
        string imgPath = "";//图片路径
        private string operaTable = "";//指定二级菜单操作的数据表
        private DataGridView currentDGV;//二级页面操作的datagridview
        byte[] imgBytes = new byte[1024];//存图像使用的数组
        string lastOperaSql = "";//记录上次操作为了在修改和删除后进行更新
        string showThisUser = "";//是否有立即要显示的信息(如果有,则表示员工编号)
        public string ShowThisUser
        {
            get { return showThisUser; }
            set { showThisUser = value; }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //验证输入
            if (!DoValitPrimary())
            {
                return;
            }

            #region 产生sql语句
            //ID	职工编号	int identit	  
            string insertSql = string.Format("insert into tb_Stuffbusic values('{30}','{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}',{10},"
                                                                             + "'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}',"
                                                                             + "'{21}',{22},'{23}','{24}',{25},'{26}','{27}','{28}',{29})",
                                                                             SSS_0.Text.Trim(),//StuffName	职工姓名	Varchar（20）	//0 0表示所对应的控件编号
                                                                             SSS_1.Text.Trim(), //Folk	民族	Varchar（20）	        //1
                                                                             SSS_2.Text, //Birthday	出生日期	DateTime	    //2
                                                                             SSS_3.Text.Trim(),//Age	年龄	Int	                    //3
                                                                             SSS_4.SelectedItem.ToString(),//Kultur	文化程度	Varchar（14）	4
                                                                             SSS_5.SelectedItem.ToString(),//Marriage	婚姻	Varchar（4）	    5
                                                                             SSS_6.SelectedItem.ToString(),//Sex	性别	Varchar（4）	        6
                                                                             SSS_7.Text,                     //Visage	政治面貌	Varchar（20）	7 
                                                                             SSS_8.Text,                    //IDCard	身份证号	Varchar（20）	8
                                                                             SSS_9.Text,                    //WorkDate	单位工作时间	DateTime	9
                                                                             SSS_10.Text.Trim(),            //WorkLength	工龄	Int	            10
                                                                             SSS_11.SelectedItem.ToString(),//Employee	职工类型	Varchar（20）	11
                                                                             SSS_12.SelectedItem.ToString(), //Business	职务类型	Varchar（10）	12
                                                                             SSS_13.SelectedItem.ToString(),//Laborage	工资类别	Varchar（10）	13
                                                                             SSS_14.SelectedItem.ToString(),//Branch	部门类别	Varchar（20）	14
                                                                             SSS_15.SelectedItem.ToString(),//Duthcall	职称类别	Varchar（20）	15
                                                                             SSS_16.Text.Trim(), //Phone	电话	Varchar（14）	        16
                                                                             SSS_17.Text.Trim(), //Handset	手机	Varchar（11）	    17
                                                                             SSS_18.Text.Trim(),//School	毕业学校	Varchar（50）	18
                                                                             SSS_19.Text.Trim(), //Speciality	主修专业	Varchar（20）19	
                                                                             SSS_20.Text, //GraduateDate	毕业时间	DateTime	20
                                                                             SSS_21.Text.Trim(),//Address	家庭住址	Varchar（50）	21
                                                                             "@imgBytes",//Photo	个人照片	Image	            22
                                                                             SSS_23.SelectedItem.ToString(),//BeAware	省	Varchar（30）	        23
                                                                             SSS_24.SelectedItem.ToString(),//City	市	Varchar（30）	            24
                                                                             SSS_25.Text,//M_Pay	月工资	Money	                25
                                                                             SSS_26.Text,//Bank	银行账号	Varchar（20）	    26
                                                                             SSS_27.Text,//Pact_B	合同起始日期	DateTime	27
                                                                             SSS_28.Text,//Pact_E	合同结束日期	DateTime	28
                                                                             SSS_29.Text,//Pact_Y	合同年限	Float	        29
                                                                             SSS.Text.Trim()
                                                                             );
            #endregion
            #region 将图片转为参数

            if (imgPath != "")
            {

                try
                {
                    FileStream imgFs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);//文件流
                    imgBytes = new byte[imgFs.Length];
                    BinaryReader imgBr = new BinaryReader(imgFs);//读取数据流
                    imgBytes = imgBr.ReadBytes((int)imgFs.Length);
                }
                catch
                {


                }
                //


            }
            #endregion
            //执行保存
            try
            {
                MyDBControls.GetConn();//打开连接
                if (Convert.ToInt32(MyDBControls.SaveImage(insertSql, imgBytes)) > 0)
                {
                    MessageBox.Show("保存成功!");
                }
                MyDBControls.CloseConn();//关闭连接
                ClearControl(tp1.Controls);//清空控件
                Img_Clear_Click(sender, e);//清除图片信息
                MakeIdNo();//产生新编号
            }
            catch (Exception err)//处理异常
            {
                if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                {
                    MessageBox.Show("输入内容长度不合法!");

                    return;
                }
                if (err.Message.IndexOf("un2") != -1)//un2 是数据库中的约束名,检查身份证号唯一
                {
                    MessageBox.Show("已存在此身份证号!");
                    return;
                }
                if (err.Message.IndexOf("UN") != -1)//UN 是数据库中的约束名,检查员工编号号唯一
                {
                    MessageBox.Show("已存在此员工编号!");
                    return;
                }
                MessageBox.Show("请检查输入内容是否合法!");
            }

            //MessageBox.Show(insertSql);
        }
        private bool DoValitPrimary()//验证基本信息输入内容
        {
            //编号
            if (SSS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("编号不能为空!");
                SSS.Focus();
                return false;
            }
            //姓名 检查是否空,不为空时要求必须为汉字 或字母
            if (SSS_0.Text.Trim() == string.Empty || !DoValidate.CheckName(SSS_0.Text.Trim()))
            {
                MessageBox.Show("姓名应为汉字或英文!");
                return false;
            }
            //身份证号
            if (SSS_8.Text.Trim().Length != 20 || SSS_8.Text.Trim().IndexOf(" ") != -1)//身份证号18位 2位-
            {
                MessageBox.Show("身份证号不合法!");
                return false;
            }
            if (SSS_8.Text.Substring(7, 4) != SSS_2.Value.Year.ToString() || Convert.ToInt16(SSS_8.Text.Substring(11, 2)).ToString() != SSS_2.Value.Month.ToString() || Convert.ToInt16(SSS_8.Text.Substring(13, 2)).ToString() != SSS_2.Value.Day.ToString())
            {
                MessageBox.Show("身份证号不正确!");
                return false;
            }
            //银行帐号
            if (SSS_26.Text.Trim() == string.Empty || SSS_26.Text.Trim().Length < 15 || SSS_26.Text.Trim().IndexOf(" ") != -1)
            {
                MessageBox.Show("银行帐号不合法！");
                return false;
            }
            //手机号
            if (SSS_17.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckCellPhone(SSS_17.Text.Trim()))
                {
                    MessageBox.Show("手机号不合法!");
                    return false;
                }
            }
            //固定电话
            if (SSS_16.Text.Trim() != string.Empty)
            {
                if (!DoValidate.CheckPhone(SSS_16.Text.Trim()))
                {
                    MessageBox.Show("固定电话格式就为:三或四位区号-8位号码!");
                    return false;
                }
            }
            //验证合同日期

            if (!DoValidate.DoValitTwoDatetime(SSS_27.Value.Date.ToString(), SSS_28.Value.Date.ToString()))
            {
                MessageBox.Show("合同日期不合法!");
                return false;
            }
            //出生日期
            if (SSS_3.Text == "0")
            {
                MessageBox.Show("出生日期不合法!");
                return false;
            }
            //工龄
            try
            {
                if (Convert.ToDecimal(SSS_10.Text) < 0)
                {
                    MessageBox.Show("工龄有误!");
                    return false;
                }
            }
            catch
            {

                MessageBox.Show("工龄有误!");
                return false;
            }
            //工资
            try
            {
                if (Convert.ToDecimal(SSS_25.Text) < 0)
                {
                    MessageBox.Show("工资有误!");
                    return false;
                }

            }
            catch
            {

                MessageBox.Show("工资有误!");
                return false;
            }
            return true;
        }
        private bool needClose = false;//验证基础信息不完整时要关闭
        private void Frm_DangAn_Load(object sender, EventArgs e)
        {
            #region 初始化可选项

            //限制工作时间、工作简历结束时间、家庭关系中的出生日期、最大值为当前日期
            SSS_9.MaxDate = DateTime.Now;
            G_2.MaxDate = DateTime.Now;
            F_3.MaxDate = DateTime.Now;

            //查询类型选中第一项
            cbox_type.SelectedIndex = 0;
            //性别选中第一项
            SSS_6.SelectedIndex = 0;
            //婚姻状态选中第一项
            SSS_5.SelectedIndex = 0;

            //填充民族
            string sql = "select * from tb_Folk";//定义sql语句
            InitCombox(sql, SSS_1);
            //填充文化程度
            sql = "select * from tb_Kultur";
            InitCombox(sql, SSS_4);
            //填充政治面貌
            sql = "select * from tb_Visage";
            InitCombox(sql, SSS_7);//职工基本信息中的政治面貌
            InitCombox(sql, F_5);//家庭关系中的政治面貌
            //省
            sql = "select id, BeAware from tb_City";
            InitCombox(sql, SSS_23);
            //市
            sql = "select id, City from tb_city where BeAware='广东省'";
            InitCombox(sql, SSS_24);
            //工资类别
            sql = "select * from tb_Laborage";
            InitCombox(sql, SSS_13);
            //职务类别
            sql = "select * from tb_Business";
            InitCombox(sql, SSS_12);
            //职称类别
            sql = "select * from tb_Duthcall";
            InitCombox(sql, SSS_15);
            //部门类别
            sql = "select * from tb_Branch";
            InitCombox(sql, SSS_14);
            //职工类别
            sql = "select * from tb_EmployeeGenre";
            InitCombox(sql, SSS_11);
            //奖惩类别
            sql = "select * from tb_RPKind";
            InitCombox(sql, R_1);
            //编号
            MakeIdNo();

            ////判断是否有立即显示的内容(当被查询,提醒窗体调用时会有立即被显示的内容)
            if (showThisUser != "")
            { //有要显示的内容
                string showThisUsersql = "select stu_id,stuffname from tb_stuffbusic where stu_id='" + showThisUser + "'";
                try
                {
                    MyDBControls.GetConn();
                    dgv_Info.DataSource = MyDBControls.GetDataSet(showThisUsersql).Tables[0];
                    MyDBControls.CloseConn();
                    //记录此次操作方便刷新
                    lastOperaSql = showThisUsersql;
                    //显示此员工信息
                    ShowInfo(showThisUser);

                }
                catch
                { }
            }
            ////
            if (needClose)
            {
                MessageBox.Show("基础数据不完整，请先进行基础信息设置！");
                this.Close();
            }
            #endregion
        }
        /// <summary>
        /// 初始化可选的控件
        /// </summary>
        /// <param name="sql">要查询的命令</param>
        /// <param name="cmb">要填充的控件</param>
        private void InitCombox(string sql, ComboBox cmb)//窗体的加载事件中填充供选择的 CombBox 如文化程序 政治面貌 等
        {
            try
            {
                MyDBControls.GetConn();//打开数据库连接
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //读取数据并加到相应位置
                    {
                        if (cmb.Items.Contains(sdr[1].ToString()) == false)
                        {
                            cmb.Items.Add(sdr[1].ToString());
                        } //只能是查询结果为两列并且所需为第二列的
                        cmb.SelectedIndex = 0;
                    }
                }
                else//没有计录表示基础数据表没有记录  不能进行人事添加
                {
                    needClose = true;//基础数据不完整


                }
                sdr.Close();//关闭 datareader
                MyDBControls.CloseConn();//关闭数据库连接
            }
            catch
            {
                this.Close();
            }
        }

        private void SSS_23_SelectedIndexChanged(object sender, EventArgs e)//省份改变时改变相应的市
        {//产生sql语句
            string sql = string.Format("select id,city from tb_city where BeAware='{0}'", SSS_23.SelectedItem.ToString());
            SSS_24.Items.Clear();//清空原来
            InitCombox(sql, SSS_24);//设置新值
        }

        private void SSS_2_ValueChanged(object sender, EventArgs e)//自动计算年龄  日期有误时显示为 0
        {
            int years = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(SSS_2.Value.Year);
            //if (years <= 0)
            //{
            //    MessageBox.Show("出生日期有误!");
            //}
            SSS_3.Text = years > 0 ? years.ToString() : "0";
        }

        private void SSS_28_ValueChanged(object sender, EventArgs e)//自动计算合同年限
        {
            TimeSpan ts = SSS_28.Value - SSS_27.Value;
            if (ts.Days <= 0)//检查日期出错的情况
            {
                //MessageBox.Show("合同日期有误,请检查!");
                SSS_29.Text = "0";
            }
            string years = (ts.Days / 365.0).ToString();
            SSS_29.Text = years.Length >= 3 ? years.Substring(0, 3) : years; //防止年数为整数时无法截前3位

        }

        private void SSS_27_ValueChanged(object sender, EventArgs e)
        {
            SSS_28_ValueChanged(sender, e);
        }

        private void tbc_showInfo_SelectedIndexChanged(object sender, EventArgs e)//选项卡改变当前页时移动按钮
        {
            //每次改变时都将删除状态设为不能用
            Part_Delete.Enabled = false;
            switch (tbc_showInfo.SelectedIndex)
            {
                case 1:
                    gp_SecMenu.Parent = tp2;//移动二级菜单
                    gb_MainMenu.Enabled = false;//一级菜单不能用
                    operaTable = " tb_WorkResume ";//工作简历表
                    currentDGV = dgv_G;
                    break;
                case 2:
                    gp_SecMenu.Parent = tp3;//移动二级菜单
                    gb_MainMenu.Enabled = false;//一级菜单
                    operaTable = " tb_Family ";//家庭关系表
                    currentDGV = dgv_F;
                    break;
                case 3:
                    gp_SecMenu.Parent = tp4;//
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_TrainNote ";//培训记录表
                    currentDGV = dgv_T;
                    break;
                case 4: gp_SecMenu.Parent = tp5;
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_Randp ";//奖惩
                    currentDGV = dgv_R;
                    break;
                case 5: //最后一页因为功能不同所以使用单独的菜单
                    gb_MainMenu.Enabled = false;
                    operaTable = " tb_Individual ";//个人简介
                    break;
                default: gb_MainMenu.Enabled = true;
                    break;
            }
        }
        private void MakeIdNo()//自动编号
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
            catch //异常
            {
                this.Close();
                //MessageBox.Show(err.Message);
            }

        }

        private void Img_Save_Click(object sender, EventArgs e)//添加图像
        {
            ofd_FindImage.Filter = "图像文件(*.jpg *.bmp *.png)|*.jpg; *.bmp; *.png";
            ofd_FindImage.Title = "选择";
            if (DialogResult.OK == ofd_FindImage.ShowDialog())
            {
                imgPath = ofd_FindImage.FileName;
                S_Image.Image = Image.FromFile(ofd_FindImage.FileName);
                Img_Clear.Enabled = true;
            }
        }

        private void Img_Clear_Click(object sender, EventArgs e)//图像清除按钮
        {
            S_Image.Image = null;//清除图像
            imgPath = "";//图像路径
            imgBytes = new byte[0];
        }
        /// <summary>
        /// 检查二级页面的输入合法性
        /// </summary>
        /// <param name="operatb">操作的数据表</param>
        /// <returns>输入合法返回true 否则返回 false</returns>
        private bool CheckSecGroup(string operatb)//根据当前操作的对象来检查输入
        {
            switch (operatb)
            {
                case " tb_WorkResume "://工作简历
                    if (G_3.Text.Trim() == string.Empty || G_4.Text.Trim() == string.Empty || G_5.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("请输入完整信息！");
                        return false;
                    }
                    if (!DoValidate.DoValitTwoDatetime(G_1.Value.ToString(), G_2.Value.ToString()))
                    {
                        MessageBox.Show("输入日期不合法！");
                        return false;
                    }
                    break;
                case " tb_Family "://家庭关系
                    if (F_1.Text.Trim() == string.Empty || F_2.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("请输入成员名称和与本人关系！");
                        return false;
                    }

                    break;
                case " tb_TrainNote "://培训记录
                    if (!DoValidate.DoValitTwoDatetime(T_3.Value.ToString(), T_4.Value.ToString()))
                    {
                        MessageBox.Show("日期不合法！");
                        return false;
                    }
                    try//检查培训金额是否合法
                    {
                        Double dou = Convert.ToDouble(T_5.Text);
                        if (dou < 0)
                        {
                            MessageBox.Show("费用不合法！");
                            return false;
                        }
                    }
                    catch
                    {

                        MessageBox.Show("费用不合法！");
                        return false;
                    }
                    if (T_1.Text.Trim() == string.Empty || T_2.Text.Trim() == string.Empty || T_5.Text.Trim() == string.Empty || T_6.Text.Trim() == string.Empty || T_7.Text.Trim() == string.Empty || T_8.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("请输入完整信息！");
                        return false;
                    }
                    break;
                case " tb_Randp "://奖罚
                    if (R_3.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("批准人不能为空！");
                        return false;
                    }
                    if (cbbox_re.Checked == true)//撤消时
                    {
                        if (R_5.Text.Trim() == string.Empty || R_4.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("撤消时间和原因不能为空");
                            return false;
                        }
                    }
                    break;
                case " tb_Individual "://简介
                    if (Ind_Mome.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("简介不能为空！");
                        return false;
                    }
                    break;

            }
            //通过验证
            return true;
        }
        private void Part_Add_Click(object sender, EventArgs e)//二级页面的添加
        {
            if (!CheckSecGroup(operaTable))
            {
                return;
            }
            //检查当前操作的用户是否已保存
            if (!CheckCurrentUser())
            {
                return; //当前用户基本信息未保存 不能进行二级页面的保存
            }


            //保存当前信息
            try
            {
                MyDBControls.GetConn();
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(CreateCommandText(operaTable))) > 0)
                {
                    MessageBox.Show("保存成功!");
                }
                MyDBControls.CloseConn();
                //刷新
                ShowInfo(SSS.Text.Trim());

                ClearControl(gp_SecMenu.Parent.Controls[0].Controls);//清空控件内容


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }

        }
        /// <summary>
        /// 清空已输入内容
        /// </summary>
        /// <param name="cons">要清空的控件集合</param>
        private void ClearControl(Control.ControlCollection cons)//清空指定集合对象的所有控件
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
        /// 根据当前页面来产生sql 语句
        /// </summary>
        /// <param name="operaTb">当前要操作的数据表</param>
        /// <returns>sql语句</returns>
        private string CreateCommandText(string operaTb)//根据操作的表产生sql语句
        {
            string sql = "";
            switch (operaTb) //根据操作的表的不同产生 不同的sql语句
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

        private bool CheckCurrentUser()//添加二级页面信息前   检查当前操作的对象是否为已存在对象 存在返回 true
        {
            string sql = "select count(*) from tb_Stuffbusic where stu_id='" + SSS.Text.Trim() + "'";
            try
            {
                MyDBControls.GetConn();
                if (Convert.ToInt32(MyDBControls.ExecSca(sql)) > 0)
                {
                    MyDBControls.CloseConn();
                    return true;//表示有记录
                }
                else
                {
                    MyDBControls.CloseConn();
                    MessageBox.Show("请先保存当前员工基本信息!!!");
                    return false;//表示当前用户未保存
                }

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                return false;
            }
        }

        private void SSS_9_ValueChanged(object sender, EventArgs e)//工作时间改变时自动计算工龄
        {

            SSS_10.Text = (DateTime.Now.Date.Year - SSS_9.Value.Date.Year).ToString();
        }

        private void SSS_TextChanged(object sender, EventArgs e)//显示当前操作的用户
        {
            txt_current.Text = SSS.Text;
        }

        private void btn_all_Click(object sender, EventArgs e)//显示所有信息
        {
            string sql = string.Format("select stu_id,stuffname from tb_stuffbusic");//sql语句
            try
            {
                MyDBControls.GetConn();//打开连接
                dgv_Info.DataSource = MyDBControls.GetDataSet(sql).Tables[0];//读取数据并显示
                MyDBControls.CloseConn();//关闭连接
                lastOperaSql = sql;//记录此次操作方便刷新
            }
            catch (Exception err)//处理异常
            {

                MessageBox.Show(err.Message);
            }
        }

        private void btn_find_Click(object sender, EventArgs e)//查询
        {
            string findType = "";//查询条件
            switch (cbox_type.SelectedItem.ToString())
            {
                case "按姓名查询":
                    findType = "StuffName";
                    break;
                case "按性别查询":
                    findType = "Sex";
                    break;
                case "按民族查询":
                    findType = "Folk";
                    break;
                case "按文化程度查询":
                    findType = "Kultur";
                    break;
                case "按政治面貌查询":
                    findType = "Visage";
                    break;
                case "按职工类别查询":
                    findType = "Employee";
                    break;
                case "按职工职务查询":
                    findType = "Business";
                    break;
                case "按职工部门查询":
                    findType = "Branch";
                    break;
                case "按职称类别查询":
                    findType = "Duthcall";
                    break;
                case "按工资类别查询":
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
                //记录此次操作方便刷新
                lastOperaSql = sql;
            }
            catch
            {


            }
        }

        private void cbox_type_SelectedIndexChanged(object sender, EventArgs e)//改变查询条件时填充选择项
        {
            string findType = "";//查询条件
            switch (cbox_type.SelectedItem.ToString())
            {
                case "按姓名查询":
                    findType = "StuffName";
                    break;
                case "按性别查询":
                    findType = "Sex";
                    break;
                case "按民族查询":
                    findType = "Folk";
                    break;
                case "按文化程度查询":
                    findType = "Kultur";
                    break;
                case "按政治面貌查询":
                    findType = "Visage";
                    break;
                case "按职工类别查询":
                    findType = "Employee";
                    break;
                case "按职工职务查询":
                    findType = "Business";
                    break;
                case "按职工部门查询":
                    findType = "Branch";
                    break;
                case "按职称类别查询":
                    findType = "Duthcall";
                    break;
                case "按工资类别查询":
                    findType = "Laborage";
                    break;
            }
            string sql = string.Format("select {0} from tb_stuffbusic ", findType);
            try
            {
                MyDBControls.GetConn(); //打开连接
                SqlDataReader sdr = MyDBControls.GetDataReader(sql); //读取数据
                txt_condition.Items.Clear();//清空原来内容
                txt_condition.Text = string.Empty;
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //添加到条件中
                    {
                        if (!txt_condition.Items.Contains(sdr[0].ToString()))//如果不存在则加
                        {
                            txt_condition.Items.Add(sdr[0].ToString());
                        }
                    }
                }
                sdr.Close(); //关闭
                MyDBControls.CloseConn();
            }
            catch (Exception err)//处理异常
            {

                MessageBox.Show(err.Message);
            }

        }

        private void dgv_Info_CellClick(object sender, DataGridViewCellEventArgs e)//选择要操作的对象
        {
            if (dgv_Info.SelectedRows.Count > 0 && dgv_Info.SelectedCells[0].Value != null)
            {
                //MessageBox.Show(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());
                ShowInfo(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());//显示选中的员工信息
                btn_Add.Enabled = false;//修改时不能添加防止重复
            }
        }
        /// <summary>
        /// 查询某个员工的其它信息
        /// </summary>
        /// <param name="stuId">当前操作的员工编号</param>
        private void ShowInfo(string stuId)//根据选择显示此员工信息
        {
            //修改 删除按钮能用
            btn_update.Enabled = btn_Delete.Enabled = true;
            #region 基本信息页面的信息显示
            string selSql = string.Format("select * from tb_Stuffbusic where Stu_id ='{0}'", stuId);
            #region 数据表中的信息格式
            //ID	职工编号	int identit	 
            //SSS_0.Text.Trim(),//StuffName	职工姓名	Varchar（20）	//0 0表示所对应的控件编号
            //SSS_1.Text.Trim(), //Folk	民族	Varchar（20）	        //1
            //SSS_2.Text, //Birthday	出生日期	DateTime	    //2
            //SSS_3.Text.Trim(),//Age	年龄	Int	                    //3
            //SSS_4.SelectedItem.ToString(),//Kultur	文化程度	Varchar（14）	4
            //SSS_5.SelectedItem.ToString(),//Marriage	婚姻	Varchar（4）	    5
            //SSS_6.SelectedItem.ToString(),//Sex	性别	Varchar（4）	        6
            //SSS_7.Text,                     //Visage	政治面貌	Varchar（20）	7 
            //SSS_8.Text,                    //IDCard	身份证号	Varchar（20）	8
            //SSS_9.Text,                    //WorkDate	单位工作时间	DateTime	9
            //SSS_10.Text.Trim(),            //WorkLength	工龄	Int	            10
            //SSS_11.SelectedItem.ToString(),//Employee	职工类型	Varchar（20）	11
            //SSS_12.SelectedItem.ToString(), //Business	职务类型	Varchar（10）	12
            //SSS_13.SelectedItem.ToString(),//Laborage	工资类别	Varchar（10）	13
            //SSS_14.SelectedItem.ToString(),//Branch	部门类别	Varchar（20）	14
            //SSS_15.SelectedItem.ToString(),//Duthcall	职称类别	Varchar（20）	15
            //SSS_16.Text.Trim(), //Phone	电话	Varchar（14）	        16
            //SSS_17.Text.Trim(), //Handset	手机	Varchar（11）	    17
            //SSS_18.Text.Trim(),//School	毕业学校	Varchar（50）	18
            //SSS_19.Text.Trim(), //Speciality	主修专业	Varchar（20）19	
            //SSS_20.Text, //GraduateDate	毕业时间	DateTime	20
            //SSS_21.Text.Trim(),//Address	家庭住址	Varchar（50）	21
            //"@imgBytes",//Photo	个人照片	Image	            22
            //SSS_23.SelectedItem.ToString(),//BeAware	省	Varchar（30）	        23
            //SSS_24.SelectedItem.ToString(),//City	市	Varchar（30）	            24
            //SSS_25.Text,//M_Pay	月工资	Money	                25
            //SSS_26.Text,//Bank	银行账号	Varchar（20）	    26
            //SSS_27.Text,//Pact_B	合同起始日期	DateTime	27
            //SSS_28.Text,//Pact_E	合同结束日期	DateTime	28
            //SSS_29.Text,//Pact_Y	合同年限	Float	        29
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
                        SSS_2.Text = sdr[4].ToString(); //Birthday	出生            }
                        SSS_3.Text = sdr[5].ToString();//Age	年龄        }
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
                        imgBytes = (byte[])sdr[24];//Photo	个人照片
                        SSS_23.Text = sdr[25].ToString();
                        SSS_24.Text = sdr[26].ToString();
                        SSS_25.Text = sdr[27].ToString();//M_Pay	月工资	
                        SSS_26.Text = sdr[28].ToString();//Bank	银行账号
                        SSS_27.Value = Convert.ToDateTime(sdr[29].ToString());//Pact_B	合同起始
                        SSS_28.Value = Convert.ToDateTime(sdr[30].ToString());//Pact_E	合同结束
                        SSS_29.Text = sdr[31].ToString();//Pact_Y	合同年限
                        //处理图像
                        try
                        {
                            byte[] img = (byte[])sdr[24]; //试图把图像显示
                            MemoryStream ms = new MemoryStream(img);
                            S_Image.Image = Image.FromStream(ms);
                        }
                        catch //出错时表示存的时候没有添加图像
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
            #region 工作简历
            string selSql2 = string.Format("select BeginDat as 开始时间,EndDate as 结束时间,workunit as 工作单位,Branch as 部门,Business as 职务,id from tb_WorkResume where sut_Id ='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_G.DataSource = MyDBControls.GetDataSet(selSql2).Tables[0];
                dgv_G.Columns[dgv_G.Columns.Count - 1].Visible = false;//隐藏id列
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region 家庭关系
            string selSql3 = string.Format("select leaguerName as 成员名称,Nexus as 与本人关系,Birthdate as 出生日期,WorkUnit as 工作单位,Business as 职务,visage as 政治面貌 ,id from tb_Family where Sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_F.DataSource = MyDBControls.GetDataSet(selSql3).Tables[0];
                dgv_F.Columns[dgv_F.Columns.Count - 1].Visible = false;//隐藏id
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region 培训记录
            string selSql4 = string.Format("select Trainfashion as 培训方式,BeginDate as 开始时间,EndDate as 结束时间,Speciality as 培训专业,TrainUnit as 培训单位,KulturMemo as 培训内容,Charger as 费用,Effects as 效果 ,id from tb_TrainNote where Sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                dgv_T.DataSource = MyDBControls.GetDataSet(selSql4).Tables[0];
                dgv_T.Columns[dgv_T.Columns.Count - 1].Visible = false;//  隐藏id   
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region 奖惩记录
            try
            {
                string selSql5 = string.Format("select RPKind as 类别,RPDate as 时间,sealMan as 批准人,QuashDate as 撤消时间,QuashWhys as 原因 ,id from tb_Randp where sut_ID='{0}'", stuId);
                MyDBControls.GetConn();
                dgv_R.DataSource = MyDBControls.GetDataSet(selSql5).Tables[0];
                dgv_R.Columns[dgv_R.Columns.Count - 1].Visible = false;//隐藏 id
                MyDBControls.CloseConn();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion
            #region 个人简历
            string selSql6 = string.Format("select Memo from tb_Individual where sut_ID='{0}'", stuId);
            try
            {
                MyDBControls.GetConn();
                SqlDataReader sdr6 = MyDBControls.GetDataReader(selSql6);
                if (sdr6.HasRows)//有记录时显示
                {
                    while (sdr6.Read())
                    {
                        Ind_Mome.Text = sdr6[0].ToString();

                    }
                }
                else//没有记录时清空
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

        private void btn_First_Click(object sender, EventArgs e)//查看第一条记录
        {
            try
            {
                dgv_Info.Rows[0].Selected = true;//第一行选中
                ShowInfo(dgv_Info.Rows[0].Cells[0].Value.ToString());//显示第一条
            }
            catch
            {


            }
        }

        private void btn_End_Click(object sender, EventArgs e)//查看最后一条记录
        {
            try
            {
                dgv_Info.Rows[dgv_Info.Rows.Count - 1].Selected = true;//最后一行选中
                ShowInfo(dgv_Info.Rows[dgv_Info.Rows.Count - 1].Cells[0].Value.ToString());//显示第一条
            }
            catch
            {


            }
        }

        private void btn_Back_Click(object sender, EventArgs e)//查看上一条记录
        {
            try
            {
                int currentRow = dgv_Info.SelectedRows[0].Index;//当前选中行的索引号
                int backRow = 0;
                if ((currentRow - 1) >= 0) //判断是否为第一行 如果是则一直选中第一行
                {
                    backRow = currentRow - 1;
                }
                else                     //
                {
                    MessageBox.Show("已到第一行!");
                    backRow = 0;
                }
                dgv_Info.Rows[backRow].Selected = true;//前一行选中
                ShowInfo(dgv_Info.Rows[backRow].Cells[0].Value.ToString());//显示前一条
            }
            catch
            {


            }
        }

        private void btn_next_Click(object sender, EventArgs e)//查看后一条记录
        {
            try
            {
                int currentRow = dgv_Info.SelectedRows[0].Index;//当前选中行的索引号
                int nextRow = dgv_Info.Rows.Count - 1;//后一行的索引 默认的是最在行索引
                if ((currentRow + 1) < dgv_Info.Rows.Count)//判断是否到了最后一行
                {
                    nextRow = currentRow + 1;
                }
                else
                {
                    MessageBox.Show("已到最后一行!");
                }
                dgv_Info.Rows[nextRow].Selected = true;//后一行选中
                ShowInfo(dgv_Info.Rows[nextRow].Cells[0].Value.ToString());//显示后一条员工信息
            }
            catch
            {


            }
        }

        private void btn_update_Click(object sender, EventArgs e)//修改
        {
            //验证输入
            if (!DoValitPrimary())
            {
                return;
            }
            #region 修改当前员工信息
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

                MessageBox.Show("请重试!");
            }
            #endregion
            #region 刷新
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
            btn_Delete.Enabled = btn_update.Enabled = false;//按钮不能用
        }

        private void btn_Delete_Click(object sender, EventArgs e)//删除
        {
            if (MessageBox.Show("此操作不可恢复,确认删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                MessageBox.Show("操作已取消!");
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
                MyDBControls.GetConn();//打开连接
                MyDBControls.ExecNonQuery(delStr);//执行删除
                MyDBControls.ExecNonQuery(delStr2);//执行删除
                MyDBControls.ExecNonQuery(delStr3);//执行删除
                MyDBControls.ExecNonQuery(delStr4);//执行删除
                MyDBControls.ExecNonQuery(delStr5);//执行删除
                MyDBControls.ExecNonQuery(delStr6);//执行删除
                MyDBControls.CloseConn();//关闭连接
                btn_Back_Click(sender, e);//已选中项换到上一行
                Img_Clear_Click(sender, e);//清除图片信息


                MessageBox.Show("删除成功!");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #region 刷新
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
            btn_Delete.Enabled = btn_update.Enabled = false;//按钮不能用
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = btn_update.Enabled = false;//按钮不能用
            
            ClearControl(tp1.Controls);//清空控件内容
            SSS_2_ValueChanged(sender, e);//显示年龄防止出现空值
            SSS_9_ValueChanged(sender, e);//工龄
            SSS_28_ValueChanged(sender, e);//合同年限
            MakeIdNo();//恢复为添加状态
            //清空其它页面的内容
            G_3.Text = G_4.Text = G_5.Text = string.Empty;
            dgv_G.DataSource = null;

            F_1.Text = F_2.Text = F_7.Text = F_4.Text = string.Empty;
            dgv_F.DataSource = null;

            T_1.Text = T_2.Text = T_5.Text = T_6.Text = T_7.Text = T_8.Text = string.Empty;
            dgv_T.DataSource = null;

            R_3.Text = R_5.Text = string.Empty;
            dgv_R.DataSource = null;

            Ind_Mome.Text = string.Empty;
            //清空图片
            S_Image.Image = null;
            imgPath = "";
            imgBytes = new byte[0];
            //取消修改 后添加能用
            btn_Add.Enabled = true;
        }

        private void dgv_G_CellClick(object sender, DataGridViewCellEventArgs e)//当选择工作简历时
        {
            if (dgv_G.SelectedRows.Count > 0 && dgv_G.SelectedCells[0].Value != null)
            {
                //开始 结束时间 单位 部门 职务  
                G_1.Text = dgv_G.SelectedRows[0].Cells[0].Value.ToString();
                G_2.Text = dgv_G.SelectedRows[0].Cells[1].Value.ToString();
                G_3.Text = dgv_G.SelectedRows[0].Cells[3].Value.ToString();
                G_4.Text = dgv_G.SelectedRows[0].Cells[4].Value.ToString();
                G_5.Text = dgv_G.SelectedRows[0].Cells[2].Value.ToString();
                Part_Delete.Enabled = true;//删除按钮能用

            }
        }

        private void Part_Delete_Click(object sender, EventArgs e)//二级菜单的删除
        {
            //确认操作
            if (MessageBox.Show("此操作不可恢复,确认删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                MessageBox.Show("操作已取消!");
                return;
            }//产生sql语句
            string delSql = string.Format("delete from {0} where Sut_ID='{1}' and id={2}", operaTable, SSS.Text.Trim(), currentDGV.SelectedRows[0].Cells[currentDGV.Columns.Count - 1].Value.ToString());

            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(delSql);//执行删除
                MyDBControls.CloseConn();
                ShowInfo(SSS.Text.Trim());//刷新
                //清空控件
                ClearControl(gp_SecMenu.Parent.Controls[0].Controls);//清空控件内容
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void dgv_F_CellClick(object sender, DataGridViewCellEventArgs e)//家庭关系
        {
            if (dgv_F.SelectedRows.Count > 0 && dgv_F.SelectedCells[0].Value != null)
            {
                //成员名称 本人关系 出生日期 单位 职务 政治面貌
                F_1.Text = dgv_F.SelectedRows[0].Cells[0].Value.ToString();
                F_2.Text = dgv_F.SelectedRows[0].Cells[1].Value.ToString();
                F_3.Text = dgv_F.SelectedRows[0].Cells[2].Value.ToString();
                F_4.Text = dgv_F.SelectedRows[0].Cells[4].Value.ToString();
                F_5.Text = dgv_F.SelectedRows[0].Cells[5].Value.ToString();
                F_7.Text = dgv_F.SelectedRows[0].Cells[3].Value.ToString();
                Part_Delete.Enabled = true;//删除按钮能用

            }
        }

        private void dgv_T_CellClick(object sender, DataGridViewCellEventArgs e)//培训记录
        {


            if (dgv_T.SelectedRows.Count > 0 && dgv_T.SelectedCells[0].Value != null)
            {
                //方式 开始 结束时间 专业 培训单位 培训内容 费用 效果
                T_1.Text = dgv_T.SelectedRows[0].Cells[0].Value.ToString();
                T_2.Text = dgv_T.SelectedRows[0].Cells[3].Value.ToString();
                T_3.Text = dgv_T.SelectedRows[0].Cells[1].Value.ToString();
                T_4.Text = dgv_T.SelectedRows[0].Cells[2].Value.ToString();
                T_5.Text = dgv_T.SelectedRows[0].Cells[6].Value.ToString();
                T_6.Text = dgv_T.SelectedRows[0].Cells[4].Value.ToString();
                T_7.Text = dgv_T.SelectedRows[0].Cells[7].Value.ToString();
                T_8.Text = dgv_T.SelectedRows[0].Cells[5].Value.ToString();
                Part_Delete.Enabled = true;//删除按钮能用

            }
        }

        private void dgv_R_CellClick(object sender, DataGridViewCellEventArgs e)//奖惩
        {
            if (dgv_R.SelectedRows.Count > 0 && dgv_R.SelectedCells[0].Value != null)
            {
                //类别 时间 批准人 撤消时间 原因  
                R_1.Text = dgv_R.SelectedRows[0].Cells[0].Value.ToString();
                R_2.Text = dgv_R.SelectedRows[0].Cells[1].Value.ToString();
                R_3.Text = dgv_R.SelectedRows[0].Cells[2].Value.ToString();
                R_4.Text = dgv_R.SelectedRows[0].Cells[3].Value.ToString();
                R_5.Text = dgv_R.SelectedRows[0].Cells[4].Value.ToString();
                Part_Delete.Enabled = true;//删除按钮能用

            }
        }

        private void cbbox_re_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbox_re.Checked)//要撤消时
            {
                R_4.Enabled = R_5.Enabled = true;//撤消时间和原因能用
            }
            else
            {
                R_4.Enabled = R_5.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)//保存简历
        {
            //检查当前操作的用户是否已保存
            if (!CheckCurrentUser())
            {
                return; //当前用户基本信息未保存 不能进行二级页面的保存
            }
            string delSql = string.Format("delete from {0} where sut_Id='{1}'", operaTable, SSS.Text.Trim());

            try
            {
                MyDBControls.GetConn();
                MyDBControls.ExecNonQuery(delSql);
                MyDBControls.ExecNonQuery(CreateCommandText(operaTable));
                MyDBControls.CloseConn();
                MessageBox.Show("保存成功!");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void btn_CreatDoc_Click(object sender, EventArgs e)//导出Word
        {
            //检查是否有可操作项
            if (dgv_Info.RowCount <= 0)
            {
                MessageBox.Show("当前没有可导出的员工信息!");
                return;
            }
            Frm_CreateWord frm_CW = new Frm_CreateWord();
            frm_CW.StuId =dgv_Info.SelectedRows[0].Cells[0].Value.ToString()??SSS.Text;//员工编号
            frm_CW.ShowDialog();
            frm_CW.Dispose();

        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Info_Sorted(object sender, EventArgs e)//排序过后刷新防止显示不一致
        {
            if (dgv_Info.SelectedRows.Count > 0 && dgv_Info.SelectedCells[0].Value != null)
            {
                //MessageBox.Show(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());
                ShowInfo(dgv_Info.SelectedRows[0].Cells[0].Value.ToString());//显示选中的员工信息
                btn_Add.Enabled = false;//修改时不能添加防止重复
            }
        }

    }
}
