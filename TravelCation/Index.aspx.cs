using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Net;
using System.Web.Script.Serialization;

namespace TravelCation
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender_checkin.StartDate = DateTime.Now;
            CalendarExtender_checkout.StartDate = DateTime.Now;
            CalendarExtender_checkin.EndDate = new DateTime(DateTime.Today.Year + 0, 12, 31);
            CalendarExtender_checkout.EndDate = new DateTime(DateTime.Today.Year + 0, 12, 31);
        }

        protected void menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            mv_services.ActiveViewIndex = index;
            switch (index)
            {
                case 2:
                    
                    break;
            }
        }

        protected void btn_submitHotel_Click(object sender, EventArgs e)
        {

        }

        protected void btn_submitFlight_Click(object sender, EventArgs e)
        {

        }

        protected void menu_flight_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            mv_subFlight.ActiveViewIndex = index;
            switch (index)
            {
                case 1:
                    returnDate.Visible = false;
                    break;

                case 2:
                    
                    break;
            }
        }
    }
}