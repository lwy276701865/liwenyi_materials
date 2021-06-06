using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace RemotingClient
{
    class Program
    {
        //客户端，可以有自己的业务逻辑
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel();//建立TCP通道
            ChannelServices.RegisterChannel(channel, false);//注册通道
            RemotingObjects.Iperson obj = (RemotingObjects.Iperson)Activator.GetObject(typeof(RemotingObjects.Iperson),
                "tcp://localhost:8080/RemotingPersonService");
        //从应用服务器端返回对象
            //  RemotingObjects.Iperson obj1 = (RemotingObjects.Iperson)Activator.GetObject(typeof(RemotingObjects.Iperson), "tcp://localhost:8080/RemotingPersonService");
            if (obj == null)
            {
                Console.WriteLine("Couldn't create Remoting Object 'Person'.");
          
            }
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            try
            {
                Console.WriteLine("调用远程对象返回姓名：" + obj.getName(name));
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();


        }
    }
}
