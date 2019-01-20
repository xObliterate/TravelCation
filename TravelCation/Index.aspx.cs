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
        int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender_checkin.StartDate = DateTime.Now;
            CalendarExtender_checkout.StartDate = DateTime.Now;
            CalendarExtender_checkin.EndDate = new DateTime(DateTime.Today.Year + 0, 12, 31);
            CalendarExtender_checkout.EndDate = new DateTime(DateTime.Today.Year + 0, 12, 31);
        }

        protected void menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = int.Parse(e.Item.Value);
            switch (index)
            {
                case 0:
                    menu_flight.Visible = false;
                    menu_flight.Enabled = false;
                    lbl_endDestination.Text = "Destination, hotel name";
                    input_endDestination.Attributes["class"] = "input-field col s12";
                    input_currentDestination.Visible = false;
                    tb_currentDestination.Enabled = false;
                    lbl_dateFrom.Text = "Check-in (DD/MM/YYYY)";
                    lbl_dateTo.Text = "Check-out (DD/MM/YYYY)";
                    input_ddl_rooms.Visible = true;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = true;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;
                    index = 0;
                    break;

                case 1:
                    menu_flight.Visible = true;
                    menu_flight.Enabled = true;
                    lbl_currentDestination.Text = "Flying from";
                    lbl_endDestination.Text = "Flying To";
                    input_endDestination.Attributes["class"] = "input-field col s6";
                    input_currentDestination.Visible = true;
                    tb_currentDestination.Enabled = true;
                    lbl_dateFrom.Text = "Departing (DD/MM/YYYY)";
                    lbl_dateTo.Text = "Returning (DD/MM/YYYY)";
                    input_ddl_rooms.Visible = false;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = false;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;
                    index = 1;
                    break;

                case 2:
                    menu_flight.Visible = false;
                    menu_flight.Enabled = false;
                    lbl_currentDestination.Text = "Origin";
                    lbl_endDestination.Text = "Destination";
                    input_endDestination.Attributes["class"] = "input-field col s6";
                    input_currentDestination.Visible = true;
                    tb_currentDestination.Enabled = true;
                    lbl_dateFrom.Text = "Departing (DD/MM/YYYY)";
                    lbl_dateTo.Text = "Returning (DD/MM/YYYY)";
                    input_ddl_rooms.Visible = true;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = true;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;
                    index = 2;
                    break;

                case 3:
                    menu_flight.Visible = false;
                    menu_flight.Enabled = false;
                    lbl_endDestination.Text = "Destination";
                    input_endDestination.Attributes["class"] = "input-field col s12";
                    input_currentDestination.Visible = false;
                    tb_currentDestination.Enabled = false;
                    lbl_dateFrom.Text = "From (DD/MM/YYYY)";
                    lbl_dateTo.Text = "To (DD/MM/YYYY)";
                    row_ddl.Visible = false;
                    ddl_numberofrooms.Enabled = false;
                    ddl_adults.Enabled = false;
                    ddl_childrens.Enabled = false;
                    break;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                switch (index)
                {

                }
            }
        }

        protected void menu_flight_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = int.Parse(e.Item.Value);
            switch (index)
            {
                case 0:
                    input_dateTo.Visible = true;
                    tb_dateTo.Enabled = true;
                    break;

                case 1:
                    input_dateTo.Visible = false;
                    tb_dateTo.Enabled = false;
                    break;
            }
        }
    }
}