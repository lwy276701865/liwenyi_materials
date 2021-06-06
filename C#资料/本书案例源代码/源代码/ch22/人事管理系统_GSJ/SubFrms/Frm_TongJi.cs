using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
namespace 人事管理系统_GSJ
{
    public partial class Frm_TongJi : Form
    {
        public Frm_TongJi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbx_T_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lbx_T.SelectedItem.ToString());
            if (lbx_T.SelectedItem == null)//没有选择项不执行操作
                return;

            
            string sql = "";
            switch (lbx_T.SelectedItem.ToString())
            { 
                case "职称类别":
                    sql = "select Duthcall as 职称类别,count(Duthcall) as 数量 from tb_stuffbusic group by Duthcall";
                    break;
                case "职务类别":
                    sql = "select Business as 职务类别 ,count(Business) as 数量 from tb_stuffbusic group by Business";
                    break;
                case "工资类别":
                    sql = "select Laborage as 工资类别 ,count(Laborage) as 数量 from tb_stuffbusic  group by Laborage";
                    break;
                case "部门类别":
                    sql = "select Branch as 部门类别 ,count(Branch) as 数量 from tb_stuffbusic  group by Branch";
                    break;
                case "政治面貌":
                    sql = "select Visage as 政治面貌 ,count(Visage) as 数量  from tb_stuffbusic group by Visage";
                    break;
                case "文化程度":
                    sql = "select Kultur as 文化程度 ,count(Kultur) as 数量 from tb_stuffbusic  group by Kultur";
                    break;
                case "职工类别":
                    sql = "select Employee as 职工类别 ,count(Employee) as 数量 from tb_stuffbusic  group by Employee";
                    break;
                case "民族类别":
                    sql = "select Folk as 民族类别 ,count(Folk) as 数量  from tb_stuffbusic group by Folk";
                    break;
                case "年龄":
                    sql = "select Age as 年龄 ,count(Age) as 数量 from tb_stuffbusic  group by Age";
                    break;
                case "性别":
                    sql = "select Sex as 性别 ,count(Sex) as 数量  from tb_stuffbusic group by Sex";
                    break;
            }
            try
            {
                MyDBControls.GetConn();
                dgv_TJ.DataSource = MyDBControls.GetDataSet(sql).Tables[0];
                MyDBControls.CloseConn();
            }
            catch 
            {
                this.Close();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_TJ.Rows.Count>0)//有数据时
            {
                try
                {
                    sfd_TJ.FileName = dgv_TJ.Columns[0].HeaderText;
                    if (DialogResult.OK == sfd_TJ.ShowDialog())
                    {

                        StreamWriter sw = new StreamWriter(sfd_TJ.FileName);
                        sw.WriteLine(dgv_TJ.Columns[0].HeaderText + "\t" + dgv_TJ.Columns[1].HeaderText);
                        for (int i = 0; i < dgv_TJ.Rows.Count; i++)
                        {
                            sw.WriteLine(dgv_TJ.Rows[i].Cells[0].Value.ToString() + "\t" + dgv_TJ.Rows[i].Cells[1].Value.ToString());
                        }
                        sw.Close();
                    }
                }
                catch 
                {

                    MessageBox.Show("请重试!");
                }
            }
        }
       
    }
}