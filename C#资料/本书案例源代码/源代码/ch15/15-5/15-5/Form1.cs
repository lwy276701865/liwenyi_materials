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
using System.IO;
using System.Threading;

namespace _15_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TcpListener Listener;
        public Socket SocketClient;
        NetworkStream NetStream;
        StreamReader ServerReader;
        StreamWriter ServerWriter;
        Thread Thd;
        void GetMessage()
        {
            //网络流不为空并且有可用数据
            if (NetStream != null && NetStream.DataAvailable)
            {
                richTextBox1.AppendText(DateTime.Now.ToString());
                richTextBox1.AppendText("  客户端说:\n");
                richTextBox1.AppendText(ServerReader.ReadLine() + "\n");
                //设置下拉框
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.Focus();
                richTextBox2.Focus();
            }
        }
        public void BeginLister()
        {
            while (true)
            {
                try
                {
                    //获取主机地址
                    IPAddress[] Ips = Dns.GetHostAddresses("");
                    string GetIp = Ips[0].ToString();
                    //配置监听
                    Listener = new TcpListener(IPAddress.Parse(GetIp), 8888);
                    Listener.Start();
                    CheckForIllegalCrossThreadCalls = false;
                    button1.Enabled = false;
                    // MessageBox.Show("服务器已经开启！", "服务器消息", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    this.Text = "服务器 已经开启……";
                    //接受挂起
                    SocketClient = Listener.AcceptSocket();
                    NetStream = new NetworkStream(SocketClient);
                    ServerWriter = new StreamWriter(NetStream);
                    ServerReader = new StreamReader(NetStream);
                    if (SocketClient.Connected)
                    {
                        MessageBox.Show("客户端连接成功!", "服务器消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                { }// 不做处理 继续测试监听
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //创建线程
            Thd = new Thread(new ThreadStart(BeginLister));
            //启动线程
            Thd.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //richTextBox1不可编辑
            richTextBox1.ReadOnly = true;
            //启用Enabled事件生成
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //调用接收消息方法
            GetMessage();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox2.Text.Trim() != "")
                {
                    //信息写入流
                    ServerWriter.WriteLine(richTextBox2.Text);
                    ServerWriter.Flush();
                    richTextBox1.AppendText(DateTime.Now.ToString());
                    //.Text += "服务器说:           " + rtxSendMessage.Text + "\n";
                    richTextBox1.AppendText("  服务器说:\n");
                    richTextBox1.AppendText(richTextBox2.Text + "\n");
                    richTextBox2.Clear();
                    //滚动条
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.Focus();
                    richTextBox2.Focus();
                }
                else
                {
                    MessageBox.Show("信息不能为空!", "服务器消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBox2.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("客户端连接失败……", "服务器消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Thd.Abort();
                //如果有线程则关闭线程
                this.Close();
            }
            //出错 则说明没有线程  直接关闭窗体
            catch
            {
                this.Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Dr = MessageBox.Show("这样会中断与客户端的连接,你要关闭该窗体吗？", "服务器信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (DialogResult.Yes == Dr)
            {
                try
                {
                    Listener.Stop();
                    this.Thd.Abort();
                    e.Cancel = false;
                }
                catch { }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
