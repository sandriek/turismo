using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Turismo.Components;
using Turismo.Data;
using Turismo.Data.Objects;
using Turismo.Objects;
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
        MultipleLanguageString headerString;


        public RouteScherm()
        {
            InitializeComponent();
            DataContext = RouteSchermViewModel.Instance;

            //De tekst bovenaan de pagina
            headerString = new MultipleLanguageString("Beschikbare routes", "Available routes");
            BeschikbareRoutes.Text = headerString.Text;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Beschikbare routes koppelen aan de ListView
            RouteList.ItemsSource = AppGlobal.Instance.RouteList;
        }


        private void TaalKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaalScherm));
        }

        public T FindDescendantByName<T>(DependencyObject obj, string objname) where T : DependencyObject
        {
            string controlneve = "";

            Type tyype = obj.GetType();
            if (tyype.GetProperty("Name") != null)
            {
                PropertyInfo prop = tyype.GetProperty("Name");
                controlneve = prop.GetValue(obj, null).ToString();
            }
            else
            {
                return null;
            }

            if (obj is T && objname.ToString().ToLower() == controlneve.ToString().ToLower())
            {
                return obj as T;
            }

            // Check for children
            int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
            if (childrenCount < 1)
                return null;

            // First check all the children
            for (int i = 0; i <= childrenCount - 1; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is T && objname.ToString().ToLower() == controlneve.ToString().ToLower())
                {
                    return child as T;
                }
            }

            // Then check the childrens children
            for (int i = 0; i <= childrenCount - 1; i++)
            {
                string checkobjname = objname;
                DependencyObject child = FindDescendantByName<T>(VisualTreeHelper.GetChild(obj, i), objname);
                if (child != null && child is T && objname.ToString().ToLower() == checkobjname.ToString().ToLower())
                {
                    return child as T;
                }
            }

            return null;
        }

        private void KaartKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }


        private void RouteList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;

            Route r = (Route)lv.SelectedItem;

            string naam = r.Name;

            AppGlobal.Instance._CurrentSession.SwitchRoute(naam);
            if (!(AppGlobal.Instance._CurrentSession.FollowedRoute == null) && AppGlobal.Instance._CurrentSession.FollowedRoute.Any())
            {
                AppGlobal.Instance._CurrentSession.FollowedRoute.Add(AppGlobal.Instance._CurrentSession.CurrentRoute.LocationList.FirstOrDefault());//Weet niet waar deze regel voor is maar ik zag hem staan bij de click methode (click is overbodig geworden)
            }
            Frame.Navigate(typeof(KaartScherm));
        }
    }
}
