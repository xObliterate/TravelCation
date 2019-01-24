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
                    tb_dateFrom.Attributes.Add("placeholder", "Check-in (DD/MM/YYYY)");
                    tb_dateTo.Attributes.Add("placeholder", "Check-out (DD/MM/YYYY)");
                    //lbl_dateFrom.Text = "Check-in (DD/MM/YYYY)";
                    //lbl_dateTo.Text = "Check-out (DD/MM/YYYY)";
                    input_ddl_rooms.Visible = true;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = true;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;

                    rfv_currentDestination.ValidationGroup = "validate";
                    rfv_endDestination.ValidationGroup = "0";
                    rfv_dateFrom.ValidationGroup = "0";
                    rfv_dateTo.ValidationGroup = "0";
                    rfv_numberOfRooms.ValidationGroup = "0";
                    rfv_adults.ValidationGroup = "0";
                    btn_submit.ValidationGroup = "0";
                    break;

                case 1:
                    menu_flight.Visible = true;
                    menu_flight.Enabled = true;
                    lbl_currentDestination.Text = "Flying from";
                    lbl_endDestination.Text = "Flying To";
                    input_endDestination.Attributes["class"] = "input-field col s6";
                    input_currentDestination.Visible = true;
                    tb_currentDestination.Enabled = true;
                    //lbl_dateFrom.Text = "Departing (DD/MM/YYYY)";
                    //lbl_dateTo.Text = "Returning (DD/MM/YYYY)";
                    tb_dateFrom.Attributes.Add("placeholder", "Departing (DD/MM/YYYY)");
                    tb_dateTo.Attributes.Add("placeholder", "Returning-out (DD/MM/YYYY)");
                    input_ddl_rooms.Visible = false;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = false;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;

                    rfv_currentDestination.ValidationGroup = "1";
                    rfv_endDestination.ValidationGroup = "1";
                    rfv_dateFrom.ValidationGroup = "1";
                    rfv_dateTo.ValidationGroup = "1";
                    rfv_numberOfRooms.ValidationGroup = "validate";
                    rfv_adults.ValidationGroup = "1";
                    btn_submit.ValidationGroup = "1";
                    break;

                case 2:
                    menu_flight.Visible = false;
                    menu_flight.Enabled = false;
                    lbl_currentDestination.Text = "Origin";
                    lbl_endDestination.Text = "Destination";
                    input_endDestination.Attributes["class"] = "input-field col s6";
                    input_currentDestination.Visible = true;
                    tb_currentDestination.Enabled = true;
                    //lbl_dateFrom.Text = "Departing (DD/MM/YYYY)";
                    //lbl_dateTo.Text = "Returning (DD/MM/YYYY)";
                    tb_dateFrom.Attributes.Add("placeholder", "Departing (DD/MM/YYYY)");
                    tb_dateTo.Attributes.Add("placeholder", "Returning-out (DD/MM/YYYY)");
                    input_ddl_rooms.Visible = true;
                    row_ddl.Visible = true;
                    ddl_numberofrooms.Enabled = true;
                    ddl_adults.Enabled = true;
                    ddl_childrens.Enabled = true;

                    rfv_currentDestination.ValidationGroup = "2";
                    rfv_endDestination.ValidationGroup = "2";
                    rfv_dateFrom.ValidationGroup = "2";
                    rfv_dateTo.ValidationGroup = "2";
                    rfv_numberOfRooms.ValidationGroup = "2";
                    rfv_adults.ValidationGroup = "2";
                    btn_submit.ValidationGroup = "2";
                    break;

                case 3:
                    menu_flight.Visible = false;
                    menu_flight.Enabled = false;
                    lbl_endDestination.Text = "Destination";
                    input_endDestination.Attributes["class"] = "input-field col s12";
                    input_currentDestination.Visible = false;
                    tb_currentDestination.Enabled = false;
                    //lbl_dateFrom.Text = "From (DD/MM/YYYY)";
                    //lbl_dateTo.Text = "To (DD/MM/YYYY)";
                    tb_dateFrom.Attributes.Add("placeholder", "From (DD/MM/YYYY)");
                    tb_dateTo.Attributes.Add("placeholder", "To (DD/MM/YYYY)");
                    row_ddl.Visible = false;
                    ddl_numberofrooms.Enabled = false;
                    ddl_adults.Enabled = false;
                    ddl_childrens.Enabled = false;

                    rfv_currentDestination.ValidationGroup = "validate";
                    rfv_endDestination.ValidationGroup = "3";
                    rfv_dateFrom.ValidationGroup = "3";
                    rfv_dateTo.ValidationGroup = "3";
                    rfv_numberOfRooms.ValidationGroup = "validate";
                    rfv_adults.ValidationGroup = "validate";
                    btn_submit.ValidationGroup = "3";
                    break;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string currentDestination = tb_currentDestination.Text;
                string destination = tb_endDestination.Text;
                string startDate = tb_dateFrom.Text;
                string endDate = tb_dateTo.Text;
                string room = ddl_numberofrooms.SelectedValue;
                string adult = ddl_adults.SelectedValue;
                string children = ddl_childrens.SelectedValue;

                switch (btn_submit.ValidationGroup)
                {
                    case "0":
                        if (ddl_childrens.SelectedValue == "0")
                        {
                            Response.Redirect(string.Format("HotelSearch.aspx?destination={0}&startDate={1}&endDate={2}&rooms={3}&adults={4}&c={5}", Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(room), Server.UrlEncode(adult), Server.UrlEncode("N")));
                        }
                        else
                        {
                            Response.Redirect(string.Format("HotelSearch.aspx?destination={0}&startDate={1}&endDate={2}&rooms={3}&adults={4}&child={5}&c={6}", Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(room), Server.UrlEncode(adult), Server.UrlEncode(children), Server.UrlEncode("Y")));
                        }
                        break;

                    case "1":
                        switch (rfv_dateTo.ValidationGroup)
                        {
                            case "1":
                                if (ddl_childrens.SelectedValue == "0")
                                {
                                    Response.Redirect(string.Format("FlightSearch.aspx?flyingFrom={0}&flyingTo={1}&startDate={2}&endDate={3}&adults={4}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(adult), Server.UrlEncode("N")));
                                }
                                else
                                {
                                    Response.Redirect(string.Format("FlightSearch.aspx?flyingFrom={0}&flyingTo={1}&startDate={2}&endDate={3}&adults={4}&child={5}&c={5}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(adult), Server.UrlEncode(children), Server.UrlEncode("Y")));
                                }
                                break;

                            case "validate":
                                if (ddl_childrens.SelectedValue == "0")
                                {
                                    Response.Redirect(string.Format("FlightSearch.aspx?flyingFrom={0}&flyingTo={1}&startDate={2}&adults={3}&c={4}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(adult), Server.UrlEncode("N")));
                                }
                                else
                                {
                                    Response.Redirect(string.Format("FlightSearch.aspx?flyingFrom={0}&flyingTo={1}&startDate={2}&adults={3}&child={4}&c={5}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(adult), Server.UrlEncode(children), Server.UrlEncode("Y")));
                                }
                                break;
                        }
                        break;

                    case "2":
                        if (ddl_childrens.SelectedValue == "0")
                        {
                            Response.Redirect(string.Format("PackageSearch.aspx?origin={0}&destination={1}&startDate={2}&endDate={3}&rooms={4}&adults={5}&c={6}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(room), Server.UrlEncode(adult), Server.UrlEncode("N")));
                        }
                        else
                        {
                            Response.Redirect(string.Format("PackageSearch.aspx?origin={0}&destination={1}&startDate={2}&endDate={3}&rooms={4}&adults={5}&child={6}&c={7}", Server.UrlEncode(currentDestination), Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(room), Server.UrlEncode(adult), Server.UrlEncode(children), Server.UrlEncode("Y")));
                        }
                        break;

                    case "3":
                        Response.Redirect(string.Format("AttractionSearch.aspx?destination={0}&startDate={1}&endDate={2}&c={3}", Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode("N")));
                        break;
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
                    rfv_dateTo.ValidationGroup = "1";
                    break;

                case 1:
                    input_dateTo.Visible = false;
                    tb_dateTo.Enabled = false;
                    rfv_dateTo.ValidationGroup = "validate";
                    break;
            }
        }

        protected void tb_dateFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTo;
                DateTime dateFrom = DateTime.Parse(tb_dateFrom.Text);

                if (tb_dateTo.Text == "")
                {
                    tb_dateTo.Text = dateFrom.AddDays(1).ToString("dd/MM/yyyy");
                    dateTo = DateTime.Parse(tb_dateTo.Text);
                }
                else
                {
                    dateTo = DateTime.Parse(tb_dateTo.Text);
                }
                if (dateFrom == dateTo || dateFrom > dateTo)
                {
                    tb_dateTo.Text = dateFrom.AddDays(1).ToString("dd/MM/yyyy");
                    DateTime newStartDate = DateTime.Parse(tb_dateTo.Text);
                    CalendarExtender_checkout.StartDate = newStartDate;
                }
            }
            catch (FormatException ex)
            {
                MISC.showToastr.Error(this.Page, ex.Message.ToString(), "");
            }
        }

        protected void tb_dateTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo = DateTime.Parse(tb_dateTo.Text);

                if (tb_dateFrom.Text == "")
                {
                    tb_dateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    dateFrom = DateTime.Parse(tb_dateFrom.Text);
                }
                else
                {
                    dateFrom = DateTime.Parse(tb_dateFrom.Text);
                }

                if (dateTo == dateFrom || dateTo < dateFrom)
                {
                    tb_dateTo.Text = dateFrom.AddDays(1).ToString("dd/MM/yyyy");
                    DateTime newStartDate = DateTime.Parse(tb_dateTo.Text);
                    CalendarExtender_checkout.StartDate = newStartDate;
                }
            }
            catch (FormatException ex)
            {
                MISC.showToastr.Error(this.Page, ex.Message.ToString(), "");
            }
        }
    }
}