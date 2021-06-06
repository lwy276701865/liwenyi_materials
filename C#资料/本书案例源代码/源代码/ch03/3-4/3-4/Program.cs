using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //显示提示
            Console.WriteLine("三种选择型号: 1=(小份, 3.0元) 2=(中份, 4.0元) 3=(大份, 5.0元)");
            Console.Write("您的选择是: ");
            //读入用户选择
            //把用户的选择赋值给变量a
            string s = Console.ReadLine();
            int a = int.Parse(s);
            //根据用户的输入提示付费信息
            switch (a)
            {
                case 1:
                    Console.WriteLine("小份，请付费3.0元。");
                    break;
                case 2:
                    Console.WriteLine("中份，请付费4.0元。");
                    break;
                case 3:
                    Console.WriteLine("大份，请付费5.0元。");
                    break;
                //缺省为中杯
                default:
                    Console.WriteLine("中份，请付费4.0元。");
                    break;
            }
            Console.WriteLine("谢谢使用，欢迎再次光临！");
            Console.ReadLine();
        }
    }
}
