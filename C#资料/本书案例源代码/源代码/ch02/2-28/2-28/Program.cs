using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_28
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b; 
            b = a++;   // a++ 先赋值再进行自增运算
            Console.WriteLine("a++运算:");
            Console.WriteLine("a 的值为 {0}", a);
            Console.WriteLine("b 的值为 {0}", b);
            a = 1;   // 重新初始化 a
            b = ++a;   // ++a 先进行自增运算再赋值
            Console.WriteLine("++a运算:");
            Console.WriteLine("a 的值为 {0}", a);
            Console.WriteLine("b 的值为 {0}", b);
            a = 1;   // 重新初始化 a
            b = a--;   // a-- 先赋值再进行自减运算
            Console.WriteLine("a--运算:");
            Console.WriteLine("a 的值为 {0}", a);
            Console.WriteLine("b 的值为 {0}", b);
            a = 1;   // 重新初始化 a
            b = --a;   // --a 先进行自减运算再赋值
            Console.WriteLine("--a运算:");
            Console.WriteLine("a 的值为 {0}", a);
            Console.WriteLine("b 的值为 {0}", b);
            Console.ReadLine();
        }
    }
}
