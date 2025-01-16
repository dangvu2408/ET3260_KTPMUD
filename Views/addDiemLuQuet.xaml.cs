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
    /// Interaction logic for addDiemLuQuet.xaml
    /// </summary>
    public partial class addDiemLuQuet : Window
    {
        private Database.Database database;
        public addDiemLuQuet()
        {
            InitializeComponent();
            database = new Database.Database();
        }

        private void addLuQuet(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameLQ = name.Text;
                string addressLQ = address.Text;
                string dateLQ = time.Text;

                bool success = database.addDiemLuQuet(nameLQ, addressLQ, dateLQ);
                if (success)
                {
                    MessageBox.Show("Thêm điểm lũ quét thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm điểm lũ quét");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 01: " + ex.Message);
            }
        }
    }
}
