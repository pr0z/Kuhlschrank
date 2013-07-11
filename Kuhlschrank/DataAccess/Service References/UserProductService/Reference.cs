﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18052
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.UserProductService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserProductService.IUserProductService")]
    public interface IUserProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/GetAll", ReplyAction="http://tempuri.org/IUserProductService/GetAllResponse")]
        System.Collections.Generic.List<DataContracts.UserProducts> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/GetAll", ReplyAction="http://tempuri.org/IUserProductService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.UserProducts>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Insert", ReplyAction="http://tempuri.org/IUserProductService/InsertResponse")]
        void Insert(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Insert", ReplyAction="http://tempuri.org/IUserProductService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Update", ReplyAction="http://tempuri.org/IUserProductService/UpdateResponse")]
        void Update(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Update", ReplyAction="http://tempuri.org/IUserProductService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Delete", ReplyAction="http://tempuri.org/IUserProductService/DeleteResponse")]
        void Delete(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/Delete", ReplyAction="http://tempuri.org/IUserProductService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(DataContracts.UserProducts entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/GetByUserId", ReplyAction="http://tempuri.org/IUserProductService/GetByUserIdResponse")]
        System.Collections.Generic.List<DataContracts.UserProducts> GetByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProductService/GetByUserId", ReplyAction="http://tempuri.org/IUserProductService/GetByUserIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.UserProducts>> GetByUserIdAsync(int userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserProductServiceChannel : DataAccess.UserProductService.IUserProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserProductServiceClient : System.ServiceModel.ClientBase<DataAccess.UserProductService.IUserProductService>, DataAccess.UserProductService.IUserProductService {
        
        public UserProductServiceClient() {
        }
        
        public UserProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DataContracts.UserProducts> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.UserProducts>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Insert(DataContracts.UserProducts entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(DataContracts.UserProducts entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Update(DataContracts.UserProducts entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(DataContracts.UserProducts entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public void Delete(DataContracts.UserProducts entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(DataContracts.UserProducts entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public System.Collections.Generic.List<DataContracts.UserProducts> GetByUserId(int userId) {
            return base.Channel.GetByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.UserProducts>> GetByUserIdAsync(int userId) {
            return base.Channel.GetByUserIdAsync(userId);
        }
    }
}
