using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 人事管理系统_GSJ
{
    public partial class Frm_TiXing : Form
    {
        public Frm_TiXing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_TiXing_Load(object sender, EventArgs e)
        {
            string codition_ht = string.Format("select Fate from tb_Clew where Kind=0");//合同
            string codition_sr = string.Format("select Fate from tb_Clew where Kind=1");//生日
            int ht;//合同提醒天数
            int sr;//生日提醒天数
            try
            {
                MyDBControls.GetConn();
                ht = Convert.ToInt32(MyDBControls.ExecSca(codition_ht));
                sr = Convert.ToInt32(MyDBControls.ExecSca(codition_sr));

                //select   birthday from tb_stuffbusic where datediff(mm,birthday,'1990-03-8')=0 and datepart(dd,birthday)<=10
                string ht_T = DateTime.Now.Date.AddDays(ht).ToString();//合同目标日期
                DateTime sr_T = DateTime.Now.Date.AddDays(sr);//异常表现为 如果今天是 25 再加上 提醒日期 10 则成了 5
                int maxMonthDay = 0;//当前月分最在天数
                switch (DateTime.Now.Month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        maxMonthDay = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        maxMonthDay = 30;
                        break;
                    case 2:
                        if (DateTime.IsLeapYear(DateTime.Now.Year))//闰年
                        {
                            maxMonthDay = 29;
                        }
                        else
                        {
                            maxMonthDay = 28;
                        }
                        break;

                        
                }
                //显示提醒的天数
                groupBox1.Text += "(当前提醒天数：" + ht.ToString() + "天)";
                groupBox2.Text += "（当前提醒天数：" + sr.ToString() + "天)";

                //产生sql语句
                string htSql = string.Format("select Stu_id as 员工编号 ,StuffName as 员工姓名 ,Pact_E as 合同结束日期 from tb_stuffbusic where Pact_E between '{0}' and '{1}' or Pact_E <'{2}'", DateTime.Now.Date.ToString(), ht_T, DateTime.Now.Date.ToString());
                string srSql;//
                if (sr_T.Day < DateTime.Now.Day)//加上提醒天数后日期变为下一月时  分两种情况 所以要 合并结果
                {
                    srSql = string.Format("select Stu_id as 员工编号 ,StuffName as 员工姓名 ,birthday as 员工生日 from tb_stuffbusic where datediff(mm,birthday,'{0}')%12=0 and datepart(dd,birthday) between {1} and {2} " +
                        " union select Stu_id as 员工编号 ,StuffName as 员工姓名 ,birthday as 员工生日 from tb_stuffbusic where datediff(mm,birthday,'{0}')%12=11 and datepart(dd,birthday) between 1 and {3}", DateTime.Now.Date.ToString(), DateTime.Now.Day.ToString(), maxMonthDay, sr_T.Day);
                }
                else
                {
                    srSql = string.Format("select Stu_id as 员工编号 ,StuffName as 员工姓名 ,birthday as 员工生日 from tb_stuffbusic where datediff(mm,birthday,'{0}')%12=0 and datepart(dd,birthday) between {1} and {2}", DateTime.Now.Date.ToString(), DateTime.Now.Day.ToString(), sr_T.Day);
                }
                dgv_H.DataSource = MyDBControls.GetDataSet(htSql).Tables[0];
                dgv_S.DataSource = MyDBControls.GetDataSet(srSql).Tables[0];
                MyDBControls.CloseConn();
            }
            catch
            {


            }
            #region 已过期合同红色背景
            for (int i = 0; i < dgv_H.Rows.Count; i++)//已过期合同红色背景
            {
                if (Convert.ToDateTime(dgv_H.Rows[i].Cells[2].Value) < DateTime.Now.Date)
                {
                    dgv_H.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
            }
            //MessageBox.Show(ht_T);
            #endregion
            this.CancelButton = button1;
        }

        private void dgv_H_Sorted(object sender, EventArgs e)//更改排序后也要红色显示过期合同
        {
            #region 已过期合同红色背景
            for (int i = 0; i < dgv_H.Rows.Count; i++)//已过期合同红色背景
            {
                if (Convert.ToDateTime(dgv_H.Rows[i].Cells[2].Value) < DateTime.Now.Date)
                {
                    dgv_H.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
            }
            //MessageBox.Show(ht_T);
            #endregion
        }

        private void dgv_H_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FrmMain.P_haveDAAccess)//判断权限
            {
                Frm_DangAn frm_da = new Frm_DangAn();
                frm_da.ShowThisUser = dgv_H.SelectedRows[0].Cells[0].Value.ToString();
                frm_da.ShowDialog();
                frm_da.Dispose();
            }
            else
            {
                MessageBox.Show("当前用户无权调用!");
            }
        }

        private void dgv_S_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FrmMain.P_haveDAAccess)//判断权限
            {
                Frm_DangAn frm_da = new Frm_DangAn();
                frm_da.ShowThisUser = dgv_S.SelectedRows[0].Cells[0].Value.ToString();
                frm_da.ShowDialog();
                frm_da.Dispose();
            }
            else
            {
                MessageBox.Show("当前用户无权调用!");
            }
        }
    }
}