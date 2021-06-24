using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAuthors.xaml
    /// </summary>
    public partial class PageAuthors : Page
    {
        public PageAuthors()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Author author = AuthorGrid.SelectedItem as Author;
            NavigationService.Navigate(new PageAddAuthor(author));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Author author = AuthorGrid.SelectedItem as Author;
                DB.db.Authors.Remove(author);
                DB.db.SaveChanges();
                GetAuthors();
            }
        }

        private void GetAuthors()
        {
            List<Author> authors = DB.db.Authors.ToList();
            AuthorGrid.ItemsSource = authors;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetAuthors();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddAuthor(new Author()));
        }
    }
}