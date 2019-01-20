using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using TravelCation.BLL;

namespace TravelCation.DAL
{
    public class PaymentDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["TravelCation"].ConnectionString;

        public int insertPayment(int custID, PaymentBLL payment)
        {
            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "INSERT INTO Payment(CustID, CreditCardNo, Expiry, AccountHolder) VALUES(@custID, @creditCardNo, @expiry, @accountHolder";
            SqlCommand cmd = new SqlCommand(queryStr, con);

            if (!InputValidation.ValidateCC(payment.CreditCardNo))
            {
                return 1;// Invalid CreditCardNo
            }

            else
            {
                cmd.Parameters.AddWithValue("@creditCardNo", payment.CreditCardNo);
                cmd.Parameters.AddWithValue("@expiry", payment.Expiry);
                cmd.Parameters.AddWithValue("@accountHolder", payment.AccountHolder);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;// success
        }

        public PaymentBLL getPaymentInfo(int custID)
        {
            PaymentBLL payment;

            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "SELECT CreditCardNo, Expiry, AccountHolder FROM Payment WHERE CustID = @custID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@custID", custID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string CreditCardNo = dr["CreditCardNo"].ToString();
                string Expiry = dr["Expiry"].ToString();
                string AccountHolder = dr["AccountHolder"].ToString();
                payment = new PaymentBLL(CreditCardNo, Expiry, AccountHolder);
            }
            else
            {
                payment = null;
            }
            con.Close();
            con.Dispose();
            dr.Dispose();

            return payment;
        }

        public int updatePayment(int custID, PaymentBLL payment)
        {
            SqlConnection con = new SqlConnection(connStr);
            string queryStr = "UPDATE Payment SET CreditCardNo = @creditCardNo, Expiry = @expiry, AccountHolder = @accountHolder WHERE CustID = @custID";
            SqlCommand cmd = new SqlCommand(queryStr, con);

            if (!InputValidation.ValidateCC(payment.CreditCardNo))
            {
                return 1;// Invalid CreditCardNo
            }

            else
            {
                cmd.Parameters.AddWithValue("@creditCardNo", payment.CreditCardNo);
                cmd.Parameters.AddWithValue("@expiry", payment.Expiry);
                cmd.Parameters.AddWithValue("@accountHolder", payment.AccountHolder);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;// success
        }
    }
}