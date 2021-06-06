using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            string s;
            Console.WriteLine("数组的行数为：" + arr.Rank);
            Console.WriteLine("数组的列数为：" + (arr.GetUpperBound(1) + 1));
            Console.WriteLine("二维数组的元素为：");
            for (int i = 0; i < arr.Rank; i++)
            {
                s = null;
                for (int j = 0; j < arr.GetUpperBound(arr.Rank - 1) + 1; j++)
                {   //循环输出二维数组中的每个元素
                    s += arr[i, j] + "  ";
                }
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
