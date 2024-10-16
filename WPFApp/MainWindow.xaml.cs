using BusinessObject;
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
        private readonly ICustomerService iCustomerService;

        public MainWindow()
        {
            InitializeComponent();
            ICustomerService customerService = new CustomerService();
            List<Customer> list = customerService.GetAllCustomer();

            // Bind the list of customers to the ListBox
            CustomerListBox.ItemsSource = list;
        }
    }
}