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
    /// Interaction logic for addGiayChungNhan.xaml
    /// </summary>
    public partial class addGiayChungNhan : Window
    {
        public ObservableCollection<ToChucChungNhanItem> ToChucChungNhanItems { get; set; }
        public ObservableCollection<ChiCucMutliItem> ChiCucMutliItems { get; set; }
        private Database.Database database;
        private List<ToChucChungNhanItem> list;
        private List<ChiCucMutliItem> list0;
        public addGiayChungNhan()
        {
            InitializeComponent();

            database = new Database.Database();
            list = new List<ToChucChungNhanItem>();
            list0 = new List<ChiCucMutliItem>();
            DataTable listToChuc = database.getToChucChungNhan();
            DataTable listChiCuc = database.getChiCuc();
            foreach (DataRow row in listToChuc.Rows)
            {
                list.Add(new ToChucChungNhanItem
                {
                    Name = row["tenTC"].ToString(),
                    Represent = row["nguoiDaiDien"].ToString(),
                    Email = row["email"].ToString(),
                    Number = row["soDT"].ToString(),
                    IsSelected = false,
                    ID = (int)row["id_tochucCN"]
                });
            }

            foreach (DataRow row in listChiCuc.Rows)
            {
                list0.Add(new ChiCucMutliItem
                {
                    Name = row["tenChiCuc"].ToString(),
                    Address = row["diaChiCC"].ToString(),
                    Number = row["soDienThoaiCC"].ToString(),
                    IsSelected = false,
                    ID = (int)row["id_chiCuc"]
                });
            }

            ToChucChungNhanItems = new ObservableCollection<ToChucChungNhanItem>(list.Cast<ToChucChungNhanItem>());
            ChiCucMutliItems = new ObservableCollection<ChiCucMutliItem>(list0.Cast<ChiCucMutliItem>());

            comboBox1.ItemsSource = ToChucChungNhanItems;
            comboBox2.ItemsSource = ChiCucMutliItems;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as CheckBox)?.DataContext as ToChucChungNhanItem;

            if (selectedItem != null)
            {
                foreach (var item in ToChucChungNhanItems)
                {
                    if (!item.Equals(selectedItem))
                    {
                        item.IsSelected = false;
                    }
                }

                comboBox1.Items.Refresh();
            }
        }

        private void addGiayChungNhan_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string tenGiayCN = name.Text;
                string ngayCN = date.Text;

                int selectedId = -1;

                foreach (var toChuc in ToChucChungNhanItems)
                {
                    if (toChuc.IsSelected)
                    {
                        selectedId = toChuc.ID;
                    }
                }

                List<int> selectedIds = new List<int>();

                foreach (var chicuc in ChiCucMutliItems)
                {
                    if (chicuc.IsSelected)
                    {
                        selectedIds.Add(chicuc.ID);
                    }
                }
                bool success = database.addGiayChungNhan(tenGiayCN, selectedId, selectedIds, ngayCN);
                if (success)
                {
                    MessageBox.Show("Thêm giấy chứng nhận thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm giấy chứng nhận!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 12: " + ex.Message);
            }
        }
    }
}
