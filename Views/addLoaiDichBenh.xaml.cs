using System;
using System.Collections;
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
    /// Interaction logic for addLoaiDichBenh.xaml
    /// </summary>
    public partial class addLoaiDichBenh : Window
    {
        public ObservableCollection<TrieuChungItem> TrieuChungItems { get; set; }
        private Database.Database database;
        private List<TrieuChungItem> list;
        public addLoaiDichBenh()
        {
            InitializeComponent();
            database = new Database.Database();
            list = new List<TrieuChungItem>();
            DataTable listTrieuChung = database.getTrieuChung();
            foreach (DataRow row in listTrieuChung.Rows)
            {
                list.Add(new TrieuChungItem
                {
                    Name = row["tenTrieuChung"].ToString(), 
                    Description = row["moTa"].ToString(), 
                    IsSelected = false 
                });
            }

            TrieuChungItems = new ObservableCollection<TrieuChungItem>(list.Cast<TrieuChungItem>());

            comboBox.ItemsSource = TrieuChungItems;

        }

        private void AddLoaiDichBenh_Click(object sender, RoutedEventArgs e)
        {
            
        }

        

    }

    public class SelectableItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
