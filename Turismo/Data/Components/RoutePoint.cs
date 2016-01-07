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
    class RoutePoint : Location
    {
        public string name { get; set; }
        public BasicGeoposition Position { get; set; }
        public Geofence Fence { get; set; }
        public List<string> ImageGallery { get; set; }
        public MutipleLanguageString Description { get; set; }

        Boolean IsBezienswaardigheid;


        public RoutePoint(string name, MutipleLanguageString Description, BasicGeoposition Position, Boolean IsBezienswaardigheid)
        {
            this.name = name;
            this.Description = Description;
            this.Position = Position;
            this.IsBezienswaardigheid = IsBezienswaardigheid;

        }
    }
}
