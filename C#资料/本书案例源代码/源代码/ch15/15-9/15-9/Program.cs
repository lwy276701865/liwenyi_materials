using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace _15_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化MailAddress类
            MailAddress m = new MailAddress("C @C#.com","张三");
            //获取电子邮件地址的相关信息
            Console.WriteLine("电子邮箱地址为:{0} 显示名为:{1} 服务器名为:{2} 用户名为:{3}", m.Address, m.DisplayName, m.Host, m.User);
            Console.ReadLine();
        }
    }
}
