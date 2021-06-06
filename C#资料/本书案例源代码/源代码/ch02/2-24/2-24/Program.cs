using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_24
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 2017;   //声明一个int型变量val并初始化为2017
            object obj = val;   //将val转换为引用对象obj
            Console.WriteLine("val的值为{0},obj的值为{1}", val, obj);
            val = 2018;   //给val赋值2018
            Console.WriteLine("val的值为{0},obj的值为{1}", val, obj);
            Console.ReadLine();
        }
    }
}
