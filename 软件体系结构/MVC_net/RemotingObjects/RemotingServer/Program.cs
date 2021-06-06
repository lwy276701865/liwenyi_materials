using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace RemotingServer
{//RemotingServer
    //生成应用服务exe文件
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8080);//建立TCP端口 通道
            ChannelServices.RegisterChannel(channel, false);//注册通道
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObjects.Person),
                "RemotingPersonService", WellKnownObjectMode.SingleCall);
            System.Console.WriteLine("Server:Press Enter key to exit");
            System.Console.ReadLine();
        }
    }
}
