﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.DeviceService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DeviceService.IDeviceService")]
    public interface IDeviceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetAll", ReplyAction="http://tempuri.org/IDeviceService/GetAllResponse")]
        System.Collections.Generic.List<DataContracts.Device> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetAll", ReplyAction="http://tempuri.org/IDeviceService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Device>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetById", ReplyAction="http://tempuri.org/IDeviceService/GetByIdResponse")]
        DataContracts.Device GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetById", ReplyAction="http://tempuri.org/IDeviceService/GetByIdResponse")]
        System.Threading.Tasks.Task<DataContracts.Device> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetByUserId", ReplyAction="http://tempuri.org/IDeviceService/GetByUserIdResponse")]
        System.Collections.Generic.List<DataContracts.Device> GetByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/GetByUserId", ReplyAction="http://tempuri.org/IDeviceService/GetByUserIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Device>> GetByUserIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Delete", ReplyAction="http://tempuri.org/IDeviceService/DeleteResponse")]
        void Delete(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Delete", ReplyAction="http://tempuri.org/IDeviceService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Update", ReplyAction="http://tempuri.org/IDeviceService/UpdateResponse")]
        void Update(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Update", ReplyAction="http://tempuri.org/IDeviceService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Insert", ReplyAction="http://tempuri.org/IDeviceService/InsertResponse")]
        void Insert(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Insert", ReplyAction="http://tempuri.org/IDeviceService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(DataContracts.Device entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/CheckRegistration", ReplyAction="http://tempuri.org/IDeviceService/CheckRegistrationResponse")]
        bool CheckRegistration(string uniqueIdentifier, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/CheckRegistration", ReplyAction="http://tempuri.org/IDeviceService/CheckRegistrationResponse")]
        System.Threading.Tasks.Task<bool> CheckRegistrationAsync(string uniqueIdentifier, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Register", ReplyAction="http://tempuri.org/IDeviceService/RegisterResponse")]
        void Register(string type, string uniqueIdentifier, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/Register", ReplyAction="http://tempuri.org/IDeviceService/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(string type, string uniqueIdentifier, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/rest_delete", ReplyAction="http://tempuri.org/IDeviceService/rest_deleteResponse")]
        void rest_delete(string uniqueIdentifier);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceService/rest_delete", ReplyAction="http://tempuri.org/IDeviceService/rest_deleteResponse")]
        System.Threading.Tasks.Task rest_deleteAsync(string uniqueIdentifier);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeviceServiceChannel : DataAccess.DeviceService.IDeviceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeviceServiceClient : System.ServiceModel.ClientBase<DataAccess.DeviceService.IDeviceService>, DataAccess.DeviceService.IDeviceService {
        
        public DeviceServiceClient() {
        }
        
        public DeviceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeviceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DataContracts.Device> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Device>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public DataContracts.Device GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<DataContracts.Device> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public System.Collections.Generic.List<DataContracts.Device> GetByUserId(int userId) {
            return base.Channel.GetByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Device>> GetByUserIdAsync(int userId) {
            return base.Channel.GetByUserIdAsync(userId);
        }
        
        public void Delete(DataContracts.Device entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(DataContracts.Device entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(DataContracts.Device entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(DataContracts.Device entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public void Insert(DataContracts.Device entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(DataContracts.Device entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public bool CheckRegistration(string uniqueIdentifier, int userId) {
            return base.Channel.CheckRegistration(uniqueIdentifier, userId);
        }
        
        public System.Threading.Tasks.Task<bool> CheckRegistrationAsync(string uniqueIdentifier, int userId) {
            return base.Channel.CheckRegistrationAsync(uniqueIdentifier, userId);
        }
        
        public void Register(string type, string uniqueIdentifier, int userId) {
            base.Channel.Register(type, uniqueIdentifier, userId);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(string type, string uniqueIdentifier, int userId) {
            return base.Channel.RegisterAsync(type, uniqueIdentifier, userId);
        }
        
        public void rest_delete(string uniqueIdentifier) {
            base.Channel.rest_delete(uniqueIdentifier);
        }
        
        public System.Threading.Tasks.Task rest_deleteAsync(string uniqueIdentifier) {
            return base.Channel.rest_deleteAsync(uniqueIdentifier);
        }
    }
}
