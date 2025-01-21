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
using System.Xml.Linq;
using ET3260_Project.Models;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for updatePassword.xaml
    /// </summary>
    public partial class updatePassword : Window
    {
        private User currentUser;
        private Database.Database database;
        public updatePassword(User userData)
        {
            InitializeComponent();

            currentUser = userData;
            database = new Database.Database();

        }

        private void UpdatePassword_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string oldPassword = oldpass.Password;
                string newPassword = newpass.Password;
                
                if (currentUser.Password == oldPassword)
                {
                    bool success = database.updatePassword(currentUser.ID, newPassword);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công");

                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Lỗi!!");
                    }
                } else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng, vui lòng nhập lại");

                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 00c: " + ex.Message);
            }
        }
    }
}
