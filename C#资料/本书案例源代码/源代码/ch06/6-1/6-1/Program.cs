using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = new int[10];   //n是一个带有10个整数的数组
            int i;
            for (i = 0; i < 10; i++)   //初始化数组n中的元素,并输出它们
            {
                n[i] = i + 1;
                Console.WriteLine(n[i]);
            }
            Console.ReadLine();
        }
    }
}
