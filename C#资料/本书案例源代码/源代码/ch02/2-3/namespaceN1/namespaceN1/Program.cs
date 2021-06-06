using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N1;   //使用using指令引入命名空间N1

namespace N1   //建立命名空间N1
{
    class A   //在命名空间N1中声明一个类A
    {
        public void M()
        {
            Console.WriteLine("欢迎来到C#世界");   //输出字符串
            Console.ReadLine();
        }
    }
}

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            A N2 = new A();   //实例化N1中的类A
            N2.M();   //调用类A中的M方法
        }
    }
}
