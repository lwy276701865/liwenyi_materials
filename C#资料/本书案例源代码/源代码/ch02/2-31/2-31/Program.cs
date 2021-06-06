using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_31
{
    class Program
    {
        static void Main(string[] args)
        {
            bool B = false;   //声明bool类型变量B初始化为false
            int num = 2017;
            bool result;
            result = B && (num < 2018);   //输出逻辑与运算后返回值
            Console.WriteLine(result);
            result = B || (num < 2018);   //输出逻辑或运算后返回值
            Console.WriteLine(result);
            result = ! (num < 2018);   //输出逻辑异或运算后返回值
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
