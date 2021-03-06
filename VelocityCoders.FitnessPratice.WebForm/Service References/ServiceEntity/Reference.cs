﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelocityCoders.FitnessPratice.WebForm.ServiceEntity {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityDTO", Namespace="http://schemas.datacontract.org/2004/07/VelocityCoders.FitnessPractice.Services.D" +
        "ataContracts")]
    [System.SerializableAttribute()]
    public partial class EntityDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EntityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntityNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EntityId {
            get {
                return this.EntityIdField;
            }
            set {
                if ((this.EntityIdField.Equals(value) != true)) {
                    this.EntityIdField = value;
                    this.RaisePropertyChanged("EntityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntityName {
            get {
                return this.EntityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityNameField, value) != true)) {
                    this.EntityNameField = value;
                    this.RaisePropertyChanged("EntityName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="EntityDTOCollection", Namespace="http://schemas.datacontract.org/2004/07/VelocityCoders.FitnessPractice.Services.D" +
        "ataContracts", ItemName="EntityDTO")]
    [System.SerializableAttribute()]
    public class EntityDTOCollection : System.Collections.Generic.List<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityLookupServiceFault", Namespace="http://schemas.datacontract.org/2004/07/VelocityCoders.FitnessPractice.Services.F" +
        "aults")]
    [System.SerializableAttribute()]
    public partial class EntityLookupServiceFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceEntity.IEntityService")]
    public interface IEntityService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntity", ReplyAction="http://tempuri.org/IEntityService/GetEntityResponse")]
        VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO GetEntity(int entityId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntity", ReplyAction="http://tempuri.org/IEntityService/GetEntityResponse")]
        System.Threading.Tasks.Task<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO> GetEntityAsync(int entityId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntityCollection", ReplyAction="http://tempuri.org/IEntityService/GetEntityCollectionResponse")]
        VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTOCollection GetEntityCollection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntityCollection", ReplyAction="http://tempuri.org/IEntityService/GetEntityCollectionResponse")]
        System.Threading.Tasks.Task<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTOCollection> GetEntityCollectionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/DeleteEntity", ReplyAction="http://tempuri.org/IEntityService/DeleteEntityResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityLookupServiceFault), Action="http://tempuri.org/IEntityService/DeleteEntityEntityLookupServiceFaultFault", Name="EntityLookupServiceFault", Namespace="http://schemas.datacontract.org/2004/07/VelocityCoders.FitnessPractice.Services.F" +
            "aults")]
        void DeleteEntity(int entityId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/DeleteEntity", ReplyAction="http://tempuri.org/IEntityService/DeleteEntityResponse")]
        System.Threading.Tasks.Task DeleteEntityAsync(int entityId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/SaveEntity", ReplyAction="http://tempuri.org/IEntityService/SaveEntityResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityLookupServiceFault), Action="http://tempuri.org/IEntityService/SaveEntityEntityLookupServiceFaultFault", Name="EntityLookupServiceFault", Namespace="http://schemas.datacontract.org/2004/07/VelocityCoders.FitnessPractice.Services.F" +
            "aults")]
        void SaveEntity(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO entityToSave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/SaveEntity", ReplyAction="http://tempuri.org/IEntityService/SaveEntityResponse")]
        System.Threading.Tasks.Task SaveEntityAsync(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO entityToSave);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEntityServiceChannel : VelocityCoders.FitnessPratice.WebForm.ServiceEntity.IEntityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EntityServiceClient : System.ServiceModel.ClientBase<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.IEntityService>, VelocityCoders.FitnessPratice.WebForm.ServiceEntity.IEntityService {
        
        public EntityServiceClient() {
        }
        
        public EntityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EntityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EntityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EntityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO GetEntity(int entityId) {
            return base.Channel.GetEntity(entityId);
        }
        
        public System.Threading.Tasks.Task<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO> GetEntityAsync(int entityId) {
            return base.Channel.GetEntityAsync(entityId);
        }
        
        public VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTOCollection GetEntityCollection() {
            return base.Channel.GetEntityCollection();
        }
        
        public System.Threading.Tasks.Task<VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTOCollection> GetEntityCollectionAsync() {
            return base.Channel.GetEntityCollectionAsync();
        }
        
        public void DeleteEntity(int entityId) {
            base.Channel.DeleteEntity(entityId);
        }
        
        public System.Threading.Tasks.Task DeleteEntityAsync(int entityId) {
            return base.Channel.DeleteEntityAsync(entityId);
        }
        
        public void SaveEntity(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO entityToSave) {
            base.Channel.SaveEntity(entityToSave);
        }
        
        public System.Threading.Tasks.Task SaveEntityAsync(VelocityCoders.FitnessPratice.WebForm.ServiceEntity.EntityDTO entityToSave) {
            return base.Channel.SaveEntityAsync(entityToSave);
        }
    }
}
