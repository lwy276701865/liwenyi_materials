using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建RegistryKey实例
            RegistryKey r = Registry.Users;
            //使用OpenSubKey打开HKEY_USERS\.DEFAULT子键
            RegistryKey sys = r.OpenSubKey(@".DEFAULT");
            //通过foreach语句输出HKEY_USERS\.DEFAULT子键下所有项目名称
            foreach(string s in sys.GetSubKeyNames())
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
