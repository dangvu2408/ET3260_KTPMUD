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
using ET3260_Project.Models;
using ET3260_Project.Database;

namespace ET3260_Project.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private User current;
        private Database.Database database;
        public Home(User user)
        {
            InitializeComponent();
            current = user;
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
                        content.Content = new Views.ProfileTab(current);
                        break;
                    case "Logout":
                        this.Hide();
                        break;
                }
            }
        }
    }
}
