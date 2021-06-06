using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_16
{
    class Program
    {
        enum Days { Sun,Mon,Tue,Wed,Thu,Fri,Sat};   //定义枚举类型Days，并赋值

        static void Main(string[] args)
        {
            Days WeekdayStart = Days.Mon;   //为枚举变量WeekdayStart赋值Mon
            Days WeekdayEnd = Days.Fri;   //为枚举变量WeekdayEnd赋值Fri
            Console.WriteLine("WeekdayStart:{0}", WeekdayStart);
            Console.WriteLine("WeekdayEnd：{0}", WeekdayEnd);
            Console.ReadLine();
        }
    }
}
