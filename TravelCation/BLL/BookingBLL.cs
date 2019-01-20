using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCation.BLL
{
    public class BookingBLL
    {
        public int insertBooking(decimal finalAmount)
        {
            DAL.BookingDAL bookingDAL = new DAL.BookingDAL();
            return bookingDAL.insertBooking(finalAmount);
        }

        public int insertBookingDetail(int custID, int serviceID, decimal cost, int pax)
        {
            DAL.BookingDAL bookingDAL = new DAL.BookingDAL();
            return bookingDAL.insertBookingDetail(custID, serviceID, cost, pax);
        }
    }
}