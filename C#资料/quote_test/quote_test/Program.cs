using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quote_test
{
    class Program
    {
        delegate int MyDele(int x, int y);
        static void Main(string[] args)
        {
            int Sum(int x,int y)
                {
                    return x + y;
                }
            MyDele DeleObj = new MyDele(Sum);
            int Result = DeleObj(1, 2);
            Console.WriteLine("1+2="+Result);
            Console.ReadLine();
        }
    }
  
}
