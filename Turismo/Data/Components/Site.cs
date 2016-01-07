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
        public string Name { get; set; }
        public BasicGeoposition Position { get; set; }
        public Geofence Fence { get; set; }
        public Image Image { get; set; }
        public MultipleLanguageString Description { get; set; }
        public List<string> ImageGallery { get; set; }

        public Site(string name, MultipleLanguageString Description, BasicGeoposition Position, Image SiteImage)
        {
            this.Name = name;
            this.Description = Description;
            this.Position = Position;
            this.Image = SiteImage;
        }

    }
}
