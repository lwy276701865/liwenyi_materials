using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string StrArray1 = null;
            string StrArray2 = null;
            int[] a = new int[5] { 3, 9, 7, 5, 11 };   //声明并初始化数组a，该数组将作为源数组
            int[] b;   //声明数组b，该数组将作为目标数组
            b=(int[])a.Clone();   //使用数组的克隆方法
            foreach (int i in a)
            {
                StrArray1 = StrArray1 + i.ToString() + "   ";
            }
           // Array.Sort(b);   //对数组b按升序排序
            Array.Reverse(b, 0, b.Length-1);   //对数组b按降序排序
            foreach(int j in b)
            {
                StrArray2 = StrArray2 + j.ToString() + "   ";
            }
            Console.WriteLine("排序前："+StrArray1+"\n"+"排序后："+ StrArray2);
            Console.ReadLine();
        }
    }
}
