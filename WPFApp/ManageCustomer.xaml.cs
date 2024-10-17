using BusinessObject;
using BusinessObject.Enums;
using Services;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService _customerService;
        private Customer _selectedCustomer;

        public MainWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService(); // Use DI in the future, this is for simplicity now
            LoadCustomers();
        }

        // Load all customers into the listbox
        private void LoadCustomers()
        {
            List<Customer> customers = _customerService.GetAllCustomer();
            CustomerListBox.ItemsSource = customers;
        }

       
        private void CustomerListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CustomerListBox.SelectedItem is Customer customer)
            {
                _selectedCustomer = customer;
                FullNameTextBox.Text = customer.CustomerFullName;
                TelephoneTextBox.Text = customer.Telephone;
                EmailTextBox.Text = customer.EmailAddress;
                BirthdayPicker.SelectedDate = customer.CustomerBirthday;
            }
        }

        // Create new customer
        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            Customer newCustomer = new Customer()
            {
                CustomerFullName = FullNameTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                EmailAddress = EmailTextBox.Text,
                CustomerBirthday = BirthdayPicker.SelectedDate ?? DateTime.Now,
                CustomerStatus = CustomerStatus.Active, 
                Password = password 
            };

            _customerService.CreateCustomer(newCustomer);
            LoadCustomers(); // Reload the customer list
        }

        // Update selected customer
        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                _selectedCustomer.CustomerFullName = FullNameTextBox.Text;
                _selectedCustomer.Telephone = TelephoneTextBox.Text;
                _selectedCustomer.EmailAddress = EmailTextBox.Text;
                _selectedCustomer.CustomerBirthday = BirthdayPicker.SelectedDate ?? DateTime.Now;

                _customerService.UpdateCustomer(_selectedCustomer);
                LoadCustomers(); // Reload the customer list
            }
            else
            {
                MessageBox.Show("No customer selected!");
            }
        }

        // Delete selected customer
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                _customerService.DeleteCustomer(_selectedCustomer.CustomerID);
                LoadCustomers(); // Reload the customer list
            }
            else
            {
                MessageBox.Show("No customer selected!");
            }
        }

        // Search customers by name
        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<Customer> filteredList = _customerService.GetAllCustomer()
                .FindAll(c => c.CustomerFullName.ToLower().Contains(searchText));

            CustomerListBox.ItemsSource = filteredList;
        }
    }
}