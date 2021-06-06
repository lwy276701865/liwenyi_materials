using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_25
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 2017;   //声明一个int型变量val并初始化为2017
            object obj = val;   //将val转换为引用对象obj
            Console.WriteLine("val的值为{0},装箱后obj的值为{1}", val, obj);
            int i=(int)obj;   //拆箱操作
            Console.WriteLine("拆箱后obj的值为{0},i值为{1}",  obj,i);
            Console.ReadLine();

        }
    }
}
