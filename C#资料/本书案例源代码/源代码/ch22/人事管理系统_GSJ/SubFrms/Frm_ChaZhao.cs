using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SqlClient;

namespace 人事管理系统_GSJ
{
    public partial class Frm_ChaZhao : Form
    {
        public Frm_ChaZhao()
        {
            InitializeComponent();
        }

        private void Frm_ChaZhao_Load(object sender, EventArgs e)
        {
            
            //设置默认选择项
            Find_Sex.SelectedIndex = 0;//性别
            Find_Marriage.SelectedIndex = 0;//婚
            Age_Sign.SelectedIndex = 0;//年龄标识
            WorkLength_Sign.SelectedIndex = 0;//工作长度
            M_Pay_Sign.SelectedIndex = 0;//月工资
            Pact_Y_Sign.SelectedIndex = 0;//合同年限

            MyDBControls.GetConn();//打开数据库连接
            DoWork();
            MyDBControls.CloseConn();//关闭数据库连接 
            
        }
        /// <summary>
        /// 窗体的加载事件中填充供选择的 CombBox 如文化程序 政治面貌 等
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="cmb">要填充的下拉列表</param>
        private void InitCombox(string sql, ComboBox cmb)//
        {
            try
            {
               // MyDBControls.GetConn();//打开数据库连接
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);
                if (sdr.HasRows)
                {
                    while (sdr.Read()) //读取数据并加到相应位置
                    {
                        if (!cmb.Items.Contains(sdr[1]))
                        {
                            cmb.Items.Add(sdr[1].ToString()); //只能是查询结果为两列并且所需为第二列的 
                        }
                       
                    }
                }
                sdr.Close();//关闭 datareader
              //  MyDBControls.CloseConn();//关闭数据库连接
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
            //要查询的内容
            findSql.Append(" Stu_id as 员工编号,");
            findSql.Append(" StuffName as 职工姓名, ");
            findSql.Append(" Folk as 民族 ,");
            findSql.Append(" Birthday as 出生日期, ");
            findSql.Append(" Age as 年龄, ");
            findSql.Append(" Kultur as 文化程度, ");
            findSql.Append(" Marriage  as 婚姻, ");
            findSql.Append(" Sex as 性别, ");
            findSql.Append(" Visage as 政治面貌, ");
            findSql.Append(" IDCard as 身份证号, ");
            findSql.Append(" WorkDate as 单位工作时间, ");
            findSql.Append(" WorkLength as 工龄, ");
            findSql.Append(" Employee as 职工类型, ");
            findSql.Append(" Business as 职务类型, ");
            findSql.Append(" Laborage as 工资类别, ");
            findSql.Append(" Branch as 部门类别, ");
            findSql.Append(" Duthcall as 职称类别, ");
            findSql.Append(" Phone as 电话, ");
            findSql.Append(" Handset as 手机, ");
            findSql.Append(" School as 毕业学校, ");
            findSql.Append(" Speciality as 主修专业, ");
            findSql.Append(" GraduateDate as 毕业时间, ");
            findSql.Append(" Address as 家庭住址, ");
            findSql.Append(" BeAware as 省, ");
            findSql.Append(" City as 市, ");
            findSql.Append(" M_Pay as 月工资, ");
            findSql.Append(" Bank as 银行账号, ");
            findSql.Append(" Pact_B as 合同起始日期, ");
            findSql.Append(" Pact_E as 合同结束日期, ");
            findSql.Append(" Pact_Y as 合同年限 ");
            
            //表名
            findSql.Append(" from tb_Stuffbusic ");

            try
            {
                MyDBControls.GetConn();
                dgv_result.DataSource = MyDBControls.GetDataSet(findSql.ToString()).Tables[0];
                MyDBControls.CloseConn();
                dgv_result.Columns[0].Frozen = true;//冻结第一列
            }
            catch 
            { }
        }
        /// <summary>
        /// 清空已输入内容
        /// </summary>
        private void btn_clear_Click(object sender, EventArgs e)//清空条件
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

        private void btn_find_Click(object sender, EventArgs e)//开始查找
        {
            string conditionType = "";
            if (rbt_and.Checked)//查询条件的类型
            {
                conditionType = " and ";
            }
            if (rbt_or.Checked)
            {
                conditionType = " or ";
            }
            #region 产生sql语句
            StringBuilder findSql = new StringBuilder("select ");
            //要查询的内容
            findSql.Append(" Stu_id as 员工编号,");
            findSql.Append(" StuffName as 职工姓名, ");
            findSql.Append(" Folk as 民族 ,");
            findSql.Append(" Birthday as 出生日期, ");
            findSql.Append(" Age as 年龄, ");
            findSql.Append(" Kultur as 文化程度, ");
            findSql.Append(" Marriage  as 婚姻, ");
            findSql.Append(" Sex as 性别, ");
            findSql.Append(" Visage as 政治面貌, ");
            findSql.Append(" IDCard as 身份证号, ");
            findSql.Append(" WorkDate as 单位工作时间, ");
            findSql.Append(" WorkLength as 工龄, ");
            findSql.Append(" Employee as 职工类型, ");
            findSql.Append(" Business as 职务类型, ");
            findSql.Append(" Laborage as 工资类别, ");
            findSql.Append(" Branch as 部门类别, ");
            findSql.Append(" Duthcall as 职称类别, ");
            findSql.Append(" Phone as 电话, ");
            findSql.Append(" Handset as 手机, ");
            findSql.Append(" School as 毕业学校, ");
            findSql.Append(" Speciality as 主修专业, ");
            findSql.Append(" GraduateDate as 毕业时间, ");
            findSql.Append(" Address as 家庭住址, ");
            findSql.Append(" BeAware as 省, ");
            findSql.Append(" City as 市, ");
            findSql.Append(" M_Pay as 月工资, ");
            findSql.Append(" Bank as 银行账号, ");
            findSql.Append(" Pact_B as 合同起始日期, ");
            findSql.Append(" Pact_E as 合同结束日期, ");
            findSql.Append(" Pact_Y as 合同年限 ");
            //表名
            findSql.Append(" from tb_Stuffbusic ");

            //条件
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
            //以下条件不只有要内容不为空时才加上所以要把 or 加在前面 因为不确定后面还要不要加
            if (Find1_WorkDate.Text != string.Empty && Find2_WorkDate.Text != string.Empty)
            {
                try  //检查输入的内容是否为合法日期 是则加
                {
                    DateTime dtTest = new DateTime();
                    dtTest = Convert.ToDateTime(Find1_WorkDate.Text);
                    dtTest = Convert.ToDateTime(Find2_WorkDate.Text);
                    findSql.Append(conditionType);
                    findSql.Append(" WorkDate between '" + Find1_WorkDate.Text + "' and '" + Find2_WorkDate.Text + "' ");
                }
                catch//日期不合法不处理
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

                dgv_result.Columns[0].Frozen = true;//冻结第一列
            }
            catch 
            {

                
            }
        }

        private void dgv_result_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)//显示更多信息
        {
            if (FrmMain.P_haveDAAccess)//判断权限
            {
                Frm_DangAn frm_da = new Frm_DangAn();
                frm_da.ShowThisUser = dgv_result.SelectedRows[0].Cells[0].Value.ToString();
                frm_da.ShowDialog();
                frm_da.Dispose();
            }
            else
            {
                MessageBox.Show("当前用户无权调用!");
            }
        }

        private void DoWork()//加载可选择项
        {
           
            //填充民族
            string sql = "select * from tb_Folk";//定义sql语句
            InitCombox(sql, Find_Folk);
            //填充文化程度
            sql = "select * from tb_Kultur";
            InitCombox(sql, Find_Kultur);
            //填充政治面貌
            sql = "select * from tb_Visage";
            InitCombox(sql, Find_Visage);//职工基本信息中的政治面貌
            //省                                        //todo:省和市对应
            sql = "select id, BeAware from tb_City";
            InitCombox(sql, Find_BeAware);
            //市
            sql = "select id, City from tb_city";
            InitCombox(sql, Find_City);
            //工资类别
            sql = "select * from tb_Laborage";
            InitCombox(sql, Find_Laborage);
            //职务类别
            sql = "select * from tb_Business";
            InitCombox(sql, Find_Business);
            //职称类别
            sql = "select * from tb_Duthcall";
            InitCombox(sql, Find_Duthcall);
            //部门类别
            sql = "select * from tb_Branch";
            InitCombox(sql, Find_Branch);
            //职工类别
            sql = "select * from tb_EmployeeGenre";
            InitCombox(sql, Find_Employee);
            //毕业学校
            sql = "select id,school from tb_Stuffbusic";
            InitCombox(sql, Find_School);
            //所修专业
            sql = "select id,speciality from tb_Stuffbusic";
            InitCombox(sql, Find_Speciality);
        }

    }
}