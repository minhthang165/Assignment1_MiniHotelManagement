using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; } 
        public string Telephone { get; set; }
        public string EmailAddress { get; set; } 
        public DateTime CustomerBirthday { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public string Password { get; set; }

        public Customer(int customerID, string customerFullName, string telephone, string emailAddress, 
            DateTime customerBirthday, CustomerStatus customerStatus, string password)
        {
            CustomerID = customerID;
            CustomerFullName = customerFullName;
            Telephone = telephone;
            EmailAddress = emailAddress;
            CustomerBirthday = customerBirthday;
            CustomerStatus = customerStatus;
            Password = password;
        }

        public Customer(int customerID, string customerFullName, string telephone, string emailAddress,
            DateTime customerBirthday, CustomerStatus customerStatus)
        {
            CustomerID = customerID;
            CustomerFullName = customerFullName;
            Telephone = telephone;
            EmailAddress = emailAddress;
            CustomerBirthday = customerBirthday;
            CustomerStatus = customerStatus;
        }
    }
}
