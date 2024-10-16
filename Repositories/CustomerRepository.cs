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
        
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomer() => CustomerDAO.GetAllCustomer();

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        
    }

}
