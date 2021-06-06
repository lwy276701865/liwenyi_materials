using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            try
            {
                int i = 10 / m;
            }
            catch (DivideByZeroException ex)        //除数不能数零异常类
            {
                Console.WriteLine("错误:" + ex.Message.ToString());
            }
            Console.WriteLine("离开了try...catch语句");
            Console.ReadLine();
        }
    }
}
