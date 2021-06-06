using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            a: Console.WriteLine(i);
            if(i<9)
            {
                i++;
                goto a;
            }
            Console.ReadLine();
        }
    }
}
