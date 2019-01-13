using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelCation
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            string email = tb_resetEmail.Text;

            if (Page.IsValid)
            {
                BLL.CustomerBLL customerBLL = new BLL.CustomerBLL();
                switch (customerBLL.resetAccountPassword(email))
                {
                    case 0:
                        MISC.showToastr.Success(this.Page, "Check email for more information", "");
                        tb_resetEmail.Text = "";
                        Response.AddHeader("REFRESH", "3;URL=/Index.aspx");
                        break;

                    case 1:
                        MISC.showToastr.Error(this.Page, "No empty fields", "");
                        Response.Write("Empty fields");
                        break;

                    case 2:
                        MISC.showToastr.Error(this.Page, "Invalid email", "");
                        break;
                }
            }
        }

        protected void resetEmailValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (InputValidation.ValidateEmail(args.Value) == true)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}