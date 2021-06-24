using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageMagazine.xaml
    /// </summary>
    public partial class PageMagazines : Page
    {
        public PageMagazines()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Magazine magazine = MagazineGrid.SelectedItem as Magazine;
            NavigationService.Navigate(new PageAddMagazine(magazine));
        }

        private void GetMagazines()
        {
            List<Magazine> magazines = DB.db.Magazines.ToList();
            MagazineGrid.ItemsSource = magazines;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Magazine magazine = MagazineGrid.SelectedItem as Magazine;
                DB.db.Magazines.Remove(magazine);
                DB.db.SaveChanges();
                GetMagazines();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddMagazine(new Magazine()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetMagazines();
        }
    }
}