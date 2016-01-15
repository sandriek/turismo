using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Turismo.Library
{
    public class GeoUtil
    {
        private Geolocator geoLocator;
        private CancellationTokenSource _cts;


        public GeoUtil()
        {
            geoLocator = new Geolocator();
            geoLocator.DesiredAccuracy = PositionAccuracy.High;
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

        public async Task CheckFenceColission()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    break;

                case GeolocationAccessStatus.Denied:
                    ErrorHandler.HandleError("011");
                    break;

                case GeolocationAccessStatus.Unspecified:
                    ErrorHandler.HandleError("011");
                    break;
            }
        }
    }
}
