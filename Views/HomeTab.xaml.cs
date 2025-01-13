using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomeTab.xaml
    /// </summary>
    public partial class HomeTab : UserControl
    {
        public HomeTab()
        {
            InitializeComponent();
        }

        private void DiemTruotLo(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addDiemTruotLo win1 = new addDiemTruotLo();
            win1.Show();
        }

        private void DiemLuQuet(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addDiemLuQuet win2 = new addDiemLuQuet();
            win2.Show();
        }

        private void LoaiDichBenh(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addLoaiDichBenh win3 = new addLoaiDichBenh();
            win3.Show();
        }

        private void TrieuChung(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addTrieuChung win4 = new addTrieuChung();
            win4.Show();
        }

        private void ODich(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addODich win5 = new addODich();
            win5.Show();
        }
    }
}
