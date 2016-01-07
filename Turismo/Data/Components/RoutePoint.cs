using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data.Objects;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Xaml.Controls;

namespace Turismo.Components
{
    class RoutePoint : Location
    {
        public string Name { get; set; }
        public BasicGeoposition Position { get; set; }
        public Geofence Fence { get; set; }
        public Image Image { get; set; }
        public MultipleLanguageString Description { get; set; }

        Boolean IsBezienswaardigheid;


        public RoutePoint(string name, MultipleLanguageString Description, BasicGeoposition Position, Boolean IsBezienswaardigheid)
        {
            this.Name = name;
            this.Description = Description;
            this.Position = Position;
            this.IsBezienswaardigheid = IsBezienswaardigheid;

        }
    }
}
