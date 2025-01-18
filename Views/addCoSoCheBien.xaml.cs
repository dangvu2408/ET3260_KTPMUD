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
    /// Interaction logic for addCoSoCheBien.xaml
    /// </summary>
    public partial class addCoSoCheBien : Window
    {
        public ObservableCollection<CoSoChanNuoiItem> CoSoChanNuoiItems { get; set; }
        private Database.Database database;
        private List<CoSoChanNuoiItem> list;
        public addCoSoCheBien()
        {
            InitializeComponent();

            database = new Database.Database();
            list = new List<CoSoChanNuoiItem>();
            DataTable listCSCN = database.getCoSoChanNuoi();
            foreach (DataRow row in listCSCN.Rows)
            {
                list.Add(new CoSoChanNuoiItem
                {
                    Name = row["tenCoSo"].ToString(),
                    Address = row["diaChiCoSo"].ToString(),
                    Number = row["soDienThoaiCS"].ToString(),
                    IsSelected = false,
                    ID = (int)row["id_csChanNuoi"]
                });
            }

            CoSoChanNuoiItems = new ObservableCollection<CoSoChanNuoiItem>(list.Cast<CoSoChanNuoiItem>());

            comboBox.ItemsSource = CoSoChanNuoiItems;
        }

        private void AddCoSoCheBien_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> selectedIds = new List<int>();

                foreach (var coso in CoSoChanNuoiItems)
                {
                    if (coso.IsSelected)
                    {
                        selectedIds.Add(coso.ID);
                    }
                }

                string nameCSCB = name.Text;
                string addressCSCB = address.Text;
                string numberCSCB = number.Text;

                bool success = database.addCoSoCheBien(nameCSCB, selectedIds, addressCSCB, numberCSCB);
                if (success)
                {
                    MessageBox.Show("Thêm cơ sở chế biến thành công!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi thêm cơ sở chế biến!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi 10: " + ex.Message);
            }

        }
    }
}
