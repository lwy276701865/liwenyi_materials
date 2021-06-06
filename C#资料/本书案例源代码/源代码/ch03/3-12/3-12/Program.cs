using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_12
{
    class Program
    {
        static string MyName(string s)
        {
            string n;
            n = "您的姓名为：" + s;
            return n;   //使用return语句返回姓名字符串
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入姓名：");
            string Name = Console.ReadLine();
            Console.WriteLine(MyName(Name));   //调用MyName方法输出姓名
            Console.ReadLine();
        }
    }
}
