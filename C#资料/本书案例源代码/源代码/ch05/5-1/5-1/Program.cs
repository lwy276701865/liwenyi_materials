using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_1
{
    class S
    {
        private int a = 0;
        private int b = 0;
        public int A { get => a; set => a = value; }   //封装
        public int B { get => b; set => b = value; }
        public int Sum()   //求和方法
        {
            return A + B;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            S s = new S();
            s.A = 1;
            s.B = 2;
            Console.WriteLine("A+B={0}",s.Sum());   //调用求和方法计算结果
            Console.ReadLine();
        }
    }
}
