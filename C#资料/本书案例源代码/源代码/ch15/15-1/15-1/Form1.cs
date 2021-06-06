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

namespace _15_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("请输入主机地址！");
            }
            else
            {
                IPAddress[] ip = Dns.GetHostAddresses(textBox1.Text);
                foreach(IPAddress i in ip)
                {
                    label2.Text = i.ToString();
                }
                label2.Text = "主机IP地址：" + " " + label2.Text;
                label3.Text = "本机主机名：" + " " + Dns.GetHostName();
                label4.Text = "DNS主机名：" + " " + Dns.GetHostByName(Dns.GetHostName()).HostName;
            }
        }
    }
}
