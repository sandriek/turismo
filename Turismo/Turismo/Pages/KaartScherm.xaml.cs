using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Turismo.Library;
using Turismo.Data;
using System.Threading.Tasks;
using Turismo.Objects;
using Turismo.Components;
using Windows.Storage.Streams;

namespace Turismo.Pages
{
    public sealed partial class KaartScherm : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public KaartScherm()
        {
            this.InitializeComponent();

            //Settings for timer
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            

            RefreshMapLocation();

        }

        private void timer_Tick(object sender, object e)
        {
            RefreshMapLocation();
            UpdateRouteOnMap();
        }

        private void SetPushpins()
        {
            foreach (Location l in AppGlobal.Instance._CurrentSession.CurrentRoute.LocationList)
            {
                // Create a MapIcon.
                MapIcon icon = new MapIcon();
                icon.Location = new Geopoint(l.Position);
                icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Logo150x150.png"));
                icon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                //icon.Title = "Space Needle";
                MapControl1.MapElements.Add(icon);
            }
        }

        private async void UpdateRouteOnMap()
        {
            
            List<Location> route = AppGlobal.Instance._CurrentSession.GetToFollowRoute();

            if (!route.Any())
            {
                // Route is finished
                AppGlobal.Instance._CurrentSession.CurrentRoute = null;
                AppGlobal.Instance._CurrentSession.FollowedRoute = null;
            }
            else
            {  
                // Get the route between the points.
                MapRouteFinderResult routePoints = await AppGlobal.Instance._GeoUtil.GetRoutePoint2Point(route);

                if (routePoints.Status == MapRouteFinderStatus.Success)
                {
                    // Use the route to initialize a MapRouteView.
                    MapRouteView viewOfRoute = new MapRouteView(routePoints.Route);
                    viewOfRoute.RouteColor = Colors.RoyalBlue;
                    viewOfRoute.OutlineColor = Colors.MidnightBlue;

                    // Add the new MapRouteView to the Routes collection
                    // of the MapControl.
                    MapControl1.Routes.Clear();
                    MapControl1.Routes.Add(viewOfRoute);
                }

            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            

            AppGlobal.Instance._CurrentSession.CurrentRoute = new Route();
            AppGlobal.Instance._CurrentSession.FollowedRoute = new List<Location>();
            AppGlobal.Instance._CurrentSession.FollowedRoute.Add(AppGlobal.Instance.SiteList.ElementAt(2));
            SetPushpins();
            timer.Start();
            
        }

        public async void RefreshMapLocation()
        {
            Geoposition pos = await AppGlobal.Instance._GeoUtil.GetGeoLocation();
            MapControl1.Center = pos.Coordinate.Point;
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
