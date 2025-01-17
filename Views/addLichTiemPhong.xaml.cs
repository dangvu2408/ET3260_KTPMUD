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
    /// Interaction logic for addLichTiemPhong.xaml
    /// </summary>
    public partial class addLichTiemPhong : Window
    {
        public ObservableCollection<ODichItem> ODichItems { get; set; }
        private Database.Database database;
        private List<ODichItem> list;
        public addLichTiemPhong()
        {
            InitializeComponent();

            database = new Database.Database();
            list = new List<ODichItem>();
            DataTable listODich = database.getODich();

            foreach (DataRow row in listODich.Rows)
            {
                list.Add(new ODichItem
                {
                    Name = row["tenODich"].ToString(),
                    Date = row["ngayPhatHien"].ToString(),
                    Status = (int)row["trangThai"],
                    IsSelected = false,
                    ID = (int)row["id_ODich"]
                });
            }

            var distinctODich = list
                .GroupBy(x => x.Name)
                .Select(group => group.First())
                .ToList();

            ODichItems = new ObservableCollection<ODichItem>(distinctODich);


            comboBox.ItemsSource = ODichItems;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Lấy ODichItem hiện tại
            var selectedItem = (sender as CheckBox)?.DataContext as ODichItem;

            if (selectedItem != null)
            {
                // Bỏ chọn tất cả các item khác
                foreach (var item in ODichItems)
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

        private void addLichTiemPhong_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameVac = name.Text;
                string dateVac = date.Text;
                int numberVac = int.Parse(number.Text);

                int selectedId = -1;

                foreach (var oDich in ODichItems)
                {
                    if (oDich.IsSelected)
                    {
                        selectedId = oDich.ID;
                    }
                }

                bool success = database.addLichTiemPhong(nameVac, selectedId, dateVac, numberVac);
                if (success)
                {
                    MessageBox.Show("Thêm lịch tiêm phòng thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm lịch tiêm phòng!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi 06: " + ex.Message);
            }
        }
    }
}
