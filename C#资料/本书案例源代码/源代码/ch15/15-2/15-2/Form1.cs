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
using System.Net.Sockets;

namespace _15_2
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
                //获取指定主机IP地址
                IPAddress[] ip = Dns.GetHostAddresses(textBox1.Text);
                foreach (IPAddress i in ip)
                {
                    //显示网络协议地址
                    label2.Text = "网络协议地址：" + i.Address;
                    //显示IP地址的地址族
                    label3.Text = "IP地址的地址族：" + i.AddressFamily.ToString();
                    //判断是否为一个IPv4-mapped IPv6地址
                    label4.Text = "是否为一个IPv4-mapped IPv6地址：" + i.IsIPv4MappedToIPv6;
                    //判断是否为 IPv6 链接本地地址
                    label5.Text = "是否为 IPv6 链接本地地址：" + i.IsIPv6LinkLocal;
                }
            }
        }
    }
}
