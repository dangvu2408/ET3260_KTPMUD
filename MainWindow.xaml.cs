using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ET3260_Project.Views;
using ET3260_Project.Models;
using ET3260_Project.Database;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ET3260_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database.Database database;
        public MainWindow()
        {
            InitializeComponent();
            database = new Database.Database();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo và hiển thị cửa sổ mới
            SigninWindow signinWindow = new SigninWindow();
            signinWindow.Show();

            // Nếu muốn ẩn cửa sổ hiện tại, dùng:
            // this.Hide();
        }

        private void LoginSuccess(object sender, RoutedEventArgs e)
        {

            string username = un.Text;
            string password = ps.Password;

            if (database.authenticateUser(username, password))
            {
                string role = database.getUserRole(username);
                string fullname = database.GetUserFullName(username);

                User current = new User { email = username, Role = role, Fullname = fullname };
                Home homeWin = new Home(current);
                homeWin.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
            }
            
        }
    }
}

// Tạo một lớp User chứa thông tin người dùng
