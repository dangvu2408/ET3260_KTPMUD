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

namespace ET3260_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            // Tạo và hiển thị cửa sổ mới
            Home homeWin = new Home();
            homeWin.Show();

            // Nếu muốn ẩn cửa sổ hiện tại, dùng:
            // this.Hide();
        }
    }
}