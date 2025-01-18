using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for addVungChanNuoi.xaml
    /// </summary>
    public partial class addVungChanNuoi : Window
    {
        private Database.Database database;
        private List<ChiCucItem> list;
        public ObservableCollection<ChiCucItem> chiCucItems { get; set; }
        public addVungChanNuoi()
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

        private void AddVungChanNuoi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tenvung = name.Text;

                int statusVung = 0;

                if (status.SelectedItem is ComboBoxItem selectedItem)
                {
                    string selectedStatus = selectedItem.Content.ToString();

                    statusVung = (selectedStatus == "An toàn") ? 0 : (selectedStatus == "Nguy hiểm") ? 1 : -1;

                }

                int selectedId = -1;

                foreach (var coSo in chiCucItems)
                {
                    if (coSo.IsSelected)
                    {
                        selectedId = coSo.ID;
                    }
                }

                bool success = database.addVungChanNuoi(tenvung, selectedId, statusVung);
                if (success)
                {
                    MessageBox.Show("Thêm vùng chăn nuôi thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm vùng chăn nuôi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 13: " + ex.Message);
            }
        }
    }
}
