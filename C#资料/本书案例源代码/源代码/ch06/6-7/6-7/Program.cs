using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_7
{
    class Output<T>   //定义泛型类Output，包含Output方法
    {
        public T obj;
        public Output(T obj)
        {
            this.obj = obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int obj1 = 2017;
            Output<int> a = new Output<int>(obj1);
            Console.Write(a.obj + ",");
            string obj2 = "hello C#!";
            Output<string> b = new Output<string>(obj2);
            Console.WriteLine(b.obj);
            Console.ReadLine();
        }
    }
}
