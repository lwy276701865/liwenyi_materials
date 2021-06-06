using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_6
{
    public partial class Test   //定义分部类
    {
        private int x;
        private int y;

        public Test(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Test
    {
        public void Print()
        {
            Console.WriteLine("x={0},y={1}",x, y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test(1, 2);
            t.Print();
            Console.ReadLine();
        }
    }
}
