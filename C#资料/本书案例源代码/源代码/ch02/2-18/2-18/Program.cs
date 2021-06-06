using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_18
{
    class Program
    {
        public struct V   //定义结构V
        {
            public int N;   //定义int型变量N
        }
        public class A   //定义类A
        {
            public int N;   //定义int型变量N
        }
        static void Main(string[] args)
        {
            A S1 = new A();   //对类A创建一个名为S1的对象并赋值10
            S1.N = 10;
            A S2 = S1;   //对类A创建一个名为S2的对象并赋值为S1
            S2.N = 11;   //更改S2的变量值为11
            Console.WriteLine("S1={0} \t S2={1}", S1.N, S2.N);

            V R1 = new V();   //对结构V创建一个名为R1的对象并赋值20
            R1.N = 20;
            V R2 = R1;   //对结构V创建一个名为R2的对象并赋值为R1
            R2.N = 22;   //更改R2的变量值为22
            Console.WriteLine("R1={0} \t R2={1}", R1.N, R2.N);
            Console.ReadLine();
        }
    }
}
