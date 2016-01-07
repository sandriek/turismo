using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;

namespace Turismo.Objects
{
    public interface Location
    {
        int id { get; set; }
        string name { get; set; }
        BasicGeoposition Position { get; set; }
        Geofence Fence { get; set; }
        List<string> ImageGallery { get; set; }
        Description Description { get; set; }
    }
}
