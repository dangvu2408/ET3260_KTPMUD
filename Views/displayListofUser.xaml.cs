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
    /// Interaction logic for displayListofUser.xaml
    /// </summary>
    public partial class displayListofUser : Window
    {
        private Database.Database database;
        public displayListofUser()
        {
            InitializeComponent();
            database = new Database.Database();

            DataTable dataTable = new DataTable();
            dataTable = database.getUser();
            GridViewQuery.ItemsSource = dataTable.DefaultView;
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
