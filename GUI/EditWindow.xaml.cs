using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ObservableCollection<Tenant> listTenant = new ObservableCollection<Tenant>();
        int RoomID;
        public ObservableCollection<Tenant> ListTenant
        {
            get { return listTenant; }
            set
            {
                listTenant = value;
                OnPropertyChanged(nameof(ListTenant));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditWindow(Room room)
        {
            InitializeComponent();
            RoomID = room.RoomID;
            this.DataContext = this;
            LoadRoomData(room);
            LoadTenantData(room.RoomID);
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

        public void LoadRoomData(Room room)
        {
            txbRoomNumber.Text =room.RoomNumber;
            txbRoomRate.Text = "Tiền trọ: " + room.RoomRate.ToString();
            txbElectricityBill.Text ="Tiền điện: " + room.ElectricityBill.ToString();
            txbWaterBill.Text = "Tiền nước: " + room.WaterBill.ToString();
        }

        private void LoadTenantData(int roomID)
        {
            ListTenant = BUS.TenantBUS.GetListTenantByRoomID(roomID);
        }

        private void btnDeleteTenant_Click(object sender, RoutedEventArgs e)
        {
            Room r = BUS.RoomBUS.GetRoomByRoomNumber(txbRoomNumber.Text.ToUpper());
            ObservableCollection<Tenant> selectedTenant = new ObservableCollection<Tenant>();
            foreach (Tenant tenant in dtgTenant.ItemsSource)
            {
                DataGridRow row = (DataGridRow)dtgTenant.ItemContainerGenerator.ContainerFromItem(tenant);
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox.IsChecked == true)
                    {
                        selectedTenant.Add(tenant);
                    }
                }
            }
            foreach (Tenant tenant in selectedTenant)
                TenantBUS.DeleteTenant(tenant);

            foreach (Tenant tenant in selectedTenant)
                ListTenant.Remove(tenant);
            LoadTenantData(r.RoomID);
        }

        private void btnAddTenant_Click(object sender, RoutedEventArgs e)
        {
            Room r = BUS.RoomBUS.GetRoomByRoomNumber(txbRoomNumber.Text.ToUpper());
            AddTenantWindow addTenantWindow = new AddTenantWindow(r);
            addTenantWindow.ShowDialog();
        }

        private void btnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            this.LoadTenantData(RoomID);
        }
    }
}
