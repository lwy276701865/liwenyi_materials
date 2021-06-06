using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            Console.WriteLine("请输入起始数字：");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入结尾数字：");
            int e = int.Parse(Console.ReadLine());
            for (i = s; i < e; i++)
            {
                for (j = 2; j <= (i / j); j++)
                {
                    if ((i % j) == 0)
                    break; // 如果找到，则不是质数
                }
                if (i != 1 && i != 0)
                {
                    if (j > (i / j))
                        Console.WriteLine("{0} 是质数", i);
                }
            }
            Console.ReadLine();
        }
    }
}
