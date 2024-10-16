using BusinessObject;
using BusinessObject.Enums;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for ManageRoom.xaml
    /// </summary>
    public partial class ManageRoom : Window
    {
        private readonly IRoomService _roomService;
        private RoomInformation _selectedRoom;

        public ManageRoom()
        {
            InitializeComponent();
            _roomService = new RoomService(); // Use DI in the future, this is for simplicity now
            LoadRooms();
        }

        // Load all rooms into the listbox
        private void LoadRooms()
        {
            List<RoomInformation> rooms = _roomService.GetAllRoom();
            RoomListBox.ItemsSource = rooms;
        }

        // When a room is selected, populate the fields
        private void RoomListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RoomListBox.SelectedItem is RoomInformation room)
            {
                _selectedRoom = room;
                RoomNumberTextBox.Text = room.RoomNumber;
                DescriptionTextBox.Text = room.RoomDescription;
                MaxCapacityTextBox.Text = room.RoomMaxCapacity.ToString();
                RoomStatusTextBox.Text = room.RoomStatus.ToString();
                PriceTextBox.Text = room.RoomPricePerDate.ToString();
            }
        }

        // Create new room
        private void CreateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Room Type.");
                return;
            }

            RoomInformation newRoom = new RoomInformation()
            {
                RoomNumber = RoomNumberTextBox.Text,
                RoomDescription = DescriptionTextBox.Text,
                RoomMaxCapacity = int.Parse(MaxCapacityTextBox.Text),
                RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem,
                RoomPricePerDate = 0, // Default or other field not shown
                RoomTypeID = int.Parse((RoomTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString()) // Assuming RoomTypeName corresponds to the selected ID

            };

            _roomService.CreateNewRoom(newRoom);
            LoadRooms(); // Reload the room list
        }

        // Update selected room
        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _selectedRoom.RoomNumber = RoomNumberTextBox.Text;
                _selectedRoom.RoomDescription = DescriptionTextBox.Text;
                _selectedRoom.RoomMaxCapacity = int.Parse(MaxCapacityTextBox.Text);
                _selectedRoom.RoomStatus = (RoomStatus)RoomStatusComboBox.SelectedItem;
                _selectedRoom.RoomPricePerDate = decimal.Parse(PriceTextBox.Text);

                _roomService.UpdateRoom(_selectedRoom);
                LoadRooms(); // Reload the room list
            }
            else
            {
                MessageBox.Show("No room selected!");
            }
        }

        // Delete selected room
        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _roomService.DeleteRoom(_selectedRoom.RoomID);
                LoadRooms(); // Reload the room list
            }
            else
            {
                MessageBox.Show("No room selected!");
            }
        }

        // Search rooms by number
        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<RoomInformation> filteredList = _roomService.GetAllRoom()
                .FindAll(r => r.RoomNumber.ToLower().Contains(searchText));

            RoomListBox.ItemsSource = filteredList;
        }
    }
}
