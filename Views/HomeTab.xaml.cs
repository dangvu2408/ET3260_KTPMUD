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

        private void TiemPhong(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addLichTiemPhong win6 = new addLichTiemPhong();
            win6.Show();
        }

        private void ChiCuc(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addChiCucThuY win7 = new addChiCucThuY();
            win7.Show();
        }

        private void DaiLyThuoc(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addDaiLyThuoc win8 = new addDaiLyThuoc();
            win8.Show();
        }

        private void KhuTamGiu(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addKhuTamGiu win9 = new addKhuTamGiu();
            win9.Show();
        }

        private void CoSoChanNuoi(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addCoSoChanNuoi win10 = new addCoSoChanNuoi();
            win10.Show();
        }

        private void CoSoCheBien(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addCoSoCheBien win11 = new addCoSoCheBien();
            win11.Show();
        }
    }
}
