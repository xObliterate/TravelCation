using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TravelCation.BLL;

namespace TravelCation.DAL
{
    public class CustomerDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public int createAccount(CustomerBLL customer)
        {
            string queryStr = "", email = customer.Email.ToLower();
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
            string queryStr = "SELECT Email, FirstName, LastName, Gender, PhoneNo, DOB, Password FROM Customer WHERE Email = @email";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", loginEmail);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() && !dr.HasRows)
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
                    CustomerBLL cust = new CustomerBLL(Email, FirstName, LastName, Gender, PhoneNo, DOB);
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session["Customer"] = cust;
                    HttpContext.Current.Response.BufferOutput = true;
                    HttpContext.Current.Response.Redirect("/APP/Profile.aspx");
                }
                else
                {
                    return 4;// Wrong Password
                }
                con.Close();
                dr.Close();
                dr.Dispose();
            }
            return 0;// Login Success
        }
    }
}