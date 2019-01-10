using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelCation
{
    public partial class TravelCation : System.Web.UI.MasterPage
    {
        BLL.CustomerBLL customerBLL = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.CustomerBLL cust = (BLL.CustomerBLL)Session["Customer"];

            if (cust != null)
            {
                panelSignIn.Visible = false;
                panelSignUp.Visible = false;
                linkbtn_acc.Text = cust.FirstName.ToString().ToUpper();
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["tbEmail"] != null && Request.Cookies["tbPw"] != null)
                {
                    cb_remember.Checked = true;
                    tb_loginEmail.Text = Request.Cookies["tbEmail"].Value;
                    tb_loginPassword.Text = Request.Cookies["tbPw"].Value;
                }
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string email = tb_loginEmail.Text;
            string password = tb_loginPassword.Text;

            if (Page.IsValid)
            {
                if (cb_remember.Checked == true)
                {
                    Response.Cookies["tbEmail"].Value = tb_loginEmail.Text;
                    Response.Cookies["tbPw"].Value = tb_loginPassword.Text;
                    Response.Cookies["tbEmail"].Expires = DateTime.Now.AddDays(3);
                    Response.Cookies["tbPw"].Expires = DateTime.Now.AddDays(3);
                }
                else
                {
                    Response.Cookies["tbEmail"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["tbPw"].Expires = DateTime.Now.AddDays(-1);
                }

                customerBLL = new BLL.CustomerBLL();
                switch (customerBLL.Login(email, password))
                {
                    case 0:
                        panelSignIn.Visible = false;
                        panelSignUp.Visible = false;
                        BLL.CustomerBLL cust = (BLL.CustomerBLL)Session["Customer"];
                        MISC.showToastr.Success(this.Page, "Welcome " + cust.getFullName(), "");
                        break;

                    case 1:
                        MISC.showToastr.Warning(this.Page, "Email does not exist", "");
                        break;

                    case 2:
                        MISC.showToastr.Error(this.Page, "Empty fields", "");
                        break;

                    case 3:
                        MISC.showToastr.Warning(this.Page, "Invalid email", "");
                        break;
                }
            }
            else
            {
                modalPopUpExtenderLogin.Show();
            }
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            string firstName = tb_firstName.Text;
            string lastName = tb_lastName.Text;
            string email = tb_registerEmail.Text;
            string password = tb_registerPassword.Text;

            if (Page.IsValid)
            {
                customerBLL = new BLL.CustomerBLL(email, firstName, lastName, password);
                BLL.CustomerBLL cust = new BLL.CustomerBLL();
                switch (cust.createAccount(customerBLL))
                {
                    case 0:
                        MISC.showToastr.Success(this.Page, "Register successful " + cust.getFullName(), "");
                        break;

                    case 1:
                        MISC.showToastr.Info(this.Page, "Email exist", "");
                        modalPopUpExtenderRegister.Show();
                        break;

                    case 2:
                        List<string> emptyMsg = new List<string>();
                        StringBuilder sb = new StringBuilder();

                        if (string.IsNullOrEmpty(firstName))
                        {
                            emptyMsg.Add("First Name");
                        }

                        if (string.IsNullOrEmpty(lastName))
                        {
                            emptyMsg.Add("Last Name");
                        }

                        if (string.IsNullOrEmpty(email))
                        {
                            emptyMsg.Add("Email");
                        }

                        if (string.IsNullOrEmpty(password))
                        {
                            emptyMsg.Add("Password");
                        }

                        foreach (string emptymsg in emptyMsg)
                        {
                            sb.Append(emptymsg);
                            if (emptyMsg.Count() < emptymsg.Count() - 1)
                            {
                                sb.Append(", ");
                            }
                        }
                        MISC.showToastr.Warning(this.Page, sb.ToString() + "required", "");
                        break;

                    case 3:
                        MISC.showToastr.Error(this.Page, "Invalid email", "");
                        break;

                    case 4:
                        MISC.showToastr.Error(this.Page, "Password length must be more than 6", "");
                        break;
                }
            }
            else
            {
                modalPopUpExtenderRegister.Show();
            }
        }

        protected void linkbtn_logout_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();

            Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.Redirect("/Index.aspx");
        }

        protected void emailValidator_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void loginEmailValidator_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void passValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (InputValidation.ValidateOnePassword(args.Value) == true)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void loginPasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (InputValidation.ValidateOnePassword(args.Value) == true)
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