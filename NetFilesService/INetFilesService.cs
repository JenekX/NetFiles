using System.ServiceModel;
using System;

namespace NetFiles.Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(INetFilesServiceCallback))]
    public interface INetFilesService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string userName);

        [OperationContract(IsOneWay = false)]
        String[] UserList();

        [OperationContract(IsOneWay = true)]
        void Disconnect();

        [OperationContract(IsOneWay = true)]
        void AddUser(string login, string passwordHash, string surname, string name, string patronymic, DateTime bornDate);

        [OperationContract(IsOneWay = true)]
        void AddMessage(string nserNameFor, string text);
    }
}