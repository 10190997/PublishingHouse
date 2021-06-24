using ClassLibraryPublishingHouse;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAddAuthor.xaml
    /// </summary>
    public partial class PageAddAuthor : Page
    {
        private Author NewAuthor { get; set; }

        public PageAddAuthor(Author author)
        {
            InitializeComponent();
            NewAuthor = author;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (NewAuthor == null)
            {
                NewAuthor = new Author();
                NavigationService.Navigate(new PageAddAuthor(NewAuthor));
            }
            if (NewAuthor.IdAuthor != 0)
            {
                tbName.Text = NewAuthor.NameA;
                tbLastName.Text = NewAuthor.LastNameA;
                tbPatronymic.Text = NewAuthor.PatronymA;
                tbPhone.Text = NewAuthor.Phone;
            }
        }

        private bool IsPhoneNumber(string input)
        {
            string pattern = "0(000)000-00-00";
            if (input.Length != pattern.Length)
            {
                return false;
            }

            for (int i = 0; i < input.Length; ++i)
            {
                bool isPhone = char.IsDigit(pattern, i) ? char.IsDigit(input, i) : input[i] == pattern[i];
                if (!isPhone)
                {
                    return false;
                }
            }
            return true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrEmpty(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrEmpty(tbPatronymic.Text) ||
                string.IsNullOrWhiteSpace(tbPatronymic.Text) ||
                string.IsNullOrEmpty(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Заполните все значения!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!IsPhoneNumber(tbPhone.Text))
            {
                MessageBox.Show("Формат номера телефона: 8(921)123-45-67", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewAuthor.NameA = tbName.Text;
            NewAuthor.LastNameA = tbLastName.Text;
            NewAuthor.PatronymA = tbPatronymic.Text;
            NewAuthor.Phone = tbPhone.Text;
            if (NewAuthor.IdAuthor == 0)
            {
                DB.db.Authors.Add(NewAuthor);
            }
            DB.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}