using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _6_9
{
    class Program
    {
        static void Swap<T>(ref T x,ref T y)   //定义Swap泛型方法，将参数定义为泛型
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        static void Main(string[] args)
        {
            int a, b;
            char c, d;
            a = 1;
            b = 2;
            c = 'C';
            d = 'D';
            Console.WriteLine("int型变量交换前的值为：");   //在交换之前显示值
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("char型变量交换前的值为：");
            Console.WriteLine("c = {0}, d = {1}", c, d);
            Swap<int>(ref a,ref  b);   //调用swap方法，交换变量值
            Swap<char>(ref c,ref  d); 
            Console.WriteLine("int型变量交换后的值为：");   //在交换之后显示值
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("char型变量交换后的值为：");
            Console.WriteLine("c = {0}, d = {1}", c, d);
            Console.ReadLine();
        }
    }
}
