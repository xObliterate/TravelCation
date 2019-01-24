using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TravelCation.SvcRefHotelSupplier;

namespace TravelCation.DAL
{
    public class ServiceDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public List<BLL.ServiceBLL> searchHotel(string input)
        {
            List<BLL.ServiceBLL> searchList = new List<BLL.ServiceBLL>();
            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "SELECT ServiceName, ServiceLocation, ServiceRating FROM Service WHERE ServiceName LIKE CONCAT('%', @serviceName, '%') OR ServiceLocation LIKE CONCAT('%', @serviceLocation, '%')";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@serviceName", input);
            cmd.Parameters.AddWithValue("@serviceLocation", input);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string ServiceName = dr["ServiceName"].ToString();
                string ServiceLocation = dr["ServiceLocation"].ToString();
                decimal ServiceRating = decimal.Parse(dr["ServiceRating"].ToString());
                BLL.ServiceBLL service = new BLL.ServiceBLL(ServiceName, ServiceLocation, ServiceRating);
                searchList.Add(service);
            }
            con.Close();
            dr.Close();
            dr.Dispose();

            return searchList;
        }

        public int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType, string ServiceLocation)
        {
            string name = ServiceName.ToLower(), inCharge = ServiceInCharge.ToLower(), contact = ServiceContact.ToLower(), type = ServiceType.ToString().ToLower(), location = ServiceLocation.ToLower();
            string queryStr = "";
            SqlCommand cmd;

            SqlConnection con = new SqlConnection(connStr);
            queryStr = "SELECT ServiceName FROM Service WHERE ServiceName = @serviceName";
            cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@serviceName", name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                return 1;// ServiceName Exists
            }

            if (string.IsNullOrEmpty(ServiceName) || string.IsNullOrEmpty(ServiceInCharge) || string.IsNullOrEmpty(ServiceContact) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(location))
            {
                return 2;// Empty fields
            }

            else
            {
                dr.Close();
                dr.Dispose();

                queryStr = "INSERT INTO Service(ServiceName, ServiceInCharge, ServiceContact, ServiceType, ServiceLocation) VALUES(@serviceName, @serviceInCharge, @serviceContact, @serviceType, @serviceLocation, @serviceRating)";
                cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@serviceName", name);
                cmd.Parameters.AddWithValue("@serviceInCharge", inCharge);
                cmd.Parameters.AddWithValue("@serviceContact", contact);
                cmd.Parameters.AddWithValue("@serviceType", type);
                cmd.Parameters.AddWithValue("@serviceLocation", location);
                cmd.Parameters.AddWithValue("@serviceRating", 0);//default rating
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;//success
        }

        public List<byte[]> getRoomImage(int roomID)
        {
            WsHotelSupplierClient hotelSupplier = new WsHotelSupplierClient();
            return hotelSupplier.getRoomImage(roomID);
        }

        public SvcRefHotelSupplier.Hotel getHotelInformation()
        {
            WsHotelSupplierClient hotelSupplier = new WsHotelSupplierClient();
            return hotelSupplier.getHotelInformation();
        }

        public List<Room> getRoomByOccupants(int roomOccupant)
        {
            WsHotelSupplierClient hotelSupplier = new WsHotelSupplierClient();
            return hotelSupplier.getRoomByOccupants(roomOccupant);
        }
    }
}