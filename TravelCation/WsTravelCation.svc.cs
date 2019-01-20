using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TravelCation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WsTravelCation" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WsTravelCation.svc or WsTravelCation.svc.cs at the Solution Explorer and start debugging.
    public class WsTravelCation : IWsTravelCation
    {
        public int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType)
        {
            BLL.ServiceBLL serviceBLL = new BLL.ServiceBLL();
            return serviceBLL.insertService(ServiceName, ServiceInCharge, ServiceContact, ServiceType);
        }
    }
}
