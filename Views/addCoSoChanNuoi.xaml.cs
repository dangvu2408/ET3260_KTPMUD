using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for addCoSoChanNuoi.xaml
    /// </summary>
    public partial class addCoSoChanNuoi : Window
    {
        private Database.Database database;
        private List<ChiCucItem> list;
        public ObservableCollection<ChiCucItem> chiCucItems { get; set; }
        public addCoSoChanNuoi()
        {
            InitializeComponent();

            database = new Database.Database();

            list = new List<ChiCucItem>();
            DataTable listChiCuc = database.getChiCuc();

            foreach (DataRow row in listChiCuc.Rows)
            {
                list.Add(new ChiCucItem
                {
                    Name = row["tenChiCuc"].ToString(),
                    Address = row["diaChiCC"].ToString(),
                    Number = row["soDienThoaiCC"].ToString(),
                    IsSelected = false,
                    ID = (int)row["id_chiCuc"]
                });
            }

            var distinct = list
                .GroupBy(x => x.Name)
                .Select(group => group.First())
                .ToList();

            chiCucItems = new ObservableCollection<ChiCucItem>(distinct);


            comboBox.ItemsSource = chiCucItems;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Lấy ODichItem hiện tại
            var selectedItem = (sender as CheckBox)?.DataContext as ChiCucItem;

            if (selectedItem != null)
            {
                // Bỏ chọn tất cả các item khác
                foreach (var item in chiCucItems)
                {
                    if (!item.Equals(selectedItem))
                    {
                        item.IsSelected = false;
                    }
                }

                // Cập nhật giao diện người dùng
                comboBox.Items.Refresh();
            }
        }

        private void addCoSoChanNuoiBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string tenCoSo = name.Text;
                string diaChiCSCN = address.Text;
                string soDienThoaiCSCN = number.Text;

                int selectedId = -1;

                foreach (var oDich in chiCucItems)
                {
                    if (oDich.IsSelected)
                    {
                        selectedId = oDich.ID;
                    }
                }

                bool success = database.addCoSoChanNuoi(tenCoSo, selectedId, diaChiCSCN, soDienThoaiCSCN);
                if (success)
                {
                    MessageBox.Show("Thêm cơ sở chăn nuôi thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm cơ sở chăn nuôi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 09: " + ex.Message);
            }
        }
    }
}
