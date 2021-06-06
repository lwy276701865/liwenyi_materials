using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_6
{
    class Program
    {
        static double n1 = 1;
        static double n2 = 1;
        public static void Main()
        {
            // 获取线程池的最大线程数和维护的最小空闲线程数
            int maxThreadNum, portThreadNum;
            int minThreadNum;
            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
            Console.WriteLine("最大线程数：{0}", maxThreadNum);
            Console.WriteLine("最小空闲线程数：{0}", minThreadNum);
            int x = 1230;
            //启动第一个任务：计算x的6次方
            Console.WriteLine("启动第一个任务：计算{0}的6次方。", x);
            ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc1), x);
            //启动第二个任务：计算x的6次方根
            Console.WriteLine("启动第二个任务：计算{0}的6次方根。", x);
            ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc2), x);
            // 等待，直到两个数值都完成计算
            while (n1 == 1 || n2 == 1) ;
            // 打印计算结果
            Console.WriteLine("{0},{1}", n1, n2);
            Console.ReadLine();
        }   
        static void TaskProc1(object i)   // 启动第一个任务：计算x的6次方
        {
            n1 = Math.Pow(Convert.ToDouble(i), 6);
        }       
        static void TaskProc2(object j)   // 启动第二个任务：计算x的6次方根
        {
            n2 = Math.Pow(Convert.ToDouble(j), 1.0 / 6.0);
        }
    }
}
