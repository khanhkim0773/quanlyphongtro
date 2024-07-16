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
    /// Interaction logic for AddTenantWindow.xaml
    /// </summary>
    public partial class AddTenantWindow : Window
    {
        ObservableCollection<Tenant> listTenant = new ObservableCollection<Tenant>();
        private Tenant tenant;
        private int roomID;

        public AddTenantWindow(Room room)
        {
            InitializeComponent();
            tenant = new Tenant();
            roomID = room.RoomID;
            this.DataContext = this;
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cmb.SelectedItem;
            string gender = selectedItem.Tag.ToString();
            tenant.Gender = gender;
        }

        public Tenant GetTenantFromTextBox()
        {
            tenant.Name = txbName.Text;

            DateTime? selectedDate = dpBirthDay.SelectedDate;
            DateTime birthDate = selectedDate.Value;
            tenant.DateOfBirth = birthDate;
            tenant.PhoneNumber = txbNumberPhone.Text;
            tenant.Email = txbEmail.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)cmbGender.SelectedItem;
            string gender = selectedItem.Tag.ToString();
            tenant.Gender = gender;
            tenant.RoomID = roomID;
            tenant.CCCD = txbCCCD.Text;
            return tenant;
        }

        private void btnAddTenant_Click(object sender, RoutedEventArgs e)
        {
            listTenant = BUS.TenantBUS.GetListTenant();
            Tenant tenant = GetTenantFromTextBox();
            bool isFound = listTenant.Any(t => t.Name == tenant.Name && t.DateOfBirth == tenant.DateOfBirth
                                            && t.PhoneNumber == tenant.PhoneNumber && t.Email == tenant.Email
                                            && t.Gender == tenant.Gender);
            if (isFound)
                MessageBox.Show("Khách hàng đã tồn tại!");
            else
            {
                BUS.TenantBUS.AddTenant(tenant);
                listTenant.Add(tenant);
                this.Close();
                MessageBox.Show("Đã thêm");
            }
        }
    }
    
}
