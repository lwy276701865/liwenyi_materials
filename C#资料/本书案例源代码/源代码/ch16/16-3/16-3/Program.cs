using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _16_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建RegistryKey实例
            RegistryKey r = Registry.Users;
            //使用OpenSubKey方法打开打开HKEY_USERS\.DEFAULT子键
            RegistryKey r2 = r.OpenSubKey(".DEFAULT", true);
            //使用CreateSubKey方法创建名为test1的子键
            RegistryKey r3 = r2.CreateSubKey("test1");
            //使用CreateSubKey方法在test1键下创建一个名为test2的子键
            RegistryKey r4 = r3.CreateSubKey("test2");
            //在test2子键下创建一个名为value的键值，初始化键值为1
            r4.SetValue("value", "1");
        }
    }
}
