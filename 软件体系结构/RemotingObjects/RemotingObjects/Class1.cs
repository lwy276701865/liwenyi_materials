using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingObjects
{
    public class Class1
    {
    }
    public interface Iperson
    { 
        string getName(string name);
    }
    public class Person : MarshalByRefObject, Iperson
    {
        public Person()
        {
            Console.WriteLine("[Person]:Remoting Object 'Person' is activated.");
        }

        public string getName(string name)
        {
            return name;
        }
    }

}
