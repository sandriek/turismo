﻿using Turismo.Components;
using Turismo.Data;
using Turismo.Objects;
using Turismo.Pages;
using Turismo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Turismo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = MainPageViewModel.Instance;

            if(AppGlobal.Instance.RouteList.Count == 0)
            {
                AppGlobal.Instance.InitializeRoute();
            }

        }

        private void KaartKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }

        private void RouteKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RouteScherm));
        }

        private void TaalKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaalScherm));
        }

        private void Popup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Bezienswaardigheidpopup));
        }
    }
}
