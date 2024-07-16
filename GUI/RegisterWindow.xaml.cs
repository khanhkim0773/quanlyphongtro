using BUS;
using DTO;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?",
                "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txbNameLogin.Text;
            string password = pwb_password.Password;
            List<Account> accounts = AccountBUS.GetAccounts();
            bool isFound = accounts.Any(acc => username == acc.Username && password == acc.Password);
            if (isFound)
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu đã tồn tại");
            else
            {
                Account account = new Account();  account.Username = username;
                account.Password = password; account.AccountType = 1;
                BUS.AccountBUS.AddAccount(account);
                MessageBox.Show("Đăng kí tài khoản thành công");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
