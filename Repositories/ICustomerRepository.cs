using BusinessObject;
using BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(int CustomerID);
        void UpdateCustomer(Customer customer);
        List<Customer> GetAllCustomer();
        Customer GetCustomer(int CustomerID);
    }
}
