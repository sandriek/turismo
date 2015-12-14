using System;
using System.Collections.Generic;
using Turismo.Components;
using Turismo.Library;

namespace Turismo.Data
{
    public class AppGlobal
    {
        private static AppGlobal _Instance;
        protected GeoUtil _GeoUtil;
        protected List<Site> SiteList;
        protected List<Route> RouteList;
        public CurrentSession _CurrentSession;
        protected List<Help> HelpDescriptionList;

        public static AppGlobal Instance { get { return _Instance ?? (_Instance = new AppGlobal()); } }
    }
}
