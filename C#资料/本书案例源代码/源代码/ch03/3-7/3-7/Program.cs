using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.WriteLine("100以内自然数求和");
            for (int i = 1; i <= 100; i++)
            {
                sum += i;
            }
            Console.WriteLine("1+2+3+...+100={0}", sum);
            Console.ReadLine();
        }
    }
}
