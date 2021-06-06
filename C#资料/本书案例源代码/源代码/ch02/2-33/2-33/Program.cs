using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("int 的大小是 {0}", sizeof(int));
            Console.WriteLine("int 的原型是 {0}", typeof(int));
            int a, b;
            a = 1;
            b = (a == 1) ? 2 : 3;
            Console.WriteLine("b 的值是 {0}", b);
            Console.ReadLine();
        }
    }
}
