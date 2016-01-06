using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using System.Diagnostics;
using Turismo.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KaartScherm : Page
    {
        MapControl MapControl2 = new MapControl();
        public KaartScherm()
        {
            this.InitializeComponent();
            DataContext = KaartSchermViewModel.Instance;
            MapControl2.ZoomInteractionMode = MapInteractionMode.GestureAndControl;
            MapControl2.TiltInteractionMode = MapInteractionMode.GestureAndControl;
            MapControl2.RotateInteractionMode = MapInteractionMode.GestureAndControl;
            MapControl2.MapServiceToken = "LmASekjs1bjQfxvA4OM3~V85W7tCphoOfYRlRHoYQZQ~Av6XwRGn0FrD0PhSTpCprZy12knFFh-UPKHGvEOnEISST7c5iHqwDbl-oN-TnTuY";
            pageGrid.Children.Add(MapControl2);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the map location.
            Geoposition current = await Data.AppGlobal.Instance._GeoUtil.GetGeoLocation();
            MapControl1.Center = current.Coordinate.Point;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }

        private void TaalKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaalScherm));
        }

        private void RouteKnop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
