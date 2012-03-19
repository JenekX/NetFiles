﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.530
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.INetFilesService", CallbackContract=typeof(ConsoleApplication1.ServiceReference1.INetFilesServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface INetFilesService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INetFilesService/Connect")]
        void Connect(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INetFilesService/Disconnect")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INetFilesService/AddUser")]
        void AddUser(string login, string passwordHash, string surname, string name, string patronymic, System.DateTime bornDate);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INetFilesService/AddMessage")]
        void AddMessage(int idUserFor, string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INetFilesServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INetFilesService/NewMessageReceive")]
        void NewMessageReceive();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INetFilesServiceChannel : ConsoleApplication1.ServiceReference1.INetFilesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NetFilesServiceClient : System.ServiceModel.DuplexClientBase<ConsoleApplication1.ServiceReference1.INetFilesService>, ConsoleApplication1.ServiceReference1.INetFilesService {
        
        public NetFilesServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public NetFilesServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public NetFilesServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NetFilesServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NetFilesServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect(int idUser) {
            base.Channel.Connect(idUser);
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
        
        public void AddUser(string login, string passwordHash, string surname, string name, string patronymic, System.DateTime bornDate) {
            base.Channel.AddUser(login, passwordHash, surname, name, patronymic, bornDate);
        }
        
        public void AddMessage(int idUserFor, string text) {
            base.Channel.AddMessage(idUserFor, text);
        }
    }
}