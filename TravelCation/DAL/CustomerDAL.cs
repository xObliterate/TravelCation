using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TravelCation.BLL;
using System.Web.UI;
using System.Web.Security;

namespace TravelCation.DAL
{
    public class CustomerDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public int createAccount(CustomerBLL customer)
        {
            string queryStr = "";
            string email = customer.Email.ToLower();
            SqlCommand cmd;

            SqlConnection con = new SqlConnection(connStr);
            queryStr = "SELECT Email FROM Customer WHERE Email = @email";
            cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                return 1;// Email exists
            }

            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) || string.IsNullOrEmpty(customer.Email) || string.IsNullOrEmpty(customer.Password))
            {
                return 2;// Empty fields
            }

            if (!InputValidation.ValidateEmail(customer.Email))
            {
                return 3;// Invalid email
            }

            if (!InputValidation.ValidateOnePassword(customer.Password))
            {
                return 4;// Invalid password requirement
            }

            else
            {
                dr.Close();
                dr.Dispose();

                queryStr = "INSERT INTO Customer(Email, FirstName, LastName, Password) VALUES(@email, @firstName, @lastName, @password)";
                cmd = new SqlCommand(queryStr, con);

                // First ":" to second is the salt
                // Second ":" to the end is the hash
                string saltHashReturned = PasswordHash.CreateHash(customer.Password);
                int commaIndex = saltHashReturned.IndexOf(":");
                string extractedString = saltHashReturned.Substring(0, commaIndex);
                commaIndex = saltHashReturned.IndexOf(":");
                extractedString = saltHashReturned.Substring(commaIndex + 1);
                commaIndex = extractedString.IndexOf(":");
                string salt = extractedString.Substring(0, commaIndex);

                commaIndex = extractedString.IndexOf(":");
                extractedString = extractedString.Substring(commaIndex + 1);
                string hash = extractedString;

                cmd.Parameters.AddWithValue("@email", customer.Email.ToLower());
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName.ToLower());
                cmd.Parameters.AddWithValue("@lastName", customer.LastName.ToLower());
                cmd.Parameters.AddWithValue("@password", saltHashReturned);
                cmd.ExecuteNonQuery();
                con.Close();

                string body = string.Format("Hi {0},<br/><br/>Thank you for registering with TravelCation.<br/>Below is your account details:<br/><br/>Log in: {1}<br/>Password: {2}<br/><br/>TravelCation", customer.FirstName, customer.Email, customer.Password);
                new SendMail().send(email, "[TravelCation] Account Registered", body);
            }
            return 0;// Register success
        }

        public int Login(string email, string password)
        {
            string loginEmail = email.ToLower();

            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "SELECT CustID, Email, FirstName, LastName, Gender, PhoneNo, DOB, Password FROM Customer WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", loginEmail);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.HasRows)
            {
                return 1;// Email does not exist
            }

            if (string.IsNullOrEmpty(loginEmail) || string.IsNullOrEmpty(password))
            {
                return 2;// Empty fields
            }

            if (!InputValidation.ValidateEmail(loginEmail))
            {
                return 3;// Invalid email
            }

            else
            {
                if (dr.Read())
                {
                    int CustID = int.Parse(dr["CustID"].ToString());
                    string Email = dr["Email"].ToString();
                    string FirstName = dr["FirstName"].ToString();
                    string LastName = dr["LastName"].ToString();
                    string Gender = dr["Gender"].ToString();
                    string PhoneNo = dr["PhoneNo"].ToString();
                    string DOB = dr["DOB"].ToString();
                    string HashPassword = dr["Password"].ToString();

                    bool validUser = PasswordHash.ValidatePassword(password, HashPassword);
                    if (validUser == true)
                    {
                        CustomerBLL cust = new CustomerBLL(CustID, Email, FirstName, LastName, Gender, PhoneNo, DOB);
                        HttpContext.Current.Session.RemoveAll();
                        HttpContext.Current.Session["Customer"] = cust;
                    }
                    else
                    {
                        return 4;// Wrong Password
                    }
                    con.Close();
                    dr.Close();
                    dr.Dispose();
                }
            }
            return 0;// Login Success
        }

        public int resetAccountPassword(string email)
        {
            string resetemail = email.ToLower();
            string queryStr = "";
            string uniqueID = PasswordHash.generateResetToken();
            Uri uri = HttpContext.Current.Request.Url;
            string aspx = "/APP/ResetPassword.aspx?code=";

            SqlConnection con = new SqlConnection(connStr);
            queryStr = "SELECT Email FROM Customer WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue(@"email", resetemail);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (string.IsNullOrEmpty(resetemail))
            {
                return 1;// Empty fields
            }

            if (!InputValidation.ValidateEmail(resetemail))
            {
                return 2;// Invalid email
            }

            else
            {
                dr.Close();
                dr.Dispose();

                queryStr = "UPDATE Customer SET UniqueID = @uniqueid WHERE Email = @email";
                cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@uniqueid", uniqueID);
                cmd.Parameters.AddWithValue("email", resetemail);
                cmd.ExecuteNonQuery();
                con.Close();

                string url = string.Format("{0}{1}{2}:{3}{4}{5}", uri.Scheme, Uri.SchemeDelimiter, uri.Host, uri.Port, aspx, uniqueID);
                string body = string.Format("Hello {0},<br/><br/> We received a request to reset your password.<br/><br/>{1}<br/><br/>TravelCation", "a", url);

                new SendMail().send(email, "[TravelCation] Password Reset", body);
            }
            return 0;//Success
        }

        public CustomerBLL getEmail(string uniqueID)
        {
            CustomerBLL cust = null;

            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "SELECT Email FROM Customer WHERE UniqueID = @uniqueid";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@uniqueid", uniqueID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string Email = dr["Email"].ToString();
                cust = new CustomerBLL(Email);
            }

            else
            {
                cust = null;// unique id does not exist
            }
            con.Close();
            dr.Close();
            dr.Dispose();

            return cust;// success
        }

        public int changePassword(string email, string password)
        {
            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "UPDATE Customer SET Password = @password, UniqueID = NULL WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(queryStr, con);

            if (!InputValidation.ValidateOnePassword(password))
            {
                return 1;// Invalid password requirement
            }

            else
            {
                // First ":" to second is the salt
                // Second ":" to the end is the hash
                string saltHashReturned = PasswordHash.CreateHash(password);
                int commaIndex = saltHashReturned.IndexOf(":");
                string extractedString = saltHashReturned.Substring(0, commaIndex);
                commaIndex = saltHashReturned.IndexOf(":");
                extractedString = saltHashReturned.Substring(commaIndex + 1);
                commaIndex = extractedString.IndexOf(":");
                string salt = extractedString.Substring(0, commaIndex);

                commaIndex = extractedString.IndexOf(":");
                extractedString = extractedString.Substring(commaIndex + 1);
                string hash = extractedString;

                cmd.Parameters.AddWithValue("@password", saltHashReturned);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }

        public void logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
            FormsAuthentication.SignOut();

            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1));
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            HttpContext.Current.Response.Redirect("/Index.aspx");
        }
    }
}