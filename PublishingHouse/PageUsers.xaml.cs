using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        public PageUsers()
        {
            InitializeComponent();
        }

        private void GetUsers()
        {
            List<User> users = DB.db.Users.ToList();
            UserGrid.ItemsSource = users;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                User user = UserGrid.SelectedItem as User;
                DB.db.Users.Remove(user);
                DB.db.SaveChanges();
                GetUsers();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetUsers();
        }
    }
}