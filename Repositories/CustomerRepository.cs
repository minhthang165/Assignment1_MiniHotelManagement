using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer) => CustomerDAO.CreateNewCustomer(customer);

        public void DeleteCustomer(int CustomerID) => CustomerDAO.DeleteCustomer(CustomerID);

        public List<Customer> GetAllCustomer() => CustomerDAO.GetAllCustomer();

        public Customer GetCustomer(int CustomerID) => CustomerDAO.GetCustomer(CustomerID); 

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
        
    }

}
