using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _16_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建RegistryKey实例
            RegistryKey r = Registry.Users;
            //使用OpenSubKey方法打开HKEY_USERS\.DEFAULT子键
            RegistryKey r2 = r.OpenSubKey(".DEFAULT", true);
            //使用OpenSubKey方法打开名为test1的子键
            RegistryKey r3 = r2.OpenSubKey("test1", true);
            //使用DeleteSubKey方法删除名为test2的子键
            r3.DeleteSubKey("test2", false);
        }
    }
}
