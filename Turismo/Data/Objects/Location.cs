using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data.Objects;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Xaml.Controls;

namespace Turismo.Objects
{
    interface Location
    {
        string Name { get;}
        BasicGeoposition Position { get; }
        Geofence Fence { get; }        
        MultipleLanguageString Description { get; }
        Image Image { get; }
    }
}
