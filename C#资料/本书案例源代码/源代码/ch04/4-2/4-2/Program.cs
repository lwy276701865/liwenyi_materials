using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2
{
    public class Circle
    {
        public const double PI = 3.14;   //创建常量
        public static double Girth;   //声名静态变量
        private int _r;   //声名非静态变量
        public int R   //将半径封装成公共属性
        {
            get { return _r; }
            set
            {
                if (_r >= 0)
                {
                    _r = value;
                }
            }
        }
        public double GetArea(int UserR)   //声明计算面积方法
        {
            R = UserR;
            return PI * R * R;   //返回圆的面积
        }
        public double GetGirth(int UserR)   //声明计算周长方法
        {
            R = UserR;
            return PI * (2 * R);   //返回圆的周长
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入半径：");
            Circle c = new Circle();
            c.R = int.Parse(Console.ReadLine());
            Console.WriteLine("圆的面积为：" + c.GetArea(c.R));
            Console.WriteLine("圆的周长为：" + c.GetGirth(c.R));
            Console.ReadLine();
        }
    }
}
