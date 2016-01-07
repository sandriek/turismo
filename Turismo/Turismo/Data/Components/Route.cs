using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Objects;
using Windows.Devices.Geolocation;

namespace Turismo.Components
{
    public class Route
    {
        string Name;
        public List<Location> LocationList;
        public Description Description;
        public Category category;

        public Route()
        {
            LocationList = new List<Location>();
            LocationList.Add(AppGlobal.Instance.SiteList.ElementAt(1));
            LocationList.Add(AppGlobal.Instance.SiteList.ElementAt(2));
            LocationList.Add(AppGlobal.Instance.SiteList.ElementAt(3));
        }
    }
}
