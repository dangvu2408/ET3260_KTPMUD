using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for addLoaiDichBenh.xaml
    /// </summary>
    public partial class addLoaiDichBenh : Window
    {
        public ObservableCollection<SelectableItem> Items { get; set; }
        public addLoaiDichBenh()
        {
            InitializeComponent();

            Items = new ObservableCollection<SelectableItem>
            {
                new SelectableItem { Name = "Option 1", IsSelected = false },
                new SelectableItem { Name = "Option 2", IsSelected = false },
                new SelectableItem { Name = "Option 3", IsSelected = false },
                new SelectableItem { Name = "Option 4", IsSelected = false },
            };

            // Gán dữ liệu cho ComboBox
            comboBox.ItemsSource = Items;
        }

        private void ShowSelectedItems_Click(object sender, RoutedEventArgs e)
        {
            // Lấy các mục đã chọn
            var selectedItems = Items.Where(item => item.IsSelected)
                                      .Select(item => item.Name);

            // Hiển thị danh sách mục đã chọn
            MessageBox.Show("Mục đã chọn: " + string.Join(", ", selectedItems));
        }
    }

    public class SelectableItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
