using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList MyAL = new ArrayList();
            MyAL.Add(15);
            MyAL.Add(18);
            MyAL.Add(25);
            MyAL.Add(37);
            MyAL.Add(17);
            MyAL.Add(1);
            MyAL.Add(5);
            MyAL.Add(10);
            Console.WriteLine("Capacity: {0} ", MyAL.Capacity);
            Console.WriteLine("Count: {0}", MyAL.Count);
            Console.WriteLine("排序前为: ");
            foreach (int i in MyAL)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("升序排序后为: ");
            MyAL.Sort();
            foreach (int i in MyAL)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}
