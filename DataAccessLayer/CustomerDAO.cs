using BusinessObject;
using BusinessObject.Enums;
using System.Data;

namespace DataAccessLayer
{

    public class CustomerDAO
    {
        private static string SELECT_ALL_CUSTOMERS = "SELECT * FROM [dbo].[Customer]";
        public static List<Customer> GetAllCustomer()
        {
            List<Customer> list = new List<Customer>();
            DataTable dataTable = DBContext.ExecuteQuery(SELECT_ALL_CUSTOMERS);

            foreach (DataRow row in dataTable.Rows)
            {
                int CustomerID = Convert.ToInt32(row["CustomerID"]);
                string CustomerFullName = row["CustomerFullName"].ToString();
                string Telephone = row["Telephone"].ToString();
                string EmailAddress = row["EmailAddress"].ToString();
                DateTime CustomerBirthday = Convert.ToDateTime(row["CustomerBirthday"]);
                CustomerStatus CustomerStatus = (CustomerStatus)Convert.ToInt32(row["CustomerStatus"]);
                string Password = row["Password"].ToString();

                Customer customer = new Customer(CustomerID, CustomerFullName, Telephone, EmailAddress, CustomerBirthday, CustomerStatus, Password);
                
                list.Add(customer);
            }

            return list;
        }

    }
}
