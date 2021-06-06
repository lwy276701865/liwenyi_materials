using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _16_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建RegistryKey
            RegistryKey USBKey;
            //使用OpenSubKey方法打开HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\USBSTOR    
            USBKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USBSTOR", false);
            //检索USBSTOR下所有子项的字符串数组
            foreach (string sub1 in USBKey.GetSubKeyNames())
            {
                //使用OpenSubKey方法打开sub1
                RegistryKey sub1key = USBKey.OpenSubKey(sub1, false);
                foreach (string sub2 in sub1key.GetSubKeyNames())
                {
                    try
                    {
                        //打开sub1key的子项
                        RegistryKey sub2key = sub1key.OpenSubKey(sub2, false);
                        //检索Service=disk(磁盘)值的子项 cdrom(光盘)
                        if (sub2key.GetValue("Service", "").Equals("disk"))
                        {
                            String Path = "USBSTOR" + "\\" + sub1 + "\\" + sub2;
                            String Name = (string)sub2key.GetValue("FriendlyName", "");
                            Console.WriteLine("USB名称：  " + Name);
                            Console.WriteLine("UID标记：  " + sub2);
                            Console.WriteLine("路径信息： " + Path);
                            Console.WriteLine();
                            Console.WriteLine("\t\t\t"+"——————分割线——————");
                            Console.WriteLine();
                        }
                    }
                    //异常处理
                    catch (Exception msg) 
                    {
                        Console.WriteLine(msg.Message);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
