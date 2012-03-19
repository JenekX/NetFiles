using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.ServiceReference1;
using System.ServiceModel;

namespace ConsoleApplication1
{
    public class CallbackHandler : INetFilesServiceCallback
    {
        public void NewMessageReceive()
        {
            Console.WriteLine("new message received");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
            NetFilesServiceClient client = new NetFilesServiceClient(instanceContext);

            int idUser = Convert.ToInt32(Console.ReadLine());
            int idUserFor = Convert.ToInt32(Console.ReadLine());

            client.Connect(idUser);

            Console.ReadKey();

            client.AddMessage(idUserFor, "Test message for client_" + idUserFor.ToString());

            Console.ReadKey();

            client.Disconnect();
            client.Close();
        }
    }
}
