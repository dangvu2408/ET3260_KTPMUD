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
    /// Interaction logic for addHoChanNuoi.xaml
    /// </summary>
    public partial class addHoChanNuoi : Window
    {
        private Database.Database database;
        private List<VungChanNuoiItem> list;
        public ObservableCollection<VungChanNuoiItem> VungChanNuoiItems { get; set; }
        public addHoChanNuoi()
        {
            InitializeComponent();

            database = new Database.Database();

            list = new List<VungChanNuoiItem>();
            DataTable listVung = database.getVungChanNuoi();

            foreach (DataRow row in listVung.Rows)
            {
                list.Add(new VungChanNuoiItem
                {
                    Name = row["diaDiem"].ToString(),
                    Status = (int)row["trangThai"],
                    IsSelected = false,
                    ID = (int)row["id_vungChanNuoi"]
                });
            }

            var distinct = list
                .GroupBy(x => x.Name)
                .Select(group => group.First())
                .ToList();

            VungChanNuoiItems = new ObservableCollection<VungChanNuoiItem>(distinct);


            comboBox.ItemsSource = VungChanNuoiItems;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Lấy ODichItem hiện tại
            var selectedItem = (sender as CheckBox)?.DataContext as VungChanNuoiItem;

            if (selectedItem != null)
            {
                // Bỏ chọn tất cả các item khác
                foreach (var item in VungChanNuoiItems)
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

        private void addHoChanNuoi_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string tenHo = name.Text;
                string nguoiDaiDien = represent.Text;
                string Email = email.Text;
                string SoDT = number.Text;


                int selectedId = -1;

                foreach (var coSo in VungChanNuoiItems)
                {
                    if (coSo.IsSelected)
                    {
                        selectedId = coSo.ID;
                    }
                }

                bool success = database.addHoChanNuoi(tenHo, selectedId, nguoiDaiDien, Email, SoDT);
                if (success)
                {
                    MessageBox.Show("Thêm hộ chăn nuôi thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm hộ chăn nuôi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 14: " + ex.Message);
            }
        }
    }
}
