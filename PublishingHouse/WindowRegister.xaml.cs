using ClassLibraryPublishingHouse;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            else if (!CheckEmail(tbEmail.Text))
            {
                MessageBox.Show("Неверный email!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!IsStrong(PassBox.Password))
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

        private static bool CheckEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static bool HasUpper(string password)
        {
            foreach (char c in password)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasDigit(string password)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasSpecialSymbol(string password)
        {
            foreach (char c in password)
            {
                if (c.Equals('!') ||
                    c.Equals('@') ||
                    c.Equals('#') ||
                    c.Equals('$') ||
                    c.Equals('%') ||
                    c.Equals('^'))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsLong(string password)
        {
            int count = 0;
            foreach (char c in password)
            {
                count++;
            }

            return count >= 6;
        }

        public static bool IsStrong(string password)
        {
            return IsLong(password) &&
                HasUpper(password) &&
                HasDigit(password) &&
                HasSpecialSymbol(password);
        }
    }
}