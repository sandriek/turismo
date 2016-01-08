using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Turismo.Components;
using Turismo.Data;
using Turismo.Data.Objects;
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

        MultipleLanguageString omschrijving;
        MultipleLanguageString textenString;
        string texten;

        public RouteScherm()
        {
            this.InitializeComponent();
            DataContext = RouteSchermViewModel.Instance;

            //De tekst bovenaan de pagina
            textenString = new MultipleLanguageString("Beschikbare routes", "Available routes");
            texten = textenString.Text;
            BeschikbareRoutes.Text = texten;

            //Lijst met alle beschikbare routes
            List<Route> routes = new List<Route>();

            //Nieuwe route aanmaken
            omschrijving = new MultipleLanguageString("Een route langs historische gebouwen in Breda.", "A route passing historical buildings found in Breda.");
            Route r = new Route("HistorischeRoute", omschrijving, 1000);
            routes.Add(r);


            //Beschikbare routes koppelen aan de ListView
            RouteLijst.ItemsSource = routes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AppGlobal.Instance._CurrentSession.FollowedRoute = new List<Objects.Location>();
            //AppGlobal.Instance._CurrentSession.CurrentRoute = AppGlobal.Instance.RouteList.Where(p => p.Name == routeBTN.Content.ToString()).FirstOrDefault();
            //AppGlobal.Instance._CurrentSession.FollowedRoute.Add(AppGlobal.Instance._CurrentSession.CurrentRoute.LocationList.FirstOrDefault());

            //Frame.Navigate(typeof(KaartScherm));
        }

        private void KaartKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }


        private void RouteLijst_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Debug.WriteLine(lv.SelectedItem);

            Route r = (Route)lv.SelectedItem;

            string naam = r.Name;

            Data.AppGlobal.Instance._CurrentSession.SwitchRoute(naam);
            if (AppGlobal.Instance._CurrentSession.FollowedRoute == null)
                AppGlobal.Instance._CurrentSession.FollowedRoute = new List<Objects.Location>();
            AppGlobal.Instance._CurrentSession.FollowedRoute.Add(AppGlobal.Instance._CurrentSession.CurrentRoute.LocationList.FirstOrDefault());//Weet niet waar deze regel voor is maar ik zag hem staan bij de click methode (click is overbodig geworden)
            Frame.Navigate(typeof(KaartScherm));
        }
    }
}
