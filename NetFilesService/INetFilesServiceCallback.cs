using System.ServiceModel;

namespace NetFiles.Service
{
    public interface INetFilesServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewMessageReceive(string userNameFrom, string text);
    }
}