﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace Turismo.Library
{
    public class GeoUtil
    {
        private Geolocator geoLocator;
        private CancellationTokenSource _cts;
        public GeolocationAccessStatus AccessStatus;
        private static Geoposition Cur_Position;

        public GeoUtil()
        {
            geoLocator = new Geolocator()
            {
                ReportInterval = 1500
            };
            geoLocator.DesiredAccuracy = PositionAccuracy.High;
            geoLocator.PositionChanged += GeoLocator_PositionChanged;
        }

        private void GeoLocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Cur_Position = args.Position;
        }

        public async void RequestAccess()
        {
            AccessStatus = await Geolocator.RequestAccessAsync();
        }

        public async Task<Geoposition> GetGeoLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
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
                        const int WaitTimeoutHResult = unchecked((int)0x80070102);

                        if (ex.HResult == WaitTimeoutHResult) // WAIT_TIMEOUT 
                        {
                            ErrorHandler.HandleError("010");
                        }
                        else
                        {
                            //Om te testen. Moet nog anders. 
                            var dialog = new Windows.UI.Popups.MessageDialog(ex.ToString());
                        }
                        return null;
                    }
                    finally
                    {
                        _cts = null;
                    }

                case GeolocationAccessStatus.Denied:
                    ErrorHandler.HandleError("011");
                    return null;

                case GeolocationAccessStatus.Unspecified:
                    ErrorHandler.HandleError("011");
                    return null;
            }

            return null;
        }

        public async Task<MapRouteFinderResult> GetRoutePoint2Point(List<Location> routeList)
        {
            List<Geopoint> geoList = new List<Geopoint>();
            geoList.Add(Cur_Position.Coordinate.Point);

            foreach (Location l in routeList)
            {
                geoList.Add(new Geopoint(l.Position));
            }

            // Get the route between the points.
            MapRouteFinderResult result = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(geoList);

            return result;
        }
    }
}
