using System;
using System.Collections.Generic;
using Turismo.Components;
using Turismo.Library;
using Windows.Devices.Geolocation;

namespace Turismo.Data
{
    public class AppGlobal
    {
        private static AppGlobal _Instance;
        public GeoUtil _GeoUtil;
        public List<Site> SiteList;
        protected List<Route> RouteList;
        public CurrentSession _CurrentSession;
        protected List<Help> HelpDescriptionList;

        public static AppGlobal Instance { get { return _Instance ?? (_Instance = new AppGlobal()); } }

        public AppGlobal()
        {
            _GeoUtil = new GeoUtil();
            SiteList = new List<Site>();
            RouteList = new List<Route>();
            _CurrentSession = new CurrentSession();
            HelpDescriptionList = new List<Help>();

            SiteList.Add(new Site(1, new BasicGeoposition() { Latitude = 51.5888, Longitude = 004.7749 }));
            SiteList.Add(new Site(2, new BasicGeoposition() { Latitude = 51.5882, Longitude = 004.7752 }));
            SiteList.Add(new Site(3, new BasicGeoposition() { Latitude = 51.5881, Longitude = 004.7729 }));
            SiteList.Add(new Site(4, new BasicGeoposition() { Latitude = 51.5891, Longitude = 004.7733 }));
            SiteList.Add(new Site(5, new BasicGeoposition() { Latitude = 51.5900, Longitude = 004.7743 }));
        }

    }
}
