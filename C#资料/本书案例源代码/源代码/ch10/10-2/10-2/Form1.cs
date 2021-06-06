using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _10_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread MyThread1;   //声明线程1
        Thread MyThread2;   //声明线程2
        void GetProgress2()   //线程2方法
        {
            while (progressBar1.Value < 100)
            {
                progressBar1.PerformStep();   //按照step值递增
                if (progressBar2.Value >= 100)
                {
                    if (MyThread1.IsAlive)
                    {
                        MyThread1.Abort();      //终止线程1
                    }
                }
                else
                {
                    if (progressBar1.Value >= 100)
                    {
                        progressBar1.Value = 0;      //进度条1进度下一轮进度加载
                    }
                }
                Thread.Sleep(50);   //线程休眠
            }
        }
        void GetProgress1()   //线程1方法
        {
            while (progressBar2.Value < 100)
            {
                progressBar2.PerformStep();
                if (progressBar2.Value >= 100) //判断进度条2是否完成
                {
                    MessageBox.Show("进度完成");
                    if (MyThread2.IsAlive)
                    {
                        MyThread2.Abort();//终止线程2
                    }
                }
                Thread.Sleep(50);   //线程休眠
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Step = 10;   //设置进度条1的增量属性
            progressBar2.Step = 2;   //设置进度条2的增量属性
            CheckForIllegalCrossThreadCalls = false;    //禁用不安全线程的检测
            MyThread1 = new Thread(new ThreadStart(GetProgress1));
            MyThread2 = new Thread(new ThreadStart(GetProgress2));
            MyThread1.Priority = ThreadPriority.Lowest;   //安排在任何其他优先级的线程之后
            MyThread1.Start();
            MyThread2.Start();
        }
    }
}
