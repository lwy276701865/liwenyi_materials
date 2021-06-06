using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using KwicObjects;
using System.IO;
using System.Collections;

namespace KwicClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //方法一
            //BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            //BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            //serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            //IDictionary props = new Hashtable();
            //props["port"] = 8081;
            //TcpChannel chan = new TcpChannel(props , clientProvider, serverProvider);
            // Creating a custom formatter for a TcpChannel sink chain.

            //方法二
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = 8085;
            // Pass the properties for the port setting and the server provider in the server chain argument. (Client remains null here.)
            //建立通道
            TcpChannel chan = new TcpChannel(props, null, provider);
            //注册通道
            ChannelServices.RegisterChannel(chan,false);
            IKwic obj = (IKwic)Activator.GetObject(typeof(KwicObjects.IKwic),
                "tcp://localhost:8080/RemotingKwicService");

            if (obj == null)
            {
                Console.WriteLine("Cloudn't create Remoting Object 'Kwic'.");
            }
            FileStream in_fs = new FileStream("D:\\input.txt", FileMode.Open);
            ArrayList in_al = new ArrayList();
            ArrayList out_al = new ArrayList();
            try
            {
                in_al = obj.input(in_fs, in_al);
                //obj.sort(in_al);
                out_al = obj.sort(in_al);
                foreach (string st in out_al)
                {
                    Console.WriteLine(st);
                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
