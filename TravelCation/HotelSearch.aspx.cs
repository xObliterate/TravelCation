using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelCation
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int occupants;

                string isThereChild = Request.QueryString["c"].ToString();
                if (isThereChild == "N")
                {
                    int adult = int.Parse(Request.QueryString["adults"].ToString());
                    occupants = adult;
                }
                else
                {
                    int adults = int.Parse(Request.QueryString["adults"].ToString());
                    int child = int.Parse(Request.QueryString["child"].ToString());
                    occupants = adults + child;
                }

                string destination = Request.QueryString["destination"].ToString();
                BLL.ServiceBLL service = new BLL.ServiceBLL();
                gv_hotelsearch.DataSource = service.searchHotel(destination);
                gv_hotelsearch.DataBind();
            }
        }

        protected void gv_hotelsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isThereChild = Request.QueryString["c"].ToString();
            string destination = Request.QueryString["destination"].ToString();
            string startDate = Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"].ToString();
            string room = Request.QueryString["rooms"].ToString();
            string adult = Request.QueryString["adults"].ToString();
            string url = "";
            if (isThereChild == "N")
            {
                url = string.Format("?destination={0}&startDate={1}&endDate={2}&rooms={3}&adults={4}&c={5}", Server.UrlEncode(destination), Server.UrlEncode(startDate), Server.UrlEncode(endDate), Server.UrlEncode(room), Server.UrlEncode(adult), Server.UrlEncode(isThereChild));
            }
            else
            {

            }
            Response.Redirect("Hotel.aspx" + url);
        }
    }
}