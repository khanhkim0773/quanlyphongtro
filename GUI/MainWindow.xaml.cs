using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Room> allRooms = new ObservableCollection<Room>();
        private ObservableCollection<Tenant> allTenant = new ObservableCollection<Tenant>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadRooms();
        }

        public ObservableCollection<Room> AllRooms
        {
            get { return allRooms; }
            set
            {
                allRooms = value;
                OnPropertyChanged(nameof(AllRooms));
            }
        }

        public ObservableCollection<Tenant> AllTenant
        {
            get { return allTenant; }
            set
            {
                allTenant = value;
                OnPropertyChanged(nameof(AllTenant));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void LoadRooms()
        {
            AllRooms.Clear();
            ObservableCollection<Room> rooms = RoomBUS.GetRooms();

            foreach (Room room in rooms)
            {
                Tenant tenant = TenantBUS.GetTenantByRoomID(room.RoomID);
                if (tenant != null)
                    room.TenantName = tenant.Name;
                AllRooms.Add(room);
            }
        }              

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow addRoomWindow = new AddRoomWindow(AllRooms);
            addRoomWindow.ShowDialog();
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Room> selectedRooms = new ObservableCollection<Room>();
            foreach (Room room in dataGridAllRooms.ItemsSource)
            {
                DataGridRow row = (DataGridRow)dataGridAllRooms.ItemContainerGenerator.ContainerFromItem(room);
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox.IsChecked == true)
                        selectedRooms.Add(room);
                }
            }
            foreach (Room room in selectedRooms)
                RoomBUS.DeleteRoom(room);
            foreach (Room room in selectedRooms)
                AllRooms.Remove(room);
            LoadRooms();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                LoginWindow loginWindow = new LoginWindow();
                this.Close();
                loginWindow.Show();
            }
            
        }


        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRooms = new Room();
            foreach (Room room in dataGridAllRooms.ItemsSource)
            {
                DataGridRow row = (DataGridRow)dataGridAllRooms.ItemContainerGenerator.ContainerFromItem(room);
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox.IsChecked == true)
                        selectedRooms = room;
                }
            }
            EditWindow editWindow = new EditWindow(selectedRooms);
            editWindow.ShowDialog();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = txbSearch.Text;
            AllRooms.Clear();
            ObservableCollection<Room> rooms = RoomBUS.GetRooms();

            foreach (Room room in rooms)
            {
                Tenant tenant = TenantBUS.GetTenantByRoomID(room.RoomID);
                if (tenant != null && tenant.Name == name)
                {
                    room.TenantName = tenant.Name;
                    AllRooms.Add(room);
                } 
            }
        }
    }
}

