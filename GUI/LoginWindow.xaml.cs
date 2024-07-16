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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txb_username.Text;
            string password = pwb_password.Password;

            List<Account> accounts = AccountBUS.GetAccounts();

            bool isFound = accounts.Any(acc => username == acc.Username 
                        && password == acc.Password);

            if (isFound)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác!");
            }
        }


        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            //đóng ứng dụng
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", 
                "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();   
            this.Close();
            registerWindow.Show();

        }
    }
}
