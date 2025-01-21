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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ET3260_Project.Models;
using ET3260_Project.Database;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for ProfileTab.xaml
    /// </summary>
    public partial class ProfileTab : UserControl
    {
        private User currentUser;
        private Database.Database database;
        public ProfileTab(User user)
        {
            InitializeComponent();
            currentUser = user;
            UserFullname.Text = currentUser.Fullname;
            if (currentUser.Role == "1")
            {
                UserRoleField.Text = "Quản trị";
                Role1Display1st.Visibility = Visibility.Visible;
                Role1Display2nd.Visibility = Visibility.Visible;
                Role1Display3rd.Visibility = Visibility.Visible;
            }
            if (currentUser.Role == "2")
            {
                UserRoleField.Text = "Cán bộ nghiệp vụ";
                Role1Display1st.Visibility = Visibility.Collapsed;
                Role1Display2nd.Visibility = Visibility.Collapsed;
                Role1Display3rd.Visibility = Visibility.Collapsed;
            }
        }

        private void ThemNguoiDung(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addNguoiDung win1 = new addNguoiDung();
            win1.Show();
        }

        private void CapNhatNguoiDung(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateThongTinNguoiDung win2 = new updateThongTinNguoiDung(currentUser);
            win2.Show();
        }

        private void CapNhatMatKhau(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updatePassword win3 = new updatePassword(currentUser);
            win3.Show();
        }

        private void QueryUser(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            displayListofUser win4 = new displayListofUser();
            win4.Show();
        }
    }

    
}
