using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismo.ViewModel.Objects;
using Turismo.ViewModel.Components;

namespace Turismo.ViewModel
{
    public class AppGlobal
    {
        private AppGlobal _instance;
        protected GeoUtil _GeoUtil;
        private List<Site> SiteList;
        private List<Route> RouteList;
        private CurrentSession _CurrentSession;
        private List<Help> HelpDescriptionList;

        public AppGlobal instance()
        {
            return this;
        }
    }
}
