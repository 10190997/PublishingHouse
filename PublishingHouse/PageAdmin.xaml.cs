using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void ButtonAuthors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAuthors());
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUsers());
        }

        private void ButtonPublications_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagePublications());
        }

        private void ButtonMagazines_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMagazines());
        }

        private void ButtonUDKs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUDKs());
        }

        private void ButtonTypes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageTypes());
        }
    }
}