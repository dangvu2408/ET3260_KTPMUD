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
    /// Interaction logic for addTrieuChung.xaml
    /// </summary>
    public partial class addTrieuChung : Window
    {
        private Database.Database database;
        public List<TrieuChungItem> list;
        public addTrieuChung()
        {
            InitializeComponent();
            database = new Database.Database();
            list = new List<TrieuChungItem>();
        }

        private void addTrieuChung_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameCT = name.Text;
                string describeCT = describe.Text;

                bool success = database.addTrieuChung(nameCT, describeCT);
                if (success)
                {
                    MessageBox.Show("Thêm triệu chứng lâm sàng thành công!");
                    
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm triệu chứng lâm sàng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 03: " + ex.Message);
            }
        }
    }
}
