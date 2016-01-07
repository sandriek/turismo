using System;
using System.Collections.Generic;
using Turismo.Components;
using Turismo.Library;

namespace Turismo.Data
{
    public class AppGlobal
    {
        public static AppGlobal _Instance;
        public GeoUtil _GeoUtil;
        protected List<Site> SiteList;
        public List<Route> RouteList;
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
        }
    }
}
