using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace _15_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明对象
        UdpClient UdpClient = new UdpClient(8888);
        //发送
        IPEndPoint EndPoint;
        //接受
        IPEndPoint EndPointGet;
        Thread MyThread;
        //声明接受消息方法
        public void GetMess()//接收数据
        {
            //获取已经从网络接收且可供读取的数据量
            if (UdpClient.Available > 0)
            {
                //调用UdpClient对象的Receive方法获取从远程主机返回的Udp数据报
                Byte[] Received = UdpClient.Receive(ref EndPointGet);
                //得到发送信息的ip
                EndPoint = new IPEndPoint((IPAddress.Any), 0);
                string GetUserIp = EndPoint.Address.ToString();
                string GetReceived = Encoding.Default.GetString(Received).Substring(Encoding.Default.GetString(Received).IndexOf("~") + 1);
                //判断接受数据
                if (Received.Length > 0)
                {
                    //配置聊天框
                    richTextBox1.AppendText("主机" + GetUserIp + "  说:\n");
                    richTextBox1.AppendText(GetReceived + "\n");
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.Focus();
                    richTextBox2.Focus();
                }
                //线程终止
                MyThread.Abort();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //得到主机名称
            string IpsName = Dns.GetHostName();
            EndPointGet = new IPEndPoint(IPAddress.Any, 8888);
            textBox1.Text = IpsName;
            textBox2.Text = "8888";
            //禁止异常
            CheckForIllegalCrossThreadCalls = false;
            //启用定时器
            timer1.Enabled = true;
            //设置只读
            richTextBox1.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //本机ip变量
            string Getip = "";
            try
            {
                IPAddress[] Ip = Dns.GetHostAddresses("");//获取本机IP
                foreach (IPAddress Ips in Ip)
                {
                    Getip = Ips.ToString();
                }
                if (richTextBox2.Text != "")
                {
                    //向全段发送广播
                    EndPoint = new IPEndPoint(IPAddress.Broadcast, 8888);
                    UdpClient.EnableBroadcast = true;
                    //定义字节组存放发送到远程主机的信息
                    Byte[] Send = Encoding.Default.GetBytes(Getip + "~" + richTextBox2.Text);
                    //调用Send方法发送信息
                    UdpClient.Send(Send, Send.Length, EndPoint);
                    richTextBox2.Clear();
                    //设置滚动条
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.Focus();
                    richTextBox2.Focus();
                }
                else
                {
                    MessageBox.Show("发送内容不能为空！");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("操作失败!");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //启动线程
            MyThread = new Thread(new ThreadStart(GetMess));
            MyThread.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();
            }
        }
        //窗体关闭事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UdpClient.Close();
            MyThread.Abort();
            Application.Exit();
        }
    }
}
