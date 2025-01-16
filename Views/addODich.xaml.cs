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
    /// Interaction logic for addODich.xaml
    /// </summary>
    public partial class addODich : Window
    {
        public ObservableCollection<LoaiDichItem> LoaiDichItems { get; set; }
        private Database.Database database;
        private List<LoaiDichItem> list;
        public addODich()
        {
            InitializeComponent();

            database = new Database.Database();
            list = new List<LoaiDichItem>();
            DataTable listTrieuChung = database.getLoaiDich();
            foreach (DataRow row in listTrieuChung.Rows)
            {
                list.Add(new LoaiDichItem
                {
                    Name = row["tenLoaiDich"].ToString(),
                    Description = row["moTa"].ToString(),
                    IsSelected = false,
                    ID = (int)row["id_loaiDich"]
                });
            }

            var distinctLoaiDich = list
                .GroupBy(x => x.Name) 
                .Select(group => group.First()) 
                .ToList();

            LoaiDichItems = new ObservableCollection<LoaiDichItem>(distinctLoaiDich);


            comboBox.ItemsSource = LoaiDichItems;
        }

        private void AddODich_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> selectedIds = new List<int>();

                foreach (var loaiDich in LoaiDichItems)
                {
                    if (loaiDich.IsSelected)
                    {
                        selectedIds.Add(loaiDich.ID);
                    }
                }

                string nameOD = name.Text;
                string dayOD = day.Text;
                int statusOD = 0;

                if (status.SelectedItem is ComboBoxItem selectedItem)
                {
                    string selectedStatus = selectedItem.Content.ToString();

                    statusOD = (selectedStatus == "An toàn") ? 0 : (selectedStatus == "Nguy hiểm") ? 1 : -1;

                }

                bool success = database.addODich(nameOD, selectedIds, dayOD, statusOD);
                if (success)
                {
                    MessageBox.Show("Thêm ổ dịch bệnh thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm ổ dịch bệnh!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 05: " + ex.Message);
            }
        }
    }
}
