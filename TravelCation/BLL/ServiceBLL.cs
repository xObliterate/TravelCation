using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCation.BLL
{
    public class ServiceBLL
    {
        public int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType)
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.insertService(ServiceName, ServiceInCharge, ServiceContact, ServiceType);
        }
    }
}