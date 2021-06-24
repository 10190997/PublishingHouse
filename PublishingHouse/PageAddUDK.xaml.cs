using ClassLibraryPublishingHouse;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAddUDK.xaml
    /// </summary>
    public partial class PageAddUDK : Page
    {
        private UDK NewUDK { get; set; }

        public PageAddUDK(UDK UDK)
        {
            InitializeComponent();
            NewUDK = UDK;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Заполните все значения!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewUDK.UDKName = tbName.Text;
            if (NewUDK.IdUDK == 0)
            {
                DB.db.UDKs.Add(NewUDK);
            }
            DB.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (NewUDK == null)
            {
                NewUDK = new UDK();
                NavigationService.Navigate(new PageAddUDK(NewUDK));
            }
            if (NewUDK.IdUDK != 0)
            {
                tbName.Text = NewUDK.UDKName;
            }
        }
    }
}