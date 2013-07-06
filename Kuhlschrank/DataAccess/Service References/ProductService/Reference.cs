﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.17929
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.ProductService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductService.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAll", ReplyAction="http://tempuri.org/IProductService/GetAllResponse")]
        System.Collections.Generic.List<DataContracts.Product> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAll", ReplyAction="http://tempuri.org/IProductService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Product>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetById", ReplyAction="http://tempuri.org/IProductService/GetByIdResponse")]
        DataContracts.Product GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetById", ReplyAction="http://tempuri.org/IProductService/GetByIdResponse")]
        System.Threading.Tasks.Task<DataContracts.Product> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Insert", ReplyAction="http://tempuri.org/IProductService/InsertResponse")]
        void Insert(DataContracts.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Insert", ReplyAction="http://tempuri.org/IProductService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(DataContracts.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Update", ReplyAction="http://tempuri.org/IProductService/UpdateResponse")]
        void Update(DataContracts.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Update", ReplyAction="http://tempuri.org/IProductService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(DataContracts.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Delete", ReplyAction="http://tempuri.org/IProductService/DeleteResponse")]
        void Delete(DataContracts.Product entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Delete", ReplyAction="http://tempuri.org/IProductService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(DataContracts.Product entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : DataAccess.ProductService.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<DataAccess.ProductService.IProductService>, DataAccess.ProductService.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DataContracts.Product> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DataContracts.Product>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public DataContracts.Product GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<DataContracts.Product> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public void Insert(DataContracts.Product entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(DataContracts.Product entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Update(DataContracts.Product entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(DataContracts.Product entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public void Delete(DataContracts.Product entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(DataContracts.Product entity) {
            return base.Channel.DeleteAsync(entity);
        }
    }
}
