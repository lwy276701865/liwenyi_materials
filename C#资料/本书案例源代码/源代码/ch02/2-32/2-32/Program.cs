using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_32
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;   /* 20 = 0001 0100 */
            int b = 15;   /* 15 = 0000 1111 */
            int c = 0;
            Console.WriteLine("a 的值是 {0} \t b 的值是 {1}", a,b);
            c = a & b;   /* 4 = 0000 0100 */
            Console.WriteLine("a & b 的值是 {0}", c);
            c = a | b;   /* 31 = 0001 1111 */
            Console.WriteLine("a | b 的值是 {0}", c);
            c = a ^ b;   /* 27 = 0001 1011 */
            Console.WriteLine("a ^ b 的值是 {0}", c);
            c = ~a;   /* -21 = 1110 1011 */
            Console.WriteLine("~a 的值是 {0}", c);
            c = a << 2;   /* 80 = 0101 0000 */
            Console.WriteLine("a << 2 的值是 {0}", c);
            c = a >> 2;   /* 5 = 0000 0101 */
            Console.WriteLine("a >> 2 的值是 {0}", c);
            Console.ReadLine();
        }
    }
}
