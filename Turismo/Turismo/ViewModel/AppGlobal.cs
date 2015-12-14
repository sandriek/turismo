using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismo.ViewModel
{
    public class AppGlobal
    {
        private AppGlobal _instance;
        private GeoUtil _GeoUtil;
        private List<Site> SiteList;
        private List<Route> RouteList;
        private CurrentSession _CurrentSession;

    }
}
