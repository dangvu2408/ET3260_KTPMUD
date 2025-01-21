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
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dataTable = AddRoleDescriptions(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu người dùng!");
            }
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private DataTable AddRoleDescriptions(DataTable dataTable)
        {
            dataTable.Columns.Add("role_description", typeof(string));

            foreach (DataRow row in dataTable.Rows)
            {
                int roleValue = Convert.ToInt32(row["role"]);
                switch (roleValue)
                {
                    case 1:
                        row["role_description"] = "Quản trị";
                        break;
                    case 2:
                        row["role_description"] = "Cán bộ nghiệp vụ";
                        break;
                    default:
                        row["role_description"] = "Chưa xác định";
                        break;
                }
            }

            return dataTable;
        }

    }
}
