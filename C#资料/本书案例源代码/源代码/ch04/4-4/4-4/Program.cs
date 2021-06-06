using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_4
{
    class Program
    {
        public int a = 1;
        public int b = 2;
        public int sum;
        public Program()
        {
            sum = a + b;
        }
        static void Main(string[] args)
        {
            Program s = new Program();   //使用构造函数实例化Program对象
            Console.WriteLine("a+b=" + s.sum);
            Console.ReadLine();
        }
    }
}
