using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Turismo.Objects;
using Windows.UI.Xaml.Controls;
using Turismo.Data.Objects;

namespace Turismo.Components
{
    public class Site : Location
    {
        public string Name { get; }
        public BasicGeoposition Position { get; }
        public Geofence Fence { get; }
        public MultipleLanguageString Description { get; }
        public Image Image { get; }

        public Site(string name, BasicGeoposition Position, Image SiteImage)
        {
            this.Name = name;            
            this.Position = Position;
            this.Image = SiteImage;
        }
    }
}
