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
using System.Net;
using System.IO;
using System.Threading;

namespace _15_6
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        public TcpClient TcpClient;
        StreamReader ClientReader;
        StreamWriter ClientWriter;
        NetworkStream Stream;
        Thread Thd;
        private void Client_Load(object sender, EventArgs e)
        {
            //设置不可编辑
            richTextBox1.ReadOnly = true;
            //定时器启动
            timer1.Enabled = true;
        }
        void GetMessage()
        {
            if (Stream != null && Stream.DataAvailable)
            {
                richTextBox1.AppendText(DateTime.Now.ToString());
                richTextBox1.AppendText(" 服务器说:\n");
                richTextBox1.AppendText(ClientReader.ReadLine() + "\n");
                //下拉框
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.Focus();
                richTextBox2.Focus();
            }
        }
        void GetConn()
        {
            CheckForIllegalCrossThreadCalls = false;
            while (true)
            {
                try
                {
                    TcpClient = new TcpClient(textBox1.Text, int.Parse(textBox2.Text.Trim()));
                    Stream = TcpClient.GetStream();
                    //创建读写流
                    ClientReader = new StreamReader(Stream);
                    ClientWriter = new StreamWriter(Stream);
                    textBox1.Enabled = false;
                    button1.Enabled = false;
                    this.Text = "客户端   " + "正在与" + textBox1.Text.Trim() + "连接……";
                    return;
                }
                catch
                {
                    textBox1.Enabled = true;
                    button1.Enabled = true;
                    this.Text = "连接失败……";
                    //MessageBox.Show("连接失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入服务器IP", "客户端信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Thd = new Thread(new ThreadStart(GetConn));
                Thd.Start();
            }
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
                    ClientWriter.WriteLine(richTextBox2.Text);
                    //清空缓冲区数据
                    ClientWriter.Flush();
                    richTextBox1.AppendText(DateTime.Now.ToString());
                    richTextBox1.AppendText(" 客户端说: \n");
                    richTextBox1.AppendText(richTextBox2.Text + "\n");
                    richTextBox2.Clear();
                    //设置下拉框
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.Focus();
                    richTextBox2.Focus();
                }
                else
                {
                    MessageBox.Show("信息不能为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
            }
            catch
            {
                //启用控件
                textBox1.Enabled = true;
                button1.Enabled = true;
                MessageBox.Show("服务器连失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = "连接失败……";
                return;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("这样会中断与服务器的连接,你要关闭该窗体吗？", "客户端信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (DialogResult.Yes == dr)
            {
                e.Cancel = false;
                if (Thd != null)
                {
                    Thd.Abort();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
