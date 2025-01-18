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

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for addToChucChungNhan.xaml
    /// </summary>
    public partial class addToChucChungNhan : Window
    {
        private Database.Database database;
        public addToChucChungNhan()
        {
            InitializeComponent();
            database = new Database.Database();
        }

        private void addToChucChunngNhan_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameTC = name.Text;
                string nguoiDaiDien = represent.Text;
                string emailTC = email.Text;
                string sdtTC = number.Text;

                bool success = database.addToChucChungNhan(nameTC, nguoiDaiDien, emailTC, sdtTC);
                if (success)
                {
                    MessageBox.Show("Thêm tổ chức chứng nhận thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm tổ chức chứng nhận!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 12: " + ex.Message);
            }
        }
    }
}
