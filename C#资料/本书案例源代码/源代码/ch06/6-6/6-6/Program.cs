using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable HT = new Hashtable();
            HT.Add("id", "HW001");
            HT.Add("name", "Jack");
            HT.Add("sex", "男");
            Console.WriteLine(HT.Contains("id"));
            HT.Remove("sex");
            HT.Clear();
        }
    }
}
