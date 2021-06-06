using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_3
{
    class Program
    {
        public int Sum(int a,int b)   //定义一个返回值为int型的方法
        {
            return a + b;
        }
        public double Sum(int a,double b)   //重新定义方法Sum，它与第一个的返回值
        {                                   //以及参数类型均不同
            return a + b;                   
        }
        public int Sum(int a,int b,int c)   //重新定义方法Sum，它与第一个的参数个数不同
        {
            return a + b + c;
        }
        static void Main(string[] args)
        {
            Program S = new Program();
            int a = 1, b = 2, c = 3;
            double B = 4;
            Console.WriteLine("a=1,b=2,c=3,B=4");
            Console.WriteLine("a+b=" + S.Sum(a, b));   //根据传入参数个数及类型的不同
            Console.WriteLine("a+B=" + S.Sum(a, B));   //分别调用不用Sum重载方法
            Console.WriteLine("a+b+c=" + S.Sum(a, b, c));
            Console.ReadLine();
        }
    }
}
