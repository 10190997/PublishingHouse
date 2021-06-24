using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageUDKs.xaml
    /// </summary>
    public partial class PageUDKs : Page
    {
        public PageUDKs()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UDK UDK = UDKGrid.SelectedItem as UDK;
            NavigationService.Navigate(new PageAddUDK(UDK));
        }

        private void GetUDKs()
        {
            List<UDK> UDKs = DB.db.UDKs.ToList();
            UDKGrid.ItemsSource = UDKs;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                UDK UDK = UDKGrid.SelectedItem as UDK;
                DB.db.UDKs.Remove(UDK);
                DB.db.SaveChanges();
                GetUDKs();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddUDK(new UDK()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetUDKs();
        }
    }
}