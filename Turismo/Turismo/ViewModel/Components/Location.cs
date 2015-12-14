using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.ViewModel.Components
{
    interface Location
    {
        string Name { get; set; }
        GeoPositon Position { get; set; }
        GeoFence Fence { get; set; }
        List<string> ImageGallery { get; set; }
        Description _Description { get; set; }
    }
}
