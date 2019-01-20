using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TravelCation.DAL
{
    public class BookingDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public int insertBooking(decimal finalAmount)
        {
            //status
            // 0 = paid, 1 = canceled,

            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "INSERT INTO Booking(Amount, Status) VALUES(@finalAmount, @status)";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@finalAmount", finalAmount);
            cmd.Parameters.AddWithValue("@status", 0);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return 0;// success
        }

        public int insertBookingDetail(int custID, int serviceID, decimal cost, int pax)
        {
            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "INSERT INTO BookingDetail(BookingID, CustID, ServiceID, BookingDate, Cost, Pax) VALUES((SELECT MAX(BookingID) FROM Booking), @custID, @serviceID, @bookingDate, @cost, @pax)";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@custID", custID);
            cmd.Parameters.AddWithValue("@serviceID", serviceID);
            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.Parameters.AddWithValue("@pax", pax);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return 0;// success
        }
    }
}