using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            do
            {
                if (a == 3)
                {
                    /* 跳过迭代 */
                    a = a + 1;
                    continue;
                }
                Console.WriteLine(a);
                a++;
            }
            while (a < 5);
            Console.ReadLine();
        }
    }
}
