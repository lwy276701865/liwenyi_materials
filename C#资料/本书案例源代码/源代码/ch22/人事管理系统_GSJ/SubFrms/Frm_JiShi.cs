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
    public partial class Frm_JiShi : Form
    {
        public Frm_JiShi()
        {
            InitializeComponent();
        }

        private void Frm_JiShi_Load(object sender, EventArgs e)
        {
            #region 提取记事类别
            string sql = "select WordPad from tb_WordPad"; //sql语句
            try
            {
                MyDBControls.GetConn(); //打开连接
                SqlDataReader sdr = MyDBControls.GetDataReader(sql);//读取数据
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        cbbox_type.Items.Add(sdr[0].ToString());
                        cbbox_type.SelectedIndex = cbbox_type.Items.Count - 1;
                        WordPad_2.Items.Add(sdr[0].ToString());
                        WordPad_2.SelectedIndex = WordPad_2.Items.Count - 1;
                    }
                }
                else
                {
                    MessageBox.Show("请先设置记事类别！");
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch  //处理异常
            {
                this.Close();
                
            }
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//查询时间
        {
            if (checkBox1.Checked) { dtp_time.Enabled = true; }
            else { dtp_time.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//查询类型
        {
            if (checkBox2.Checked) { cbbox_type.Enabled = true; }
            else { cbbox_type.Enabled = false; }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckPrompt()//验证输入的有效性 
        { 
        //是否 有主题
            if (WordPad_3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("主题不能为空!");
                WordPad_3.Focus();
                return false;
            }
            //是否有 内容
            if (WordPad_4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("内容不能为空!");
                WordPad_4.Focus();
                return false;
            }
            return true;
        }
        private void btn_Add_Click(object sender, EventArgs e)//添加记事内容
        {
            if (CheckPrompt())//输入合法
            {                                                                      //时间  类别 主题 内容 (时间只取 日期部分 否则查询时将失效)
                string insertSql = string.Format("insert into tb_DayWordPad values('{0}','{1}','{2}','{3}')", WordPad_1.Value.Date, WordPad_2.SelectedItem.ToString(), WordPad_3.Text.Trim(), WordPad_4.Text.Trim());
                try
                {
                    MyDBControls.GetConn();
                    if (Convert.ToInt32(MyDBControls.ExecNonQuery(insertSql)) > 0)
                    {
                        MessageBox.Show("添加成功!");
                        btn_Find_Click(sender, e);//更新
                        WordPad_4.Text = WordPad_3.Text = string.Empty;
                    }
                    MyDBControls.CloseConn();
                }
                catch (Exception err) //处理异常
                {
                    if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                    {
                        MessageBox.Show("输入主题长度不合法,最大长度为20位字母或10个汉字!");
                        WordPad_3.Focus();
                        return;
                    }
                    
                }
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)//查找并显示
        {
            //产生 sql 语句

            string sql = string.Empty;
            if (checkBox1.Checked && checkBox2.Checked == false)//条件只有日期
            {
                sql = string.Format("select Motif as 主题 ,BlotterDate as 时间 ,BlotterSort as 类别 ,Wordpa as 内容 from tb_DayWordPad where BlotterDate='{0}'", dtp_time.Value.Date);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked)//只有类别
            {
                sql = string.Format("select Motif as 主题 ,BlotterDate as 时间 ,BlotterSort as 类别 ,Wordpa as 内容 from tb_DayWordPad where BlotterSort='{0}'", cbbox_type.SelectedItem.ToString());
            }
            else if (checkBox1.Checked && checkBox2.Checked) //两者都有
            {
                sql = string.Format("select Motif as 主题 ,BlotterDate as 时间 ,BlotterSort as 类别 ,Wordpa as 内容 from tb_DayWordPad where BlotterDate='{0}' and BlotterSort='{1}'", dtp_time.Value.Date, cbbox_type.SelectedItem.ToString());
            }
            else//全不选则所有
            {
                sql = string.Format("select Motif as 主题 ,BlotterDate as 时间 ,BlotterSort as 类别 ,Wordpa as 内容 from tb_DayWordPad");
            }
            //提取结果
            try
            {
                MyDBControls.GetConn();
                DataSet ds = MyDBControls.GetDataSet(sql);
                MyDBControls.CloseConn();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch 
            {

               
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //显示内容
            WordPad_1.Value =(DateTime) dataGridView1.SelectedRows[0].Cells[1].Value;//时间
            WordPad_2.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//类别
            WordPad_3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//主题
            WordPad_4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//内容
            //按钮能用
            btn_Delete.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = btn_update.Enabled = false;
            WordPad_3.Text = WordPad_4.Text = string.Empty;//清空
            WordPad_3.Focus();
        }

        private void btn_update_Click(object sender, EventArgs e)//修改记事
        {
           
            string updSql = string.Format("update tb_DayWordPad set BlotterDate='{0}' ,BlotterSort='{1}',Motif='{2}',Wordpa='{3}' where BlotterDate='{4}' and BlotterSort='{5}' and Motif='{6}'",
                WordPad_1.Value.Date,//更新后的时间
                WordPad_2.SelectedItem.ToString(),//类别
                WordPad_3.Text.Trim(),//主题
                WordPad_4.Text,//内容
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),//原来的时间
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),//原来的类别
                dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//原来主题
            //MessageBox.Show(updSql);
            //return;
            try
            {
                MyDBControls.GetConn(); //打开连接
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(updSql)) != 0) //修改内容
                {
                    MessageBox.Show("修改成功!");
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch (Exception err) //处理异常
            {
                if (err.Message.IndexOf("将截断字符串或二进制数据") != -1)
                {
                    MessageBox.Show("输入主题长度不合法,最大长度为20位字母或10个汉字!");
                    WordPad_3.Focus();
                    return;
                }
                
            }

            // //将修改更新
            dataGridView1.SelectedRows[0].Cells[1].Value = WordPad_1.Value.Date;
            dataGridView1.SelectedRows[0].Cells[2].Value = WordPad_2.SelectedItem.ToString();
            dataGridView1.SelectedRows[0].Cells[0].Value = WordPad_3.Text;
            dataGridView1.SelectedRows[0].Cells[3].Value = WordPad_4.Text;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string delSql = string.Format("delete from tb_DayWordPad where  BlotterDate='{0}' and BlotterSort='{1}' and Motif='{2}'",
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),//原来的时间
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),//原来的类别
                dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//原来主题
            try
            {
                MyDBControls.GetConn(); //打开连接
                if (Convert.ToInt32(MyDBControls.ExecNonQuery(delSql)) != 0) //删除内容
                {
                    MessageBox.Show("删除成功!");
                    btn_Find_Click(sender, e);//更新
                    WordPad_4.Text = WordPad_3.Text = string.Empty;//清空原有内容
                }
                MyDBControls.CloseConn(); //关闭连接
            }
            catch  //处理异常
            {
               
                MessageBox.Show("操作失败，请重新登录！");
            }
        }
       

    }
}