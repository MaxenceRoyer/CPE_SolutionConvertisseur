using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientConvertisseurV2.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage()
        {
            this.InitializeComponent();
        }

        public RootPage(Frame frame)
        {
            this.InitializeComponent();
            this.MySplitView.Content = frame;
            (MySplitView.Content as Frame).Navigate(typeof(MainPageDeviseVersEuros));
        }

        private void HamburgerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void buttonDollars_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(MainPageDeviseVersEuros));
        }

        private void buttonEuros_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(MainPage));
        }

    }
}
