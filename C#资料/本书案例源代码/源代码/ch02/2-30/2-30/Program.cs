using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_30
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2018, y = 2017;
            Console.WriteLine("x是否小于y：" + (x < y));
            Console.WriteLine("x是否大于y：" + (x > y));
            Console.WriteLine("x是否小于或等于y：" + (x <= y));
            Console.WriteLine("x是否大于或等于y：" + (x >= y));
            Console.WriteLine("x是否等于y：" + (x == y));
            Console.WriteLine("x是否不等于y：" + (x != y));
            Console.ReadLine();
        }
    }
}
