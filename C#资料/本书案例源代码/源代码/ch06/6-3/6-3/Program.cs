using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string StrArray = "";
            int[] arr = new int[10] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            Console.WriteLine("一维数组遍历结果：");
            foreach (int i in arr)
            {
                StrArray = StrArray + i.ToString() + "   ";
            }
            Console.WriteLine(StrArray);
            Console.ReadLine();
        }
    }
}
