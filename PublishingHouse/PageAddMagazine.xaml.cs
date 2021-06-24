using ClassLibraryPublishingHouse;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAddMagazine.xaml
    /// </summary>
    public partial class PageAddMagazine : Page
    {
        private Magazine NewMagazine { get; set; }

        public PageAddMagazine(Magazine magazine)
        {
            InitializeComponent();
            NewMagazine = magazine;
        }

        private string filePath;

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNumber.Text) ||
                string.IsNullOrWhiteSpace(tbNumber.Text))
            {
                MessageBox.Show("Заполните номер журнала!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(tbNumber.Text, out int magNo))
            {
                MessageBox.Show("Исправьте числовые данные!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                photo.Source = new BitmapImage(new Uri(filePath));
                txtPhoto.Text = Path.GetFileName(photo.Source.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Укажите верный путь к файлу", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewMagazine.MagazineNumber = magNo;
            NewMagazine.PublishingDate = dpPubDate.SelectedDate != null ? (DateTime?)(DateTime)dpPubDate.SelectedDate : null;
            NewMagazine.CoverImage = filePath;
            if (NewMagazine.IdMagazine == 0)
            {
                DB.db.Magazines.Add(NewMagazine);
            }
            DB.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void buttonPhoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "1",
                DefaultExt = ".png",
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    photo.Source = new BitmapImage(new Uri(dlg.FileName));
                    txtPhoto.Text = Path.GetFileName(dlg.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Укажите верный путь к файлу", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                filePath = Path.GetFullPath(dlg.FileName);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dpPubDate.DisplayDate = DateTime.Today;
            if (NewMagazine == null)
            {
                NewMagazine = new Magazine();
                NavigationService.Navigate(new PageAddMagazine(NewMagazine));
            }
            if (NewMagazine.IdMagazine > 0)
            {
                tbNumber.Text = NewMagazine.MagazineNumber.ToString();
                dpPubDate.SelectedDate = NewMagazine.PublishingDate;
                txtPhoto.Text = Path.GetFileName(NewMagazine.CoverImage);
                Uri uri = new Uri(NewMagazine.CoverImage, UriKind.Absolute);
                ImageSource imgSource = new BitmapImage(uri);
                photo.Source = imgSource;
            }
        }
    }
}