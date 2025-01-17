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

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for addChiCucThuY.xaml
    /// </summary>
    public partial class addChiCucThuY : Window
    {
        private Database.Database database;
        public addChiCucThuY()
        {
            InitializeComponent();
            database = new Database.Database();
        }

        private void addChiCucThuY_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string tenChiCuc = name.Text;
                string diaChiCC = address.Text;
                string soDienThoaiCC = number.Text;
                

                bool success = database.addChiCucThuY(tenChiCuc, diaChiCC, soDienThoaiCC);
                if (success)
                {
                    MessageBox.Show("Thêm chi cục thú y thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm chi cục thú y!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 07: " + ex.Message);
            }
        }
    }
}
