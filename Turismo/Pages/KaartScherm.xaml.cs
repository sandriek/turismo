using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Turismo.Library;
using Turismo.Data;
using Turismo.Objects;
using Turismo.Components;
using Windows.Storage.Streams;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Popups;
using Turismo.ViewModels;
using System;
using Windows.Foundation;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KaartScherm : Page
    {
        const int fenceIndex = 1;
        MapIcon user = new MapIcon();
        private bool running = true;

        DispatcherTimer timer = new DispatcherTimer();
        public KaartScherm()
        {
            this.InitializeComponent();
            DataContext = KaartSchermViewModel.Instance;
            MapControl1.MapElements.Add(user);

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
                List<Location> firstRoute = new List<Location>();
                firstRoute.Add(route.ElementAt(0));
                // Get the route between the points.
                MapRouteFinderResult routePoints = await AppGlobal.Instance._GeoUtil.GetRoutePoint2Point(route);
                MapRouteFinderResult currentPath = await AppGlobal.Instance._GeoUtil.GetRoutePoint2Point(firstRoute);

                if (routePoints.Status == MapRouteFinderStatus.Success)
                {
                    // Use the route to initialize a MapRouteView.
                    MapRouteView viewOfRoute = new MapRouteView(routePoints.Route);
                    viewOfRoute.RouteColor = Colors.LightGray;
                    viewOfRoute.OutlineColor = Colors.LightGray;

                    MapRouteView currentFollowingPath = new MapRouteView(currentPath.Route);
                    currentFollowingPath.RouteColor = Colors.RoyalBlue;
                    currentFollowingPath.OutlineColor = Colors.RoyalBlue;

                    // Add the new MapRouteView to the Routes collection
                    // of the MapControl.
                    MapControl1.Routes.Clear();
                    MapControl1.Routes.Add(viewOfRoute);
                    MapControl1.Routes.Add(currentFollowingPath);
                }

            }
        }

        private void SetPushpins()
        {
            if (AppGlobal.Instance._CurrentSession.CurrentRoute != null)
            {
                foreach (Location l in AppGlobal.Instance._CurrentSession.CurrentRoute.SiteList)
                {
                    // Create a MapIcon.
                    MapIcon icon = new MapIcon();
                    icon.Location = new Geopoint(l.Position);
                    icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/icons/museum35.png"));
                    icon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                    MapControl1.MapElements.Add(icon);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetPushpins();
            timer.Start();
            GeofenceMonitor.Current.GeofenceStateChanged += GeofenceStateChanged;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            timer.Stop();
            GeofenceMonitor.Current.GeofenceStateChanged -= GeofenceStateChanged;
            MapControl1.MapElements.Clear();
        }

        public async void RefreshMapLocation()
        {
            Geoposition pos = await AppGlobal.Instance._GeoUtil.GetGeoLocation();
            if (pos != null)
            {
                MapControl1.Center = pos.Coordinate.Point;

                user.Location = pos.Coordinate.Point;
                user.NormalizedAnchorPoint = new Point(0.5, 0.5);
                user.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/icons/pin65.png"));
            }
        }

        private async void GeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            if (AppGlobal._Instance.SiteList.Count > 0)
                if (sender.Geofences.Any())
                {

                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
       () =>
       {
           BezienswaardigheidPopup();
       });

                    var reports = sender.ReadReports();
                    foreach (var report in reports)
                    {
                        switch (report.NewState)
                        {
                            case GeofenceState.Entered:
                                {
                                    foreach (Site s in AppGlobal.Instance.SiteList)
                                        if (s.id.Equals(report.Geofence.Id))
                                            BezienswaardigheidsPopupViewModel.Instance.CurrentSite = s;


                                    break;
                                }

                            case GeofenceState.Exited:
                                {
                                    Frame.Navigate(typeof(KaartScherm));
                                    break;
                                }
                        }
                    }
                }
        }



        private void TaalKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaalScherm));
        }

        private void RouteKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RouteScherm));
        }

        private void InfoKnop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InfoScherm));
        }

        private void BezienswaardigheidPopup()
        {
            Frame.Navigate(typeof(Bezienswaardigheidpopup));
        }


        private void RemoveGeofences()
        {
            var routeFences = MapControl1.MapElements.Where(p => p.ZIndex == fenceIndex).ToList();
            foreach (var fence in routeFences)
            {
                MapControl1.MapElements.Remove(fence);
            }
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled && running)
            {
                timer.Stop();
                pauseButton.Icon = new FontIcon() { Glyph = "\uE768", FontFamily = new FontFamily("Segoe MDL2 Assets") };
                pauseButton.InvalidateArrange();
            }
            else
            {
                timer.Start();
                pauseButton.Icon = new FontIcon() { Glyph = "\uE769", FontFamily = new FontFamily("Segoe MDL2 Assets") };
                pauseButton.InvalidateArrange();
            }
            running = !running;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            AppGlobal.Instance._CurrentSession = new CurrentSession();
            Frame.Navigate(typeof(MainPage));
        }
    }
}
