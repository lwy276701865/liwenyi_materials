using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    class Student
    {
        private string name;
        private string classid;
        public string ClassId
        {
            get
            {
                return classid;
            }
            set
            {
                classid = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                   name = value; 
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student S = new Student();
            S.Name = "张三";
            S.ClassId = "计算机3班";
            Console.WriteLine(S.Name+"\t"+S.ClassId);
            Console.ReadLine();
        }
    }
}
