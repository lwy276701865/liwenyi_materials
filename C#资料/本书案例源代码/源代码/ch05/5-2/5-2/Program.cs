using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2
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
    class S2:S   //S2继承于S，拥有S类中的所有公有成员，并且可以拓展其成员
    {
        public int Result()
        {
            return A * B;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            S2 s2 = new S2();
            s2.A = 1;
            s2.B = 2;
            Console.WriteLine("A+B={0}", s2.Sum());   //调用S类中的求和方法
            Console.WriteLine("A*B={0}", s2.Result());   //调用S2类中的方法
            Console.ReadLine();
        }
    }
}
