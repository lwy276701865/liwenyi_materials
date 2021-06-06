using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace _15_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化MailMessage
            MailMessage message = new MailMessage();
            message.Body = "邮件的正文部分";
            //设置正文的编码形式.这里的设置为取系统默认编码
            message.BodyEncoding = System.Text.Encoding.Default;
            message.From = new MailAddress("Mail@163.com");
            message.IsBodyHtml = false;
            message.ReplyTo = new MailAddress("Mail@163.com");
            message.Sender = new MailAddress("Mail@163.com");
            message.Subject = "邮件的主题";
            //添加附件
            Attachment content = new Attachment(@"E:\附件.txt", MediaTypeNames.Text.Plain);
            ContentDisposition disposition = content.ContentDisposition;
            disposition.FileName = "文本附件";
            message.Attachments.Add(content);
            //设置主题的编码形式.这里的设置为取系统默认编码
            message.SubjectEncoding = System.Text.Encoding.Default;
            //输出文件附件相关信息
            Console.Write("附件内容名称:{0} 类型名称:{1} 附件文件名:{2}", content.Name, content.ContentType.MediaType, content.ContentDisposition.FileName);
            Console.ReadLine();
        }
    }
}
