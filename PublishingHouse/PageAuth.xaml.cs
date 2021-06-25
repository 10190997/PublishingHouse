using ClassLibraryPublishingHouse;
using System.Windows;
using System.Windows.Controls;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public static User user = new User();

        public PageAuth()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginBox.Text) ||
                string.IsNullOrEmpty(loginBox.Text) ||
                string.IsNullOrEmpty(PassBox.Password) ||
                string.IsNullOrWhiteSpace(PassBox.Password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string result = Authentificator.Authorize(loginBox.Text, PassBox.Password, user);

            if (result == "OK")
            {
                NavigationService.Navigate(new PageAdmin());
            }
            else if (result == "User not found")
            {
                MessageBox.Show("Пользователь не найден",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == "Incorrect password")
            {
                MessageBox.Show("Неверный пароль.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister windowRegister = new WindowRegister();
            windowRegister.ShowDialog();
        }
    }
}