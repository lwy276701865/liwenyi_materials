using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double Score;
            Console.WriteLine("请输入分数并按Enter键结束：");
            Score = double.Parse(Console.ReadLine());
            if (Score < 60)
            {
                Console.WriteLine("不及格");
            }
            else
            {
                if (Score <= 69)
                {
                    Console.WriteLine("及格");
                }
                else
                {
                    if (Score <= 79)
                    {
                        Console.WriteLine("中等");
                    }
                    else
                    {
                        if (Score <= 89)
                        {
                            Console.WriteLine("良好");
                        }
                        else
                        {
                            Console.WriteLine("优秀");
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
