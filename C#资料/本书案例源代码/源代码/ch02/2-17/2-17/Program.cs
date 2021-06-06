using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_17
{
    class Program
    {
        class A   //创建一个类A
        {
            public int value = 0;   //声明一个公共int类型变量value
        }
        static void Main(string[] args)
        {
            int v1 = 0;   //声明一个int类型变量v1初始化为0
            int v2 = v1;   //声明一个int类型的变量v2，并将v1赋值给v2
            v2 = 258;   //重新将变量v2赋值为258
            A b1 = new A();   //使用new关键字创建引用对象
            A b2 = b1;   //使b1等于b2
            b2.value = 147;   //设置变量b2的value值
            Console.WriteLine("v1={0},v2={1}", v1, v2);   //输出变量v1和v2
            Console.WriteLine("b1={0},b2={1}", b1.value, b2.value);   //输出引用类型对象的value值
            Console.ReadLine();
        }
    }
}
