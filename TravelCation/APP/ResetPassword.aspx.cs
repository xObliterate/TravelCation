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
                    lbl_msg.Text = "Error 404";
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
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgbox", "alert('Reset password success');window.location = '/Index.aspx';", true);
                        break;

                    case 1:
                        Response.Write("At least 6 characters");
                        break;
                }
            }
        }
    }
}