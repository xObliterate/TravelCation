using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelCation
{
    public partial class Hotel : System.Web.UI.Page
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
                BLL.ServiceBLL service = new BLL.ServiceBLL();
                gv_hotelsearch.DataSource = service.getRoomByOccupants(occupants);
                gv_hotelsearch.DataBind();
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = (Image)e.Row.FindControl("Image1") as Image;
                Label lbl = (Label)e.Row.FindControl("lbl_roomID") as Label;
                BLL.ServiceBLL service = new BLL.ServiceBLL();
                foreach (byte[] b in service.getRoomImage(int.Parse(lbl.Text)))
                {
                    img.ImageUrl = "data:image;base64," + Convert.ToBase64String(b);
                }
            }
        }
    }
}