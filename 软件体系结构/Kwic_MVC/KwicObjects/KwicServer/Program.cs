using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Collections;
using System.IO;
using System.Collections;
namespace KwicServer
{
    class Program
    {
        static void Main(string[] args)
        {

            //BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();

            //BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();

            //serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            //IDictionary props = new Hashtable();

            //props["port"] = 8080;


            //TcpChannel chan = new TcpChannel(props, clientProvider, serverProvider);

            // Creating a custom formatter for a TcpChannel sink chain.
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = 8080;
            // Pass the properties for the port setting and the server provider in the server chain argument. (Client remains null here.)
            TcpChannel chan = new TcpChannel(props, null, provider);
            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(KwicObjects.Kwic),
                "RemotingKwicService", WellKnownObjectMode.SingleCall);
            System.Console.WriteLine("Server:Press Enter key to exit");
            System.Console.ReadLine();
        }

    }
}
