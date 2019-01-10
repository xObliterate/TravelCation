using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCation.BLL
{
    public class CustomerBLL
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string DOB { get; set; }
        public string Password { get; set; }

        public CustomerBLL()
        {

        }

        public CustomerBLL(string Email)
        {
            this.Email = Email;
        }

        public CustomerBLL(string Email, string FirstName, string LastName, string Password) : this(Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
        }

        public CustomerBLL(string Email, string FirstName, string LastName, string Gender, string PhoneNo, string DOB) : this(Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.PhoneNo = PhoneNo;
            this.DOB = DOB;
        }

        public int createAccount(CustomerBLL customer)
        {
            DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
            return customerDAL.createAccount(customer);
        }

        public int Login(string email, string password)
        {
            DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
            return customerDAL.Login(email, password);
        }

        public int resetAccountPassword(string email)
        {
            DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
            return customerDAL.resetAccountPassword(email);
        }

        public CustomerBLL getEmail(string uniqueID)
        {
            DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
            return customerDAL.getEmail(uniqueID);
        }

        public int changePassword(string email, string password)
        {
            DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();
            return customerDAL.changePassword(email, password);
        }
    }
}