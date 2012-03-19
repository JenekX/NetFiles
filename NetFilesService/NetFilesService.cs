using System;
using System.Linq;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections;

namespace NetFiles.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class NetFilesService : INetFilesService
    {
        private static NetFilesDataClassesDataContext context = new NetFilesDataClassesDataContext();
        private static Dictionary<string, INetFilesServiceCallback> connected = new Dictionary<string, INetFilesServiceCallback>();

        private string userName = "";
        private INetFilesServiceCallback callback = null;

        public void Connect(string userName)
        {
            this.userName = userName;
            this.callback = OperationContext.Current.GetCallbackChannel<INetFilesServiceCallback>();

            connected.Add(userName, callback);
        }

        public void Disconnect()
        {
            connected.Remove(userName);

            //OperationContext.Current.Channel.Abort();
        }

        public void AddUser(string login, string passwordHash, string surname, string name, string patronymic, DateTime bornDate)
        {
            /*User user = new User() { Login = login, PasswordHash = passwordHash, Surname = surname, Name = name, Patronymic = patronymic, BornDate = bornDate };
            
            context.Users.InsertOnSubmit(user);
            context.SubmitChanges();*/
        }
        
        public void AddMessage(string userNameFor, string text)
        {
            /*Message message = new Message() { IdUserFrom = idUser, IdUserFor = idUserFor, Text = text };

            context.Messages.InsertOnSubmit(message);
            context.SubmitChanges();*/

            if (connected.ContainsKey(userNameFor))
            {
                connected[userNameFor].NewMessageReceive(userName, text);
            }
        }

        public String[] UserList()
        {
            return connected.Select(x => x.Key).ToArray();
        }
    }
}