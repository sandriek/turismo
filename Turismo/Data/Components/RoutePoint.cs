using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;

namespace Turismo.Components
{
    class RoutePoint
    {
        public string name { get; set; }
        public Geoposition Position { get; set; }
        public Geofence Fence { get; set; }
        public List<string> ImageGallery { get; set; }
        public Description Description { get; set; }
    }
}
