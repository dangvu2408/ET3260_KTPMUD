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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for QueryTab.xaml
    /// </summary>
    public partial class QueryTab : UserControl
    {
        private Database.Database database;
        public QueryTab()
        {
            InitializeComponent();
            database = new Database.Database();
            
        }

        private void Query_Btn(object sender, RoutedEventArgs e)
        {
            if (queryDropdown.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedStatus = selectedItem.Content.ToString();
                DataTable dataTable = new DataTable();

                // Gọi phương thức tương ứng trong lớp database
                switch (selectedStatus)
                {
                    case "Tra cứu điểm trượt lở":
                        dataTable = database.getDiemTruotLo();
                        break;
                    case "Tra cứu điểm lũ quét":
                        dataTable = database.getDiemLuQuet();
                        break;
                    case "Tra cứu ổ dịch":
                        dataTable = database.getODich();
                        break;
                    case "Tra cứu chi cục thú y":
                        dataTable = database.getChiCuc();
                        break;
                    case "Tra cứu đại lý bán thuốc thú y":
                        dataTable = database.getDaiLy();
                        break;
                    case "Tra cứu khu tạm giữ, tiêu hủy gia súc gia cầm":
                        dataTable = database.getKhuTamGiu();
                        break;
                    case "Tra cứu cơ sở giết mổ gia súc, gia cầm":
                        dataTable = database.getCoSoGietMo();
                        break;
                    case "Tra cứu các hộ chăn nuôi nhỏ lẻ":
                        dataTable = database.getHoChanNuoi();
                        break;
                    case "Tra cứu thông tin tổ chức chứng nhận":
                        dataTable = database.getToChucChungNhan();
                        break;
                    case "Tra cứu thông tin cơ sở chế biến sản phẩm chăn nuôi":
                        dataTable = database.getCoSoCheBien();
                        break;
                    case "Tra cứu thông tin vùng chăn nuôi an toàn dịch bệnh":
                        dataTable = database.getVungChanNuoi();
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn mục tra cứu hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                }

                // Gán DataTable vào DataGrid
                GridViewQuery.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục cần tra cứu.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
