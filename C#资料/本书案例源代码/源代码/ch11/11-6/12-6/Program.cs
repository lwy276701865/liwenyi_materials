using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义数组arr1和arr2
            int[] arr1 = { 1, 3, 5, 7, 9 };
            int[] arr2 = { 2, 4, 6, 8, 10, 12 };
            //创建查询，val+1与val/1相等就添加到grpName集合中
            var query =
               from val1 in arr1
               join val2 in arr2 on val1 + 1 equals val2 / 1 into grpName
               from grp in grpName.DefaultIfEmpty()
               select new { VAL1 = val1, VAL2 = grp };
            foreach (var val in query)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
    }
}
