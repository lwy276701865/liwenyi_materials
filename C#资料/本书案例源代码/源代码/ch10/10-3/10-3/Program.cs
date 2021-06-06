using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_3
{
    class Program
    {
        void lockthread()   //定义lockthread方法
        {
            lock(this)
            {
                Console.WriteLine("Lock实例演示");
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();   //实例化对象
            p.lockthread();   //调用Lock锁定线程的方法
        }
    }
}
