using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_27
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 31;
            int b = 10;
            int c;
            c = a + b;
            Console.WriteLine("a+b={0}", c);
            c = a - b;
            Console.WriteLine("a-b={0}", c);
            c = a * b;
            Console.WriteLine("a*b={0}", c);
            c = a / b;
            Console.WriteLine("a/b={0}", c);
            c = a % b;
            Console.WriteLine("a%b={0}", c);
            c = ++a;    // ++a 先进行自增运算再赋值
            Console.WriteLine("++a={0}", c);
            c = --a;   // --a 先进行自减运算再赋值
            Console.WriteLine("--a={0}", c);
            Console.ReadLine();
        }
    }
}
