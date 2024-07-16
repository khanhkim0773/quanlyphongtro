using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private ObservableCollection<Room> allRooms;

        public ObservableCollection<Room> AllRooms
        {
            get { return allRooms; }
            set { allRooms = value; }
        }
        public AddRoomWindow(ObservableCollection<Room> rooms)
        {
            InitializeComponent();
            AllRooms = rooms;
        }

        private Room GetRoomFromTextBox()
        {
            Room room = new Room();
            room.RoomNumber = txbRoomNumber.Text.ToUpper();
            room.RoomRate = decimal.Parse(txbRoomRate.Text);
            room.ElectricityBill = decimal.Parse(txbElectricityBill.Text);
            room.WaterBill = decimal.Parse(txbWaterBill.Text);
            return room;
        }


        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            Room room = GetRoomFromTextBox();
            ObservableCollection<Room> listRoom = RoomBUS.GetRooms();

            bool isFound = listRoom.Any(r => room.RoomNumber == r.RoomNumber);
            if (isFound)
                MessageBox.Show("Phòng đã tồn tại!");
            else
            {
                RoomBUS.AddRoom(room);
                AllRooms.Add(room);
                this.Close();
                MessageBox.Show("Đã thêm");
            }
        }
    }
}
