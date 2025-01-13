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
            }
            if (currentUser.Role == "2")
            {
                UserRoleField.Text = "Cán bộ nghiệp vụ";
            }
        }
    }
}
