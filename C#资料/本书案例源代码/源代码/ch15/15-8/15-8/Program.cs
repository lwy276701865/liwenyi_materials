using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace _15_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化MailMessage
            MailMessage message = new MailMessage();
            //添加密件的抄送人
            message.Bcc.Add("C@domain.com");
            //Body属性设置邮件正文
            message.Body = "邮件的正文";
            //BodyEncoding属性设置正文的编码形式，此处为系统默认编码
            message.BodyEncoding = System.Text.Encoding.Default;
            //设置邮件发送人
            message.From = new MailAddress("FromMailBox@Sina.com");
            //设置邮件主题
            message.Subject = "邮件的主题";
        }
    }
}
