using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_2
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
            //除数不能为零异常类
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("错误:" + ex.Message.ToString());
            }
            finally
            {
                Console.WriteLine("finally块内的代码总是会执行");
            }
            Console.WriteLine("离开了try...catch...finally语句");
            Console.ReadLine();
        }
    }
}
