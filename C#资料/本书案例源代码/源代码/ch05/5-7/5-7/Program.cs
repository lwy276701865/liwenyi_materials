using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_7
{
    class Program
    {
        delegate int MyDele(int x, int y);   //定义MyDele委托

        static void Main(string[] args)
        {
            int Sum(int x, int y)   //声明与MyDele委托匹配的方法
            {
                return x + y;
            }
            MyDele DeleObj = new MyDele(Sum);   //实例化委托，并将Sum方法指向委托
            int Result = DeleObj(1, 2);   //调用委托方法
            Console.WriteLine("x+y={0}", Result);
            Console.ReadLine();
        }
    }
}
