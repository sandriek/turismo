﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Turismo.Objects;
using Windows.UI.Xaml.Controls;

namespace Turismo.Components
{
    public class Site : Location
    {
        public string name { get; set; }
        public BasicGeoposition Position { get; set; }
        public Geofence Fence { get; set; }
        public Image SiteImage { get; set; }
        public Description Description { get; set; }
        public List<string> ImageGallery { get; set; }

        public Site(string name, Description Description, BasicGeoposition Position, Image SiteImage)
        {
            this.name = name;
            this.Description = Description;
            this.Position = Position;
            this.SiteImage = SiteImage;
        }

    }
}
