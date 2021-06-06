using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建RegistryKey实例
            RegistryKey r1 = Registry.Users;
            //使用OpenSubKey打开HKEY_USERS\.DEFAULT子键
            RegistryKey sys = r1.OpenSubKey(@".DEFAULT");
            //使用foreach循环检索HKEY_USERS\.DEFAULT下的所有子项目
            foreach (string s1 in sys.GetSubKeyNames())
            {
                //第一层foreach循环打开s1子键
                Console.WriteLine("子键：" + s1);
                RegistryKey r2 = sys.OpenSubKey(s1);
                //第二层foreach循环输出s1子键下所有项目
                foreach(string s2 in r2.GetSubKeyNames())
                {
                    Console.WriteLine("\t"+s2 + r2.GetValue(s2));
                }
            }
            Console.ReadLine();
        }
    }
}
