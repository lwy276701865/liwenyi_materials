using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_5
{
    class Program
    {
        void lockthread()
        {
            Mutex m = new Mutex(false);   //实例化Mutex对象
            m.WaitOne();   //阻止当前线程
            Console.WriteLine("Mutex类线程同步实例");
            Console.ReadLine();
            m.ReleaseMutex();   //释放Mutex对象
        }
        static void Main(string[] args)
        {
            Program p = new Program();   //实例化对象
            p.lockthread();   //调用lockthread方法
        }
    }
}
