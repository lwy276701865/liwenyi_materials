using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_4
{
    class Program
    {
        void lockthread()
        {
            Monitor.Enter(this);   //锁定线程
            Console.WriteLine("Monitor线程同步实例");
            Console.ReadLine();
            Monitor.Exit(this);   //释放线程
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.lockthread();   //调用锁定线程方法
        }
    }
}
