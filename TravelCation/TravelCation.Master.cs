using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelCation
{
    public partial class TravelCation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InputValidation.ClearInputs(Controls);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string email = tb_loginEmail.Text;
            string password = tb_loginPassword.Text;

            if (Page.IsValid)
            {
                DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
                switch (customerDAL.Login(email, password))
                {
                    case 0:
                        Response.Write("Login successful");
                        break;

                    case 1:
                        Response.Write("Email does exist");
                        break;

                    case 2:
                        Response.Write("Empty fields");
                        break;

                    case 3:
                        Response.Write("Invalid email");
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
                BLL.CustomerBLL customerBLL = new BLL.CustomerBLL(email, firstName, lastName, password);
                DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
                switch (customerDAL.createAccount(customerBLL))
                {
                    case 0:
                        Response.Write("Register successful");
                        break;

                    case 1:
                        Response.Write("Email exist");
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
                        Response.Write(sb.ToString() + "required");
                        break;

                    case 3:
                        Response.Write("Invalid Email");
                        break;

                    case 4:
                        Response.Write("Password length must be more than 6");
                        break;
                }
            }
            else
            {
                modalPopUpExtenderRegister.Show();
            }
        }

        protected void linkbtn_forgot_Click(object sender, EventArgs e)
        {

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