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
                return 1;//Email exists
            }
            else
            {
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
                dr.Close();
                dr.Dispose();

                string body = string.Format("Hi {0},<br/><br/>Thank you for registering with TravelCation.<br/>Below is your account details:<br/><br/>Log in: {1}<br/>Password: {2}<br/><br/>TravelCation", customer.FirstName, customer.Email, customer.Password);
                new SendMail().send(email, "[TravelCation] Account Registered", body);
            }
            return 0;//Register success
        }
    }

}