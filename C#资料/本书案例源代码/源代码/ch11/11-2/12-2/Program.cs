using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 8, 50, 37, 9, 57, 54, 1, 10, 15, 6, 7, 35, 25, 58, 41 };
            var query1 =
                from val in arr
                orderby val
                select val;
            Console.WriteLine("升序数组：");
            foreach (var item in query1)
            {
                Console.Write("{0}   ", item);
            }
            Console.WriteLine();
            var query2 =
                from val in arr
                orderby val descending
                select val;
            Console.WriteLine("降序数组：");
            foreach (var item in query2)
            {
                Console.Write("{0}   ", item);
            }
            Console.ReadLine();
        }
    }
}
