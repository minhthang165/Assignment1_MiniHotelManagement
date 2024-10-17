using BusinessObject;
using BusinessObject.Enums;
using DataAccessLayer;
using Services;
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
        private readonly BookingService _bookingService;

        public ManageBooking()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            LoadBookings();
        }

        private void LoadBookings()
        {
            bookings = _bookingService.GetALlBooking();
            BookingListBox.ItemsSource = bookings;
        }

        private void BookingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookingListBox.SelectedItem is BookingReservation selectedBooking)
            {
                StartDatePicker.SelectedDate = selectedBooking.BookingDate;
                TotalPriceTextBox.Text = selectedBooking.TotalPrice.ToString("F2");
                CustomerIDTextBox.Text = selectedBooking.CustomerID.ToString();
                BookingStatusComboBox.SelectedItem = BookingStatusComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == selectedBooking.BookingStatus.ToString());
            }
        }

        private void CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingReservation newBooking = new BookingReservation()
            {
                BookingReservationID = int.Parse(BookingReservationIDTextBox.Text),
                BookingDate = StartDatePicker.SelectedDate.Value,
                TotalPrice = decimal.Parse(TotalPriceTextBox.Text),
                CustomerID = int.Parse(CustomerIDTextBox.Text),
                BookingStatus = (BookingStatus)Enum.Parse(typeof(BookingStatus), (BookingStatusComboBox.SelectedItem as ComboBoxItem).Content.ToString())
            };

            BookingDetail newBookingDetail = new BookingDetail()
            {
                BookingReservationID = int.Parse(BookingReservationIDTextBox.Text),
                RoomID = int.Parse((RoomIDComboBox.SelectedItem as ComboBoxItem).Content.ToString()),
                StartDate = StartDatePicker.SelectedDate.Value,
                EndDate = EndDatePicker.SelectedDate.Value,
                ActualPrice = decimal.Parse(ActualPriceTextBox.Text)
            };

            bool isSuccess = _bookingService.BookRoom(newBooking, newBookingDetail);

            if (isSuccess)
            {
                MessageBox.Show("Booking created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Booking creation failed. Please check the details and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ClearForm();
        }

        private void ClearForm()
        {
            StartDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
            TotalPriceTextBox.Clear();
            CustomerIDTextBox.Clear();
            BookingStatusComboBox.SelectedIndex = -1;
            BookingListBox.SelectedItem = null;
        }
    }
}
