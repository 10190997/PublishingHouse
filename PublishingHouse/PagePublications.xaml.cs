using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PagePublications.xaml
    /// </summary>
    public partial class PagePublications : Page
    {
        public PagePublications()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Publication publication = PublicationGrid.SelectedItem as Publication;
            NavigationService.Navigate(new PageAddPublication(publication));
        }

        private void GetPublications()
        {
            List<Publication> publications = DB.db.Publications.ToList();
            PublicationGrid.ItemsSource = publications;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Publication publication = PublicationGrid.SelectedItem as Publication;
                DB.db.Publications.Remove(publication);
                DB.db.SaveChanges();
                GetPublications();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddPublication(new Publication()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetPublications();
        }
    }
}