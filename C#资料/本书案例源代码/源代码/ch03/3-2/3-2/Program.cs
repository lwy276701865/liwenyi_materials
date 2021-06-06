using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            Console.WriteLine("a 的值是 {0}", a);
            if (a > 20)
            {
                Console.WriteLine("a 大于 20");   // 如果条件为真，则输出该语句
            }
            else
            {  
                Console.WriteLine("a 小于 20");   // 如果条件为假，则输出该语句
            }
            Console.ReadLine();
        }
    }
}
