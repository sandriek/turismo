using Turismo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaalScherm : Page
    {
        public TaalScherm()
        {
            this.InitializeComponent();
            DataContext = TaalSchermViewModel.Instance;
        }

        private void TaalGeselecteerd(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }

        private void NLFlag_Click(object sender, RoutedEventArgs e)
        {
            Data.AppGlobal.Instance._CurrentSession.SwitchLanguage("NL");
            Frame.Navigate(typeof(KaartScherm));
        }

        private void ENFlag_Click(object sender, RoutedEventArgs e)
        {
            Data.AppGlobal.Instance._CurrentSession.SwitchLanguage("EN");
            Frame.Navigate(typeof(KaartScherm));
        }

        private void KaartKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }
    }
}
