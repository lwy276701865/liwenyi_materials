using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_3
{
    class Program
    {
        //定义一个方法，用于检测参数是否为空
        static void CheckString(string s)
        {
            if (s == "")
            {
                //抛出异常
                throw new ArgumentNullException();
            }
        }
        static void Main()
        {
            Console.WriteLine("输出结果为：");
            //初始化变量，调用CheckString方法
            try
            {
                string s = "";
                CheckString(s);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine( e.Message);
            }
            Console.ReadLine();
        }
    }
}
