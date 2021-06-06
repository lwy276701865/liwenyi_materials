using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_5
{
    class Program
    {
        class test
        {
            ~test()
            {
                Console.WriteLine("测试析构函数的自动调用");
                Console.ReadLine();   //短暂显示结果
            }
        }
        static void Main(string[] args)
        {
            test t = new test();   //实例化Program对象
        }
    }
}
