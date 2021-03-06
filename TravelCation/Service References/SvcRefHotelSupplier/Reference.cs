﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelCation.SvcRefHotelSupplier {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Hotel", Namespace="http://schemas.datacontract.org/2004/07/HotelSupplier")]
    [System.SerializableAttribute()]
    public partial class Hotel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CheckInField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CheckOutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostalCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceContactField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceInChargeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceTypeField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CheckIn {
            get {
                return this.CheckInField;
            }
            set {
                if ((object.ReferenceEquals(this.CheckInField, value) != true)) {
                    this.CheckInField = value;
                    this.RaisePropertyChanged("CheckIn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CheckOut {
            get {
                return this.CheckOutField;
            }
            set {
                if ((object.ReferenceEquals(this.CheckOutField, value) != true)) {
                    this.CheckOutField = value;
                    this.RaisePropertyChanged("CheckOut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostalCode {
            get {
                return this.PostalCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostalCodeField, value) != true)) {
                    this.PostalCodeField = value;
                    this.RaisePropertyChanged("PostalCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceContact {
            get {
                return this.ServiceContactField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceContactField, value) != true)) {
                    this.ServiceContactField = value;
                    this.RaisePropertyChanged("ServiceContact");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceInCharge {
            get {
                return this.ServiceInChargeField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceInChargeField, value) != true)) {
                    this.ServiceInChargeField = value;
                    this.RaisePropertyChanged("ServiceInCharge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceName {
            get {
                return this.ServiceNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceNameField, value) != true)) {
                    this.ServiceNameField = value;
                    this.RaisePropertyChanged("ServiceName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceType {
            get {
                return this.ServiceTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceTypeField, value) != true)) {
                    this.ServiceTypeField = value;
                    this.RaisePropertyChanged("ServiceType");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Room", Namespace="http://schemas.datacontract.org/2004/07/HotelSupplier")]
    [System.SerializableAttribute()]
    public partial class Room : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal DailyRoomRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomAvailableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomFloorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomOccupantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomTypeIDField;
        
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
        public decimal DailyRoomRate {
            get {
                return this.DailyRoomRateField;
            }
            set {
                if ((this.DailyRoomRateField.Equals(value) != true)) {
                    this.DailyRoomRateField = value;
                    this.RaisePropertyChanged("DailyRoomRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomAvailable {
            get {
                return this.RoomAvailableField;
            }
            set {
                if ((this.RoomAvailableField.Equals(value) != true)) {
                    this.RoomAvailableField = value;
                    this.RaisePropertyChanged("RoomAvailable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoomFloor {
            get {
                return this.RoomFloorField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomFloorField, value) != true)) {
                    this.RoomFloorField = value;
                    this.RaisePropertyChanged("RoomFloor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoomID {
            get {
                return this.RoomIDField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomIDField, value) != true)) {
                    this.RoomIDField = value;
                    this.RaisePropertyChanged("RoomID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoomNumber {
            get {
                return this.RoomNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomNumberField, value) != true)) {
                    this.RoomNumberField = value;
                    this.RaisePropertyChanged("RoomNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomOccupant {
            get {
                return this.RoomOccupantField;
            }
            set {
                if ((this.RoomOccupantField.Equals(value) != true)) {
                    this.RoomOccupantField = value;
                    this.RaisePropertyChanged("RoomOccupant");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoomTypeID {
            get {
                return this.RoomTypeIDField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomTypeIDField, value) != true)) {
                    this.RoomTypeIDField = value;
                    this.RaisePropertyChanged("RoomTypeID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SvcRefHotelSupplier.IWsHotelSupplier")]
    public interface IWsHotelSupplier {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getHotelInformation", ReplyAction="http://tempuri.org/IWsHotelSupplier/getHotelInformationResponse")]
       SvcRefHotelSupplier.Hotel getHotelInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getHotelInformation", ReplyAction="http://tempuri.org/IWsHotelSupplier/getHotelInformationResponse")]
        System.Threading.Tasks.Task<SvcRefHotelSupplier.Hotel> getHotelInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomsByType", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomsByTypeResponse")]
        System.Collections.Generic.List<SvcRefHotelSupplier.Room> getRoomsByType(string roomTypeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomsByType", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomsByTypeResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SvcRefHotelSupplier.Room>> getRoomsByTypeAsync(string roomTypeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomImage", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomImageResponse")]
        System.Collections.Generic.List<byte[]> getRoomImage(int roomID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomImage", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomImageResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<byte[]>> getRoomImageAsync(int roomID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomByOccupants", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomByOccupantsResponse")]
        System.Collections.Generic.List<SvcRefHotelSupplier.Room> getRoomByOccupants(int roomOccupant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHotelSupplier/getRoomByOccupants", ReplyAction="http://tempuri.org/IWsHotelSupplier/getRoomByOccupantsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SvcRefHotelSupplier.Room>> getRoomByOccupantsAsync(int roomOccupant);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWsHotelSupplierChannel : SvcRefHotelSupplier.IWsHotelSupplier, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsHotelSupplierClient : System.ServiceModel.ClientBase<SvcRefHotelSupplier.IWsHotelSupplier>, SvcRefHotelSupplier.IWsHotelSupplier {
        
        public WsHotelSupplierClient() {
        }
        
        public WsHotelSupplierClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsHotelSupplierClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsHotelSupplierClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsHotelSupplierClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SvcRefHotelSupplier.Hotel getHotelInformation() {
            return base.Channel.getHotelInformation();
        }
        
        public System.Threading.Tasks.Task<SvcRefHotelSupplier.Hotel> getHotelInformationAsync() {
            return base.Channel.getHotelInformationAsync();
        }
        
        public System.Collections.Generic.List<SvcRefHotelSupplier.Room> getRoomsByType(string roomTypeID) {
            return base.Channel.getRoomsByType(roomTypeID);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SvcRefHotelSupplier.Room>> getRoomsByTypeAsync(string roomTypeID) {
            return base.Channel.getRoomsByTypeAsync(roomTypeID);
        }
        
        public System.Collections.Generic.List<byte[]> getRoomImage(int roomID) {
            return base.Channel.getRoomImage(roomID);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<byte[]>> getRoomImageAsync(int roomID) {
            return base.Channel.getRoomImageAsync(roomID);
        }
        
        public System.Collections.Generic.List<SvcRefHotelSupplier.Room> getRoomByOccupants(int roomOccupant) {
            return base.Channel.getRoomByOccupants(roomOccupant);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SvcRefHotelSupplier.Room>> getRoomByOccupantsAsync(int roomOccupant) {
            return base.Channel.getRoomByOccupantsAsync(roomOccupant);
        }
    }
}
