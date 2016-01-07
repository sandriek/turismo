using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Turismo.Data;
using Turismo.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteScherm : Page
    {
        public RouteScherm()
        {
            this.InitializeComponent();
            DataContext = RouteSchermViewModel.Instance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppGlobal.Instance._CurrentSession.CurrentRoute = AppGlobal.Instance.RouteList.Where(p => p.Name == routeBTN.Content.ToString()).FirstOrDefault();
            AppGlobal.Instance._CurrentSession.FollowedRoute.Add(AppGlobal.Instance._CurrentSession.CurrentRoute.LocationList.FirstOrDefault());

            Frame.Navigate(typeof(KaartScherm));
        }

        private void KaartKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }
    }
}
