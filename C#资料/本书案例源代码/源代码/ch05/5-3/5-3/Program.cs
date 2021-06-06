using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_3
{
    public class Preson   //定义Person类
    {
        public string GetInfo()
        {
            return "张三";
        }
    }
    class Student:Preson   //派生Student类
    {
        public new string GetInfo()   //重写GetInfo方法
        {
            return "学生李四";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine(s.GetInfo());
            Console.ReadLine();
        }
    }
}
