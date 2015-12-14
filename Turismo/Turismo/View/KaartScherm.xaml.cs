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
using Turismo.View;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KaartScherm : Page
    {
        public KaartScherm()
        {
            this.InitializeComponent();
            MapControl MapControl2 = new MapControl();
            MapControl2.ZoomInteractionMode = MapInteractionMode.GestureAndControl;
            MapControl2.TiltInteractionMode = MapInteractionMode.GestureAndControl;
            MapControl2.MapServiceToken = "EnterYourAuthenticationKeyHere";
            pageGrid.Children.Add(MapControl2);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }
        
        private void TaalKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaalScherm));
        }
    }
}
