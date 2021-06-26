using ClassLibraryPublishingHouse;
using System.Text;
using System.Windows;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            if (tbEmail.Text == null || PassBox.Password == null || tbLogin.Text == null)
            {
                MessageBox.Show("Поля почта, логин и пароль - обязательные!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (encoding.GetBytes(tbLogin.Text).Length < 8)
            {
                MessageBox.Show("Попробуйте другой логин", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PassBox.Password != RepeatPassBox.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!UserDataCheck.CheckEmail(tbEmail.Text))
            {
                MessageBox.Show("Неверный email!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!UserDataCheck.IsStrong(PassBox.Password))
            {
                MessageBox.Show("Пароль должен отвечать следующим требованиям:\nМинимум 6 символов\n" +
                        "Минимум 1 прописная буква\n" +
                        "Минимум 1 цифра\n" +
                        "По крайней мере один из следующих символов: ! @ # $ % ^");
            }
            else if (PassBox.Password == RepeatPassBox.Password)
            {
                if (Authentificator.Register(tbEmail.Text, PassBox.Password, tbLogin.Text, tbLastName.Text, tbName.Text))
                {
                    MessageBox.Show("Регистрация прошла успешно", "", MessageBoxButton.OK);
                    Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с такими данными уже зарегистрирован!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}