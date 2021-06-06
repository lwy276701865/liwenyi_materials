using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_2
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
            ResultInfo = "姓名：" + txtName.Text + "\r\n";
            ResultInfo += "电话：" + txtPhone.Text + "\r\n";
            ResultInfo += "通信地址：" + txtAddress.Text + "\r\n";
            txtInfo.Text = ResultInfo;
        }
    }
}
