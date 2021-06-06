using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始");
            Thread t = new Thread(new ThreadStart(ThreadMethod));   //实例化Thread类，委托方法ThreadMethod           
            t.Start();   //启动线程
            Thread.Sleep(3000);   //休眠3秒
            t.Resume();   //恢复被挂起线程
            for (char i = 'a'; i < 'f'; i++)
            {
                Console.WriteLine("主线程：{0}", i);
                Thread.Sleep(100);
            }
            t.Join();   //主线程等待辅助线程结束  
            Console.WriteLine("主线程结束");
            Console.ReadLine();
        }
        static void ThreadMethod()
        {
            Thread.CurrentThread.Suspend();   //挂起当前线程
            Console.WriteLine("辅助线程开始...");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("辅助线程：{0}", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("辅助线程结束");
        }
    }
}
