using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            while (a < 10)
            {
                Console.WriteLine(a);
                a++;
                if (a > 5)
                {
                    /* 使用 break 语句终止循环 */
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
