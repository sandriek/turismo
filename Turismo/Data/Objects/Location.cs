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
    public interface Location
    {
        int id { get; }
        string Name { get;}
        BasicGeoposition Position { get; } 
        
    }
}
