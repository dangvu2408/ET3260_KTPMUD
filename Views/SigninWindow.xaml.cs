using System;
using System.Collections.Generic;
using System.Data;
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

using ET3260_Project.Database;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for SigninWindow.xaml
    /// </summary>
    public partial class SigninWindow : Window
    {
        private Database.Database database;
        public SigninWindow()
        {
            InitializeComponent();
            database = new Database.Database();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = em.Text;
                string fullname = un.Text;
                string password = ps.Password;
                int role = 0;
                if (UserDropdown.SelectedItem is ComboBoxItem selectedItem)
                {
                    string selectedContent = selectedItem.Content.ToString();

                    if (selectedContent == "Quản trị")
                    {
                        role = 1;
                    }
                    else if (selectedContent == "Cán bộ nghiệp vụ")
                    {
                        role = 2;
                    }

                }

                bool success = database.addUser(email, password, role, fullname);
                if (success)
                {
                    MessageBox.Show("User added successfully!");
                    DataTable userData = database.getUser();
                    
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Failed to add user. Try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 00: " + ex.Message);
            }
        }
    }
}
