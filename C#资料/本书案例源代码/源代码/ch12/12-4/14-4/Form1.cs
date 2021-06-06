using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置comboBox1不可编辑属性
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //设置comboBox1默认选项为“+”
            comboBox1.SelectedIndex = 0;
            //设置textBox3不可编辑
            textBox3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int DataFirst, DataSencond, Result, OP;
            try
            {
                DataFirst = int.Parse(textBox1.Text);
                DataSencond = int.Parse(textBox2.Text);
                OP = comboBox1.SelectedIndex;
                //判断组合框选项，进行不同计算
                switch (OP)
                {
                    case 0:
                        Result = DataFirst + DataSencond;
                        break;
                    case 1:
                        Result = DataFirst - DataSencond;
                        break;
                    case 2:
                        Result = DataFirst * DataSencond;
                        break;
                    default:
                        Result = DataFirst / DataSencond;
                        break;
                }
                textBox3.Text = Result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    //弹出异常信息对话框
            }
        }
    }
}
