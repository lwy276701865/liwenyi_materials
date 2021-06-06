using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace _15_11
{
    class Program
    { 
        public static void Main(string[] args)
        {
            //发件人
            MailAddress from = new MailAddress("test@163.com");
            //接收人
            MailAddress to = new MailAddress("test@163.com");
            //实例化MailMessage对象
            MailMessage m = new MailMessage(from,to);
            //邮件主题
            m.Subject = "邮件的主题";
            //邮件内容
            m.Body = "邮件内容";
            //实例化SmtpClient
            SmtpClient c = new SmtpClient("192.168.1.107", 25);
            //设置发件人验证凭证
            c.Credentials = new System.Net.NetworkCredential("test", "123");
            //发送邮件
            c.Send(m);
        }
    }
}
