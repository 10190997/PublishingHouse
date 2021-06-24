using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageTypes.xaml
    /// </summary>
    public partial class PageTypes : Page
    {
        public PageTypes()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PublicationType type = TypeGrid.SelectedItem as PublicationType;
            NavigationService.Navigate(new PageAddType(type));
        }

        private void GetTypes()
        {
            List<PublicationType> Types = DB.db.PublicationTypes.ToList();
            TypeGrid.ItemsSource = Types;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                PublicationType type = TypeGrid.SelectedItem as PublicationType;
                DB.db.PublicationTypes.Remove(type);
                DB.db.SaveChanges();
                GetTypes();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddType(new PublicationType()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetTypes();
        }
    }
}