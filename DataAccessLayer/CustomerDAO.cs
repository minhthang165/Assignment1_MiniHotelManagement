using BusinessObject;
using BusinessObject.Enums;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private static string SELECT_ALL_CUSTOMERS =    "SELECT * FROM [dbo].[Customer]";
        private static string INSERT_NEW_CUSTOMERS =    "INSERT [dbo].[Customer] ([CustomerFullName], [Telephone], [EmailAddress], [CustomerBirthday], [CustomerStatus], [Password])\n" +
                                                        "VALUES (@FullName, @Telephone, @Email, CAST(@Birthday AS Date), @Status, @Password)";
        private static string UPDATE_CUSTOMER_BY_ID =   "UPDATE [dbo].[Customer]\n" +
                                                        "SET\n" +
                                                        "   CustomerFullName = @FullName,\n" +
                                                        "   Telephone = @Telephone,\n" +
                                                        "   EmailAddress = @Email,\n" +
                                                        "   CustomerBirthday = CAST(@Birthday AS Date),\n" +
                                                        "   CustomerStatus = @Status,\n" +
                                                        "   Password = @Password\n" +
                                                        "WHERE\n    " +
                                                        "   CustomerID = @CustomerID; ";
        private static string DELETE_CUSTOMER_BY_ID =   "DELETE FROM [dbo].[Customer]\n" +
                                                        "WHERE CustomerID = @CustomerID;";
        private static string SELECT_CUSTOMER_BY_ID =   "SELECT * FROM [dbo].[Customer]" +
                                                        "WHERE CustomerID = @CustomerID;";

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

        public static void CreateNewCustomer(Customer customer)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@FullName", customer.CustomerFullName),
                new SqlParameter("@Telephone", customer.Telephone),
                new SqlParameter("@Email", customer.EmailAddress),
                new SqlParameter("@Birthday", customer.CustomerBirthday),
                new SqlParameter("@Status", customer.CustomerStatus),
                new SqlParameter("Password", customer.Password)
            };

            DBContext.ExecuteNonQuerry(INSERT_NEW_CUSTOMERS, parameters);
        }

        public static void UpdateCustomer(Customer customer)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@FullName", customer.CustomerFullName),
                new SqlParameter("@Telephone", customer.Telephone),
                new SqlParameter("@Email", customer.EmailAddress),
                new SqlParameter("@Birthday", customer.CustomerBirthday),
                new SqlParameter("@Status", customer.CustomerStatus),
                new SqlParameter("@Password", customer.Password),
                new SqlParameter("@CustomerID", customer.CustomerID)
            };

            DBContext.ExecuteNonQuerry(UPDATE_CUSTOMER_BY_ID, parameters);
        }

        public static void DeleteCustomer(int CustomerId)
        {
            SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@CustomerID", CustomerId)};

            DBContext.ExecuteNonQuerry(DELETE_CUSTOMER_BY_ID, parameters);
        }

        public static Customer GetCustomer(int CustomerId) 
        {
            SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@CustomerID", CustomerId)};
            DataTable dataTable = DBContext.ExecuteQuery(SELECT_CUSTOMER_BY_ID, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                int CustomerID = Convert.ToInt32(row["CustomerID"]);
                string CustomerFullName = row["CustomerFullName"].ToString();
                string Telephone = row["Telephone"].ToString();
                string EmailAddress = row["EmailAddress"].ToString();
                DateTime CustomerBirthday = Convert.ToDateTime(row["CustomerBirthday"]);
                CustomerStatus CustomerStatus = (CustomerStatus)Convert.ToInt32(row["CustomerStatus"]);
                string Password = row["Password"].ToString();

                return new Customer(CustomerID, CustomerFullName, Telephone, EmailAddress, CustomerBirthday, CustomerStatus, Password);
            }
            return null;
        }
    }
}
