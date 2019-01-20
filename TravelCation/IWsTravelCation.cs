using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TravelCation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWsTravelCation" in both code and config file together.
    [ServiceContract]
    public interface IWsTravelCation
    {
        [OperationContract]
        int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType);

    }

    [DataContract]
    public class Service
    {
        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string ServiceInCharge { get; set; }

        [DataMember]
        public string ServiceContact { get; set; }

        [DataMember]
        public char ServiceType { get; set; }

        [DataMember]
        public decimal ServiceRating { get; set; }
    }
}
