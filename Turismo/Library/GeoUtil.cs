using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Services.Maps;
using Windows.UI.Core;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Turismo.Pages;
using Windows.UI.Popups;

namespace Turismo.Library
{
    public class GeoUtil
    {
        public GeolocationAccessStatus AccessStatus;
        private Geolocator geoLocator;
        private CancellationTokenSource _cts;


        public GeoUtil()
        {
            geoLocator = new Geolocator();
            GeofenceMonitor.Current.GeofenceStateChanged += GeofenceStateChanged;
            geoLocator.DesiredAccuracy = PositionAccuracy.High;

        }

        private void GeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            if (sender.Geofences.Any())
            {
                var reports = sender.ReadReports();
                foreach (var report in reports)
                {
                    switch (report.NewState)
                    {
                        case GeofenceState.Entered:
                            {
                                new MessageDialog("Boem");
                                break;
                            }

                        case GeofenceState.Exited:
                            {
                                new MessageDialog("Niks meer aan de hand");
                                break;
                            }
                    }
                }
            }
        }

        public async void RequestAccess()
        {
            AccessStatus = await Geolocator.RequestAccessAsync();

        }

        public async Task<Geoposition> GetGeoLocation()
        {
            AccessStatus = GeolocationAccessStatus.Allowed;
            switch (AccessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    try
                    {
                        //Get cancellation token
                        _cts = new CancellationTokenSource();
                        CancellationToken token = _cts.Token;

                        //Carry out the operation
                        return await geoLocator.GetGeopositionAsync().AsTask(token);
                    }
                    catch (TaskCanceledException)
                    {
                        ErrorHandler.HandleError("");
                        return null;
                    }
                    catch (Exception ex)
                    {
                        // If there are no location sensors GetGeopositionAsync() 
                        // will timeout -- that is acceptable. 
                        const int WaitTimeoutHResult = unchecked((int)0x8070102);

                        if (ex.HResult == WaitTimeoutHResult) // WAIT_TIMEOUT 
                        {
                            ErrorHandler.HandleError("010");
                        }
                        else
                        {
                            //Om te testen. Moet nog anders. 
                            new Windows.UI.Popups.MessageDialog(ex.ToString());
                            RequestAccess();
                        }
                        return null;
                    }
                    finally
                    {
                        _cts = null;
                    }

                case GeolocationAccessStatus.Denied:
                    ErrorHandler.HandleError("011");
                    RequestAccess();
                    return null;

                case GeolocationAccessStatus.Unspecified:
                    ErrorHandler.HandleError("011");
                    RequestAccess();
                    return null;
            }

            return null;
        }

        public async Task<MapRouteFinderResult> GetRoutePoint2Point(List<Location> routeList)
        {
            List<Geopoint> geoList = new List<Geopoint>();
            geoList.Add(((await GetGeoLocation()).Coordinate.Point));

            foreach (Location l in routeList)
            {
                geoList.Add(new Geopoint(l.Position));
            }

            // Get the route between the points.
            return await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(geoList);

        }
    }
}
