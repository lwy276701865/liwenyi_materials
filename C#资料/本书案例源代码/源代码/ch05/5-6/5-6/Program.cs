using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_6
{
    interface IPerson
    {
        string Name { get; set; }
        string Sex { get; set; }
    }
    interface IStudent:IPerson
    {
        void Output();
    }
    interface ITeacher:IPerson
    {
        void Output();
    }
    class Program:IPerson,ITeacher,IStudent
    {
        string name = "";
        string sex = "";
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        void IStudent.Output()   //显式实现接口IStudent
        {
            Console.WriteLine("学生：" + Name + " " + Sex);
        }
        void ITeacher.Output()   //显式实现接口ITeacher
        {
            Console.WriteLine("老师：" + Name + " " + Sex);
        }
        static void Main(string[] args)
        {
            Program a1 = new Program();
            Program a2 = new Program();
            a1.Name = "张三";
            a2.Name = "李四";
            a1.Sex = "男";
            a2.Sex = "女";
            IStudent s = a1;
            s.Output();
            ITeacher t = a2;
            t.Output();
            Console.ReadLine();
        }
    }
}
