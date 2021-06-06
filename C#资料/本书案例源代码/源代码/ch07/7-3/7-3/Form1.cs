using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "个人联系信息";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string ResultInfo;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            if (name != "")
            {
                ResultInfo = "姓名：" + name + "\r\n";
            }
            else
            {
                MessageBox.Show("姓名不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   //结束单击事件，终止程序的运行
            }
            if (phone != "")
            {
                ResultInfo += "电话：" + phone + "\r\n";
            }
            else
            {
                MessageBox.Show("电话不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   //结束单击事件，终止程序的运行
            }
            if (address != "")
            {
                ResultInfo += "通信地址：" + address + "\r\n";
            }
            else
            {
                MessageBox.Show("通信地址不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   //结束单击事件，终止程序的运行
            }
            bool IsNum = true;   //判断是否为数字
                                 //以下循环实现对电话号码是否为数字的判断
            for (int i = 0; i < phone.Length; i++)
            {
                if (!(char.IsDigit(phone[i])))
                {
                    IsNum = false;
                    break;
                }
            }
            if (!IsNum)
            {
                MessageBox.Show("电话号码必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   //结束单击事件，终止程序的运行
            }
            txtInfo.Text = ResultInfo;
        }
    }
}
