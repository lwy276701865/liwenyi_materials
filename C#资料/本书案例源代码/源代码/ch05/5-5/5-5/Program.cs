using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_5
{
    interface Istudent   //定义接口
    {
        string StudentID { get; set; }   //定义Id属性
        string Name { get; set; }   //定义Name属性
        char Sex { get; set; }   //定义Sex属性
        void Answer();  //定义Answer方法
    }
    class Program:Istudent
    {
        //声明私有字段
        string _ID;
        string _name;
        char _sex;
        //封装私有字段，从而实现从接口继承的属性成员
        public string StudentID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public char Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        //实现从接口继承的方法成员
        public void Answer()
        {
            string s = "学号：" + StudentID+"\t";
            s += "姓名：" + Name+"\t";
            s += "性别：" + Sex.ToString();
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            Program a = new Program();
            a.StudentID = "2017";
            a.Name = "张三";
            a.Sex = '男';
            Istudent a1= a ;
            a.Answer();
            Console.ReadLine();
        }
    }
}
