using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turismo.Components
{
    class RoutePoint
    {
        public string name { get; set; }
        public GeoPosition Position { get; set; }
        public GeoFence Fence { get; set; }
        public List<string> ImageGallery { get; set; }
        public Objects.Description Description { get; set; }
    }
}
