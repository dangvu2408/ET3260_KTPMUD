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
    /// Interaction logic for addDiemTruotLo.xaml
    /// </summary>
    public partial class addDiemTruotLo : Window
    {
        private Database.Database database;
        public addDiemTruotLo()
        {
            InitializeComponent();
            database = new Database.Database();

        }

        private void addTruotLo(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameLQ = name.Text;
                string addressLQ = address.Text;
                string dateLQ = time.Text;

                bool success = database.addDiemTruotLo(nameLQ, addressLQ, dateLQ);
                if (success)
                {
                    MessageBox.Show("Thêm điểm trượt lở thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm điểm trượt lở");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 02: " + ex.Message);
            }
        }
    }
}
