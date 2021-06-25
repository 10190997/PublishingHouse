using ClassLibraryPublishingHouse;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAddPublication.xaml
    /// </summary>
    public partial class PageAddPublication : Page
    {
        private Publication NewPublication { get; set; }

        public PageAddPublication(Publication publication)
        {
            InitializeComponent();
            NewPublication = publication;
            cbMagazine.SelectedIndex = -1;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Заполните обязательные значения!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(tbRegNo.Text, out int regNo) && !string.IsNullOrEmpty(tbRegNo.Text))
            {
                MessageBox.Show("Исправьте числовые данные!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lbAuthors.SelectedItems.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного автора!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewPublication.PublicationName = tbName.Text;
            NewPublication.Authors.Clear();
            foreach (var item in lbAuthors.SelectedItems)
            {
                NewPublication.Authors.Add(item as Author);
            }
            NewPublication.Magazine = cbMagazine.SelectedIndex == -1 ? null : cbMagazine.SelectedItem as Magazine;
            NewPublication.PublicationType = cbType.SelectedItem as PublicationType;
            NewPublication.RegDate = dpRegDate.SelectedDate != null ? (DateTime?)(DateTime)dpRegDate.SelectedDate : null;
            NewPublication.RegistrationNum = string.IsNullOrEmpty(tbRegNo.Text) ? null : (int?)regNo;
            NewPublication.UDK = cbUDK.SelectedItem as UDK;
            if (NewPublication.IdPublication == 0)
            {
                DB.db.Publications.Add(NewPublication);
            }
            DB.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dpRegDate.DisplayDate = DateTime.Today;
            
            lbAuthors.ItemsSource = DB.db.Authors.ToList();
            cbMagazine.ItemsSource = DB.db.Magazines.ToList();
            cbType.ItemsSource = DB.db.PublicationTypes.ToList();
            cbUDK.ItemsSource = DB.db.UDKs.ToList();
            if (NewPublication == null)
            {
                NewPublication = new Publication();
                NavigationService.Navigate(new PageAddPublication(NewPublication));
            }
            if (NewPublication.IdPublication > 0)
            {
                tbName.Text = NewPublication.PublicationName;
                tbRegNo.Text = NewPublication.RegistrationNum.ToString();
                //lbAuthors.Items.Clear();
                foreach (var item in NewPublication.Authors)
                {
                    lbAuthors.SelectedItems.Add(item);
                }
                cbMagazine.SelectedItem = NewPublication.Magazine;
                cbType.SelectedItem = NewPublication.PublicationType;
                cbUDK.SelectedItem = NewPublication.UDK;
                dpRegDate.SelectedDate = NewPublication.RegDate;
            }
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cbMagazine.SelectedIndex = -1;
        }

        private void authorChange_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageAuthors());
        }

        private void UDKChange_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageUDKs());
        }

        private void TypeChange_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageTypes());
        }

        private void MagazineChange_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageMagazines());
        }
    }
}