using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_7
{
    struct test
    {
        public int x;   //不能直接对其进行赋值
        public int y;
        public test(int x, int y)   //带参数的构造函数
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("x={0},y={1}", x, y);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            test t = new test(1, 2);
            test t2 = t;
            t.x = 10;
            Console.WriteLine("t2.x={0}", t2.x);
            Console.ReadLine();
        }
    }
}
