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
using System.Windows.Shapes;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)((ListBox)sender).SelectedItem;
            if (selectedItem != null)
            {
                string selectedTag = selectedItem.Tag.ToString();
                switch (selectedTag)
                {
                    case "Home":
                        content.Content = new Views.HomeTab(); 
                        break;
                    case "Query":
                        content.Content = new Views.QueryTab(); 
                        break;
                    case "Profile":
                        content.Content = new Views.ProfileTab();
                        break;
                    case "Logout":
                        content.Content = new Views.ProfileTab();
                        break;
                }
            }
        }
    }
}
