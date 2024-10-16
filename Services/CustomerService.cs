using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository iCustomerRepository = new CustomerRepository();
        public void CreateCustomer(Customer customer)
        {
            iCustomerRepository.CreateCustomer(customer);
        }

        public void DeleteCustomer(int CustomerId)
        {
            iCustomerRepository.DeleteCustomer(CustomerId);
        }

        public List<Customer> GetAllCustomer()
        {
            return iCustomerRepository.GetAllCustomer();
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return iCustomerRepository.GetCustomer(CustomerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            iCustomerRepository.UpdateCustomer(customer);
        }
    }
}
