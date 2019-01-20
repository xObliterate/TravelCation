using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCation.BLL
{
    public class PaymentBLL
    {
        public string CreditCardNo { get; set; }
        public string Expiry { get; set; }
        public string AccountHolder { get; set; }
        public string CVV { get; set; }

        public PaymentBLL()
        {

        }

        public PaymentBLL(string CreditCardNo, string Expiry, string AccountHolder)
        {
            this.CreditCardNo = CreditCardNo;
            this.Expiry = Expiry;
            this.AccountHolder = AccountHolder;
        }

        public int insertPayment(int custID, PaymentBLL payment)
        {
            DAL.PaymentDAL paymentDAL = new DAL.PaymentDAL();
            return paymentDAL.insertPayment(custID, payment);
        }

        public PaymentBLL getPaymentInfo(int custID)
        {
            DAL.PaymentDAL paymentDAL = new DAL.PaymentDAL();
            return paymentDAL.getPaymentInfo(custID);
        }

        public int updatePayment(int custID, PaymentBLL payment)
        {
            DAL.PaymentDAL paymentDAL = new DAL.PaymentDAL();
            return paymentDAL.updatePayment(custID, payment);
        }
    }
}