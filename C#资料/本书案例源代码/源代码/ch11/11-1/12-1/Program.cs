using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //数据源
            int[] numbers = new int[7] { 2, 3, 4, 5, 6, 7, 8 };
            //创建查询
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;
            //执行查询
            foreach (int num in numQuery)
            {
                Console.WriteLine("{0,1} ", num);
            }
            Console.ReadLine();
        }
    }
}
