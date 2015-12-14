using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turismo.Objects
{
    interface Location
    {
        string name { get; set; }
        GeoPosition Position { get; set; }
        GeoFence Fence { get; set; }
        List<string> ImageGallery { get; set; }
        Description Description { get; set; }
    }
}
