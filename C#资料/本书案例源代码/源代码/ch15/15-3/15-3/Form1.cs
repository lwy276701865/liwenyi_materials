using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace _15_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //判断IP地址是否为空
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入IP地址！");
            }
            else
            {
                //实例化IPEndPoint对象
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(textBox1.Text), 80);
                //IP地址
                label2.Text = "IP地址为：" + ipe.Address.ToString();
                //端口号
                label3.Text = "端口号为：" + ipe.Port;
                //IP地址族
                label4.Text = "IP地址族为：" + ipe.AddressFamily;
            }
        }
    }
}
