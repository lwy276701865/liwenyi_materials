using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_15
{
    class Program
    {
        struct Book
        {
            public string title;
            public string author;
            public string subject;
            public int bookid;
        }
        static void Main(string[] args)
        {
            Book C;
            C.title = "C#";
            C.author = "L";
            C.subject = "C# Program";
            C.bookid = 2017;
            Console.WriteLine("C title:{0}", C.title);
            Console.WriteLine("C author:{0}", C.author);
            Console.WriteLine("C subject:{0}", C.subject);
            Console.WriteLine("C bookid:{0}", C.bookid);
            Console.ReadLine();
        }
    }
}
