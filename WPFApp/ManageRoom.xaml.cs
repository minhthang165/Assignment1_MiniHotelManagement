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
            _roomService = new RoomService();
            LoadRooms();
        }


        private void LoadRooms()
        {
            List<RoomInformation> rooms = _roomService.GetAllRoom();
            RoomListBox.ItemsSource = rooms;
        }


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
                RoomPricePerDate = 0, 
                RoomTypeID = int.Parse((RoomTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString()) 

            };

            _roomService.CreateNewRoom(newRoom);
            LoadRooms();
        }


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
                LoadRooms(); 
            }
            else
            {
                MessageBox.Show("No room selected!");
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _roomService.DeleteRoom(_selectedRoom.RoomID);
                LoadRooms();
            }
            else
            {
                MessageBox.Show("No room selected!");
            }
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<RoomInformation> filteredList = _roomService.GetAllRoom()
                .FindAll(r => r.RoomNumber.ToLower().Contains(searchText));

            RoomListBox.ItemsSource = filteredList;
        }
    }
}
