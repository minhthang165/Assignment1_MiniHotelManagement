using BusinessObject;
using BusinessObject.Enums;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    public partial class ManageBooking : Window
    {
        private List<BookingReservation> bookings;

        public ManageBooking()
        {
            InitializeComponent();
            //LoadBookings();
        }

        //private void LoadBookings()
        //{
        //    bookings = BookingDAO.GetAllBookings(); // Replace with your method to get all bookings
        //    BookingListBox.ItemsSource = bookings;
        //}

        private void BookingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookingListBox.SelectedItem is BookingReservation selectedBooking)
            {
                BookingDatePicker.SelectedDate = selectedBooking.BookingDate;
                TotalPriceTextBox.Text = selectedBooking.TotalPrice.ToString("F2");
                CustomerIDTextBox.Text = selectedBooking.CustomerID.ToString();
                BookingStatusComboBox.SelectedItem = BookingStatusComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == selectedBooking.BookingStatus.ToString());
            }
        }

        //private void CreateBooking_Click(object sender, RoutedEventArgs e)
        //{
        //    BookingReservation newBooking = new BookingReservation()
        //    {
        //        BookingDate = BookingDatePicker.SelectedDate.Value,
        //        TotalPrice = decimal.Parse(TotalPriceTextBox.Text),
        //        CustomerID = int.Parse(CustomerIDTextBox.Text),
        //        BookingStatus = (BookingStatus)((ComboBoxItem)BookingStatusComboBox.SelectedItem).Content
        //    };

        //    BookingDetail newBookingDetail = new BookingDetail()
        //    {
        //        StartDate = StartDatePicker.SelectedDate.Value,
        //        EndDate = EndDatePicker.SelectedDate.Value,
        //        ActualPrice = decimal.Parse(TotalPriceTextBox.Text),
        //        RoomID = int.Parse(CustomerIDTextBox.Text), 
                
        //    };

        //    BookingDAO.BookingRoom(newBooking); 
        //    //LoadBookings();
        //    ClearForm();
        //}

        private void ClearForm()
        {
            BookingDatePicker.SelectedDate = null;
            TotalPriceTextBox.Clear();
            CustomerIDTextBox.Clear();
            BookingStatusComboBox.SelectedIndex = -1;
            BookingListBox.SelectedItem = null;
        }
    }
}
