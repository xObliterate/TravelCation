using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TravelCation.DAL
{
    public class ServiceDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public int insertService(string ServiceName, string ServiceInCharge, string ServiceContact, char ServiceType)
        {
            string name = ServiceName.ToLower(), inCharge = ServiceInCharge.ToLower(), contact = ServiceContact.ToLower(), type = ServiceType.ToString().ToLower();
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

            if (string.IsNullOrEmpty(ServiceName) || string.IsNullOrEmpty(ServiceInCharge) || string.IsNullOrEmpty(ServiceContact) || string.IsNullOrEmpty(ServiceType.ToString()))
            {
                return 2;// Empty fields
            }

            else
            {
                dr.Close();
                dr.Dispose();

                queryStr = "INSERT INTO Service(ServiceName, ServiceInCharge, ServiceContact, ServiceType) VALUES(@serviceName, @serviceInCharge, @serviceContact, @serviceType)";
                cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@serviceName", name);
                cmd.Parameters.AddWithValue("@serviceInCharge", inCharge);
                cmd.Parameters.AddWithValue("@serviceContact", contact);
                cmd.Parameters.AddWithValue("@serviceType", type);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;//success
        }
    }
}