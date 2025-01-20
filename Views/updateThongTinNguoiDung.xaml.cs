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
using ET3260_Project.Models;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for updateThongTinNguoiDung.xaml
    /// </summary>
    public partial class updateThongTinNguoiDung : Window
    {
        private User currentUser;
        private Database.Database database;
        public updateThongTinNguoiDung(User userData)
        {
            InitializeComponent();
            currentUser = userData;
            database = new Database.Database();

            email.Text = currentUser.email;
            name.Text = currentUser.Fullname;
        }

        private void UpdateUser_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string emailNew = email.Text;
                string fullnameNew = name.Text;
                int roleNew = 0;
                if (UserDropdown.SelectedItem is ComboBoxItem selectedItem)
                {
                    string selectedContent = selectedItem.Content.ToString();

                    if (selectedContent == "Quản trị")
                    {
                        roleNew = 1;
                    }
                    else if (selectedContent == "Cán bộ nghiệp vụ")
                    {
                        roleNew = 2;
                    }

                }

                bool success = database.updateUser(currentUser.ID, emailNew, roleNew, fullnameNew);
                if (success)
                {
                    MessageBox.Show("Cập nhật dữ liệu người dùng thành công");
                    DataTable userData = database.getUser();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Lỗi!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 00b: " + ex.Message);
            }
        }
    }
}
