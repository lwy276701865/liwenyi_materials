using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Kwic
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fr = new FileStream("d:\\input.txt", FileMode.Open);
            FileStream fw = new FileStream("d:\\output.txt", FileMode.Create);
            Pipe in_cs, cs_al, al_ou;
            in_cs = new Pipe();
            cs_al = new Pipe();
            al_ou = new Pipe();
            Input_Filter input = new Input_Filter(fr, in_cs);
            Circular_shift cs = new Circular_shift(in_cs, cs_al);
            Alphabetizer al = new Alphabetizer(cs_al, al_ou);
            Output_Filter of = new Output_Filter(al_ou, fw);
            input.run();
            cs.run();
            al.run();
            of.run();

            Console.Read();


        }
    }
}
