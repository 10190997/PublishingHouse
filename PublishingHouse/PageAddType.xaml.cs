using ClassLibraryPublishingHouse;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for PageAddType.xaml
    /// </summary>
    public partial class PageAddType : Page
    {
        private PublicationType NewType { get; set; }

        public PageAddType(PublicationType type)
        {
            InitializeComponent();
            NewType = type;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Заполните все значения!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewType.PublicationType1 = tbName.Text;
            if (NewType.IdType == 0)
            {
                DB.db.PublicationTypes.Add(NewType);
            }
            DB.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (NewType == null)
            {
                NewType = new PublicationType();
                NavigationService.Navigate(new PageAddType(NewType));
            }
            if (NewType.IdType != 0)
            {
                tbName.Text = NewType.PublicationType1;
            }
        }
    }
}