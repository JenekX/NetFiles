using System.ServiceProcess;
using System.ServiceModel;
using System;

namespace NetFiles.Service
{
    public partial class ProjectService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public ProjectService()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            ServiceBase.Run(new ProjectService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(NetFilesService));
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            Uri adress = new Uri("net.tcp://localhost:8000/NetFilesService");
            serviceHost.AddServiceEndpoint(typeof(INetFilesService), binding, adress.ToString());
            //Открываем порт и сервис ожидает клиентов  
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}