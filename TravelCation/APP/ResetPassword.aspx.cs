using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TravelCation.APP
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        BLL.CustomerBLL customerBLL = null;
        DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uniqueID = Request.QueryString["code"];
                lbl_msg.Text = "";

                customerBLL = customerDAL.getEmail(uniqueID);

                if (customerBLL != null)
                {
                    lbl_email.Text = string.Format("<b>Email:</b> {0}", customerBLL.Email);
                    lbl_msg.Text = "Change Password";
                    lbl_msg.ForeColor = Color.Orange;
                }
                else
                {
                    lbl_msg.Text = "Error 404<br/><p><h6>Link has expired</h6></p>";
                    lbl_msg.ForeColor = Color.Red;
                    tb_password.Visible = false;
                    btn_changePw.Visible = false;
                }
            }
        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string uniqueID = Request.QueryString["code"];
                customerBLL = customerDAL.getEmail(uniqueID);
                string email = customerBLL.Email;

                switch (customerDAL.changePassword(email, tb_password.Text))
                {
                    case 0:
                        MISC.showToastr.Success(this.Page, "Password has been updated", "");
                        tb_password.Text = "";
                        Response.AddHeader("REFRESH", "3;URL=/Index.aspx");
                        break;

                    case 1:
                        MISC.showToastr.Error(this.Page, "At least 6 characters", "");
                        break;
                }
            }
        }
    }
}