using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1, sum = 0;
            Console.WriteLine("100以内自然数求和");
            do
            {
                sum += i;
                i++;
            }
            while (i <= 100);
            Console.WriteLine("1+2+3+...+100={0}", sum);
            Console.ReadLine();
        }
    }
}
