using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCation.BLL
{
    public class ServiceBLL
    {
        public string ServiceName { get; set; }

        public string ServiceInCharge { get; set; }

        public string ServiceContact { get; set; }

        public char ServiceType { get; set; }

        public decimal ServiceRating { get; set; }

        public string ServiceLocation { get; set; }

        public ServiceBLL()
        {

        }

        public ServiceBLL(string ServiceName, string ServiceLocation, decimal ServiceRating)
        {
            this.ServiceName = ServiceName;
            this.ServiceLocation = ServiceLocation;
            this.ServiceRating = ServiceRating;
        }

        public List<ServiceBLL> searchHotel(string input)
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.searchHotel(input);
        }

        public int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType, string ServiceLocation)
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.insertService(ServiceName, ServiceInCharge, ServiceContact, ServiceType, ServiceLocation);
        }

        public List<byte[]> getRoomImage(int roomID)
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.getRoomImage(roomID);
        }

        public SvcRefHotelSupplier.Hotel getHotelInformation()
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.getHotelInformation();
        }

        public List<SvcRefHotelSupplier.Room> getRoomByOccupants(int roomOccupant)
        {
            DAL.ServiceDAL serviceDAL = new DAL.ServiceDAL();
            return serviceDAL.getRoomByOccupants(roomOccupant);
        }
    }
}